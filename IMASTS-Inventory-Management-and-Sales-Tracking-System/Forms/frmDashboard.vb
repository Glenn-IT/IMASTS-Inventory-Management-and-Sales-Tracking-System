Imports System.Drawing.Drawing2D

Public Class frmDashboard

    Private _repo As New DashboardRepository()
    Private _reportRepo As New ReportRepository()

    ' --- Sales trend (line chart) ---
    Private _chartDays() As String = Array.Empty(Of String)()
    Private _chartRevenue() As Double = Array.Empty(Of Double)()
    Private ReadOnly _trendToolTip As New ToolTip()
    Private ReadOnly _trendPoints As New List(Of PointF)

    ' --- Sales by category (pie chart) ---
    Private ReadOnly _categoryNames As New List(Of String)
    Private ReadOnly _categoryRevenue As New List(Of Decimal)
    Private ReadOnly _pieSlices As New List(Of (StartAngle As Single, SweepAngle As Single))
    Private ReadOnly _legendRowRects As New List(Of RectangleF)
    Private _pieCenter As PointF
    Private _pieRadius As Single
    Private ReadOnly _categoryToolTip As New ToolTip()

    ' --- Top 5 products (bar chart) ---
    Private ReadOnly _topProductNames As New List(Of String)
    Private ReadOnly _topProductRevenue As New List(Of Decimal)
    Private ReadOnly _topProductQty As New List(Of Integer)
    Private ReadOnly _topProductBarRects As New List(Of RectangleF)
    Private ReadOnly _topProductsToolTip As New ToolTip()

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
Me.Text = "Dashboard"
        LoadDashboard()
    End Sub

    Private Sub LoadDashboard()
        Try
            lblTotalProducts.Text = _repo.GetTotalProducts().ToString()
            lblLowStock.Text = _repo.GetLowStockCount().ToString()
            lblTodaySales.Text = _repo.GetTodaySalesCount().ToString()
            lblTodayRevenue.Text = _repo.GetTodayRevenue().ToString("C2")

            Dim monthStart As Date = New Date(Date.Today.Year, Date.Today.Month, 1)
            Dim monthEnd As Date = Date.Today

            LoadSalesTrend()
            LoadCategoryBreakdown(monthStart, monthEnd)
            LoadTopProducts(monthStart, monthEnd)

            pnlTrendCanvas.Invalidate()
            pnlCategoryCanvas.Invalidate()
            pnlTopProductsCanvas.Invalidate()
        Catch ex As Exception
            MessageBox.Show("Failed to load dashboard data: " & ex.Message,
                            "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSalesTrend()
        Dim toDate As Date = Date.Today
        Dim fromDate As Date = toDate.AddDays(-6)
        Dim dt As DataTable = _repo.GetDailyRevenue(fromDate, toDate)

        Dim revenueByDay As New Dictionary(Of Date, Decimal)
        For Each row As DataRow In dt.Rows
            revenueByDay(CDate(row("SaleDay")).Date) = CDec(row("Revenue"))
        Next

        Dim days As New List(Of String)
        Dim revenues As New List(Of Double)
        For i As Integer = 0 To 6
            Dim d As Date = fromDate.AddDays(i).Date
            days.Add(d.ToString("ddd"))
            Dim rev As Decimal = 0
            revenueByDay.TryGetValue(d, rev)
            revenues.Add(CDbl(rev))
        Next

        _chartDays = days.ToArray()
        _chartRevenue = revenues.ToArray()
    End Sub

    Private Sub LoadCategoryBreakdown(fromDate As Date, toDate As Date)
        Dim dt As DataTable = _repo.GetSalesByCategory(fromDate, toDate)

        _categoryNames.Clear()
        _categoryRevenue.Clear()

        Dim otherTotal As Decimal = 0
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim name As String = dt.Rows(i)("CategoryName").ToString()
            Dim revenue As Decimal = CDec(dt.Rows(i)("Revenue"))
            If i < 8 Then
                _categoryNames.Add(name)
                _categoryRevenue.Add(revenue)
            Else
                otherTotal += revenue
            End If
        Next
        If otherTotal > 0 Then
            _categoryNames.Add("Other")
            _categoryRevenue.Add(otherTotal)
        End If
    End Sub

    Private Sub LoadTopProducts(fromDate As Date, toDate As Date)
        Dim dt As DataTable = _reportRepo.GetTopProducts(fromDate, toDate)

        _topProductNames.Clear()
        _topProductRevenue.Clear()
        _topProductQty.Clear()
        For Each row As DataRow In dt.Rows
            _topProductNames.Add(row("Product").ToString())
            _topProductRevenue.Add(CDec(row("TotalRevenue")))
            _topProductQty.Add(CInt(row("TotalSold")))
        Next
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadDashboard()
    End Sub

#Region "Sales Trend (line chart)"

    Private Sub pnlTrendCanvas_Paint(sender As Object, e As PaintEventArgs) Handles pnlTrendCanvas.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        DrawSalesTrendChart(e.Graphics, pnlTrendCanvas.ClientRectangle)
    End Sub

    Private Sub pnlTrendCanvas_Resize(sender As Object, e As EventArgs) Handles pnlTrendCanvas.Resize
        pnlTrendCanvas.Invalidate()
    End Sub

    Private Sub pnlTrendCanvas_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlTrendCanvas.MouseMove
        For i As Integer = 0 To _trendPoints.Count - 1
            Dim dx As Single = e.X - _trendPoints(i).X
            Dim dy As Single = e.Y - _trendPoints(i).Y
            If (dx * dx + dy * dy) <= 64.0F Then
                Dim tipText = $"{_chartDays(i)}: ₱{_chartRevenue(i):N0}"
                If _trendToolTip.GetToolTip(pnlTrendCanvas) <> tipText Then
                    _trendToolTip.SetToolTip(pnlTrendCanvas, tipText)
                End If
                Return
            End If
        Next
        _trendToolTip.SetToolTip(pnlTrendCanvas, Nothing)
    End Sub

    Private Sub DrawSalesTrendChart(g As Graphics, bounds As Rectangle)
        _trendPoints.Clear()

        If _chartDays.Length = 0 Then Return

        Dim accent = Color.FromArgb(52, 152, 219)
        Dim gridColor = Color.FromArgb(235, 236, 240)
        Dim axisColor = Color.FromArgb(220, 222, 226)
        Dim mutedText = Color.FromArgb(130, 135, 145)
        Dim axisFont As New Font("Segoe UI", 8.5F)
        Dim labelBrush As New SolidBrush(mutedText)

        Const leftPad As Integer = 64
        Const rightPad As Integer = 16
        Const topPad As Integer = 16
        Const bottomPad As Integer = 30

        Dim plotWidth As Single = bounds.Width - leftPad - rightPad
        Dim plotHeight As Single = bounds.Height - topPad - bottomPad
        If plotWidth <= 0 OrElse plotHeight <= 0 Then Return

        Dim niceMax As Double = Math.Ceiling(_chartRevenue.Max() / 5000.0) * 5000.0
        If niceMax <= 0 Then niceMax = 5000.0

        ' Gridlines and Y-axis labels
        Using gridPen As New Pen(gridColor, 1)
            For i As Integer = 0 To 4
                Dim y As Single = topPad + plotHeight * i / 4.0F
                g.DrawLine(gridPen, leftPad, y, leftPad + plotWidth, y)

                Dim labelValue As Double = niceMax * (4 - i) / 4.0
                Dim labelText = "₱" & labelValue.ToString("N0")
                Dim labelSize = g.MeasureString(labelText, axisFont)
                g.DrawString(labelText, axisFont, labelBrush, leftPad - labelSize.Width - 8, y - labelSize.Height / 2)
            Next
        End Using

        ' X-axis baseline
        Using axisPen As New Pen(axisColor, 1)
            g.DrawLine(axisPen, leftPad, topPad + plotHeight, leftPad + plotWidth, topPad + plotHeight)
        End Using

        ' Plot points + day labels
        Dim stepX As Single = plotWidth / (_chartDays.Length - 1)
        For i As Integer = 0 To _chartDays.Length - 1
            Dim x As Single = leftPad + stepX * i
            Dim ratio As Single = CSng(_chartRevenue(i) / niceMax)
            Dim y As Single = topPad + plotHeight - plotHeight * ratio
            _trendPoints.Add(New PointF(x, y))

            Dim dayLabelSize = g.MeasureString(_chartDays(i), axisFont)
            g.DrawString(_chartDays(i), axisFont, labelBrush, x - dayLabelSize.Width / 2, topPad + plotHeight + 8)
        Next

        ' Trend line
        If _trendPoints.Count > 1 Then
            Using linePen As New Pen(accent, 2.5F)
                linePen.LineJoin = LineJoin.Round
                g.DrawLines(linePen, _trendPoints.ToArray())
            End Using
        End If

        ' Markers
        Const markerRadius As Single = 4.0F
        Using markerBrush As New SolidBrush(accent), ringPen As New Pen(Color.White, 2)
            For Each pt In _trendPoints
                g.FillEllipse(markerBrush, pt.X - markerRadius, pt.Y - markerRadius, markerRadius * 2, markerRadius * 2)
                g.DrawEllipse(ringPen, pt.X - markerRadius, pt.Y - markerRadius, markerRadius * 2, markerRadius * 2)
            Next
        End Using

        ' Direct label on the most recent point only
        Dim lastIndex = _trendPoints.Count - 1
        If lastIndex >= 0 Then
            Dim lastPoint = _trendPoints(lastIndex)
            Dim labelText = "₱" & _chartRevenue(lastIndex).ToString("N0")
            Using boldFont As New Font("Segoe UI", 8.5F, FontStyle.Bold)
                Using accentBrush As New SolidBrush(accent)
                    Dim size = g.MeasureString(labelText, boldFont)
                    Dim labelX As Single = Math.Min(lastPoint.X - size.Width / 2, bounds.Width - rightPad - size.Width)
                    labelX = Math.Max(labelX, leftPad)
                    g.DrawString(labelText, boldFont, accentBrush, labelX, lastPoint.Y - size.Height - 10)
                End Using
            End Using
        End If
    End Sub

#End Region

#Region "Sales by Category (pie chart)"

    Private Shared ReadOnly CategoryPalette() As Color = {
        Color.FromArgb(42, 120, 214),
        Color.FromArgb(235, 104, 52),
        Color.FromArgb(27, 175, 122),
        Color.FromArgb(237, 161, 0),
        Color.FromArgb(232, 123, 164),
        Color.FromArgb(0, 131, 0),
        Color.FromArgb(74, 58, 167),
        Color.FromArgb(227, 73, 72)
    }

    Private Shared Function PaletteColor(index As Integer) As Color
        Return CategoryPalette(index Mod CategoryPalette.Length)
    End Function

    Private Sub pnlCategoryCanvas_Paint(sender As Object, e As PaintEventArgs) Handles pnlCategoryCanvas.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        DrawCategoryPieChart(e.Graphics, pnlCategoryCanvas.ClientRectangle)
    End Sub

    Private Sub pnlCategoryCanvas_Resize(sender As Object, e As EventArgs) Handles pnlCategoryCanvas.Resize
        pnlCategoryCanvas.Invalidate()
    End Sub

    Private Sub pnlCategoryCanvas_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlCategoryCanvas.MouseMove
        Dim dx As Single = e.X - _pieCenter.X
        Dim dy As Single = e.Y - _pieCenter.Y
        Dim dist As Single = CSng(Math.Sqrt(dx * dx + dy * dy))
        Dim tipText As String = Nothing

        If dist <= _pieRadius Then
            Dim gdiAngle As Double = Math.Atan2(dy, dx) * 180.0 / Math.PI
            Dim myAngle As Double = gdiAngle + 90.0
            If myAngle < 0 Then myAngle += 360
            If myAngle >= 360 Then myAngle -= 360

            For i As Integer = 0 To _pieSlices.Count - 1
                Dim sl = _pieSlices(i)
                If myAngle >= sl.StartAngle AndAlso myAngle < sl.StartAngle + sl.SweepAngle Then
                    tipText = $"{_categoryNames(i)}: ₱{_categoryRevenue(i):N0}"
                    Exit For
                End If
            Next
        End If

        If tipText Is Nothing Then
            For i As Integer = 0 To _legendRowRects.Count - 1
                If _legendRowRects(i).Contains(e.Location) Then
                    tipText = $"{_categoryNames(i)}: ₱{_categoryRevenue(i):N0}"
                    Exit For
                End If
            Next
        End If

        _categoryToolTip.SetToolTip(pnlCategoryCanvas, tipText)
    End Sub

    Private Sub DrawCategoryPieChart(g As Graphics, bounds As Rectangle)
        _pieSlices.Clear()
        _legendRowRects.Clear()

        Dim mutedText = Color.FromArgb(130, 135, 145)
        Dim inkText = Color.FromArgb(40, 44, 52)
        Dim legendFont As New Font("Segoe UI", 8.5F)

        Dim total As Decimal = _categoryRevenue.Sum()
        If _categoryNames.Count = 0 OrElse total <= 0 Then
            Dim msg = "No sales this month"
            Using mutedBrush As New SolidBrush(mutedText)
                Dim sz = g.MeasureString(msg, legendFont)
                g.DrawString(msg, legendFont, mutedBrush,
                             bounds.Left + (bounds.Width - sz.Width) / 2,
                             bounds.Top + (bounds.Height - sz.Height) / 2)
            End Using
            Return
        End If

        Const padding As Single = 12.0F
        Const legendRowHeight As Single = 22.0F
        Const swatchSize As Single = 10.0F

        Dim legendHeight As Single = _categoryNames.Count * legendRowHeight + 8.0F
        Dim availableForPie As Single = bounds.Width - padding * 2
        Dim pieDiameter As Single = Math.Min(availableForPie, bounds.Height - legendHeight - padding * 2)
        pieDiameter = Math.Max(pieDiameter, 40.0F)

        Dim blockHeight As Single = pieDiameter + padding + legendHeight
        Dim blockTop As Single = bounds.Top + Math.Max(padding, (bounds.Height - blockHeight) / 2)

        Dim pieRect As New RectangleF(
            bounds.Left + (bounds.Width - pieDiameter) / 2,
            blockTop,
            pieDiameter, pieDiameter)
        _pieCenter = New PointF(pieRect.X + pieDiameter / 2, pieRect.Y + pieDiameter / 2)
        _pieRadius = pieDiameter / 2

        Dim cumulative As Single = 0
        For i As Integer = 0 To _categoryNames.Count - 1
            Dim sweep As Single = CSng(_categoryRevenue(i) / total * 360.0)
            _pieSlices.Add((cumulative, sweep))
            Dim gdiStart As Single = cumulative - 90.0F
            Using sliceBrush As New SolidBrush(PaletteColor(i))
                g.FillPie(sliceBrush, pieRect, gdiStart, sweep)
            End Using
            cumulative += sweep
        Next

        Using separatorPen As New Pen(Color.White, 2)
            For Each sl In _pieSlices
                g.DrawPie(separatorPen, pieRect, sl.StartAngle - 90.0F, sl.SweepAngle)
            Next
        End Using

        Dim rowY As Single = pieRect.Bottom + padding
        For i As Integer = 0 To _categoryNames.Count - 1
            Dim rowRect As New RectangleF(bounds.Left + padding, rowY, bounds.Width - padding * 2, legendRowHeight)
            _legendRowRects.Add(rowRect)

            Dim swatchY As Single = rowY + (legendRowHeight - swatchSize) / 2
            Using swatchBrush As New SolidBrush(PaletteColor(i))
                g.FillRectangle(swatchBrush, bounds.Left + padding, swatchY, swatchSize, swatchSize)
            End Using

            Dim nameX As Single = bounds.Left + padding + swatchSize + 8.0F
            Using nameBrush As New SolidBrush(inkText)
                g.DrawString(_categoryNames(i), legendFont, nameBrush, nameX, rowY + 3.0F)
            End Using

            Dim valueText = "₱" & _categoryRevenue(i).ToString("N0")
            Dim valueSize = g.MeasureString(valueText, legendFont)
            Using valueBrush As New SolidBrush(mutedText)
                g.DrawString(valueText, legendFont, valueBrush,
                             bounds.Right - padding - valueSize.Width, rowY + 3.0F)
            End Using

            rowY += legendRowHeight
        Next
    End Sub

#End Region

#Region "Top 5 Products (bar chart)"

    Private Sub pnlTopProductsCanvas_Paint(sender As Object, e As PaintEventArgs) Handles pnlTopProductsCanvas.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        DrawTopProductsBarChart(e.Graphics, pnlTopProductsCanvas.ClientRectangle)
    End Sub

    Private Sub pnlTopProductsCanvas_Resize(sender As Object, e As EventArgs) Handles pnlTopProductsCanvas.Resize
        pnlTopProductsCanvas.Invalidate()
    End Sub

    Private Sub pnlTopProductsCanvas_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlTopProductsCanvas.MouseMove
        For i As Integer = 0 To _topProductBarRects.Count - 1
            If _topProductBarRects(i).Contains(e.Location) Then
                Dim tipText = $"{_topProductNames(i)}: ₱{_topProductRevenue(i):N0} ({_topProductQty(i)} sold)"
                _topProductsToolTip.SetToolTip(pnlTopProductsCanvas, tipText)
                Return
            End If
        Next
        _topProductsToolTip.SetToolTip(pnlTopProductsCanvas, Nothing)
    End Sub

    Private Function RoundedBarPath(rect As RectangleF, radius As Single) As GraphicsPath
        Dim path As New GraphicsPath()
        radius = Math.Min(radius, rect.Height / 2)
        If rect.Width <= radius Then
            path.AddRectangle(rect)
            Return path
        End If

        path.AddLine(rect.Left, rect.Top, rect.Right - radius, rect.Top)
        path.AddArc(rect.Right - radius * 2, rect.Top, radius * 2, radius * 2, -90, 180)
        path.AddLine(rect.Right - radius, rect.Bottom, rect.Left, rect.Bottom)
        path.CloseFigure()
        Return path
    End Function

    Private Function TruncateToWidth(g As Graphics, text As String, font As Font, maxWidth As Single) As String
        If g.MeasureString(text, font).Width <= maxWidth Then Return text
        Dim truncated As String = text
        While truncated.Length > 1 AndAlso g.MeasureString(truncated & "…", font).Width > maxWidth
            truncated = truncated.Substring(0, truncated.Length - 1)
        End While
        Return truncated & "…"
    End Function

    Private Sub DrawTopProductsBarChart(g As Graphics, bounds As Rectangle)
        _topProductBarRects.Clear()

        Dim accent = Color.FromArgb(52, 152, 219)
        Dim mutedText = Color.FromArgb(130, 135, 145)
        Dim inkText = Color.FromArgb(40, 44, 52)
        Dim nameFont As New Font("Segoe UI", 8.5F)
        Dim valueFont As New Font("Segoe UI", 8.5F, FontStyle.Bold)

        If _topProductNames.Count = 0 Then
            Dim msg = "No sales this month"
            Using mutedBrush As New SolidBrush(mutedText)
                Dim sz = g.MeasureString(msg, nameFont)
                g.DrawString(msg, nameFont, mutedBrush,
                             bounds.Left + (bounds.Width - sz.Width) / 2,
                             bounds.Top + (bounds.Height - sz.Height) / 2)
            End Using
            Return
        End If

        Const nameLineHeight As Single = 16.0F
        Const gapNameToBar As Single = 4.0F
        Const barHeight As Single = 20.0F
        Const barRadius As Single = 4.0F
        Dim blockHeight As Single = nameLineHeight + gapNameToBar + barHeight

        Dim rowHeight As Single = bounds.Height / _topProductNames.Count
        Dim maxRevenue As Decimal = _topProductRevenue.Max()
        If maxRevenue <= 0 Then maxRevenue = 1

        For i As Integer = 0 To _topProductNames.Count - 1
            Dim rowTop As Single = bounds.Top + rowHeight * i
            Dim rowRect As New RectangleF(bounds.Left, rowTop, bounds.Width, rowHeight)
            _topProductBarRects.Add(rowRect)

            Dim blockTop As Single = rowTop + Math.Max(0.0F, (rowHeight - blockHeight) / 2)

            Dim nameText = TruncateToWidth(g, _topProductNames(i), nameFont, bounds.Width)
            Using nameBrush As New SolidBrush(inkText)
                g.DrawString(nameText, nameFont, nameBrush, bounds.Left, blockTop)
            End Using

            Dim barTop As Single = blockTop + nameLineHeight + gapNameToBar
            Dim barWidthMax As Single = bounds.Width - 8.0F
            Dim barLength As Single = CSng(_topProductRevenue(i) / maxRevenue) * barWidthMax
            barLength = Math.Max(barLength, barRadius * 2)
            Dim barRect As New RectangleF(bounds.Left, barTop, barLength, barHeight)

            Using barBrush As New SolidBrush(accent)
                Dim path = RoundedBarPath(barRect, barRadius)
                g.FillPath(barBrush, path)
            End Using

            Dim labelText = $"₱{_topProductRevenue(i):N0}  ({_topProductQty(i)} sold)"
            Dim labelSize = g.MeasureString(labelText, valueFont)
            Dim labelX As Single = barRect.Right + 8.0F
            If labelX + labelSize.Width > bounds.Right Then
                labelX = Math.Max(bounds.Left, bounds.Right - labelSize.Width)
            End If
            Using labelBrush As New SolidBrush(inkText)
                g.DrawString(labelText, valueFont, labelBrush, labelX, barTop + (barHeight - labelSize.Height) / 2)
            End Using
        Next
    End Sub

#End Region

End Class
