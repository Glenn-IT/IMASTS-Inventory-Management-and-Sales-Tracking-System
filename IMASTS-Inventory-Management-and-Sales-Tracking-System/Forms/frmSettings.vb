Public Class frmSettings

    Private _selectedUserId   As Integer = 0
    Private _selectedUsername As String  = ""

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
Me.Text = "Settings"
        If SessionManager.IsAdmin Then
            ConfigureGrid()
            PopulateUserTypeCombo()
            LoadUsers()
            LoadPreferences()
        Else
            tabControl.TabPages.Remove(tabUsers)
            tabControl.TabPages.Remove(tabPrefs)
        End If
        PopulateSecurityQuestionCombo()
        LoadSecurityQA()
    End Sub

    ' ── Tab 1 — User Management ───────────────────────────────────────────

    Private Sub ConfigureGrid()
        dgvUsers.AutoGenerateColumns = False
        dgvUsers.Columns.Clear()

        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "UserID", .DataPropertyName = "UserID", .Visible = False
        })
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Username", .DataPropertyName = "Username",
            .HeaderText = "Username", .Width = 180, .ReadOnly = True
        })
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "UserType", .DataPropertyName = "UserType",
            .HeaderText = "Role", .Width = 100, .ReadOnly = True
        })
        dgvUsers.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "CreatedAt", .DataPropertyName = "CreatedAt",
            .HeaderText = "Created", .Width = 160, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "dd MMM yyyy  hh:mm tt"}
        })
    End Sub

    Private Sub PopulateUserTypeCombo()
        cboNewUserType.Items.Clear()
        cboNewUserType.Items.Add(Constants.RoleAdmin)
        cboNewUserType.Items.Add(Constants.RoleStaff)
        cboNewUserType.SelectedIndex = 1
    End Sub

    Private Sub LoadUsers()
        dgvUsers.DataSource    = UserRepository.GetAll()
        _selectedUserId        = 0
        _selectedUsername      = ""
        btnDeleteUser.Enabled  = False
        btnChangePass.Enabled  = False
        lblSelectedUser.Text   = "Select a user above."
    End Sub

    Private Sub dgvUsers_SelectionChanged(sender As Object, e As EventArgs) Handles dgvUsers.SelectionChanged
        If dgvUsers.CurrentRow Is Nothing Then Return
        Dim row = dgvUsers.CurrentRow
        _selectedUserId   = CInt(row.Cells("UserID").Value)
        _selectedUsername = row.Cells("Username").Value?.ToString()
        lblSelectedUser.Text  = $"Selected: {_selectedUsername}"
        btnDeleteUser.Enabled = (_selectedUsername <> SessionManager.Username)
        btnChangePass.Enabled = True
    End Sub

    ' ── Add User ──────────────────────────────────────────────────────────

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Dim uname = InputHelper.SanitizeInput(txtNewUsername.Text)
        If uname = "" Then
            MessageBox.Show("Username is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If txtNewPassword.Text.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If cboNewUserType.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a role.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If UserRepository.GetByUsername(uname).Rows.Count > 0 Then
            MessageBox.Show($"Username ""{uname}"" already exists.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim hash    = PasswordHelper.HashPassword(txtNewPassword.Text)
        Dim utype   = cboNewUserType.SelectedItem.ToString()
        UserRepository.Insert(uname, hash, utype)
        ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, $"Added user: {uname} ({utype})")
        LoadUsers()
        txtNewUsername.Clear()
        txtNewPassword.Clear()
        cboNewUserType.SelectedIndex = 1
    End Sub

    ' ── Change Password ───────────────────────────────────────────────────

    Private Sub btnChangePass_Click(sender As Object, e As EventArgs) Handles btnChangePass.Click
        If _selectedUserId = 0 Then Return
        If txtChangePassword.Text.Length < 6 Then
            MessageBox.Show("New password must be at least 6 characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm = MessageBox.Show(
            $"Change password for ""{_selectedUsername}""?",
            "Confirm",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        Dim hash = PasswordHelper.HashPassword(txtChangePassword.Text)
        UserRepository.UpdatePassword(_selectedUserId, hash)
        ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess,
            $"Changed password for user: {_selectedUsername}")
        txtChangePassword.Clear()
        MessageBox.Show("Password updated successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ── Delete User ───────────────────────────────────────────────────────

    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        If _selectedUserId = 0 Then Return

        Dim confirm = MessageBox.Show(
            $"Delete user ""{_selectedUsername}""? This cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)
        If confirm <> DialogResult.Yes Then Return

        UserRepository.Delete(_selectedUserId)
        ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess,
            $"Deleted user: {_selectedUsername}")
        LoadUsers()
    End Sub

    ' ── Tab 2 — System Preferences ────────────────────────────────────────

    Private Sub LoadPreferences()
        SettingsManager.Load()
        txtCompanyName.Text    = SettingsManager.CompanyName
        txtCurrencySymbol.Text = SettingsManager.CurrencySymbol
    End Sub

    Private Sub btnSavePreferences_Click(sender As Object, e As EventArgs) Handles btnSavePreferences.Click
        Dim company  = InputHelper.SanitizeInput(txtCompanyName.Text)
        Dim currency = InputHelper.SanitizeInput(txtCurrencySymbol.Text)
        If company = "" Then
            MessageBox.Show("Company name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If currency = "" Then
            MessageBox.Show("Currency symbol cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            SettingsManager.CompanyName    = company
            SettingsManager.CurrencySymbol = currency
            SettingsManager.Save()
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, "System preferences updated.")
            MessageBox.Show("Preferences saved successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Failed to save preferences: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Tab 3 — My Security Question (self-service) ──────────────────────

    Private Sub PopulateSecurityQuestionCombo()
        cboSecurityQuestion.Items.Clear()
        For Each q In Constants.SecurityQuestions
            cboSecurityQuestion.Items.Add(q)
        Next
    End Sub

    Private Sub LoadSecurityQA()
        Dim dt As DataTable = UserRepository.GetSecurityInfo(SessionManager.Username)
        If dt.Rows.Count = 0 Then Return

        Dim question = dt.Rows(0)("SecurityQuestion").ToString()
        If question <> "" Then
            lblSecurityStatus.Text = "Security question is set. Enter a new answer below to update it."
            cboSecurityQuestion.SelectedIndex = Array.IndexOf(Constants.SecurityQuestions, question)
        Else
            lblSecurityStatus.Text = "No security question set. Set one below so you can recover your password."
            cboSecurityQuestion.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnSaveSecurityQA_Click(sender As Object, e As EventArgs) Handles btnSaveSecurityQA.Click
        If cboSecurityQuestion.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a security question.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim answer  = InputHelper.SanitizeInput(txtSecurityAnswer.Text)
        Dim confirm = InputHelper.SanitizeInput(txtConfirmSecurityAnswer.Text)

        If InputHelper.IsEmpty(answer) Then
            MessageBox.Show("Answer is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If answer <> confirm Then
            MessageBox.Show("Answers do not match.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim question   = cboSecurityQuestion.SelectedItem.ToString()
        Dim answerHash = PasswordHelper.HashPassword(answer.Trim().ToLowerInvariant())

        UserRepository.UpdateSecurityQA(SessionManager.UserID, question, answerHash)
        ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, "Updated security question.")

        txtSecurityAnswer.Clear()
        txtConfirmSecurityAnswer.Clear()
        lblSecurityStatus.Text = "Security question is set. Enter a new answer below to update it."
        MessageBox.Show("Security question saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
