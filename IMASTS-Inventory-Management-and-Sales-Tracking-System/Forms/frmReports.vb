Public Class frmReports

    Private _repo As New ReportRepository()
    Private _inventoryTable As DataTable
    Private _topProductsTable As DataTable
    Private _totalSales As Integer = 0
    Private _totalRevenue As Decimal = 0
    Private _avgSaleValue As Decimal = 0

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Reports"
        dtpFrom.Value = DateTime.Today.AddDays(-30)
        dtpTo.Value   = DateTime.Today
        ConfigureInventoryGrid()
        ConfigureTopProductsGrid()
        LoadInventoryReport()
        GenerateSalesReport()
    End Sub

    ' ── Tab 1 — Inventory Status ───────────────────────────────────────────

    Private Sub ConfigureInventoryGrid()
        dgvInventory.AutoGenerateColumns = False
        dgvInventory.Columns.Clear()

        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Name", .DataPropertyName = "Name",
            .HeaderText = "Product Name", .Width = 220, .ReadOnly = True
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "CategoryName", .DataPropertyName = "CategoryName",
            .HeaderText = "Category", .Width = 150, .ReadOnly = True
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "StockQty", .DataPropertyName = "StockQty",
            .HeaderText = "Stock Qty", .Width = 90, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "ReorderLevel", .DataPropertyName = "ReorderLevel",
            .HeaderText = "Reorder Lvl", .Width = 90, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Status", .DataPropertyName = "Status",
            .HeaderText = "Status", .Width = 110, .ReadOnly = True
        })
    End Sub

    Private Sub LoadInventoryReport()
        _inventoryTable = _repo.GetInventoryStatus()
        dgvInventory.DataSource = _inventoryTable
        ColorizeInventoryRows()
    End Sub

    Private Sub ColorizeInventoryRows()
        For Each row As DataGridViewRow In dgvInventory.Rows
            Select Case row.Cells("Status").Value?.ToString()
                Case "Out of Stock"
                    row.DefaultCellStyle.BackColor = Drawing.Color.FromArgb(255, 200, 200)
                    row.DefaultCellStyle.ForeColor = Drawing.Color.FromArgb(150, 0, 0)
                Case "Low Stock"
                    row.DefaultCellStyle.BackColor = Drawing.Color.FromArgb(255, 235, 180)
                    row.DefaultCellStyle.ForeColor = Drawing.Color.FromArgb(140, 80, 0)
                Case Else
                    row.DefaultCellStyle.BackColor = Drawing.Color.White
                    row.DefaultCellStyle.ForeColor = Drawing.Color.FromArgb(40, 44, 52)
            End Select
        Next
    End Sub

    Private Sub btnRefreshInventory_Click(sender As Object, e As EventArgs) Handles btnRefreshInventory.Click
        LoadInventoryReport()
    End Sub

    Private Sub btnPrintInventory_Click(sender As Object, e As EventArgs) Handles btnPrintInventory.Click
        If _inventoryTable Is Nothing OrElse _inventoryTable.Rows.Count = 0 Then
            MessageBox.Show("No inventory report records available to print.", "Print Inventory Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        InventoryReportHelper.OpenReportInChrome(_inventoryTable.DefaultView, "All Categories", "")
    End Sub

    Private Sub btnExportInventory_Click(sender As Object, e As EventArgs) Handles btnExportInventory.Click
        If _inventoryTable Is Nothing OrElse _inventoryTable.Rows.Count = 0 Then
            MessageBox.Show("No inventory report records available to export.", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        InventoryExportHelper.ExportInventory(_inventoryTable.DefaultView, "All Categories")
    End Sub

    ' ── Tab 2 — Sales Summary ─────────────────────────────────────────────

    Private Sub ConfigureTopProductsGrid()
        dgvTopProducts.AutoGenerateColumns = False
        dgvTopProducts.Columns.Clear()

        dgvTopProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Product", .DataPropertyName = "Product",
            .HeaderText = "Product", .Width = 280, .ReadOnly = True
        })
        dgvTopProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "TotalSold", .DataPropertyName = "TotalSold",
            .HeaderText = "Units Sold", .Width = 100, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvTopProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "TotalRevenue", .DataPropertyName = "TotalRevenue",
            .HeaderText = "Revenue", .Width = 120, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}
        })
    End Sub

    Private Sub GenerateSalesReport()
        Dim summary = _repo.GetSalesSummary(dtpFrom.Value, dtpTo.Value)
        If summary.Rows.Count > 0 Then
            Dim row = summary.Rows(0)
            _totalSales   = If(IsNumeric(row("TotalSales")), CInt(row("TotalSales")), 0)
            _totalRevenue = If(IsNumeric(row("TotalRevenue")), CDec(row("TotalRevenue")), 0)
            _avgSaleValue = If(IsNumeric(row("AvgSaleValue")), CDec(row("AvgSaleValue")), 0)

            lblTotalSalesVal.Text = _totalSales.ToString("N0")
            lblRevenueVal.Text    = _totalRevenue.ToString("N2")
            lblAvgVal.Text        = _avgSaleValue.ToString("N2")
        Else
            _totalSales = 0
            _totalRevenue = 0
            _avgSaleValue = 0
            lblTotalSalesVal.Text = "0"
            lblRevenueVal.Text    = "0.00"
            lblAvgVal.Text        = "0.00"
        End If

        _topProductsTable = _repo.GetTopProducts(dtpFrom.Value, dtpTo.Value)
        dgvTopProducts.DataSource = _topProductsTable
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        GenerateSalesReport()
    End Sub

    Private Sub btnPrintSales_Click(sender As Object, e As EventArgs) Handles btnPrintSales.Click
        If _topProductsTable Is Nothing Then
            GenerateSalesReport()
        End If

        SalesReportHelper.OpenSalesReportInChrome(dtpFrom.Value, dtpTo.Value, _totalSales, _totalRevenue, _avgSaleValue, _topProductsTable)
    End Sub

    Private Sub btnExportSales_Click(sender As Object, e As EventArgs) Handles btnExportSales.Click
        If _topProductsTable Is Nothing Then
            GenerateSalesReport()
        End If

        SalesReportHelper.ExportSalesReport(dtpFrom.Value, dtpTo.Value, _totalSales, _totalRevenue, _avgSaleValue, _topProductsTable)
    End Sub

End Class
