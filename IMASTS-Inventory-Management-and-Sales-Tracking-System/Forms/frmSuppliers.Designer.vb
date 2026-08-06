<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSuppliers
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
        lblPageHeader = New Label()
        pnlForm = New Panel()
        lblName = New Label()
        txtName = New TextBox()
        lblContact = New Label()
        txtContact = New TextBox()
        lblPhone = New Label()
        txtPhone = New TextBox()
        lblEmail = New Label()
        txtEmail = New TextBox()
        lblAddress = New Label()
        txtAddress = New TextBox()
        btnAdd = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnClear = New Button()
        dgvSuppliers = New DataGridView()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        pnlFooter = New Panel()
        lblTotalRecords = New Label()
        pnlForm.SuspendLayout()
        CType(dgvSuppliers, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        pnlFooter.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblPageHeader
        ' 
        lblPageHeader.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblPageHeader.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        lblPageHeader.Location = New Point(12, 20)
        lblPageHeader.Name = "lblPageHeader"
        lblPageHeader.Size = New Size(320, 41)
        lblPageHeader.TabIndex = 0
        lblPageHeader.Text = "Supplier Management"
        ' 
        ' pnlForm
        ' 
        pnlForm.BackColor = Color.White
        pnlForm.Controls.Add(lblName)
        pnlForm.Controls.Add(txtName)
        pnlForm.Controls.Add(lblContact)
        pnlForm.Controls.Add(txtContact)
        pnlForm.Controls.Add(lblPhone)
        pnlForm.Controls.Add(txtPhone)
        pnlForm.Controls.Add(lblEmail)
        pnlForm.Controls.Add(txtEmail)
        pnlForm.Controls.Add(lblAddress)
        pnlForm.Controls.Add(txtAddress)
        pnlForm.Controls.Add(btnAdd)
        pnlForm.Controls.Add(btnUpdate)
        pnlForm.Controls.Add(btnDelete)
        pnlForm.Controls.Add(btnClear)
        pnlForm.Location = New Point(12, 6)
        pnlForm.Name = "pnlForm"
        pnlForm.Size = New Size(540, 242)
        pnlForm.TabIndex = 1
        ' 
        ' lblName
        ' 
        lblName.Font = New Font("Segoe UI", 9F)
        lblName.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblName.Location = New Point(268, 20)
        lblName.Name = "lblName"
        lblName.Size = New Size(120, 20)
        lblName.TabIndex = 0
        lblName.Text = "Supplier Name *"
        ' 
        ' txtName
        ' 
        txtName.Font = New Font("Segoe UI", 10F)
        txtName.Location = New Point(268, 42)
        txtName.MaxLength = 100
        txtName.Name = "txtName"
        txtName.Size = New Size(240, 27)
        txtName.TabIndex = 1
        ' 
        ' lblContact
        ' 
        lblContact.Font = New Font("Segoe UI", 9F)
        lblContact.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblContact.Location = New Point(16, 74)
        lblContact.Name = "lblContact"
        lblContact.Size = New Size(120, 20)
        lblContact.TabIndex = 4
        lblContact.Text = "Contact Person"
        ' 
        ' txtContact
        ' 
        txtContact.Font = New Font("Segoe UI", 10F)
        txtContact.Location = New Point(16, 96)
        txtContact.MaxLength = 100
        txtContact.Name = "txtContact"
        txtContact.Size = New Size(240, 27)
        txtContact.TabIndex = 5
        ' 
        ' lblPhone
        ' 
        lblPhone.Font = New Font("Segoe UI", 9F)
        lblPhone.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblPhone.Location = New Point(16, 20)
        lblPhone.Name = "lblPhone"
        lblPhone.Size = New Size(120, 20)
        lblPhone.TabIndex = 2
        lblPhone.Text = "Phone Number"
        ' 
        ' txtPhone
        ' 
        txtPhone.Font = New Font("Segoe UI", 10F)
        txtPhone.Location = New Point(16, 42)
        txtPhone.MaxLength = 20
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(240, 27)
        txtPhone.TabIndex = 3
        ' 
        ' lblEmail
        ' 
        lblEmail.Font = New Font("Segoe UI", 9F)
        lblEmail.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblEmail.Location = New Point(268, 74)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(120, 20)
        lblEmail.TabIndex = 6
        lblEmail.Text = "Email"
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Segoe UI", 10F)
        txtEmail.Location = New Point(268, 96)
        txtEmail.MaxLength = 100
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(240, 27)
        txtEmail.TabIndex = 7
        ' 
        ' lblAddress
        ' 
        lblAddress.Font = New Font("Segoe UI", 9F)
        lblAddress.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblAddress.Location = New Point(16, 134)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(120, 20)
        lblAddress.TabIndex = 8
        lblAddress.Text = "Address"
        ' 
        ' txtAddress
        ' 
        txtAddress.Font = New Font("Segoe UI", 10F)
        txtAddress.Location = New Point(16, 156)
        txtAddress.MaxLength = 255
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(508, 27)
        txtAddress.TabIndex = 9
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        btnAdd.Cursor = Cursors.Hand
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(16, 196)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(78, 32)
        btnAdd.TabIndex = 10
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnUpdate.Cursor = Cursors.Hand
        btnUpdate.Enabled = False
        btnUpdate.FlatAppearance.BorderSize = 0
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnUpdate.ForeColor = Color.White
        btnUpdate.Location = New Point(102, 196)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(78, 32)
        btnUpdate.TabIndex = 11
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.FromArgb(CByte(192), CByte(57), CByte(43))
        btnDelete.Cursor = Cursors.Hand
        btnDelete.Enabled = False
        btnDelete.FlatAppearance.BorderSize = 0
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(188, 196)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(78, 32)
        btnDelete.TabIndex = 12
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.FromArgb(CByte(150), CByte(155), CByte(165))
        btnClear.Cursor = Cursors.Hand
        btnClear.FlatAppearance.BorderSize = 0
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 9F)
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(274, 196)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(78, 32)
        btnClear.TabIndex = 13
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' dgvSuppliers
        ' 
        dgvSuppliers.AllowUserToAddRows = False
        dgvSuppliers.AllowUserToDeleteRows = False
        dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvSuppliers.BackgroundColor = Color.White
        dgvSuppliers.BorderStyle = BorderStyle.None
        dgvSuppliers.ColumnHeadersHeight = 36
        dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvSuppliers.Dock = DockStyle.Fill
        dgvSuppliers.Font = New Font("Segoe UI", 9.5F)
        dgvSuppliers.GridColor = Color.FromArgb(CByte(220), CByte(223), CByte(228))
        dgvSuppliers.Location = New Point(0, 0)
        dgvSuppliers.MultiSelect = False
        dgvSuppliers.Name = "dgvSuppliers"
        dgvSuppliers.ReadOnly = True
        dgvSuppliers.RowHeadersVisible = False
        dgvSuppliers.RowHeadersWidth = 45
        dgvSuppliers.RowTemplate.Height = 32
        dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSuppliers.Size = New Size(980, 357)
        dgvSuppliers.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lblPageHeader)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(980, 76)
        Panel1.TabIndex = 3
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(pnlForm)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 76)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(980, 256)
        Panel2.TabIndex = 4
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(dgvSuppliers)
        Panel3.Controls.Add(pnlFooter)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(0, 332)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(980, 393)
        Panel3.TabIndex = 5
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.White
        pnlFooter.Controls.Add(lblTotalRecords)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 357)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Size = New Size(980, 36)
        pnlFooter.TabIndex = 1
        ' 
        ' lblTotalRecords
        ' 
        lblTotalRecords.AutoSize = True
        lblTotalRecords.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblTotalRecords.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblTotalRecords.Location = New Point(12, 8)
        lblTotalRecords.Name = "lblTotalRecords"
        lblTotalRecords.Size = New Size(116, 19)
        lblTotalRecords.TabIndex = 0
        lblTotalRecords.Text = "Total Records: 0"
        ' 
        ' frmSuppliers
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        ClientSize = New Size(980, 725)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmSuppliers"
        Text = "Supplier Management"
        pnlForm.ResumeLayout(False)
        pnlForm.PerformLayout()
        CType(dgvSuppliers, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        pnlFooter.ResumeLayout(False)
        pnlFooter.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblPageHeader As Label
    Friend WithEvents pnlForm       As Panel
    Friend WithEvents lblName       As Label
    Friend WithEvents txtName       As TextBox
    Friend WithEvents lblContact    As Label
    Friend WithEvents txtContact    As TextBox
    Friend WithEvents lblPhone      As Label
    Friend WithEvents txtPhone      As TextBox
    Friend WithEvents lblEmail      As Label
    Friend WithEvents txtEmail      As TextBox
    Friend WithEvents lblAddress    As Label
    Friend WithEvents txtAddress    As TextBox
    Friend WithEvents btnAdd        As Button
    Friend WithEvents btnUpdate     As Button
    Friend WithEvents btnDelete     As Button
    Friend WithEvents btnClear      As Button
    Friend WithEvents dgvSuppliers  As DataGridView
    Friend WithEvents Panel1        As Panel
    Friend WithEvents Panel2        As Panel
    Friend WithEvents Panel3        As Panel
    Friend WithEvents pnlFooter     As Panel
    Friend WithEvents lblTotalRecords As Label

End Class
