Public Class frmSuppliers

    Private _repo As New SupplierRepository()
    Private _selectedId As Integer = 0

    Private Sub frmSuppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
Me.Text = "Supplier Management"
        ConfigureGrid()
        LoadSuppliers()
    End Sub

    Private Sub ConfigureGrid()
        dgvSuppliers.AutoGenerateColumns = False
        dgvSuppliers.Columns.Clear()

        dgvSuppliers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "SupplierID",
            .DataPropertyName = "SupplierID",
            .HeaderText       = "ID",
            .Width            = 50,
            .ReadOnly         = True
        })
        dgvSuppliers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "Name",
            .DataPropertyName = "Name",
            .HeaderText       = "Supplier Name",
            .Width            = 180,
            .ReadOnly         = True
        })
        dgvSuppliers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "ContactPerson",
            .DataPropertyName = "ContactPerson",
            .HeaderText       = "Contact Person",
            .Width            = 150,
            .ReadOnly         = True
        })
        dgvSuppliers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "Phone",
            .DataPropertyName = "Phone",
            .HeaderText       = "Phone",
            .Width            = 120,
            .ReadOnly         = True
        })
        dgvSuppliers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "Email",
            .DataPropertyName = "Email",
            .HeaderText       = "Email",
            .AutoSizeMode     = DataGridViewAutoSizeColumnMode.Fill,
            .ReadOnly         = True
        })
    End Sub

    Private Sub LoadSuppliers()
        dgvSuppliers.DataSource = _repo.GetAll()
    End Sub

    Private Sub ClearForm()
        txtName.Clear()
        txtContact.Clear()
        txtPhone.Clear()
        txtEmail.Clear()
        txtAddress.Clear()
        txtName.Focus()
        _selectedId = 0
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        dgvSuppliers.ClearSelection()
    End Sub

    ' ── Grid selection ────────────────────────────────────────────────────

    Private Sub dgvSuppliers_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSuppliers.SelectionChanged
        If dgvSuppliers.CurrentRow Is Nothing Then Return
        Dim row = dgvSuppliers.CurrentRow
        _selectedId      = CInt(row.Cells("SupplierID").Value)
        txtName.Text     = row.Cells("Name").Value?.ToString()
        txtContact.Text  = row.Cells("ContactPerson").Value?.ToString()
        txtPhone.Text    = row.Cells("Phone").Value?.ToString()
        txtEmail.Text    = row.Cells("Email").Value?.ToString()

        ' Address not in grid — fetch from repo
        Dim dt = _repo.GetAll()
        Dim rows = dt.Select($"SupplierID = {_selectedId}")
        If rows.Length > 0 Then
            txtAddress.Text = rows(0)("Address")?.ToString()
        End If

        btnUpdate.Enabled = True
        btnDelete.Enabled = True
    End Sub

    ' ── Add ───────────────────────────────────────────────────────────────

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim name As String = InputHelper.SanitizeInput(txtName.Text)
        If name = "" Then
            MessageBox.Show("Supplier name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim contact As String = InputHelper.SanitizeInput(txtContact.Text)
        Dim phone   As String = InputHelper.SanitizeInput(txtPhone.Text)
        Dim email   As String = InputHelper.SanitizeInput(txtEmail.Text)
        Dim address As String = InputHelper.SanitizeInput(txtAddress.Text)

        If _repo.Add(name, contact, phone, email, address) Then
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, $"Added supplier: {name}")
            LoadSuppliers()
            ClearForm()
        Else
            MessageBox.Show("Failed to add supplier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ── Update ────────────────────────────────────────────────────────────

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If _selectedId = 0 Then Return
        Dim name As String = InputHelper.SanitizeInput(txtName.Text)
        If name = "" Then
            MessageBox.Show("Supplier name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim contact As String = InputHelper.SanitizeInput(txtContact.Text)
        Dim phone   As String = InputHelper.SanitizeInput(txtPhone.Text)
        Dim email   As String = InputHelper.SanitizeInput(txtEmail.Text)
        Dim address As String = InputHelper.SanitizeInput(txtAddress.Text)

        If _repo.Update(_selectedId, name, contact, phone, email, address) Then
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, $"Updated supplier ID {_selectedId}: {name}")
            LoadSuppliers()
            ClearForm()
        Else
            MessageBox.Show("Failed to update supplier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ── Delete ────────────────────────────────────────────────────────────

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If _selectedId = 0 Then Return
        Dim name As String = txtName.Text

        Dim confirm = MessageBox.Show(
            $"Delete supplier ""{name}""? This cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)

        If confirm <> DialogResult.Yes Then Return

        If _repo.Delete(_selectedId) Then
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, $"Deleted supplier: {name}")
            LoadSuppliers()
            ClearForm()
        Else
            MessageBox.Show("Failed to delete supplier. It may be linked to existing products or stock receipts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ── Clear ─────────────────────────────────────────────────────────────

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

End Class
