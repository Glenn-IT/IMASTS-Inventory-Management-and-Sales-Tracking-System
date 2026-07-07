<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmForgotPassword
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlBackground   = New System.Windows.Forms.Panel()
        Me.pnlCard         = New System.Windows.Forms.Panel()
        Me.pnlHeader       = New System.Windows.Forms.Panel()
        Me.lblAppName      = New System.Windows.Forms.Label()
        Me.lblAppSub       = New System.Windows.Forms.Label()

        Me.pnlStep1        = New System.Windows.Forms.Panel()
        Me.lblStep1Hdr     = New System.Windows.Forms.Label()
        Me.txtUsername     = New System.Windows.Forms.TextBox()
        Me.btnFindUser     = New System.Windows.Forms.Button()

        Me.pnlStep2        = New System.Windows.Forms.Panel()
        Me.lblQuestionHdr  = New System.Windows.Forms.Label()
        Me.cboQuestion     = New System.Windows.Forms.ComboBox()
        Me.lblAnswerHdr    = New System.Windows.Forms.Label()
        Me.txtAnswer       = New System.Windows.Forms.TextBox()
        Me.btnVerifyAnswer = New System.Windows.Forms.Button()

        Me.pnlStep3        = New System.Windows.Forms.Panel()
        Me.lblNewPassHdr   = New System.Windows.Forms.Label()
        Me.txtNewPassword  = New System.Windows.Forms.TextBox()
        Me.lblConfirmHdr   = New System.Windows.Forms.Label()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.btnResetPassword = New System.Windows.Forms.Button()

        Me.lblError        = New System.Windows.Forms.Label()
        Me.lnkBackToLogin  = New System.Windows.Forms.LinkLabel()

        Me.pnlBackground.SuspendLayout()
        Me.pnlCard.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlStep1.SuspendLayout()
        Me.pnlStep2.SuspendLayout()
        Me.pnlStep3.SuspendLayout()
        Me.SuspendLayout()

        ' ── pnlBackground ────────────────────────────────────────────
        Me.pnlBackground.BackColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.pnlBackground.Controls.Add(Me.pnlCard)
        Me.pnlBackground.Dock      = System.Windows.Forms.DockStyle.Fill
        Me.pnlBackground.Name      = "pnlBackground"

        ' ── pnlCard ──────────────────────────────────────────────────
        Me.pnlCard.BackColor = System.Drawing.Color.White
        Me.pnlCard.Controls.Add(Me.pnlHeader)
        Me.pnlCard.Controls.Add(Me.pnlStep1)
        Me.pnlCard.Controls.Add(Me.pnlStep2)
        Me.pnlCard.Controls.Add(Me.pnlStep3)
        Me.pnlCard.Controls.Add(Me.lblError)
        Me.pnlCard.Controls.Add(Me.lnkBackToLogin)
        Me.pnlCard.Location  = New System.Drawing.Point(40, 40)
        Me.pnlCard.Name      = "pnlCard"
        Me.pnlCard.Size      = New System.Drawing.Size(380, 470)

        ' ── pnlHeader ────────────────────────────────────────────────
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(28, 43, 74)
        Me.pnlHeader.Controls.Add(Me.lblAppName)
        Me.pnlHeader.Controls.Add(Me.lblAppSub)
        Me.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Height    = 96
        Me.pnlHeader.Name      = "pnlHeader"

        Me.lblAppName.AutoSize  = False
        Me.lblAppName.BackColor = System.Drawing.Color.Transparent
        Me.lblAppName.Font      = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblAppName.ForeColor = System.Drawing.Color.White
        Me.lblAppName.Location  = New System.Drawing.Point(0, 14)
        Me.lblAppName.Name      = "lblAppName"
        Me.lblAppName.Size      = New System.Drawing.Size(380, 34)
        Me.lblAppName.Text      = "Forgot Password"
        Me.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        Me.lblAppSub.AutoSize  = False
        Me.lblAppSub.BackColor = System.Drawing.Color.Transparent
        Me.lblAppSub.Font      = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblAppSub.ForeColor = System.Drawing.Color.FromArgb(160, 195, 225)
        Me.lblAppSub.Location  = New System.Drawing.Point(10, 52)
        Me.lblAppSub.Name      = "lblAppSub"
        Me.lblAppSub.Size      = New System.Drawing.Size(360, 26)
        Me.lblAppSub.Text      = "Reset your password using your security question"
        Me.lblAppSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' ── pnlStep1 — enter username ─────────────────────────────────
        Me.pnlStep1.Location = New System.Drawing.Point(0, 106)
        Me.pnlStep1.Name     = "pnlStep1"
        Me.pnlStep1.Size     = New System.Drawing.Size(380, 140)
        Me.pnlStep1.Controls.Add(Me.lblStep1Hdr)
        Me.pnlStep1.Controls.Add(Me.txtUsername)
        Me.pnlStep1.Controls.Add(Me.btnFindUser)

        Me.lblStep1Hdr.AutoSize  = True
        Me.lblStep1Hdr.Font      = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblStep1Hdr.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100)
        Me.lblStep1Hdr.Location  = New System.Drawing.Point(30, 6)
        Me.lblStep1Hdr.Name      = "lblStep1Hdr"
        Me.lblStep1Hdr.Text      = "USERNAME"

        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font        = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtUsername.Location    = New System.Drawing.Point(30, 26)
        Me.txtUsername.MaxLength   = 50
        Me.txtUsername.Name        = "txtUsername"
        Me.txtUsername.Size        = New System.Drawing.Size(320, 36)

        Me.btnFindUser.BackColor = System.Drawing.Color.FromArgb(41, 128, 185)
        Me.btnFindUser.Cursor    = System.Windows.Forms.Cursors.Hand
        Me.btnFindUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindUser.FlatAppearance.BorderSize = 0
        Me.btnFindUser.Font      = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnFindUser.ForeColor = System.Drawing.Color.White
        Me.btnFindUser.Location  = New System.Drawing.Point(30, 74)
        Me.btnFindUser.Name      = "btnFindUser"
        Me.btnFindUser.Size      = New System.Drawing.Size(320, 42)
        Me.btnFindUser.Text      = "NEXT"

        ' ── pnlStep2 — answer security question ───────────────────────
        Me.pnlStep2.Location = New System.Drawing.Point(0, 106)
        Me.pnlStep2.Name     = "pnlStep2"
        Me.pnlStep2.Size     = New System.Drawing.Size(380, 200)
        Me.pnlStep2.Visible  = False
        Me.pnlStep2.Controls.Add(Me.lblQuestionHdr)
        Me.pnlStep2.Controls.Add(Me.cboQuestion)
        Me.pnlStep2.Controls.Add(Me.lblAnswerHdr)
        Me.pnlStep2.Controls.Add(Me.txtAnswer)
        Me.pnlStep2.Controls.Add(Me.btnVerifyAnswer)

        Me.lblQuestionHdr.AutoSize  = True
        Me.lblQuestionHdr.Font      = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblQuestionHdr.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100)
        Me.lblQuestionHdr.Location  = New System.Drawing.Point(30, 6)
        Me.lblQuestionHdr.Name      = "lblQuestionHdr"
        Me.lblQuestionHdr.Text      = "SELECT YOUR SECURITY QUESTION"

        Me.cboQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboQuestion.Font          = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboQuestion.Location      = New System.Drawing.Point(30, 26)
        Me.cboQuestion.Name          = "cboQuestion"
        Me.cboQuestion.Size          = New System.Drawing.Size(320, 28)

        Me.lblAnswerHdr.AutoSize  = True
        Me.lblAnswerHdr.Font      = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblAnswerHdr.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100)
        Me.lblAnswerHdr.Location  = New System.Drawing.Point(30, 62)
        Me.lblAnswerHdr.Name      = "lblAnswerHdr"
        Me.lblAnswerHdr.Text      = "ANSWER"

        Me.txtAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnswer.Font        = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtAnswer.Location    = New System.Drawing.Point(30, 82)
        Me.txtAnswer.MaxLength   = 255
        Me.txtAnswer.Name        = "txtAnswer"
        Me.txtAnswer.Size        = New System.Drawing.Size(320, 36)

        Me.btnVerifyAnswer.BackColor = System.Drawing.Color.FromArgb(41, 128, 185)
        Me.btnVerifyAnswer.Cursor    = System.Windows.Forms.Cursors.Hand
        Me.btnVerifyAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerifyAnswer.FlatAppearance.BorderSize = 0
        Me.btnVerifyAnswer.Font      = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnVerifyAnswer.ForeColor = System.Drawing.Color.White
        Me.btnVerifyAnswer.Location  = New System.Drawing.Point(30, 130)
        Me.btnVerifyAnswer.Name      = "btnVerifyAnswer"
        Me.btnVerifyAnswer.Size      = New System.Drawing.Size(320, 42)
        Me.btnVerifyAnswer.Text      = "VERIFY ANSWER"

        ' ── pnlStep3 — set new password ────────────────────────────────
        Me.pnlStep3.Location = New System.Drawing.Point(0, 106)
        Me.pnlStep3.Name     = "pnlStep3"
        Me.pnlStep3.Size     = New System.Drawing.Size(380, 240)
        Me.pnlStep3.Visible  = False
        Me.pnlStep3.Controls.Add(Me.lblNewPassHdr)
        Me.pnlStep3.Controls.Add(Me.txtNewPassword)
        Me.pnlStep3.Controls.Add(Me.lblConfirmHdr)
        Me.pnlStep3.Controls.Add(Me.txtConfirmPassword)
        Me.pnlStep3.Controls.Add(Me.btnResetPassword)

        Me.lblNewPassHdr.AutoSize  = True
        Me.lblNewPassHdr.Font      = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblNewPassHdr.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100)
        Me.lblNewPassHdr.Location  = New System.Drawing.Point(30, 6)
        Me.lblNewPassHdr.Name      = "lblNewPassHdr"
        Me.lblNewPassHdr.Text      = "NEW PASSWORD (min 6 chars)"

        Me.txtNewPassword.BorderStyle  = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewPassword.Font         = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtNewPassword.Location     = New System.Drawing.Point(30, 26)
        Me.txtNewPassword.MaxLength    = 100
        Me.txtNewPassword.Name         = "txtNewPassword"
        Me.txtNewPassword.PasswordChar = "*"c
        Me.txtNewPassword.Size         = New System.Drawing.Size(320, 36)

        Me.lblConfirmHdr.AutoSize  = True
        Me.lblConfirmHdr.Font      = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblConfirmHdr.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100)
        Me.lblConfirmHdr.Location  = New System.Drawing.Point(30, 74)
        Me.lblConfirmHdr.Name      = "lblConfirmHdr"
        Me.lblConfirmHdr.Text      = "CONFIRM PASSWORD"

        Me.txtConfirmPassword.BorderStyle  = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConfirmPassword.Font         = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtConfirmPassword.Location     = New System.Drawing.Point(30, 94)
        Me.txtConfirmPassword.MaxLength    = 100
        Me.txtConfirmPassword.Name         = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = "*"c
        Me.txtConfirmPassword.Size         = New System.Drawing.Size(320, 36)

        Me.btnResetPassword.BackColor = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.btnResetPassword.Cursor    = System.Windows.Forms.Cursors.Hand
        Me.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetPassword.FlatAppearance.BorderSize = 0
        Me.btnResetPassword.Font      = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnResetPassword.ForeColor = System.Drawing.Color.White
        Me.btnResetPassword.Location  = New System.Drawing.Point(30, 142)
        Me.btnResetPassword.Name      = "btnResetPassword"
        Me.btnResetPassword.Size      = New System.Drawing.Size(320, 42)
        Me.btnResetPassword.Text      = "RESET PASSWORD"

        ' ── lblError ─────────────────────────────────────────────────
        Me.lblError.AutoSize  = False
        Me.lblError.Font      = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblError.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43)
        Me.lblError.Location  = New System.Drawing.Point(30, 350)
        Me.lblError.Name      = "lblError"
        Me.lblError.Size      = New System.Drawing.Size(320, 60)
        Me.lblError.Text      = String.Empty
        Me.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblError.Visible   = False

        ' ── lnkBackToLogin ──────────────────────────────────────────
        Me.lnkBackToLogin.AutoSize  = True
        Me.lnkBackToLogin.Font      = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lnkBackToLogin.LinkColor = System.Drawing.Color.FromArgb(41, 128, 185)
        Me.lnkBackToLogin.Location  = New System.Drawing.Point(30, 432)
        Me.lnkBackToLogin.Name      = "lnkBackToLogin"
        Me.lnkBackToLogin.Text      = "Back to Login"

        ' ── frmForgotPassword ──────────────────────────────────────────
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor           = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.ClientSize          = New System.Drawing.Size(460, 550)
        Me.Controls.Add(Me.pnlBackground)
        Me.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox         = False
        Me.MinimizeBox         = False
        Me.Name                = "frmForgotPassword"
        Me.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text                = "IMASTS — Forgot Password"

        Me.pnlHeader.ResumeLayout(False)
        Me.pnlStep1.ResumeLayout(False)
        Me.pnlStep1.PerformLayout()
        Me.pnlStep2.ResumeLayout(False)
        Me.pnlStep2.PerformLayout()
        Me.pnlStep3.ResumeLayout(False)
        Me.pnlStep3.PerformLayout()
        Me.pnlCard.ResumeLayout(False)
        Me.pnlCard.PerformLayout()
        Me.pnlBackground.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents pnlBackground   As System.Windows.Forms.Panel
    Friend WithEvents pnlCard         As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader       As System.Windows.Forms.Panel
    Friend WithEvents lblAppName      As System.Windows.Forms.Label
    Friend WithEvents lblAppSub       As System.Windows.Forms.Label

    Friend WithEvents pnlStep1        As System.Windows.Forms.Panel
    Friend WithEvents lblStep1Hdr     As System.Windows.Forms.Label
    Friend WithEvents txtUsername     As System.Windows.Forms.TextBox
    Friend WithEvents btnFindUser     As System.Windows.Forms.Button

    Friend WithEvents pnlStep2        As System.Windows.Forms.Panel
    Friend WithEvents lblQuestionHdr  As System.Windows.Forms.Label
    Friend WithEvents cboQuestion     As System.Windows.Forms.ComboBox
    Friend WithEvents lblAnswerHdr    As System.Windows.Forms.Label
    Friend WithEvents txtAnswer       As System.Windows.Forms.TextBox
    Friend WithEvents btnVerifyAnswer As System.Windows.Forms.Button

    Friend WithEvents pnlStep3        As System.Windows.Forms.Panel
    Friend WithEvents lblNewPassHdr   As System.Windows.Forms.Label
    Friend WithEvents txtNewPassword  As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmHdr   As System.Windows.Forms.Label
    Friend WithEvents txtConfirmPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnResetPassword As System.Windows.Forms.Button

    Friend WithEvents lblError        As System.Windows.Forms.Label
    Friend WithEvents lnkBackToLogin  As System.Windows.Forms.LinkLabel

End Class
