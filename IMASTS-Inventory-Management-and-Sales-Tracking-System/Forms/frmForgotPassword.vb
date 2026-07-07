Public Class frmForgotPassword

    Private _userId          As Integer = 0
    Private _username        As String  = ""
    Private _question        As String  = ""
    Private _answerHash      As String  = ""

    Private Sub frmForgotPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateQuestionCombo()
        ShowStep1()
        txtUsername.Select()
    End Sub

    Private Sub PopulateQuestionCombo()
        cboQuestion.Items.Clear()
        For Each q In Constants.SecurityQuestions
            cboQuestion.Items.Add(q)
        Next
    End Sub

    ' ── Step 1: look up the account's security question ──────────────────

    Private Sub btnFindUser_Click(sender As Object, e As EventArgs) Handles btnFindUser.Click
        HideError()

        Dim uname As String = InputHelper.SanitizeInput(txtUsername.Text)
        If InputHelper.IsEmpty(uname) Then
            ShowError("Please enter your username.")
            Return
        End If

        Try
            Dim dt As DataTable = UserRepository.GetSecurityInfo(uname)

            If dt.Rows.Count = 0 Then
                ShowError("Invalid username or password.")
                Return
            End If

            Dim row As DataRow = dt.Rows(0)
            Dim question As String = row("SecurityQuestion").ToString()
            Dim hash     As String = row("SecurityAnswerHash").ToString()

            If InputHelper.IsEmpty(question) OrElse InputHelper.IsEmpty(hash) Then
                ShowError("No security question is set for this account. Please contact an administrator.")
                Return
            End If

            _userId     = CInt(row("UserID"))
            _username   = row("Username").ToString()
            _question   = question
            _answerHash = hash

            cboQuestion.SelectedIndex = -1
            txtAnswer.Clear()
            ShowStep2()
            cboQuestion.Select()

        Catch ex As Exception
            ShowError("A system error occurred. Please try again.")
        End Try
    End Sub

    ' ── Step 2: verify the security answer ────────────────────────────────

    Private Sub btnVerifyAnswer_Click(sender As Object, e As EventArgs) Handles btnVerifyAnswer.Click
        HideError()

        If cboQuestion.SelectedItem Is Nothing Then
            ShowError("Please select your security question.")
            Return
        End If

        Dim answer As String = InputHelper.SanitizeInput(txtAnswer.Text)
        If InputHelper.IsEmpty(answer) Then
            ShowError("Please enter your answer.")
            Return
        End If

        Dim selectedQuestion As String = cboQuestion.SelectedItem.ToString()
        Dim normalized       As String = answer.Trim().ToLowerInvariant()

        If selectedQuestion <> _question OrElse Not PasswordHelper.VerifyPassword(normalized, _answerHash) Then
            ShowError("Incorrect question or answer. Please try again.")
            ActivityLogger.Log(_username, Constants.LogFailed, "Forgot password — wrong security question/answer.")
            Return
        End If

        ShowStep3()
        txtNewPassword.Select()
    End Sub

    ' ── Step 3: reset the password ────────────────────────────────────────

    Private Sub btnResetPassword_Click(sender As Object, e As EventArgs) Handles btnResetPassword.Click
        HideError()

        If txtNewPassword.Text.Length < 6 Then
            ShowError("New password must be at least 6 characters.")
            Return
        End If

        If txtNewPassword.Text <> txtConfirmPassword.Text Then
            ShowError("Passwords do not match.")
            Return
        End If

        Try
            Dim hash = PasswordHelper.HashPassword(txtNewPassword.Text)
            UserRepository.UpdatePassword(_userId, hash)
            ActivityLogger.Log(_username, Constants.LogSuccess, "Password reset via security question.")

            MessageBox.Show("Your password has been reset. You can now log in.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            ShowError("A system error occurred. Please try again.")
        End Try
    End Sub

    ' ── Navigation ─────────────────────────────────────────────────────────

    Private Sub lnkBackToLogin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkBackToLogin.LinkClicked
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ShowStep1()
        pnlStep1.Visible = True
        pnlStep2.Visible = False
        pnlStep3.Visible = False
    End Sub

    Private Sub ShowStep2()
        pnlStep1.Visible = False
        pnlStep2.Visible = True
        pnlStep3.Visible = False
    End Sub

    Private Sub ShowStep3()
        pnlStep1.Visible = False
        pnlStep2.Visible = False
        pnlStep3.Visible = True
    End Sub

    Private Sub ShowError(msg As String)
        lblError.Text    = msg
        lblError.Visible = True
    End Sub

    Private Sub HideError()
        lblError.Text    = String.Empty
        lblError.Visible = False
    End Sub

End Class
