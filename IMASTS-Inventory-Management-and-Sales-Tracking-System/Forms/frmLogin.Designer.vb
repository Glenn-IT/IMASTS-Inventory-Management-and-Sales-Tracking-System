<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
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
        Me.pnlBackground  = New System.Windows.Forms.Panel()
        Me.pnlCard        = New System.Windows.Forms.Panel()
        Me.pnlHeader      = New System.Windows.Forms.Panel()
        Me.lblAppName     = New System.Windows.Forms.Label()
        Me.lblAppSub      = New System.Windows.Forms.Label()
        Me.lblUsernameHdr = New System.Windows.Forms.Label()
        Me.txtUsername    = New System.Windows.Forms.TextBox()
        Me.lblPasswordHdr = New System.Windows.Forms.Label()
        Me.txtPassword    = New System.Windows.Forms.TextBox()
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        Me.btnLogin       = New System.Windows.Forms.Button()
        Me.lblError       = New System.Windows.Forms.Label()
        Me.pnlBackground.SuspendLayout()
        Me.pnlCard.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()

        ' ── pnlBackground ────────────────────────────────────────────
        Me.pnlBackground.BackColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.pnlBackground.Controls.Add(Me.pnlCard)
        Me.pnlBackground.Dock      = System.Windows.Forms.DockStyle.Fill
        Me.pnlBackground.Name      = "pnlBackground"

        ' ── pnlCard ──────────────────────────────────────────────────
        Me.pnlCard.BackColor = System.Drawing.Color.White
        Me.pnlCard.Controls.Add(Me.pnlHeader)
        Me.pnlCard.Controls.Add(Me.lblUsernameHdr)
        Me.pnlCard.Controls.Add(Me.txtUsername)
        Me.pnlCard.Controls.Add(Me.lblPasswordHdr)
        Me.pnlCard.Controls.Add(Me.txtPassword)
        Me.pnlCard.Controls.Add(Me.chkShowPassword)
        Me.pnlCard.Controls.Add(Me.btnLogin)
        Me.pnlCard.Controls.Add(Me.lblError)
        Me.pnlCard.Location  = New System.Drawing.Point(40, 50)
        Me.pnlCard.Name      = "pnlCard"
        Me.pnlCard.Size      = New System.Drawing.Size(380, 450)

        ' ── pnlHeader ────────────────────────────────────────────────
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(28, 43, 74)
        Me.pnlHeader.Controls.Add(Me.lblAppName)
        Me.pnlHeader.Controls.Add(Me.lblAppSub)
        Me.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Height    = 112
        Me.pnlHeader.Name      = "pnlHeader"

        ' ── lblAppName ───────────────────────────────────────────────
        Me.lblAppName.AutoSize  = False
        Me.lblAppName.BackColor = System.Drawing.Color.Transparent
        Me.lblAppName.Dock      = System.Windows.Forms.DockStyle.None
        Me.lblAppName.Font      = New System.Drawing.Font("Segoe UI", 26.0!, System.Drawing.FontStyle.Bold)
        Me.lblAppName.ForeColor = System.Drawing.Color.White
        Me.lblAppName.Location  = New System.Drawing.Point(0, 18)
        Me.lblAppName.Name      = "lblAppName"
        Me.lblAppName.Size      = New System.Drawing.Size(380, 48)
        Me.lblAppName.Text      = "IMASTS"
        Me.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' ── lblAppSub ────────────────────────────────────────────────
        Me.lblAppSub.AutoSize  = False
        Me.lblAppSub.BackColor = System.Drawing.Color.Transparent
        Me.lblAppSub.Font      = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblAppSub.ForeColor = System.Drawing.Color.FromArgb(160, 195, 225)
        Me.lblAppSub.Location  = New System.Drawing.Point(10, 72)
        Me.lblAppSub.Name      = "lblAppSub"
        Me.lblAppSub.Size      = New System.Drawing.Size(360, 28)
        Me.lblAppSub.Text      = "Inventory Management && Sales Tracking System"
        Me.lblAppSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' ── lblUsernameHdr ───────────────────────────────────────────
        Me.lblUsernameHdr.AutoSize  = True
        Me.lblUsernameHdr.Font      = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsernameHdr.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100)
        Me.lblUsernameHdr.Location  = New System.Drawing.Point(30, 130)
        Me.lblUsernameHdr.Name      = "lblUsernameHdr"
        Me.lblUsernameHdr.Text      = "USERNAME"

        ' ── txtUsername ──────────────────────────────────────────────
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font        = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtUsername.Location    = New System.Drawing.Point(30, 150)
        Me.txtUsername.Name        = "txtUsername"
        Me.txtUsername.Size        = New System.Drawing.Size(320, 36)
        Me.txtUsername.MaxLength   = 50

        ' ── lblPasswordHdr ───────────────────────────────────────────
        Me.lblPasswordHdr.AutoSize  = True
        Me.lblPasswordHdr.Font      = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPasswordHdr.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100)
        Me.lblPasswordHdr.Location  = New System.Drawing.Point(30, 205)
        Me.lblPasswordHdr.Name      = "lblPasswordHdr"
        Me.lblPasswordHdr.Text      = "PASSWORD"

        ' ── txtPassword ──────────────────────────────────────────────
        Me.txtPassword.BorderStyle  = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font         = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.txtPassword.Location     = New System.Drawing.Point(30, 225)
        Me.txtPassword.Name         = "txtPassword"
        Me.txtPassword.PasswordChar = "*"c
        Me.txtPassword.Size         = New System.Drawing.Size(320, 36)
        Me.txtPassword.MaxLength    = 100

        ' ── chkShowPassword ──────────────────────────────────────────
        Me.chkShowPassword.AutoSize  = True
        Me.chkShowPassword.Font      = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100)
        Me.chkShowPassword.Location  = New System.Drawing.Point(30, 272)
        Me.chkShowPassword.Name      = "chkShowPassword"
        Me.chkShowPassword.Text      = "Show Password"

        ' ── btnLogin ─────────────────────────────────────────────────
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(41, 128, 185)
        Me.btnLogin.Cursor    = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.Font      = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location  = New System.Drawing.Point(30, 310)
        Me.btnLogin.Name      = "btnLogin"
        Me.btnLogin.Size      = New System.Drawing.Size(320, 42)
        Me.btnLogin.Text      = "LOG IN"

        ' ── lblError ─────────────────────────────────────────────────
        Me.lblError.AutoSize  = False
        Me.lblError.Font      = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblError.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43)
        Me.lblError.Location  = New System.Drawing.Point(30, 362)
        Me.lblError.Name      = "lblError"
        Me.lblError.Size      = New System.Drawing.Size(320, 52)
        Me.lblError.Text      = String.Empty
        Me.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblError.Visible   = False

        ' ── frmLogin ─────────────────────────────────────────────────
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor           = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.ClientSize          = New System.Drawing.Size(460, 550)
        Me.Controls.Add(Me.pnlBackground)
        Me.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox         = False
        Me.Name                = "frmLogin"
        Me.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text                = "IMASTS — Login"

        Me.pnlHeader.ResumeLayout(False)
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
    Friend WithEvents lblUsernameHdr  As System.Windows.Forms.Label
    Friend WithEvents txtUsername     As System.Windows.Forms.TextBox
    Friend WithEvents lblPasswordHdr  As System.Windows.Forms.Label
    Friend WithEvents txtPassword     As System.Windows.Forms.TextBox
    Friend WithEvents chkShowPassword As System.Windows.Forms.CheckBox
    Friend WithEvents btnLogin        As System.Windows.Forms.Button
    Friend WithEvents lblError        As System.Windows.Forms.Label

End Class
