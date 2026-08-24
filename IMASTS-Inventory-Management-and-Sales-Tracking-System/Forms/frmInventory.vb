Public Class frmInventory

    Private _repo As New InventoryRepository()
    Private _inventoryTable As DataTable
    Private _productsTable As DataTable
    Private _selectedProductId As Integer = 0

    Private Sub frmInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Inventory Management"
        ConfigureGrid()
        LoadComboBoxes()
        LoadInventory()
        ClearForm()
    End Sub

    ' ── Grid ──────────────────────────────────────────────────────────────

    Private Sub ConfigureGrid()
        dgvInventory.AutoGenerateColumns = False
        dgvInventory.Columns.Clear()

        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "ProductID", .DataPropertyName = "ProductID",
            .HeaderText = "ID", .Width = 50, .AutoSizeMode = DataGridViewAutoSizeColumnMode.None, .ReadOnly = True
        })
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
            .Name = "StockStatus", .DataPropertyName = "StockStatus",
            .HeaderText = "Status", .FillWeight = 100, .ReadOnly = True
        })
    End Sub

    Private Sub LoadComboBoxes()
        _productsTable = _repo.GetProducts()

        cboProduct.DataSource = Nothing
        cboProduct.DataSource = _productsTable
        cboProduct.DisplayMember = "Name"
        cboProduct.ValueMember = "ProductID"
        cboProduct.SelectedIndex = -1

        cboSupplier.DataSource = Nothing
        cboSupplier.DataSource = _repo.GetSuppliers()
        cboSupplier.DisplayMember = "Name"
        cboSupplier.ValueMember = "SupplierID"
        cboSupplier.SelectedIndex = -1
    End Sub

    Private Sub LoadInventory()
        _inventoryTable = _repo.GetAllWithStockLevel()
        ApplySearchFilter()
    End Sub

    Private Sub ApplySearchFilter()
        If _inventoryTable Is Nothing Then Return
        Dim search = txtSearch.Text.Trim().Replace("'", "''")
        If String.IsNullOrWhiteSpace(search) Then
            _inventoryTable.DefaultView.RowFilter = ""
        Else
            _inventoryTable.DefaultView.RowFilter = $"Name LIKE '%{search}%' OR Barcode LIKE '%{search}%' OR CategoryName LIKE '%{search}%' OR StockStatus LIKE '%{search}%'"
        End If
        dgvInventory.DataSource = _inventoryTable.DefaultView
        ColorizeRows()
        UpdateFooterCounts()
    End Sub

    Private Sub UpdateFooterCounts()
        If _inventoryTable Is Nothing Then
            lblTotalRecords.Text = "Total Records: 0"
            Return
        End If

        Dim total = _inventoryTable.DefaultView.Count
        Dim outOfStock = 0
        Dim lowStock = 0

        For Each drv As DataRowView In _inventoryTable.DefaultView
            Dim status = drv("StockStatus")?.ToString()
            If status = "Out of Stock" Then
                outOfStock += 1
            ElseIf status = "Low Stock" Then
                lowStock += 1
            End If
        Next

        lblTotalRecords.Text = $"Total Records: {total}   |   Low Stock: {lowStock}   |   Out of Stock: {outOfStock}"
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplySearchFilter()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If dgvInventory.Rows.Count > 0 Then
                dgvInventory.Rows(0).Selected = True
                SyncFormFromGrid()
            End If
        End If
    End Sub

    Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
        txtSearch.Clear()
        txtSearch.Focus()
    End Sub

    Private Sub ColorizeRows()
        For Each row As DataGridViewRow In dgvInventory.Rows
            Dim status = row.Cells("StockStatus").Value?.ToString()
            Select Case status
                Case "Out of Stock"
                    row.DefaultCellStyle.BackColor = Drawing.Color.FromArgb(255, 220, 220)
                    row.DefaultCellStyle.ForeColor = Drawing.Color.FromArgb(180, 0, 0)
                Case "Low Stock"
                    row.DefaultCellStyle.BackColor = Drawing.Color.FromArgb(255, 243, 205)
                    row.DefaultCellStyle.ForeColor = Drawing.Color.FromArgb(140, 80, 0)
                Case Else
                    row.DefaultCellStyle.BackColor = Drawing.Color.White
                    row.DefaultCellStyle.ForeColor = Drawing.Color.FromArgb(40, 44, 52)
            End Select
        Next
    End Sub

    ' ── Form & Selection Sync ─────────────────────────────────────────────

    Private Sub ClearForm()
        _selectedProductId = 0
        txtBarcode.Clear()
        cboProduct.SelectedIndex = -1
        txtCategory.Clear()
        txtCurrentStock.Clear()
        txtUnit.Clear()
        cboSupplier.SelectedIndex = -1
        txtQuantity.Clear()
        txtNotes.Clear()
        dgvInventory.ClearSelection()
        dgvInventory.CurrentCell = Nothing
    End Sub

    Private Sub SyncFormFromGrid()
        If dgvInventory.CurrentRow Is Nothing Then Return
        Dim row = dgvInventory.CurrentRow
        Dim prodId As Integer
        If Integer.TryParse(row.Cells("ProductID").Value?.ToString(), prodId) Then
            _selectedProductId = prodId
            cboProduct.SelectedValue = prodId
            txtBarcode.Text = row.Cells("Barcode").Value?.ToString()
            txtCategory.Text = row.Cells("CategoryName").Value?.ToString()
            txtCurrentStock.Text = row.Cells("StockQty").Value?.ToString()
            txtUnit.Text = row.Cells("Unit").Value?.ToString()

            ' Sync default supplier if present in product details
            SyncSupplierForProduct(prodId)
            txtQuantity.Focus()
        End If
    End Sub

    Private Sub SyncSupplierForProduct(productId As Integer)
        If _productsTable Is Nothing Then Return
        Dim rows = _productsTable.Select($"ProductID = {productId}")
        If rows.Length > 0 Then
            If rows(0)("SupplierID") IsNot DBNull.Value AndAlso cboSupplier.DataSource IsNot Nothing Then
                cboSupplier.SelectedValue = rows(0)("SupplierID")
            Else
                cboSupplier.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub dgvInventory_SelectionChanged(sender As Object, e As EventArgs) Handles dgvInventory.SelectionChanged
        SyncFormFromGrid()
    End Sub

    Private Sub dgvInventory_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellClick
        SyncFormFromGrid()
    End Sub

    Private Sub cboProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProduct.SelectedIndexChanged
        If _productsTable Is Nothing OrElse cboProduct.SelectedValue Is Nothing Then Return
        If TypeOf cboProduct.SelectedValue Is DataRowView Then Return

        Dim prodId As Integer
        If Integer.TryParse(cboProduct.SelectedValue.ToString(), prodId) AndAlso prodId > 0 Then
            _selectedProductId = prodId
            Dim rows = _productsTable.Select($"ProductID = {prodId}")
            If rows.Length > 0 Then
                txtBarcode.Text = rows(0)("Barcode")?.ToString()
                txtCategory.Text = rows(0)("CategoryName")?.ToString()
                txtCurrentStock.Text = rows(0)("StockQty")?.ToString()
                txtUnit.Text = rows(0)("Unit")?.ToString()
                If rows(0)("SupplierID") IsNot DBNull.Value AndAlso cboSupplier.DataSource IsNot Nothing Then
                    cboSupplier.SelectedValue = rows(0)("SupplierID")
                Else
                    cboSupplier.SelectedIndex = -1
                End If
            End If
        End If
    End Sub

    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim code = txtBarcode.Text.Trim()
            If String.IsNullOrWhiteSpace(code) OrElse _productsTable Is Nothing Then Return

            Dim rows = _productsTable.Select($"Barcode = '{code.Replace("'", "''")}'")
            If rows.Length = 0 Then
                Dim numId As Integer
                If Integer.TryParse(code, numId) Then
                    rows = _productsTable.Select($"ProductID = {numId}")
                End If
            End If

            If rows.Length > 0 Then
                cboProduct.SelectedValue = rows(0)("ProductID")
                txtQuantity.Focus()
                Try : Media.SystemSounds.Asterisk.Play() : Catch : End Try
            Else
                MessageBox.Show($"Product with barcode/ID ""{code}"" not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBarcode.SelectAll()
            End If
        End If
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' ── Helpers ───────────────────────────────────────────────────────────

    Private Function GetSelectedId(cbo As ComboBox) As Integer
        If cbo IsNot Nothing AndAlso cbo.SelectedValue IsNot Nothing Then
            Dim val As Integer
            If Integer.TryParse(cbo.SelectedValue.ToString(), val) Then
                Return val
            ElseIf TypeOf cbo.SelectedValue Is DataRowView Then
                Dim drv = CType(cbo.SelectedValue, DataRowView)
                If drv.Row.Table.Columns.Contains(cbo.ValueMember) AndAlso Integer.TryParse(drv(cbo.ValueMember).ToString(), val) Then
                    Return val
                End If
            End If
        End If
        Return 0
    End Function

    Private Sub SelectProductInGrid(productId As Integer)
        For Each row As DataGridViewRow In dgvInventory.Rows
            If row.Cells("ProductID").Value?.ToString() = productId.ToString() Then
                row.Selected = True
                dgvInventory.CurrentCell = row.Cells(0)
                Exit For
            End If
        Next
    End Sub

    ' ── Actions ───────────────────────────────────────────────────────────

    Private Sub btnReceiveStock_Click(sender As Object, e As EventArgs) Handles btnReceiveStock.Click
        Dim productId = GetSelectedId(cboProduct)
        If productId <= 0 Then
            MessageBox.Show("Please select a product from the list or table first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboProduct.Focus()
            Return
        End If

        Dim qty As Integer
        If Not Integer.TryParse(txtQuantity.Text.Trim(), qty) OrElse qty <= 0 Then
            MessageBox.Show("Please enter a valid positive quantity to receive.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Focus()
            Return
        End If

        Dim productName = cboProduct.Text
        Dim supplierId = GetSelectedId(cboSupplier)
        Dim notes = InputHelper.SanitizeInput(txtNotes.Text)

        Dim confirm = MessageBox.Show(
            $"Receive {qty} unit(s) of ""{productName}"" into inventory?",
            "Confirm Stock Receipt",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        If _repo.ReceiveStock(productId, qty, supplierId, notes) Then
            Dim logMsg = $"Received {qty} unit(s) of ""{productName}"" into stock."
            If notes <> "" Then logMsg &= $" Notes: {notes}"
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, logMsg)

            LoadInventory()
            LoadComboBoxes()
            SelectProductInGrid(productId)
            txtQuantity.Clear()
            txtNotes.Clear()

            MessageBox.Show($"Successfully received {qty} unit(s) of ""{productName}"".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to receive stock. Please check database connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnAdjustStock_Click(sender As Object, e As EventArgs) Handles btnAdjustStock.Click
        Dim productId = GetSelectedId(cboProduct)
        If productId <= 0 Then
            MessageBox.Show("Please select a product from the list or table first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboProduct.Focus()
            Return
        End If

        Dim newQty As Integer
        If Not Integer.TryParse(txtQuantity.Text.Trim(), newQty) OrElse newQty < 0 Then
            MessageBox.Show("Please enter a valid non-negative integer for the new stock level.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Focus()
            Return
        End If

        Dim productName = cboProduct.Text
        Dim notes = InputHelper.SanitizeInput(txtNotes.Text)
        Dim currentStockText = If(String.IsNullOrWhiteSpace(txtCurrentStock.Text), "0", txtCurrentStock.Text)

        Dim confirm = MessageBox.Show(
            $"Adjust stock for ""{productName}"" from {currentStockText} to {newQty} unit(s)?",
            "Confirm Stock Adjustment",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        If _repo.AdjustStock(productId, newQty) Then
            Dim logMsg = $"Adjusted stock for ""{productName}"" to {newQty} unit(s)."
            If notes <> "" Then logMsg &= $" Reason: {notes}"
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, logMsg)

            LoadInventory()
            LoadComboBoxes()
            SelectProductInGrid(productId)
            txtQuantity.Clear()
            txtNotes.Clear()

            MessageBox.Show($"Successfully set stock for ""{productName}"" to {newQty} unit(s).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to adjust stock. Please check database connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadInventory()
        LoadComboBoxes()
        ClearForm()
    End Sub

End Class
