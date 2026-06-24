Public Class frmReports

    Private _repo As New ReportRepository()

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' GATE — remove this block when unlocking for v1.08
        Dim gate As New UnderConstructionForm()
        gate.ShowDialog()
        Me.Close()
        Return
        ' END GATE
        Me.Text       = "Reports"
        dtpFrom.Value = DateTime.Today.AddDays(-30)
        dtpTo.Value   = DateTime.Today
        ConfigureInventoryGrid()
        ConfigureTopProductsGrid()
        LoadInventoryReport()
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
        dgvInventory.DataSource = _repo.GetInventoryStatus()
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

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim summary = _repo.GetSalesSummary(dtpFrom.Value, dtpTo.Value)
        If summary.Rows.Count > 0 Then
            Dim row = summary.Rows(0)
            lblTotalSalesVal.Text = row("TotalSales").ToString()
            lblRevenueVal.Text    = CDec(row("TotalRevenue")).ToString("N2")
            lblAvgVal.Text        = CDec(row("AvgSaleValue")).ToString("N2")
        End If
        dgvTopProducts.DataSource = _repo.GetTopProducts(dtpFrom.Value, dtpTo.Value)
    End Sub

End Class
