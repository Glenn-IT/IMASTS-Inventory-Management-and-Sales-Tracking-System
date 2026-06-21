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
        Me.lblPageHeader    = New System.Windows.Forms.Label()
        Me.pnlForm          = New System.Windows.Forms.Panel()
        Me.lblCategoryName  = New System.Windows.Forms.Label()
        Me.txtCategoryName  = New System.Windows.Forms.TextBox()
        Me.btnAdd           = New System.Windows.Forms.Button()
        Me.btnUpdate        = New System.Windows.Forms.Button()
        Me.btnDelete        = New System.Windows.Forms.Button()
        Me.btnClear         = New System.Windows.Forms.Button()
        Me.dgvCategories    = New System.Windows.Forms.DataGridView()

        Me.pnlForm.SuspendLayout()
        CType(Me.dgvCategories, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        ' ── lblPageHeader ─────────────────────────────────────────────────
        Me.lblPageHeader.AutoSize  = False
        Me.lblPageHeader.Font      = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblPageHeader.ForeColor = System.Drawing.Color.FromArgb(40, 44, 52)
        Me.lblPageHeader.Location  = New System.Drawing.Point(30, 20)
        Me.lblPageHeader.Name      = "lblPageHeader"
        Me.lblPageHeader.Size      = New System.Drawing.Size(300, 36)
        Me.lblPageHeader.Text      = "Category Management"

        ' ── pnlForm (input card) ─────────────────────────────────────────
        Me.pnlForm.BackColor = System.Drawing.Color.White
        Me.pnlForm.Location  = New System.Drawing.Point(30, 72)
        Me.pnlForm.Name      = "pnlForm"
        Me.pnlForm.Size      = New System.Drawing.Size(380, 120)
        Me.pnlForm.Controls.Add(Me.lblCategoryName)
        Me.pnlForm.Controls.Add(Me.txtCategoryName)
        Me.pnlForm.Controls.Add(Me.btnAdd)
        Me.pnlForm.Controls.Add(Me.btnUpdate)
        Me.pnlForm.Controls.Add(Me.btnDelete)
        Me.pnlForm.Controls.Add(Me.btnClear)

        ' lblCategoryName
        Me.lblCategoryName.AutoSize  = False
        Me.lblCategoryName.Font      = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular)
        Me.lblCategoryName.ForeColor = System.Drawing.Color.FromArgb(80, 85, 95)
        Me.lblCategoryName.Location  = New System.Drawing.Point(16, 16)
        Me.lblCategoryName.Name      = "lblCategoryName"
        Me.lblCategoryName.Size      = New System.Drawing.Size(110, 20)
        Me.lblCategoryName.Text      = "Category Name"

        ' txtCategoryName
        Me.txtCategoryName.Font      = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtCategoryName.Location  = New System.Drawing.Point(16, 38)
        Me.txtCategoryName.MaxLength = 100
        Me.txtCategoryName.Name      = "txtCategoryName"
        Me.txtCategoryName.Size      = New System.Drawing.Size(348, 26)

        ' btnAdd
        Me.btnAdd.BackColor  = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.btnAdd.FlatStyle  = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.Font       = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor  = System.Drawing.Color.White
        Me.btnAdd.Location   = New System.Drawing.Point(16, 78)
        Me.btnAdd.Name       = "btnAdd"
        Me.btnAdd.Size       = New System.Drawing.Size(78, 28)
        Me.btnAdd.Text       = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        Me.btnAdd.Cursor     = System.Windows.Forms.Cursors.Hand

        ' btnUpdate
        Me.btnUpdate.BackColor  = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.btnUpdate.FlatStyle  = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.Font       = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnUpdate.ForeColor  = System.Drawing.Color.White
        Me.btnUpdate.Location   = New System.Drawing.Point(102, 78)
        Me.btnUpdate.Name       = "btnUpdate"
        Me.btnUpdate.Size       = New System.Drawing.Size(78, 28)
        Me.btnUpdate.Text       = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        Me.btnUpdate.Cursor     = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.Enabled    = False

        ' btnDelete
        Me.btnDelete.BackColor  = System.Drawing.Color.FromArgb(192, 57, 43)
        Me.btnDelete.FlatStyle  = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.Font       = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor  = System.Drawing.Color.White
        Me.btnDelete.Location   = New System.Drawing.Point(188, 78)
        Me.btnDelete.Name       = "btnDelete"
        Me.btnDelete.Size       = New System.Drawing.Size(78, 28)
        Me.btnDelete.Text       = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Cursor     = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Enabled    = False

        ' btnClear
        Me.btnClear.BackColor  = System.Drawing.Color.FromArgb(150, 155, 165)
        Me.btnClear.FlatStyle  = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.Font       = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular)
        Me.btnClear.ForeColor  = System.Drawing.Color.White
        Me.btnClear.Location   = New System.Drawing.Point(274, 78)
        Me.btnClear.Name       = "btnClear"
        Me.btnClear.Size       = New System.Drawing.Size(78, 28)
        Me.btnClear.Text       = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        Me.btnClear.Cursor     = System.Windows.Forms.Cursors.Hand

        ' ── dgvCategories ────────────────────────────────────────────────
        Me.dgvCategories.AllowUserToAddRows        = False
        Me.dgvCategories.AllowUserToDeleteRows     = False
        Me.dgvCategories.AutoSizeColumnsMode       = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCategories.BackgroundColor           = System.Drawing.Color.White
        Me.dgvCategories.BorderStyle               = System.Windows.Forms.BorderStyle.None
        Me.dgvCategories.ColumnHeadersHeight       = 36
        Me.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvCategories.Font                      = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dgvCategories.GridColor                 = System.Drawing.Color.FromArgb(220, 223, 228)
        Me.dgvCategories.Location                  = New System.Drawing.Point(30, 210)
        Me.dgvCategories.MultiSelect               = False
        Me.dgvCategories.Name                      = "dgvCategories"
        Me.dgvCategories.ReadOnly                  = True
        Me.dgvCategories.RowHeadersVisible         = False
        Me.dgvCategories.RowTemplate.Height        = 32
        Me.dgvCategories.SelectionMode             = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCategories.Size                      = New System.Drawing.Size(380, 380)

        ' ── frmCategories ────────────────────────────────────────────────
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor           = System.Drawing.Color.FromArgb(245, 246, 248)
        Me.ClientSize          = New System.Drawing.Size(980, 640)
        Me.Controls.Add(Me.lblPageHeader)
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.dgvCategories)
        Me.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None
        Me.Name                = "frmCategories"
        Me.Text                = "Category Management"

        Me.pnlForm.ResumeLayout(False)
        CType(Me.dgvCategories, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents lblPageHeader   As System.Windows.Forms.Label
    Friend WithEvents pnlForm         As System.Windows.Forms.Panel
    Friend WithEvents lblCategoryName As System.Windows.Forms.Label
    Friend WithEvents txtCategoryName As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd          As System.Windows.Forms.Button
    Friend WithEvents btnUpdate       As System.Windows.Forms.Button
    Friend WithEvents btnDelete       As System.Windows.Forms.Button
    Friend WithEvents btnClear        As System.Windows.Forms.Button
    Friend WithEvents dgvCategories   As System.Windows.Forms.DataGridView

End Class
