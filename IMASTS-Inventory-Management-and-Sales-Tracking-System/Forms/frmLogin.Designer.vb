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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        pnlBackground = New Panel()
        pnlCard = New Panel()
        pnlHeader = New Panel()
        lblUsernameHdr = New Label()
        txtUsername = New TextBox()
        lblPasswordHdr = New Label()
        txtPassword = New TextBox()
        chkShowPassword = New CheckBox()
        btnLogin = New Button()
        lblError = New Label()
        lnkForgotPassword = New LinkLabel()
        tmrLockout = New Timer(components)
        PictureBox1 = New PictureBox()
        pnlBackground.SuspendLayout()
        pnlCard.SuspendLayout()
        pnlHeader.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlBackground
        ' 
        pnlBackground.BackColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        pnlBackground.Controls.Add(pnlCard)
        pnlBackground.Dock = DockStyle.Fill
        pnlBackground.Location = New Point(0, 0)
        pnlBackground.Name = "pnlBackground"
        pnlBackground.Size = New Size(460, 684)
        pnlBackground.TabIndex = 0
        ' 
        ' pnlCard
        ' 
        pnlCard.BackColor = Color.White
        pnlCard.Controls.Add(pnlHeader)
        pnlCard.Controls.Add(lblUsernameHdr)
        pnlCard.Controls.Add(txtUsername)
        pnlCard.Controls.Add(lblPasswordHdr)
        pnlCard.Controls.Add(txtPassword)
        pnlCard.Controls.Add(chkShowPassword)
        pnlCard.Controls.Add(btnLogin)
        pnlCard.Controls.Add(lblError)
        pnlCard.Controls.Add(lnkForgotPassword)
        pnlCard.Location = New Point(40, 57)
        pnlCard.Name = "pnlCard"
        pnlCard.Size = New Size(380, 588)
        pnlCard.TabIndex = 0
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(28), CByte(43), CByte(74))
        pnlHeader.Controls.Add(PictureBox1)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(380, 216)
        pnlHeader.TabIndex = 0
        ' 
        ' lblUsernameHdr
        ' 
        lblUsernameHdr.AutoSize = True
        lblUsernameHdr.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblUsernameHdr.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        lblUsernameHdr.Location = New Point(30, 242)
        lblUsernameHdr.Name = "lblUsernameHdr"
        lblUsernameHdr.Size = New Size(71, 15)
        lblUsernameHdr.TabIndex = 1
        lblUsernameHdr.Text = "USERNAME"
        ' 
        ' txtUsername
        ' 
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        txtUsername.Font = New Font("Segoe UI", 10.5F)
        txtUsername.Location = New Point(30, 265)
        txtUsername.MaxLength = 50
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(320, 28)
        txtUsername.TabIndex = 2
        ' 
        ' lblPasswordHdr
        ' 
        lblPasswordHdr.AutoSize = True
        lblPasswordHdr.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
        lblPasswordHdr.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        lblPasswordHdr.Location = New Point(30, 327)
        lblPasswordHdr.Name = "lblPasswordHdr"
        lblPasswordHdr.Size = New Size(73, 15)
        lblPasswordHdr.TabIndex = 3
        lblPasswordHdr.Text = "PASSWORD"
        ' 
        ' txtPassword
        ' 
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.Font = New Font("Segoe UI", 10.5F)
        txtPassword.Location = New Point(30, 350)
        txtPassword.MaxLength = 100
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(320, 28)
        txtPassword.TabIndex = 4
        ' 
        ' chkShowPassword
        ' 
        chkShowPassword.AutoSize = True
        chkShowPassword.Font = New Font("Segoe UI", 9F)
        chkShowPassword.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        chkShowPassword.Location = New Point(30, 403)
        chkShowPassword.Name = "chkShowPassword"
        chkShowPassword.Size = New Size(123, 23)
        chkShowPassword.TabIndex = 5
        chkShowPassword.Text = "Show Password"
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        btnLogin.Cursor = Cursors.Hand
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(30, 446)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(320, 48)
        btnLogin.TabIndex = 6
        btnLogin.Text = "LOG IN"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' lblError
        ' 
        lblError.Font = New Font("Segoe UI", 9F)
        lblError.ForeColor = Color.FromArgb(CByte(192), CByte(57), CByte(43))
        lblError.Location = New Point(30, 505)
        lblError.Name = "lblError"
        lblError.Size = New Size(320, 34)
        lblError.TabIndex = 7
        lblError.TextAlign = ContentAlignment.MiddleCenter
        lblError.Visible = False
        ' 
        ' lnkForgotPassword
        ' 
        lnkForgotPassword.Font = New Font("Segoe UI", 9F)
        lnkForgotPassword.LinkColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        lnkForgotPassword.Location = New Point(30, 544)
        lnkForgotPassword.Name = "lnkForgotPassword"
        lnkForgotPassword.Size = New Size(320, 23)
        lnkForgotPassword.TabIndex = 8
        lnkForgotPassword.TabStop = True
        lnkForgotPassword.Text = "Forgot Password?"
        lnkForgotPassword.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' tmrLockout
        ' 
        tmrLockout.Interval = 1000
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Dock = DockStyle.Fill
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(380, 216)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        ClientSize = New Size(460, 684)
        Controls.Add(pnlBackground)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "frmLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "IMASTS — Login"
        pnlBackground.ResumeLayout(False)
        pnlCard.ResumeLayout(False)
        pnlCard.PerformLayout()
        pnlHeader.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlBackground   As System.Windows.Forms.Panel
    Friend WithEvents pnlCard         As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader       As System.Windows.Forms.Panel
    Friend WithEvents lblUsernameHdr  As System.Windows.Forms.Label
    Friend WithEvents txtUsername     As System.Windows.Forms.TextBox
    Friend WithEvents lblPasswordHdr  As System.Windows.Forms.Label
    Friend WithEvents txtPassword     As System.Windows.Forms.TextBox
    Friend WithEvents chkShowPassword As System.Windows.Forms.CheckBox
    Friend WithEvents btnLogin        As System.Windows.Forms.Button
    Friend WithEvents lblError        As System.Windows.Forms.Label
    Friend WithEvents lnkForgotPassword As System.Windows.Forms.LinkLabel
    Friend WithEvents tmrLockout As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As PictureBox

End Class
