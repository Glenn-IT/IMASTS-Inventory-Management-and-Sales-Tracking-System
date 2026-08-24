<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSettings
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
        lblPageHeader            = New Label()
        tabControl               = New TabControl()
        tabUsers                 = New TabPage()
        dgvUsers                 = New DataGridView()
        pnlAddUser               = New Panel()
        lblAddTitle              = New Label()
        lblNewUsername           = New Label()
        txtNewUsername           = New TextBox()
        lblNewPassword           = New Label()
        txtNewPassword           = New TextBox()
        lblNewType               = New Label()
        cboNewUserType           = New ComboBox()
        btnAddUser               = New Button()
        pnlChangePass            = New Panel()
        lblChangeTitle           = New Label()
        lblSelectedUser          = New Label()
        lblChangePass            = New Label()
        txtChangePassword        = New TextBox()
        btnChangePass            = New Button()
        btnDeleteUser            = New Button()
        tabSecurity              = New TabPage()
        lblSecurityTitle         = New Label()
        lblSecurityStatus        = New Label()
        lblSecurityQuestion      = New Label()
        cboSecurityQuestion      = New ComboBox()
        lblSecurityAnswer        = New Label()
        txtSecurityAnswer        = New TextBox()
        lblConfirmSecurityAnswer = New Label()
        txtConfirmSecurityAnswer = New TextBox()
        btnSaveSecurityQA        = New Button()
        Panel1                   = New Panel()
        Panel2                   = New Panel()
        tabControl.SuspendLayout()
        tabUsers.SuspendLayout()
        tabSecurity.SuspendLayout()
        pnlAddUser.SuspendLayout()
        pnlChangePass.SuspendLayout()
        CType(dgvUsers, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()

        Dim lblFont  As New Font("Segoe UI", 9F)
        Dim lblColor As Color = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        Dim txtFont  As New Font("Segoe UI", 10F)
        '
        ' lblPageHeader
        '
        lblPageHeader.Font      = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblPageHeader.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        lblPageHeader.Location  = New Point(12, 20)
        lblPageHeader.Name      = "lblPageHeader"
        lblPageHeader.Size      = New Size(300, 41)
        lblPageHeader.TabIndex  = 0
        lblPageHeader.Text      = "Settings"
        '
        ' tabControl (Dock=Fill inside Panel2)
        '
        tabControl.Dock     = DockStyle.Fill
        tabControl.Font     = New Font("Segoe UI", 9.5F)
        tabControl.Location = New Point(0, 0)
        tabControl.Name     = "tabControl"
        tabControl.TabIndex = 0
        tabControl.TabPages.Add(tabUsers)
        tabControl.TabPages.Add(tabSecurity)
        '
        ' tabUsers — User Management
        '
        tabUsers.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        tabUsers.Name      = "tabUsers"
        tabUsers.Text      = "  User Management  "

        dgvUsers.AllowUserToAddRows         = False
        dgvUsers.AllowUserToDeleteRows      = False
        dgvUsers.Anchor                     = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        dgvUsers.BackgroundColor            = Color.White
        dgvUsers.BorderStyle                = BorderStyle.None
        dgvUsers.ColumnHeadersHeight        = 36
        dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvUsers.Font                       = New Font("Segoe UI", 9.5F)
        dgvUsers.GridColor                  = Color.FromArgb(CByte(220), CByte(223), CByte(228))
        dgvUsers.Location                   = New Point(12, 12)
        dgvUsers.MultiSelect                = False
        dgvUsers.Name                       = "dgvUsers"
        dgvUsers.ReadOnly                   = True
        dgvUsers.RowHeadersVisible          = False
        dgvUsers.RowHeadersWidth            = 45
        dgvUsers.RowTemplate.Height         = 32
        dgvUsers.SelectionMode              = DataGridViewSelectionMode.FullRowSelect
        dgvUsers.Size                       = New Size(880, 190)
        dgvUsers.TabIndex                   = 0
        '
        ' pnlAddUser
        '
        pnlAddUser.BackColor = Color.White
        pnlAddUser.Location  = New Point(12, 214)
        pnlAddUser.Name      = "pnlAddUser"
        pnlAddUser.Size      = New Size(420, 254)
        pnlAddUser.TabIndex  = 1

        lblAddTitle.Font      = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblAddTitle.ForeColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        lblAddTitle.Location  = New Point(14, 10)
        lblAddTitle.Name      = "lblAddTitle"
        lblAddTitle.Size      = New Size(200, 22)
        lblAddTitle.TabIndex  = 0
        lblAddTitle.Text      = "Add New User"

        lblNewUsername.Font      = lblFont
        lblNewUsername.ForeColor = lblColor
        lblNewUsername.Location  = New Point(14, 42)
        lblNewUsername.Name      = "lblNewUsername"
        lblNewUsername.Size      = New Size(160, 20)
        lblNewUsername.TabIndex  = 1
        lblNewUsername.Text      = "Username *"

        txtNewUsername.Font      = txtFont
        txtNewUsername.Location  = New Point(14, 64)
        txtNewUsername.MaxLength = 50
        txtNewUsername.Name      = "txtNewUsername"
        txtNewUsername.Size      = New Size(392, 27)
        txtNewUsername.TabIndex  = 2

        lblNewPassword.Font      = lblFont
        lblNewPassword.ForeColor = lblColor
        lblNewPassword.Location  = New Point(14, 102)
        lblNewPassword.Name      = "lblNewPassword"
        lblNewPassword.Size      = New Size(200, 20)
        lblNewPassword.TabIndex  = 3
        lblNewPassword.Text      = "Password * (min 6 chars)"

        txtNewPassword.Font         = txtFont
        txtNewPassword.Location     = New Point(14, 124)
        txtNewPassword.MaxLength    = 100
        txtNewPassword.Name         = "txtNewPassword"
        txtNewPassword.PasswordChar = "*"c
        txtNewPassword.Size         = New Size(392, 27)
        txtNewPassword.TabIndex     = 4

        lblNewType.Font      = lblFont
        lblNewType.ForeColor = lblColor
        lblNewType.Location  = New Point(14, 162)
        lblNewType.Name      = "lblNewType"
        lblNewType.Size      = New Size(120, 20)
        lblNewType.TabIndex  = 5
        lblNewType.Text      = "Role *"

        cboNewUserType.DropDownStyle = ComboBoxStyle.DropDownList
        cboNewUserType.Font          = txtFont
        cboNewUserType.Location      = New Point(14, 184)
        cboNewUserType.Name          = "cboNewUserType"
        cboNewUserType.Size          = New Size(392, 28)
        cboNewUserType.TabIndex      = 6

        btnAddUser.BackColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        btnAddUser.Cursor    = Cursors.Hand
        btnAddUser.FlatAppearance.BorderSize = 0
        btnAddUser.FlatStyle = FlatStyle.Flat
        btnAddUser.Font      = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnAddUser.ForeColor = Color.White
        btnAddUser.Location  = New Point(14, 220)
        btnAddUser.Name      = "btnAddUser"
        btnAddUser.Size      = New Size(120, 30)
        btnAddUser.TabIndex  = 7
        btnAddUser.Text      = "Add User"
        btnAddUser.UseVisualStyleBackColor = False

        pnlAddUser.Controls.Add(lblAddTitle)
        pnlAddUser.Controls.Add(lblNewUsername)
        pnlAddUser.Controls.Add(txtNewUsername)
        pnlAddUser.Controls.Add(lblNewPassword)
        pnlAddUser.Controls.Add(txtNewPassword)
        pnlAddUser.Controls.Add(lblNewType)
        pnlAddUser.Controls.Add(cboNewUserType)
        pnlAddUser.Controls.Add(btnAddUser)
        '
        ' pnlChangePass
        '
        pnlChangePass.BackColor = Color.White
        pnlChangePass.Location  = New Point(448, 214)
        pnlChangePass.Name      = "pnlChangePass"
        pnlChangePass.Size      = New Size(444, 180)
        pnlChangePass.TabIndex  = 2

        lblChangeTitle.Font      = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblChangeTitle.ForeColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        lblChangeTitle.Location  = New Point(14, 10)
        lblChangeTitle.Name      = "lblChangeTitle"
        lblChangeTitle.Size      = New Size(220, 22)
        lblChangeTitle.TabIndex  = 0
        lblChangeTitle.Text      = "Change Password"

        lblSelectedUser.Font      = New Font("Segoe UI", 8.5F, FontStyle.Italic)
        lblSelectedUser.ForeColor = Color.FromArgb(CByte(120), CByte(125), CByte(135))
        lblSelectedUser.Location  = New Point(14, 38)
        lblSelectedUser.Name      = "lblSelectedUser"
        lblSelectedUser.Size      = New Size(416, 20)
        lblSelectedUser.TabIndex  = 1
        lblSelectedUser.Text      = "Select a user above."

        lblChangePass.Font      = lblFont
        lblChangePass.ForeColor = lblColor
        lblChangePass.Location  = New Point(14, 68)
        lblChangePass.Name      = "lblChangePass"
        lblChangePass.Size      = New Size(200, 20)
        lblChangePass.TabIndex  = 2
        lblChangePass.Text      = "New Password * (min 6 chars)"

        txtChangePassword.Font         = txtFont
        txtChangePassword.Location     = New Point(14, 90)
        txtChangePassword.MaxLength    = 100
        txtChangePassword.Name         = "txtChangePassword"
        txtChangePassword.PasswordChar = "*"c
        txtChangePassword.Size         = New Size(416, 27)
        txtChangePassword.TabIndex     = 3

        btnChangePass.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnChangePass.Cursor    = Cursors.Hand
        btnChangePass.Enabled   = False
        btnChangePass.FlatAppearance.BorderSize = 0
        btnChangePass.FlatStyle = FlatStyle.Flat
        btnChangePass.Font      = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnChangePass.ForeColor = Color.White
        btnChangePass.Location  = New Point(14, 130)
        btnChangePass.Name      = "btnChangePass"
        btnChangePass.Size      = New Size(150, 30)
        btnChangePass.TabIndex  = 4
        btnChangePass.Text      = "Change Password"
        btnChangePass.UseVisualStyleBackColor = False

        pnlChangePass.Controls.Add(lblChangeTitle)
        pnlChangePass.Controls.Add(lblSelectedUser)
        pnlChangePass.Controls.Add(lblChangePass)
        pnlChangePass.Controls.Add(txtChangePassword)
        pnlChangePass.Controls.Add(btnChangePass)
        '
        ' btnDeleteUser
        '
        btnDeleteUser.BackColor = Color.FromArgb(CByte(192), CByte(57), CByte(43))
        btnDeleteUser.Cursor    = Cursors.Hand
        btnDeleteUser.Enabled   = False
        btnDeleteUser.FlatAppearance.BorderSize = 0
        btnDeleteUser.FlatStyle = FlatStyle.Flat
        btnDeleteUser.Font      = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnDeleteUser.ForeColor = Color.White
        btnDeleteUser.Location  = New Point(448, 406)
        btnDeleteUser.Name      = "btnDeleteUser"
        btnDeleteUser.Size      = New Size(160, 32)
        btnDeleteUser.TabIndex  = 3
        btnDeleteUser.Text      = "Delete Selected User"
        btnDeleteUser.UseVisualStyleBackColor = False

        tabUsers.Controls.Add(dgvUsers)
        tabUsers.Controls.Add(pnlAddUser)
        tabUsers.Controls.Add(pnlChangePass)
        tabUsers.Controls.Add(btnDeleteUser)
        '
        ' tabSecurity — My Security Question (self-service, all roles)
        '
        tabSecurity.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        tabSecurity.Name      = "tabSecurity"
        tabSecurity.Text      = "  My Security Question  "

        lblSecurityTitle.Font      = New Font("Segoe UI", 11F, FontStyle.Bold)
        lblSecurityTitle.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        lblSecurityTitle.Location  = New Point(30, 30)
        lblSecurityTitle.Name      = "lblSecurityTitle"
        lblSecurityTitle.Size      = New Size(400, 26)
        lblSecurityTitle.TabIndex  = 0
        lblSecurityTitle.Text      = "My Security Question"

        lblSecurityStatus.Font      = New Font("Segoe UI", 8.5F, FontStyle.Italic)
        lblSecurityStatus.ForeColor = Color.FromArgb(CByte(120), CByte(125), CByte(135))
        lblSecurityStatus.Location  = New Point(30, 60)
        lblSecurityStatus.Name      = "lblSecurityStatus"
        lblSecurityStatus.Size      = New Size(500, 20)
        lblSecurityStatus.TabIndex  = 1
        lblSecurityStatus.Text      = "No security question set."

        lblSecurityQuestion.Font      = lblFont
        lblSecurityQuestion.ForeColor = lblColor
        lblSecurityQuestion.Location  = New Point(30, 92)
        lblSecurityQuestion.Name      = "lblSecurityQuestion"
        lblSecurityQuestion.Size      = New Size(300, 20)
        lblSecurityQuestion.TabIndex  = 2
        lblSecurityQuestion.Text      = "Security Question *"

        cboSecurityQuestion.DropDownStyle = ComboBoxStyle.DropDownList
        cboSecurityQuestion.Font          = txtFont
        cboSecurityQuestion.Location      = New Point(30, 114)
        cboSecurityQuestion.Name          = "cboSecurityQuestion"
        cboSecurityQuestion.Size          = New Size(500, 28)
        cboSecurityQuestion.TabIndex      = 3

        lblSecurityAnswer.Font      = lblFont
        lblSecurityAnswer.ForeColor = lblColor
        lblSecurityAnswer.Location  = New Point(30, 156)
        lblSecurityAnswer.Name      = "lblSecurityAnswer"
        lblSecurityAnswer.Size      = New Size(300, 20)
        lblSecurityAnswer.TabIndex  = 4
        lblSecurityAnswer.Text      = "Answer *"

        txtSecurityAnswer.Font      = txtFont
        txtSecurityAnswer.Location  = New Point(30, 178)
        txtSecurityAnswer.MaxLength = 255
        txtSecurityAnswer.Name      = "txtSecurityAnswer"
        txtSecurityAnswer.Size      = New Size(500, 27)
        txtSecurityAnswer.TabIndex  = 5

        lblConfirmSecurityAnswer.Font      = lblFont
        lblConfirmSecurityAnswer.ForeColor = lblColor
        lblConfirmSecurityAnswer.Location  = New Point(30, 216)
        lblConfirmSecurityAnswer.Name      = "lblConfirmSecurityAnswer"
        lblConfirmSecurityAnswer.Size      = New Size(300, 20)
        lblConfirmSecurityAnswer.TabIndex  = 6
        lblConfirmSecurityAnswer.Text      = "Confirm Answer *"

        txtConfirmSecurityAnswer.Font      = txtFont
        txtConfirmSecurityAnswer.Location  = New Point(30, 238)
        txtConfirmSecurityAnswer.MaxLength = 255
        txtConfirmSecurityAnswer.Name      = "txtConfirmSecurityAnswer"
        txtConfirmSecurityAnswer.Size      = New Size(500, 27)
        txtConfirmSecurityAnswer.TabIndex  = 7

        btnSaveSecurityQA.BackColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        btnSaveSecurityQA.Cursor    = Cursors.Hand
        btnSaveSecurityQA.FlatAppearance.BorderSize = 0
        btnSaveSecurityQA.FlatStyle = FlatStyle.Flat
        btnSaveSecurityQA.Font      = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnSaveSecurityQA.ForeColor = Color.White
        btnSaveSecurityQA.Location  = New Point(30, 284)
        btnSaveSecurityQA.Name      = "btnSaveSecurityQA"
        btnSaveSecurityQA.Size      = New Size(200, 34)
        btnSaveSecurityQA.TabIndex  = 8
        btnSaveSecurityQA.Text      = "Save Security Question"
        btnSaveSecurityQA.UseVisualStyleBackColor = False

        tabSecurity.Controls.Add(lblSecurityTitle)
        tabSecurity.Controls.Add(lblSecurityStatus)
        tabSecurity.Controls.Add(lblSecurityQuestion)
        tabSecurity.Controls.Add(cboSecurityQuestion)
        tabSecurity.Controls.Add(lblSecurityAnswer)
        tabSecurity.Controls.Add(txtSecurityAnswer)
        tabSecurity.Controls.Add(lblConfirmSecurityAnswer)
        tabSecurity.Controls.Add(txtConfirmSecurityAnswer)
        tabSecurity.Controls.Add(btnSaveSecurityQA)
        '
        ' Panel1 — header
        '
        Panel1.Controls.Add(lblPageHeader)
        Panel1.Dock     = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name     = "Panel1"
        Panel1.Size     = New Size(980, 76)
        Panel1.TabIndex = 1
        '
        ' Panel2 — content (tabControl fills it)
        '
        Panel2.Controls.Add(tabControl)
        Panel2.Dock     = DockStyle.Fill
        Panel2.Location = New Point(0, 76)
        Panel2.Name     = "Panel2"
        Panel2.TabIndex = 2
        '
        ' frmSettings
        '
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode       = AutoScaleMode.Font
        BackColor           = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        ClientSize          = New Size(980, 725)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle     = FormBorderStyle.None
        Name                = "frmSettings"
        Text                = "Settings"
        tabControl.ResumeLayout(False)
        tabUsers.ResumeLayout(False)
        tabSecurity.ResumeLayout(False)
        tabSecurity.PerformLayout()
        pnlAddUser.ResumeLayout(False)
        pnlAddUser.PerformLayout()
        pnlChangePass.ResumeLayout(False)
        pnlChangePass.PerformLayout()
        CType(dgvUsers, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblPageHeader      As Label
    Friend WithEvents tabControl         As TabControl
    Friend WithEvents tabUsers           As TabPage
    Friend WithEvents dgvUsers           As DataGridView
    Friend WithEvents pnlAddUser         As Panel
    Friend WithEvents lblAddTitle        As Label
    Friend WithEvents lblNewUsername     As Label
    Friend WithEvents txtNewUsername     As TextBox
    Friend WithEvents lblNewPassword     As Label
    Friend WithEvents txtNewPassword     As TextBox
    Friend WithEvents lblNewType         As Label
    Friend WithEvents cboNewUserType     As ComboBox
    Friend WithEvents btnAddUser         As Button
    Friend WithEvents pnlChangePass      As Panel
    Friend WithEvents lblChangeTitle     As Label
    Friend WithEvents lblSelectedUser    As Label
    Friend WithEvents lblChangePass      As Label
    Friend WithEvents txtChangePassword  As TextBox
    Friend WithEvents btnChangePass      As Button
    Friend WithEvents btnDeleteUser      As Button
    Friend WithEvents tabSecurity            As TabPage
    Friend WithEvents lblSecurityTitle       As Label
    Friend WithEvents lblSecurityStatus      As Label
    Friend WithEvents lblSecurityQuestion    As Label
    Friend WithEvents cboSecurityQuestion    As ComboBox
    Friend WithEvents lblSecurityAnswer      As Label
    Friend WithEvents txtSecurityAnswer      As TextBox
    Friend WithEvents lblConfirmSecurityAnswer As Label
    Friend WithEvents txtConfirmSecurityAnswer As TextBox
    Friend WithEvents btnSaveSecurityQA      As Button
    Friend WithEvents Panel1             As Panel
    Friend WithEvents Panel2             As Panel

End Class
