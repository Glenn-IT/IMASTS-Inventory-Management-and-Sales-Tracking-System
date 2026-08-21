Imports Microsoft.Data.SqlClient

Public Class frmProducts

    Private _repo As New ProductRepository()
    Private _selectedId As Integer = 0
    Private _categoriesTable As DataTable
    Private _productsTable As DataTable

    Private Sub frmProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Product Management"
        ConfigureGrid()
        LoadComboBoxes()
        LoadProducts()
    End Sub

    Private Sub ConfigureGrid()
        dgvProducts.AutoGenerateColumns = False
        dgvProducts.Columns.Clear()

        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "ProductID",
            .DataPropertyName = "ProductID",
            .HeaderText       = "ID",
            .Width            = 50,
            .AutoSizeMode     = DataGridViewAutoSizeColumnMode.None,
            .ReadOnly         = True
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "Barcode",
            .DataPropertyName = "Barcode",
            .HeaderText       = "Barcode",
            .FillWeight       = 110,
            .ReadOnly         = True
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "Name",
            .DataPropertyName = "Name",
            .HeaderText       = "Product Name",
            .FillWeight       = 170,
            .ReadOnly         = True
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "CategoryName",
            .DataPropertyName = "CategoryName",
            .HeaderText       = "Category",
            .FillWeight       = 110,
            .ReadOnly         = True
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "SupplierName",
            .DataPropertyName = "SupplierName",
            .HeaderText       = "Supplier",
            .FillWeight       = 130,
            .ReadOnly         = True
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name                       = "UnitPrice",
            .DataPropertyName           = "UnitPrice",
            .HeaderText                 = "Unit Price",
            .FillWeight                 = 85,
            .ReadOnly                   = True,
            .DefaultCellStyle           = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "StockQty",
            .DataPropertyName = "StockQty",
            .HeaderText       = "Stock",
            .FillWeight       = 65,
            .ReadOnly         = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "Unit",
            .DataPropertyName = "Unit",
            .HeaderText       = "Unit",
            .FillWeight       = 65,
            .ReadOnly         = True
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "ReorderLevel",
            .DataPropertyName = "ReorderLevel",
            .HeaderText       = "Reorder",
            .FillWeight       = 65,
            .ReadOnly         = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleRight}
        })

        ' Hidden columns — needed for SelectionChanged binding
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "CategoryID",
            .DataPropertyName = "CategoryID",
            .Visible = False
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "SupplierID",
            .DataPropertyName = "SupplierID",
            .Visible = False
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Description",
            .DataPropertyName = "Description",
            .Visible = False
        })
    End Sub

    Private Sub LoadComboBoxes()
        _categoriesTable          = _repo.GetCategories()
        cboCategory.DataSource    = _categoriesTable
        cboCategory.DisplayMember = "CategoryName"
        cboCategory.ValueMember   = "CategoryID"
        cboCategory.SelectedIndex = -1

        Dim sups = _repo.GetSuppliers()
        cboSupplier.DataSource    = sups
        cboSupplier.DisplayMember = "Name"
        cboSupplier.ValueMember   = "SupplierID"
        cboSupplier.SelectedIndex = -1
    End Sub

    Private Sub LoadProducts()
        _productsTable = _repo.GetAll()
        ApplySearchFilter()
    End Sub

    Private Sub ApplySearchFilter()
        If _productsTable Is Nothing Then Return
        Dim search = txtSearch.Text.Trim().Replace("'", "''")
        If String.IsNullOrWhiteSpace(search) Then
            _productsTable.DefaultView.RowFilter = ""
        Else
            _productsTable.DefaultView.RowFilter = $"Name LIKE '%{search}%' OR Barcode LIKE '%{search}%' OR CategoryName LIKE '%{search}%' OR SupplierName LIKE '%{search}%'"
        End If
        dgvProducts.DataSource = _productsTable.DefaultView
        lblTotalRecords.Text = $"Total Records: {_productsTable.DefaultView.Count}"
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplySearchFilter()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ' If there's an exact barcode match or first row, select it
            If dgvProducts.Rows.Count > 0 Then
                dgvProducts.Rows(0).Selected = True
                dgvProducts_SelectionChanged(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
        txtSearch.Clear()
        txtSearch.Focus()
    End Sub

    Private Sub ClearForm()
        dgvProducts.ClearSelection()
        dgvProducts.CurrentCell = Nothing
        txtBarcode.Clear()
        txtName.Clear()
        cboCategory.SelectedIndex = -1
        cboSupplier.SelectedIndex = -1
        cboUnit.Text = "pcs"
        txtDescription.Clear()
        txtUnitPrice.Clear()
        txtStockQty.Clear()
        txtReorderLevel.Clear()
        txtBarcode.Focus()
        _selectedId       = 0
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub btnGenBarcode_Click(sender As Object, e As EventArgs) Handles btnGenBarcode.Click
        ' Auto-generate a unique barcode
        Dim prefix = "PRD"
        Dim timestamp = DateTime.Now.ToString("yyMMddHHmmss")
        Dim candidate = prefix & timestamp
        txtBarcode.Text = candidate
        txtName.Focus()
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        If _categoriesTable Is Nothing OrElse cboCategory.SelectedValue Is Nothing Then Return
        If TypeOf cboCategory.SelectedValue Is DataRowView Then Return
        Dim catId As Integer
        If Integer.TryParse(cboCategory.SelectedValue.ToString(), catId) AndAlso catId > 0 Then
            Dim rows = _categoriesTable.Select($"CategoryID = {catId}")
            If rows.Length > 0 AndAlso Not IsDBNull(rows(0)("DefaultUnit")) Then
                Dim defUnit = rows(0)("DefaultUnit").ToString()
                If Not String.IsNullOrWhiteSpace(defUnit) AndAlso _selectedId = 0 Then
                    cboUnit.Text = defUnit
                End If
            End If
        End If
    End Sub

    ' ── Numeric-only input guards ─────────────────────────────────────────

    Private Sub txtUnitPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnitPrice.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        ElseIf e.KeyChar = "."c AndAlso txtUnitPrice.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtStockQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStockQty.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtReorderLevel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReorderLevel.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' ── Grid selection ────────────────────────────────────────────────────

    Private Sub dgvProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProducts.SelectionChanged
        If dgvProducts.CurrentRow Is Nothing Then Return
        Dim row = dgvProducts.CurrentRow
        _selectedId            = CInt(row.Cells("ProductID").Value)
        txtBarcode.Text        = row.Cells("Barcode").Value?.ToString()
        txtName.Text           = row.Cells("Name").Value?.ToString()
        txtDescription.Text    = row.Cells("Description").Value?.ToString()
        txtUnitPrice.Text      = row.Cells("UnitPrice").Value?.ToString()
        txtStockQty.Text       = row.Cells("StockQty").Value?.ToString()
        txtReorderLevel.Text   = row.Cells("ReorderLevel").Value?.ToString()
        cboUnit.Text           = If(row.Cells("Unit").Value?.ToString(), "pcs")
        cboCategory.SelectedValue = row.Cells("CategoryID").Value
        cboSupplier.SelectedValue = row.Cells("SupplierID").Value
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
    End Sub

    ' ── Validation ────────────────────────────────────────────────────────

    Private Function ValidateInputs(ByRef barcode As String, ByRef name As String,
                                    ByRef categoryId As Integer, ByRef supplierId As Integer,
                                    ByRef unitPrice As Decimal, ByRef stockQty As Integer,
                                    ByRef reorderLevel As Integer) As Boolean
        barcode = InputHelper.SanitizeInput(txtBarcode.Text)
        name = InputHelper.SanitizeInput(txtName.Text)

        If name = "" Then
            MessageBox.Show("Product name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return False
        End If

        If Not String.IsNullOrWhiteSpace(barcode) Then
            If _repo.BarcodeExists(barcode, _selectedId) Then
                MessageBox.Show($"Barcode ""{barcode}"" is already assigned to another product. Please use a unique barcode.",
                                "Duplicate Barcode", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBarcode.Focus()
                Return False
            End If
        End If

        If cboCategory.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        categoryId = CInt(cboCategory.SelectedValue)

        If cboSupplier.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a supplier.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        supplierId = CInt(cboSupplier.SelectedValue)

        If Not Decimal.TryParse(txtUnitPrice.Text, unitPrice) OrElse unitPrice < 0 Then
            MessageBox.Show("Unit price must be a valid positive number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If Not Integer.TryParse(txtStockQty.Text, stockQty) OrElse stockQty < 0 Then
            MessageBox.Show("Stock quantity must be a valid non-negative integer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If Not Integer.TryParse(txtReorderLevel.Text, reorderLevel) OrElse reorderLevel < 0 Then
            MessageBox.Show("Reorder level must be a valid non-negative integer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    ' ── Add ───────────────────────────────────────────────────────────────

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim barcode As String = ""
        Dim name As String = ""
        Dim categoryId, supplierId, stockQty, reorderLevel As Integer
        Dim unitPrice As Decimal
        If Not ValidateInputs(barcode, name, categoryId, supplierId, unitPrice, stockQty, reorderLevel) Then Return

        Dim description As String = InputHelper.SanitizeInput(txtDescription.Text)
        Dim unit As String = InputHelper.SanitizeInput(cboUnit.Text)
        If unit = "" Then unit = "pcs"

        If _repo.Add(name, categoryId, supplierId, description, unitPrice, stockQty, reorderLevel, unit, barcode) Then
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, $"Added product: {name} (Barcode: {If(barcode = "", "N/A", barcode)})")
            LoadProducts()
            ClearForm()
        Else
            MessageBox.Show("Failed to add product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ── Update ────────────────────────────────────────────────────────────

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If _selectedId = 0 Then Return
        Dim barcode As String = ""
        Dim name As String = ""
        Dim categoryId, supplierId, stockQty, reorderLevel As Integer
        Dim unitPrice As Decimal
        If Not ValidateInputs(barcode, name, categoryId, supplierId, unitPrice, stockQty, reorderLevel) Then Return

        Dim description As String = InputHelper.SanitizeInput(txtDescription.Text)
        Dim unit As String = InputHelper.SanitizeInput(cboUnit.Text)
        If unit = "" Then unit = "pcs"

        If _repo.Update(_selectedId, name, categoryId, supplierId, description, unitPrice, stockQty, reorderLevel, unit, barcode) Then
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, $"Updated product ID {_selectedId}: {name} (Barcode: {If(barcode = "", "N/A", barcode)})")
            LoadProducts()
            ClearForm()
        Else
            MessageBox.Show("Failed to update product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ── Delete ────────────────────────────────────────────────────────────

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If _selectedId = 0 Then Return
        Dim name As String = txtName.Text

        Dim confirm = MessageBox.Show(
            $"Delete product ""{name}""? This cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)

        If confirm <> DialogResult.Yes Then Return

        Try
            If _repo.Delete(_selectedId) Then
                ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, $"Deleted product: {name}")
                LoadProducts()
                ClearForm()
            Else
                MessageBox.Show("Failed to delete product. It may be linked to existing sales or stock receipts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As SqlException When ex.Number = 547
            MessageBox.Show(
                $"""{name}"" cannot be deleted because it is still referenced by existing sales, inventory, or stock receipt records." & vbCrLf & vbCrLf &
                "Remove those records first, then try again.",
                "Product In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show($"Failed to delete product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Clear ─────────────────────────────────────────────────────────────

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

End Class
