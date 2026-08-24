Public Class frmNewSale

    Private _repo      As New SaleRepository()
    Private _saleItems As New DataTable()
    Private _products  As DataTable

    ' Last confirmed sale state for printing
    Private _lastSaleId     As Integer = 0
    Private _lastCashier    As String = ""
    Private _lastSaleDate   As DateTime = DateTime.Now
    Private _lastItems      As DataTable = Nothing
    Private _lastSubtotal   As Decimal = 0
    Private _lastDiscount   As Decimal = 0
    Private _lastNetAmount  As Decimal = 0

    Private Sub frmNewSale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "New Sale"
        InitSaleItemsTable()
        ConfigureGrid()
        LoadProducts()
        RecalculateTotals()
        ResetPrintButton()
        txtScanBarcode.Focus()
    End Sub

    Private Sub frmNewSale_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtScanBarcode.Focus()
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

    Private Sub ResetPrintButton()
        If _lastSaleId > 0 Then
            btnPrintReceipt.Enabled = True
            btnPrintReceipt.BackColor = Color.FromArgb(41, 128, 185)
            btnPrintReceipt.Text = $"🖶 Print Receipt #{_lastSaleId:D4}"
        Else
            btnPrintReceipt.Enabled = False
            btnPrintReceipt.BackColor = Color.FromArgb(189, 195, 199)
            btnPrintReceipt.Text = "🖶 Print Receipt"
        End If
    End Sub

    ' ── Barcode Scanner handler ───────────────────────────────────────────

    Private Sub txtScanBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtScanBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim scannedCode = txtScanBarcode.Text.Trim()
            If String.IsNullOrWhiteSpace(scannedCode) Then Return

            ' Look up product by Barcode first, or by ProductID if numeric
            Dim prodRows As DataRow() = _products.Select($"Barcode = '{scannedCode.Replace("'", "''")}'")
            If prodRows.Length = 0 Then
                Dim numId As Integer
                If Integer.TryParse(scannedCode, numId) Then
                    prodRows = _products.Select($"ProductID = {numId}")
                End If
            End If

            If prodRows.Length > 0 Then
                Dim row = prodRows(0)
                Dim productId   = CInt(row("ProductID"))
                Dim productName = row("Name").ToString()
                Dim unitPrice   = CDec(row("UnitPrice"))
                Dim stockQty    = CInt(row("StockQty"))

                ' Sum qty already in cart for this product
                Dim cartQty As Integer = 0
                Dim existing = _saleItems.Select($"ProductID = {productId}")
                If existing.Length > 0 Then cartQty = CInt(existing(0)("Quantity"))

                If cartQty + 1 > stockQty Then
                    Dim avail = stockQty - cartQty
                    lblScanStatus.ForeColor = Color.FromArgb(192, 57, 43)
                    lblScanStatus.Text = $"✗ Stock limit: Only {avail} left for ""{productName}""."
                    Try : Media.SystemSounds.Exclamation.Play() : Catch : End Try
                    txtScanBarcode.SelectAll()
                    Return
                End If

                Dim newQty As Integer
                If existing.Length > 0 Then
                    newQty = cartQty + 1
                    existing(0)("Quantity") = newQty
                    existing(0)("Subtotal") = newQty * unitPrice
                Else
                    newQty = 1
                    _saleItems.Rows.Add(productId, productName, 1, unitPrice, unitPrice)
                End If

                RecalculateTotals()
                lblScanStatus.ForeColor = Color.FromArgb(39, 174, 96)
                lblScanStatus.Text = $"✓ Scanned: {productName} (x{newQty})"
                Try : Media.SystemSounds.Asterisk.Play() : Catch : End Try

                txtScanBarcode.Clear()
                txtScanBarcode.Focus()
            Else
                lblScanStatus.ForeColor = Color.FromArgb(192, 57, 43)
                lblScanStatus.Text = $"✗ Barcode ""{scannedCode}"" not found."
                Try : Media.SystemSounds.Hand.Play() : Catch : End Try
                txtScanBarcode.SelectAll()
            End If
        End If
    End Sub

    ' ── Add item manually ─────────────────────────────────────────────────

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

        Dim newQty As Integer
        If existing.Length > 0 Then
            newQty = qty + cartQty
            existing(0)("Quantity") = newQty
            existing(0)("Subtotal") = newQty * unitPrice
        Else
            newQty = qty
            _saleItems.Rows.Add(productId, productName, qty, unitPrice, qty * unitPrice)
        End If

        RecalculateTotals()
        lblScanStatus.ForeColor = Color.FromArgb(39, 174, 96)
        lblScanStatus.Text = $"✓ Added: {productName} (x{newQty})"
        cboProduct.SelectedIndex = -1
        txtQty.Clear()
        txtScanBarcode.Focus()
    End Sub

    ' ── Remove item ───────────────────────────────────────────────────────

    Private Sub dgvSaleItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSaleItems.CellClick
        If e.ColumnIndex = dgvSaleItems.Columns("colRemove").Index AndAlso e.RowIndex >= 0 Then
            _saleItems.Rows.Remove(_saleItems.Rows(e.RowIndex))
            RecalculateTotals()
            txtScanBarcode.Focus()
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

        Dim subtotal As Decimal = 0
        For Each row As DataRow In _saleItems.Rows
            subtotal += CDec(row("Subtotal"))
        Next
        Dim netAmount As Decimal = subtotal - discount

        ' Copy items before completing sale
        Dim receiptItemsCopy = _saleItems.Copy()

        Dim saleId = _repo.CreateSale(SessionManager.Username, _saleItems, discount)
        If saleId > 0 Then
            _lastSaleId = saleId
            _lastCashier = SessionManager.Username
            _lastSaleDate = DateTime.Now
            _lastItems = receiptItemsCopy
            _lastSubtotal = subtotal
            _lastDiscount = discount
            _lastNetAmount = netAmount

            ResetPrintButton()

            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess,
                $"Sale #{saleId} confirmed. {_lastItems.Rows.Count} item(s), net: {txtNetAmount.Text}.")

            Dim askPrint = MessageBox.Show(
                $"Sale #{saleId} completed successfully!" & vbCrLf & vbCrLf &
                "Do you want to print the receipt now in Chrome / PDF?",
                "Sale Complete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If askPrint = DialogResult.Yes Then
                ReceiptHelper.OpenReceiptInChrome(_lastSaleId, _lastCashier, _lastSaleDate, _lastItems, _lastSubtotal, _lastDiscount, _lastNetAmount)
            End If

            ClearSale()
            LoadProducts()
        Else
            MessageBox.Show("Failed to process the sale. Please try again.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ── Print Receipt ─────────────────────────────────────────────────────

    Private Sub btnPrintReceipt_Click(sender As Object, e As EventArgs) Handles btnPrintReceipt.Click
        If _lastSaleId <= 0 OrElse _lastItems Is Nothing OrElse _lastItems.Rows.Count = 0 Then
            MessageBox.Show("No completed sale available to print.", "Print Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ReceiptHelper.OpenReceiptInChrome(_lastSaleId, _lastCashier, _lastSaleDate, _lastItems, _lastSubtotal, _lastDiscount, _lastNetAmount)
    End Sub

    ' ── Cancel / Clear ────────────────────────────────────────────────────

    Private Sub btnCancelSale_Click(sender As Object, e As EventArgs) Handles btnCancelSale.Click
        If _saleItems.Rows.Count > 0 Then
            Dim confirm = MessageBox.Show(
                "Cancel this sale? All items in the current cart will be cleared.",
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
        lblScanStatus.Text = ""
        RecalculateTotals()
        cboProduct.SelectedIndex = -1
        txtQty.Clear()
        txtScanBarcode.Clear()
        txtScanBarcode.Focus()
    End Sub

End Class
