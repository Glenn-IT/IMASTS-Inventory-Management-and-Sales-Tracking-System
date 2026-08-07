<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCategories
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
        lblCategoryName = New Label()
        txtCategoryName = New TextBox()
        lblDefaultUnit = New Label()
        cboDefaultUnit = New ComboBox()
        btnAdd = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnClear = New Button()
        dgvCategories = New DataGridView()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        pnlFooter = New Panel()
        lblTotalRecords = New Label()
        pnlForm.SuspendLayout()
        CType(dgvCategories, ComponentModel.ISupportInitialize).BeginInit()
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
        lblPageHeader.Size = New Size(300, 41)
        lblPageHeader.TabIndex = 0
        lblPageHeader.Text = "Category Management"
        ' 
        ' pnlForm
        ' 
        pnlForm.BackColor = Color.White
        pnlForm.Controls.Add(lblCategoryName)
        pnlForm.Controls.Add(txtCategoryName)
        pnlForm.Controls.Add(lblDefaultUnit)
        pnlForm.Controls.Add(cboDefaultUnit)
        pnlForm.Controls.Add(btnAdd)
        pnlForm.Controls.Add(btnUpdate)
        pnlForm.Controls.Add(btnDelete)
        pnlForm.Controls.Add(btnClear)
        pnlForm.Location = New Point(12, 6)
        pnlForm.Name = "pnlForm"
        pnlForm.Size = New Size(520, 136)
        pnlForm.TabIndex = 1
        ' 
        ' lblCategoryName
        ' 
        lblCategoryName.Font = New Font("Segoe UI", 9F)
        lblCategoryName.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblCategoryName.Location = New Point(16, 18)
        lblCategoryName.Name = "lblCategoryName"
        lblCategoryName.Size = New Size(110, 23)
        lblCategoryName.TabIndex = 0
        lblCategoryName.Text = "Category Name *"
        ' 
        ' txtCategoryName
        ' 
        txtCategoryName.Font = New Font("Segoe UI", 10F)
        txtCategoryName.Location = New Point(16, 43)
        txtCategoryName.MaxLength = 100
        txtCategoryName.Name = "txtCategoryName"
        txtCategoryName.Size = New Size(320, 27)
        txtCategoryName.TabIndex = 1
        ' 
        ' lblDefaultUnit
        ' 
        lblDefaultUnit.Font = New Font("Segoe UI", 9F)
        lblDefaultUnit.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblDefaultUnit.Location = New Point(352, 18)
        lblDefaultUnit.Name = "lblDefaultUnit"
        lblDefaultUnit.Size = New Size(110, 23)
        lblDefaultUnit.TabIndex = 2
        lblDefaultUnit.Text = "Default Unit"
        ' 
        ' cboDefaultUnit
        ' 
        cboDefaultUnit.Font = New Font("Segoe UI", 10F)
        cboDefaultUnit.FormattingEnabled = True
        cboDefaultUnit.Items.AddRange(New Object() {"pcs", "box", "case", "pack", "bottle", "can", "kg", "liter", "bag", "set", "roll", "pair"})
        cboDefaultUnit.Location = New Point(352, 43)
        cboDefaultUnit.Name = "cboDefaultUnit"
        cboDefaultUnit.Size = New Size(152, 27)
        cboDefaultUnit.TabIndex = 3
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        btnAdd.Cursor = Cursors.Hand
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(16, 88)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(78, 32)
        btnAdd.TabIndex = 4
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
        btnUpdate.Location = New Point(102, 88)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(78, 32)
        btnUpdate.TabIndex = 5
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
        btnDelete.Location = New Point(188, 88)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(78, 32)
        btnDelete.TabIndex = 6
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
        btnClear.Location = New Point(274, 88)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(78, 32)
        btnClear.TabIndex = 7
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' dgvCategories
        ' 
        dgvCategories.AllowUserToAddRows = False
        dgvCategories.AllowUserToDeleteRows = False
        dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCategories.BackgroundColor = Color.White
        dgvCategories.BorderStyle = BorderStyle.None
        dgvCategories.ColumnHeadersHeight = 36
        dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvCategories.Dock = DockStyle.Fill
        dgvCategories.Font = New Font("Segoe UI", 9.5F)
        dgvCategories.GridColor = Color.FromArgb(CByte(220), CByte(223), CByte(228))
        dgvCategories.Location = New Point(0, 0)
        dgvCategories.MultiSelect = False
        dgvCategories.Name = "dgvCategories"
        dgvCategories.ReadOnly = True
        dgvCategories.RowHeadersVisible = False
        dgvCategories.RowHeadersWidth = 45
        dgvCategories.RowTemplate.Height = 32
        dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCategories.Size = New Size(980, 493)
        dgvCategories.TabIndex = 2
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.White
        pnlFooter.Controls.Add(lblTotalRecords)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Height = 36
        pnlFooter.Name = "pnlFooter"
        ' 
        ' lblTotalRecords
        ' 
        lblTotalRecords.AutoSize = True
        lblTotalRecords.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblTotalRecords.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblTotalRecords.Location = New Point(12, 8)
        lblTotalRecords.Name = "lblTotalRecords"
        lblTotalRecords.Text = "Total Records: 0"
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
        Panel2.Size = New Size(980, 156)
        Panel2.TabIndex = 4
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(dgvCategories)
        Panel3.Controls.Add(pnlFooter)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(0, 232)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(980, 493)
        Panel3.TabIndex = 5
        ' 
        ' frmCategories
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        ClientSize = New Size(980, 725)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmCategories"
        Text = "Category Management"
        WindowState = FormWindowState.Maximized
        pnlForm.ResumeLayout(False)
        pnlForm.PerformLayout()
        CType(dgvCategories, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        pnlFooter.ResumeLayout(False)
        pnlFooter.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblPageHeader   As System.Windows.Forms.Label
    Friend WithEvents pnlForm         As System.Windows.Forms.Panel
    Friend WithEvents lblCategoryName As System.Windows.Forms.Label
    Friend WithEvents txtCategoryName As System.Windows.Forms.TextBox
    Friend WithEvents lblDefaultUnit  As System.Windows.Forms.Label
    Friend WithEvents cboDefaultUnit  As System.Windows.Forms.ComboBox
    Friend WithEvents btnAdd          As System.Windows.Forms.Button
    Friend WithEvents btnUpdate       As System.Windows.Forms.Button
    Friend WithEvents btnDelete       As System.Windows.Forms.Button
    Friend WithEvents btnClear        As System.Windows.Forms.Button
    Friend WithEvents dgvCategories   As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents lblTotalRecords As Label

End Class
