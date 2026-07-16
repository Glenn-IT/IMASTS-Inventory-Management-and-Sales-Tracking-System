Imports System.Drawing.Drawing2D

Public Class frmDashboard

    Private _repo As New DashboardRepository()

    ' Sample data for the Weekly Sales Trend panel — presentation only, not sourced from the database.
    Private ReadOnly _chartDays() As String = {"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"}
    Private ReadOnly _chartRevenue() As Double = {8200, 10500, 9600, 12800, 15400, 18200, 13100}
    Private ReadOnly _chartToolTip As New ToolTip()
    Private ReadOnly _chartPoints As New List(Of PointF)

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
        Catch ex As Exception
            MessageBox.Show("Failed to load dashboard data: " & ex.Message,
                            "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadDashboard()
    End Sub

    Private Sub pnlChartCanvas_Paint(sender As Object, e As PaintEventArgs) Handles pnlChartCanvas.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        DrawWeeklySalesChart(e.Graphics, pnlChartCanvas.ClientRectangle)
    End Sub

    Private Sub pnlChartCanvas_Resize(sender As Object, e As EventArgs) Handles pnlChartCanvas.Resize
        pnlChartCanvas.Invalidate()
    End Sub

    Private Sub pnlChartCanvas_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlChartCanvas.MouseMove
        For i As Integer = 0 To _chartPoints.Count - 1
            Dim dx As Single = e.X - _chartPoints(i).X
            Dim dy As Single = e.Y - _chartPoints(i).Y
            If (dx * dx + dy * dy) <= 64.0F Then
                Dim tipText = $"{_chartDays(i)}: ₱{_chartRevenue(i):N0}"
                If _chartToolTip.GetToolTip(pnlChartCanvas) <> tipText Then
                    _chartToolTip.SetToolTip(pnlChartCanvas, tipText)
                End If
                Return
            End If
        Next
        _chartToolTip.SetToolTip(pnlChartCanvas, Nothing)
    End Sub

    Private Sub DrawWeeklySalesChart(g As Graphics, bounds As Rectangle)
        _chartPoints.Clear()

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
            _chartPoints.Add(New PointF(x, y))

            Dim dayLabelSize = g.MeasureString(_chartDays(i), axisFont)
            g.DrawString(_chartDays(i), axisFont, labelBrush, x - dayLabelSize.Width / 2, topPad + plotHeight + 8)
        Next

        ' Trend line
        If _chartPoints.Count > 1 Then
            Using linePen As New Pen(accent, 2.5F)
                linePen.LineJoin = LineJoin.Round
                g.DrawLines(linePen, _chartPoints.ToArray())
            End Using
        End If

        ' Markers
        Const markerRadius As Single = 4.0F
        Using markerBrush As New SolidBrush(accent), ringPen As New Pen(Color.White, 2)
            For Each pt In _chartPoints
                g.FillEllipse(markerBrush, pt.X - markerRadius, pt.Y - markerRadius, markerRadius * 2, markerRadius * 2)
                g.DrawEllipse(ringPen, pt.X - markerRadius, pt.Y - markerRadius, markerRadius * 2, markerRadius * 2)
            Next
        End Using

        ' Direct label on the most recent point only
        Dim lastIndex = _chartPoints.Count - 1
        If lastIndex >= 0 Then
            Dim lastPoint = _chartPoints(lastIndex)
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

End Class
