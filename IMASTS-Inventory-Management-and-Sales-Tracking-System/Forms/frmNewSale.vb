Public Class frmNewSale

    Private _repo      As New SaleRepository()
    Private _saleItems As New DataTable()
    Private _products  As DataTable

    Private Sub frmNewSale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "New Sale"
        InitSaleItemsTable()
        ConfigureGrid()
        LoadProducts()
        RecalculateTotals()
    End Sub

    ' ── Setup ─────────────────────────────────────────────────────────────

    Private Sub InitSaleItemsTable()
        _saleItems.Columns.Add("ProductID",   GetType(Integer))
        _saleItems.Columns.Add("ProductName", GetType(String))
        _saleItems.Columns.Add("Quantity",    GetType(Integer))
        _saleItems.Columns.Add("UnitPrice",   GetType(Decimal))
        _saleItems.Columns.Add("Subtotal",    GetType(Decimal))
    End Sub

    Private Sub ConfigureGrid()
        dgvSaleItems.AutoGenerateColumns = False
        dgvSaleItems.Columns.Clear()

        dgvSaleItems.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "ProductName", .DataPropertyName = "ProductName",
            .HeaderText = "Product", .Width = 210, .ReadOnly = True
        })
        dgvSaleItems.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Quantity", .DataPropertyName = "Quantity",
            .HeaderText = "Qty", .Width = 60, .ReadOnly = True,
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

        Dim removeCol As New DataGridViewButtonColumn()
        removeCol.Name                       = "colRemove"
        removeCol.HeaderText                 = ""
        removeCol.Text                       = "Remove"
        removeCol.UseColumnTextForButtonValue = True
        removeCol.Width                      = 70
        removeCol.FlatStyle                  = FlatStyle.Flat
        dgvSaleItems.Columns.Add(removeCol)

        dgvSaleItems.DataSource = _saleItems
    End Sub

    Private Sub LoadProducts()
        _products                = _repo.GetProductsForSale()
        cboProduct.DataSource    = Nothing
        cboProduct.DataSource    = _products
        cboProduct.DisplayMember = "Name"
        cboProduct.ValueMember   = "ProductID"
        cboProduct.SelectedIndex = -1
    End Sub

    ' ── Add item ──────────────────────────────────────────────────────────

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        If cboProduct.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a product.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim qty As Integer
        If Not Integer.TryParse(txtQty.Text.Trim(), qty) OrElse qty <= 0 Then
            MessageBox.Show("Quantity must be a positive integer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim productId   = CInt(cboProduct.SelectedValue)
        Dim productName = cboProduct.Text

        Dim prodRows = _products.Select($"ProductID = {productId}")
        If prodRows.Length = 0 Then Return
        Dim unitPrice = CDec(prodRows(0)("UnitPrice"))
        Dim stockQty  = CInt(prodRows(0)("StockQty"))

        ' Sum qty already in cart for this product
        Dim cartQty As Integer = 0
        Dim existing = _saleItems.Select($"ProductID = {productId}")
        If existing.Length > 0 Then cartQty = CInt(existing(0)("Quantity"))

        If qty + cartQty > stockQty Then
            Dim avail = stockQty - cartQty
            MessageBox.Show($"Only {avail} unit(s) available for ""{productName}"".",
                            "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If existing.Length > 0 Then
            Dim newQty = qty + cartQty
            existing(0)("Quantity") = newQty
            existing(0)("Subtotal") = newQty * unitPrice
        Else
            _saleItems.Rows.Add(productId, productName, qty, unitPrice, qty * unitPrice)
        End If

        RecalculateTotals()
        cboProduct.SelectedIndex = -1
        txtQty.Clear()
        cboProduct.Focus()
    End Sub

    ' ── Remove item ───────────────────────────────────────────────────────

    Private Sub dgvSaleItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSaleItems.CellClick
        If e.ColumnIndex = dgvSaleItems.Columns("colRemove").Index AndAlso e.RowIndex >= 0 Then
            _saleItems.Rows.Remove(_saleItems.Rows(e.RowIndex))
            RecalculateTotals()
        End If
    End Sub

    ' ── Totals ────────────────────────────────────────────────────────────

    Private Sub RecalculateTotals()
        Dim subtotal As Decimal = 0
        For Each row As DataRow In _saleItems.Rows
            subtotal += CDec(row("Subtotal"))
        Next
        txtSubtotal.Text = subtotal.ToString("N2")

        Dim discount As Decimal = 0
        Decimal.TryParse(txtDiscount.Text, discount)
        If discount < 0 Then discount = 0
        If discount > subtotal Then discount = subtotal

        txtNetAmount.Text = (subtotal - discount).ToString("N2")
    End Sub

    Private Sub txtDiscount_TextChanged(sender As Object, e As EventArgs) Handles txtDiscount.TextChanged
        RecalculateTotals()
    End Sub

    ' ── Confirm sale ──────────────────────────────────────────────────────

    Private Sub btnConfirmSale_Click(sender As Object, e As EventArgs) Handles btnConfirmSale.Click
        If _saleItems.Rows.Count = 0 Then
            MessageBox.Show("No items in the sale. Please add at least one product.",
                            "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim discount As Decimal = 0
        If Not Decimal.TryParse(txtDiscount.Text, discount) OrElse discount < 0 Then discount = 0

        Dim saleId = _repo.CreateSale(SessionManager.Username, _saleItems, discount)
        If saleId > 0 Then
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess,
                $"Sale #{saleId} confirmed. {_saleItems.Rows.Count} item(s), net: {txtNetAmount.Text}.")
            MessageBox.Show($"Sale #{saleId} completed successfully!",
                            "Sale Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearSale()
            LoadProducts()
        Else
            MessageBox.Show("Failed to process the sale. Please try again.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ── Cancel / Clear ────────────────────────────────────────────────────

    Private Sub btnCancelSale_Click(sender As Object, e As EventArgs) Handles btnCancelSale.Click
        If _saleItems.Rows.Count > 0 Then
            Dim confirm = MessageBox.Show(
                "Cancel this sale? All items will be cleared.",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
            If confirm <> DialogResult.Yes Then Return
        End If
        ClearSale()
    End Sub

    Private Sub ClearSale()
        _saleItems.Rows.Clear()
        txtDiscount.Clear()
        RecalculateTotals()
        cboProduct.SelectedIndex = -1
        txtQty.Clear()
    End Sub

End Class
