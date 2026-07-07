Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Select()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        HideError()

        Dim uname As String = InputHelper.SanitizeInput(txtUsername.Text)
        Dim pwd   As String = txtPassword.Text

        If InputHelper.IsEmpty(uname) OrElse InputHelper.IsEmpty(pwd) Then
            ShowError("Please enter your username and password.")
            Return
        End If

        Try
            Dim dt As DataTable = UserRepository.GetByUsername(uname)

            If dt.Rows.Count = 0 Then
                ShowError("Invalid username or password.")
                ActivityLogger.Log(uname, Constants.LogFailed, "Login failed — user not found.")
                Return
            End If

            Dim row  As DataRow = dt.Rows(0)
            Dim hash As String  = row("PasswordHash").ToString()

            If Not PasswordHelper.VerifyPassword(pwd, hash) Then
                ShowError("Invalid username or password.")
                ActivityLogger.Log(uname, Constants.LogFailed, "Login failed — wrong password.")
                Return
            End If

            SessionManager.UserID   = CInt(row("UserID"))
            SessionManager.Username = row("Username").ToString()
            SessionManager.UserType = row("UserType").ToString()

            ActivityLogger.Log(uname, Constants.LogSuccess, "User logged in successfully.")

            Dim main As New frmMain()
            AddHandler main.FormClosed, Sub(s, ev) Me.Show()
            main.Show()
            Me.Hide()

        Catch ex As Exception
            ShowError("A system error occurred. Please try again.")
        End Try
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        txtPassword.PasswordChar = If(chkShowPassword.Checked, Chr(0), "*"c)
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then btnLogin.PerformClick()
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then txtPassword.Focus()
    End Sub

    Private Sub lnkForgotPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkForgotPassword.LinkClicked
        Using frm As New frmForgotPassword()
            frm.ShowDialog()
        End Using
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
