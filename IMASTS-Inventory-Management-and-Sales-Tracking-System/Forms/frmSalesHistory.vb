Public Class frmSalesHistory

    Private _repo           As New SaleRepository()
    Private _selectedSaleId As Integer = 0
    Private _selectedVoided As Boolean = False
    Private _selectedCashier As String = ""
    Private _selectedDate   As DateTime = DateTime.Now
    Private _selectedTotal  As Decimal = 0
    Private _selectedDiscount As Decimal = 0
    Private _selectedNet    As Decimal = 0
    Private _selectedItemsTable As DataTable = Nothing

    Private Sub frmSalesHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Sales History"
        ConfigureGrids()
        dtpFrom.Value         = DateTime.Today.AddDays(-30)
        dtpTo.Value           = DateTime.Today
        btnVoidSale.Visible   = (SessionManager.UserType = Constants.RoleAdmin)
        btnVoidSale.Enabled   = False
        btnPrintReceipt.Enabled = False
        LoadSales()
    End Sub

    ' ── Grid setup ────────────────────────────────────────────────────────

    Private Sub ConfigureGrids()
        ' Sales grid
        dgvSales.AutoGenerateColumns = False
        dgvSales.Columns.Clear()

        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "SaleID", .DataPropertyName = "SaleID",
            .HeaderText = "ID", .Width = 55, .ReadOnly = True
        })
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "SaleDate", .DataPropertyName = "SaleDate",
            .HeaderText = "Date & Time", .Width = 160, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "dd MMM yyyy  hh:mm tt"}
        })
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Cashier", .DataPropertyName = "Cashier",
            .HeaderText = "Cashier", .Width = 120, .ReadOnly = True
        })
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "TotalAmount", .DataPropertyName = "TotalAmount",
            .HeaderText = "Total", .Width = 90, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Discount", .DataPropertyName = "Discount",
            .HeaderText = "Discount", .Width = 80, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "NetAmount", .DataPropertyName = "NetAmount",
            .HeaderText = "Net Amount", .Width = 100, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Status", .DataPropertyName = "Status",
            .HeaderText = "Status", .Width = 80, .ReadOnly = True
        })
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "IsVoided", .DataPropertyName = "IsVoided",
            .Visible = False
        })

        ' Sale items detail grid
        dgvSaleItems.AutoGenerateColumns = False
        dgvSaleItems.Columns.Clear()

        dgvSaleItems.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Product", .DataPropertyName = "Product",
            .HeaderText = "Product", .Width = 280, .ReadOnly = True
        })
        dgvSaleItems.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Quantity", .DataPropertyName = "Quantity",
            .HeaderText = "Qty", .Width = 80, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvSaleItems.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "UnitPrice", .DataPropertyName = "UnitPrice",
            .HeaderText = "Unit Price", .Width = 100, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvSaleItems.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Subtotal", .DataPropertyName = "Subtotal",
            .HeaderText = "Subtotal", .Width = 100, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}
        })
    End Sub

    ' ── Load / filter ─────────────────────────────────────────────────────

    Private Sub LoadSales()
        Dim dt = _repo.GetAll(dtpFrom.Value, dtpTo.Value)
        dgvSales.DataSource  = dt
        dgvSaleItems.DataSource = Nothing
        _selectedSaleId      = 0
        _selectedVoided      = False
        _selectedItemsTable  = Nothing
        btnVoidSale.Enabled  = False
        btnPrintReceipt.Enabled = False
        lblDetailHeader.Text = "Sale Items"
        ColorizeStatusRows()
        UpdateGrandTotal(dt)
    End Sub

    Private Sub UpdateGrandTotal(dt As DataTable)
        Dim grandTotal As Decimal = 0
        Dim activeCount As Integer = 0

        If dt IsNot Nothing Then
            For Each row As DataRow In dt.Rows
                Dim isVoided As Boolean = False
                If Not IsDBNull(row("IsVoided")) Then
                    isVoided = CBool(row("IsVoided"))
                End If

                If Not isVoided Then
                    If Not IsDBNull(row("NetAmount")) AndAlso IsNumeric(row("NetAmount")) Then
                        grandTotal += CDec(row("NetAmount"))
                    End If
                    activeCount += 1
                End If
            Next
        End If

        lblGrandTotalVal.Text = "₱" & grandTotal.ToString("N2")
        lblGrandTotalTit.Text = $"GRAND TOTAL ({activeCount} Active Sale{If(activeCount = 1, "", "s")})"
    End Sub

    Private Sub ColorizeStatusRows()
        For Each row As DataGridViewRow In dgvSales.Rows
            Dim voided = row.Cells("IsVoided").Value
            If voided IsNot Nothing AndAlso CBool(voided) Then
                row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245)
            Else
                row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(40, 44, 52)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.White
            End If
        Next
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        LoadSales()
    End Sub

    ' ── Grid selection ────────────────────────────────────────────────────

    Private Sub dgvSales_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSales.SelectionChanged
        If dgvSales.CurrentRow Is Nothing Then
            lblDetailHeader.Text = "Sale Items"
            btnPrintReceipt.Enabled = False
            btnVoidSale.Enabled = False
            Return
        End If

        Dim row = dgvSales.CurrentRow
        _selectedSaleId   = CInt(row.Cells("SaleID").Value)
        _selectedVoided   = CBool(row.Cells("IsVoided").Value)
        _selectedCashier  = row.Cells("Cashier").Value?.ToString()
        _selectedDate     = If(IsDate(row.Cells("SaleDate").Value), CDate(row.Cells("SaleDate").Value), DateTime.Now)
        _selectedTotal    = If(IsNumeric(row.Cells("TotalAmount").Value), CDec(row.Cells("TotalAmount").Value), 0)
        _selectedDiscount = If(IsNumeric(row.Cells("Discount").Value), CDec(row.Cells("Discount").Value), 0)
        _selectedNet      = If(IsNumeric(row.Cells("NetAmount").Value), CDec(row.Cells("NetAmount").Value), 0)

        lblDetailHeader.Text = $"Sale Items — Sale #{_selectedSaleId}  (Total: ₱{_selectedNet:N2}{If(_selectedVoided, " - VOIDED", "")})"

        _selectedItemsTable = _repo.GetSaleItems(_selectedSaleId)
        dgvSaleItems.DataSource = _selectedItemsTable

        btnVoidSale.Enabled = (SessionManager.UserType = Constants.RoleAdmin) AndAlso Not _selectedVoided
        btnPrintReceipt.Enabled = (_selectedSaleId > 0 AndAlso _selectedItemsTable IsNot Nothing AndAlso _selectedItemsTable.Rows.Count > 0)
    End Sub

    ' ── Print receipt ─────────────────────────────────────────────────────

    Private Sub btnPrintReceipt_Click(sender As Object, e As EventArgs) Handles btnPrintReceipt.Click
        If _selectedSaleId <= 0 OrElse _selectedItemsTable Is Nothing OrElse _selectedItemsTable.Rows.Count = 0 Then
            MessageBox.Show("Please select a sale to print.", "Print Receipt", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ReceiptHelper.OpenReceiptInChrome(_selectedSaleId, _selectedCashier, _selectedDate, _selectedItemsTable, _selectedTotal, _selectedDiscount, _selectedNet)
    End Sub

    ' ── Void sale ─────────────────────────────────────────────────────────

    Private Sub btnVoidSale_Click(sender As Object, e As EventArgs) Handles btnVoidSale.Click
        If _selectedSaleId = 0 Then Return

        Dim confirm = MessageBox.Show(
            $"Void Sale #{_selectedSaleId}? This will restore stock for all line items.",
            "Confirm Void",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)
        If confirm <> DialogResult.Yes Then Return

        If _repo.VoidSale(_selectedSaleId) Then
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess,
                $"Sale #{_selectedSaleId} voided.")
            LoadSales()
        Else
            MessageBox.Show("Failed to void the sale. Please try again.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class
