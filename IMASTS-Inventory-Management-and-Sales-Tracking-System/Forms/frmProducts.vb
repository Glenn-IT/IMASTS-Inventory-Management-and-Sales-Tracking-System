Imports Microsoft.Data.SqlClient

Public Class frmProducts

    Private _repo As New ProductRepository()
    Private _selectedId As Integer = 0

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
            .ReadOnly         = True
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "Name",
            .DataPropertyName = "Name",
            .HeaderText       = "Product Name",
            .Width            = 180,
            .ReadOnly         = True
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "CategoryName",
            .DataPropertyName = "CategoryName",
            .HeaderText       = "Category",
            .Width            = 120,
            .ReadOnly         = True
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "SupplierName",
            .DataPropertyName = "SupplierName",
            .HeaderText       = "Supplier",
            .Width            = 140,
            .ReadOnly         = True
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name                       = "UnitPrice",
            .DataPropertyName           = "UnitPrice",
            .HeaderText                 = "Unit Price",
            .Width                      = 90,
            .ReadOnly                   = True,
            .DefaultCellStyle           = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "StockQty",
            .DataPropertyName = "StockQty",
            .HeaderText       = "Stock",
            .Width            = 70,
            .ReadOnly         = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvProducts.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "ReorderLevel",
            .DataPropertyName = "ReorderLevel",
            .HeaderText       = "Reorder",
            .Width            = 70,
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
        Dim cats = _repo.GetCategories()
        cboCategory.DataSource    = cats
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
        dgvProducts.DataSource = _repo.GetAll()
    End Sub

    Private Sub ClearForm()
        txtName.Clear()
        cboCategory.SelectedIndex = -1
        cboSupplier.SelectedIndex = -1
        txtDescription.Clear()
        txtUnitPrice.Clear()
        txtStockQty.Clear()
        txtReorderLevel.Clear()
        txtName.Focus()
        _selectedId       = 0
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        dgvProducts.ClearSelection()
    End Sub

    ' ── Grid selection ────────────────────────────────────────────────────

    Private Sub dgvProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProducts.SelectionChanged
        If dgvProducts.CurrentRow Is Nothing Then Return
        Dim row = dgvProducts.CurrentRow
        _selectedId            = CInt(row.Cells("ProductID").Value)
        txtName.Text           = row.Cells("Name").Value?.ToString()
        txtDescription.Text    = row.Cells("Description").Value?.ToString()
        txtUnitPrice.Text      = row.Cells("UnitPrice").Value?.ToString()
        txtStockQty.Text       = row.Cells("StockQty").Value?.ToString()
        txtReorderLevel.Text   = row.Cells("ReorderLevel").Value?.ToString()
        cboCategory.SelectedValue = row.Cells("CategoryID").Value
        cboSupplier.SelectedValue = row.Cells("SupplierID").Value
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
    End Sub

    ' ── Validation ────────────────────────────────────────────────────────

    Private Function ValidateInputs(ByRef name As String, ByRef categoryId As Integer,
                                    ByRef supplierId As Integer, ByRef unitPrice As Decimal,
                                    ByRef stockQty As Integer, ByRef reorderLevel As Integer) As Boolean
        name = InputHelper.SanitizeInput(txtName.Text)
        If name = "" Then
            MessageBox.Show("Product name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
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
        Dim name As String = ""
        Dim categoryId, supplierId, stockQty, reorderLevel As Integer
        Dim unitPrice As Decimal
        If Not ValidateInputs(name, categoryId, supplierId, unitPrice, stockQty, reorderLevel) Then Return

        Dim description As String = InputHelper.SanitizeInput(txtDescription.Text)

        If _repo.Add(name, categoryId, supplierId, description, unitPrice, stockQty, reorderLevel) Then
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, $"Added product: {name}")
            LoadProducts()
            ClearForm()
        Else
            MessageBox.Show("Failed to add product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ── Update ────────────────────────────────────────────────────────────

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If _selectedId = 0 Then Return
        Dim name As String = ""
        Dim categoryId, supplierId, stockQty, reorderLevel As Integer
        Dim unitPrice As Decimal
        If Not ValidateInputs(name, categoryId, supplierId, unitPrice, stockQty, reorderLevel) Then Return

        Dim description As String = InputHelper.SanitizeInput(txtDescription.Text)

        If _repo.Update(_selectedId, name, categoryId, supplierId, description, unitPrice, stockQty, reorderLevel) Then
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, $"Updated product ID {_selectedId}: {name}")
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
