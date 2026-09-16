Public Class frmReports

    Private _repo As New ReportRepository()
    Private _inventoryTable As DataTable
    Private _topProductsTable As DataTable
    Private _totalSales As Integer = 0
    Private _totalRevenue As Decimal = 0
    Private _avgSaleValue As Decimal = 0
    Private _selectedCategory As String = ""
    Private _isLoadingCategories As Boolean = False

    Private Class CategoryItem
        Public Property CategoryName As String = ""
        Public Property DisplayText As String = ""

        Public Sub New(name As String, display As String)
            CategoryName = name
            DisplayText = display
        End Sub

        Public Overrides Function ToString() As String
            Return DisplayText
        End Function
    End Class

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
            .Name = "Barcode", .DataPropertyName = "Barcode",
            .HeaderText = "Barcode", .FillWeight = 110, .ReadOnly = True
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Name", .DataPropertyName = "Name",
            .HeaderText = "Product Name", .FillWeight = 200, .ReadOnly = True
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "CategoryName", .DataPropertyName = "CategoryName",
            .HeaderText = "Category", .FillWeight = 120, .ReadOnly = True
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "StockQty", .DataPropertyName = "StockQty",
            .HeaderText = "Stock Qty", .FillWeight = 85, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {
                .Alignment = DataGridViewContentAlignment.MiddleRight,
                .Format = "N0"
            }
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Unit", .DataPropertyName = "Unit",
            .HeaderText = "Unit", .FillWeight = 65, .ReadOnly = True
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "ReorderLevel", .DataPropertyName = "ReorderLevel",
            .HeaderText = "Reorder Lvl", .FillWeight = 85, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {
                .Alignment = DataGridViewContentAlignment.MiddleRight,
                .Format = "N0"
            }
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Status", .DataPropertyName = "Status",
            .HeaderText = "Status", .FillWeight = 100, .ReadOnly = True
        })
    End Sub

    Private Sub LoadInventoryReport()
        _inventoryTable = _repo.GetInventoryStatus()
        LoadCategoryList()
        ApplySearchFilter()
    End Sub

    Private Sub LoadCategoryList()
        _isLoadingCategories = True
        Dim prevSelected = _selectedCategory
        lstCategories.Items.Clear()

        Dim totalCount = If(_inventoryTable IsNot Nothing, _inventoryTable.Rows.Count, 0)
        lstCategories.Items.Add(New CategoryItem("", $"📦 All Categories ({totalCount})"))

        Dim catRepo As New CategoryRepository()
        Dim catDt = catRepo.GetAll()
        Dim knownCats As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

        For Each row As DataRow In catDt.Rows
            Dim catName = row("CategoryName").ToString()
            knownCats.Add(catName)
            Dim count = 0
            If _inventoryTable IsNot Nothing Then
                count = _inventoryTable.Select($"CategoryName = '{catName.Replace("'", "''")}'").Length
            End If
            lstCategories.Items.Add(New CategoryItem(catName, $"{catName} ({count})"))
        Next

        If _inventoryTable IsNot Nothing Then
            For Each row As DataRow In _inventoryTable.Rows
                Dim catName = row("CategoryName")?.ToString()
                If Not String.IsNullOrWhiteSpace(catName) AndAlso Not knownCats.Contains(catName) Then
                    knownCats.Add(catName)
                    Dim count = _inventoryTable.Select($"CategoryName = '{catName.Replace("'", "''")}'").Length
                    lstCategories.Items.Add(New CategoryItem(catName, $"{catName} ({count})"))
                End If
            Next
        End If

        Dim selectedIdx = 0
        If Not String.IsNullOrEmpty(prevSelected) Then
            For i As Integer = 1 To lstCategories.Items.Count - 1
                Dim item = DirectCast(lstCategories.Items(i), CategoryItem)
                If String.Equals(item.CategoryName, prevSelected, StringComparison.OrdinalIgnoreCase) Then
                    selectedIdx = i
                    Exit For
                End If
            Next
        End If

        lstCategories.SelectedIndex = selectedIdx
        _isLoadingCategories = False
    End Sub

    Private Sub lstCategories_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCategories.SelectedIndexChanged
        If _isLoadingCategories Then Return
        Dim item = TryCast(lstCategories.SelectedItem, CategoryItem)
        _selectedCategory = If(item IsNot Nothing, item.CategoryName, "")
        ApplySearchFilter()
    End Sub

    Private Sub ApplySearchFilter()
        If _inventoryTable Is Nothing Then Return

        Dim search = txtSearch.Text.Trim().Replace("'", "''")
        Dim filterParts As New List(Of String)()

        If Not String.IsNullOrEmpty(_selectedCategory) Then
            filterParts.Add($"CategoryName = '{_selectedCategory.Replace("'", "''")}'")
        End If

        If Not String.IsNullOrWhiteSpace(search) Then
            filterParts.Add($"(Name LIKE '%{search}%' OR Barcode LIKE '%{search}%' OR Status LIKE '%{search}%')")
        End If

        If filterParts.Count > 0 Then
            _inventoryTable.DefaultView.RowFilter = String.Join(" AND ", filterParts)
        Else
            _inventoryTable.DefaultView.RowFilter = ""
        End If

        dgvInventory.DataSource = _inventoryTable.DefaultView
        ColorizeInventoryRows()
        UpdateCategoryHeader()
    End Sub

    Private Sub UpdateCategoryHeader()
        Dim count = If(_inventoryTable IsNot Nothing, _inventoryTable.DefaultView.Count, 0)
        Dim search = txtSearch.Text.Trim()
        Dim catTitle = If(String.IsNullOrEmpty(_selectedCategory), "All Categories", _selectedCategory)

        If String.IsNullOrWhiteSpace(search) Then
            lblCurrentCategory.Text = $"Showing: {catTitle} ({count} items)"
        Else
            lblCurrentCategory.Text = $"Showing: {catTitle} (Search: ""{search}"" — {count} items)"
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplySearchFilter()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If dgvInventory.Rows.Count > 0 Then
                dgvInventory.Rows(0).Selected = True
            End If
        End If
    End Sub

    Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
        txtSearch.Clear()
        txtSearch.Focus()
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
        If _inventoryTable Is Nothing OrElse _inventoryTable.DefaultView.Count = 0 Then
            MessageBox.Show("No inventory report records available to print.", "Print Inventory Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim catTitle = If(String.IsNullOrEmpty(_selectedCategory), "All Categories", _selectedCategory)
        InventoryReportHelper.OpenReportInChrome(_inventoryTable.DefaultView, catTitle, txtSearch.Text.Trim())
    End Sub

    Private Sub btnExportInventory_Click(sender As Object, e As EventArgs) Handles btnExportInventory.Click
        If _inventoryTable Is Nothing OrElse _inventoryTable.DefaultView.Count = 0 Then
            MessageBox.Show("No inventory report records available to export.", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim catTitle = If(String.IsNullOrEmpty(_selectedCategory), "All Categories", _selectedCategory)
        InventoryExportHelper.ExportInventory(_inventoryTable.DefaultView, catTitle)
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
