Public Class frmCategories

    Private _repo As New CategoryRepository()
    Private _selectedId As Integer = 0

    Private Sub frmCategories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' GATE — remove this block when unlocking for v1.02
        Dim gate As New UnderConstructionForm()
        gate.ShowDialog()
        Me.Close()
        Return
        ' END GATE
        Me.Text = "Category Management"
        ConfigureGrid()
        LoadCategories()
    End Sub

    Private Sub ConfigureGrid()
        dgvCategories.AutoGenerateColumns = False
        dgvCategories.Columns.Clear()

        dgvCategories.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "CategoryID",
            .DataPropertyName = "CategoryID",
            .HeaderText       = "ID",
            .Width            = 60,
            .ReadOnly         = True
        })
        dgvCategories.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name             = "CategoryName",
            .DataPropertyName = "CategoryName",
            .HeaderText       = "Category Name",
            .AutoSizeMode     = DataGridViewAutoSizeColumnMode.Fill,
            .ReadOnly         = True
        })
    End Sub

    Private Sub LoadCategories()
        dgvCategories.DataSource = _repo.GetAll()
    End Sub

    Private Sub ClearForm()
        txtCategoryName.Clear()
        txtCategoryName.Focus()
        _selectedId = 0
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        dgvCategories.ClearSelection()
    End Sub

    ' ── Grid selection ────────────────────────────────────────────────────

    Private Sub dgvCategories_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCategories.SelectionChanged
        If dgvCategories.CurrentRow Is Nothing Then Return
        Dim row = dgvCategories.CurrentRow
        _selectedId               = CInt(row.Cells("CategoryID").Value)
        txtCategoryName.Text      = row.Cells("CategoryName").Value.ToString()
        btnUpdate.Enabled         = True
        btnDelete.Enabled         = True
    End Sub

    ' ── Add ───────────────────────────────────────────────────────────────

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim name As String = InputHelper.SanitizeInput(txtCategoryName.Text)
        If name = "" Then
            MessageBox.Show("Category name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If _repo.NameExists(name) Then
            MessageBox.Show("A category with that name already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If _repo.Add(name) Then
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, $"Added category: {name}")
            LoadCategories()
            ClearForm()
        Else
            MessageBox.Show("Failed to add category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ── Update ────────────────────────────────────────────────────────────

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If _selectedId = 0 Then Return
        Dim name As String = InputHelper.SanitizeInput(txtCategoryName.Text)
        If name = "" Then
            MessageBox.Show("Category name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If _repo.NameExists(name, _selectedId) Then
            MessageBox.Show("A category with that name already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If _repo.Update(_selectedId, name) Then
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, $"Updated category ID {_selectedId} to: {name}")
            LoadCategories()
            ClearForm()
        Else
            MessageBox.Show("Failed to update category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ── Delete ────────────────────────────────────────────────────────────

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If _selectedId = 0 Then Return
        Dim name As String = txtCategoryName.Text

        Dim confirm = MessageBox.Show(
            $"Delete category ""{name}""? This cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)

        If confirm <> DialogResult.Yes Then Return

        If _repo.Delete(_selectedId) Then
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, $"Deleted category: {name}")
            LoadCategories()
            ClearForm()
        Else
            MessageBox.Show("Failed to delete category. It may be in use by existing products.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ── Clear button ──────────────────────────────────────────────────────

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

End Class
