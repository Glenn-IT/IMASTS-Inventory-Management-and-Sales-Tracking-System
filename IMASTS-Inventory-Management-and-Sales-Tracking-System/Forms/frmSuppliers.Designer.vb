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
        Me.lblPageHeader = New System.Windows.Forms.Label()
        Me.pnlForm       = New System.Windows.Forms.Panel()
        Me.lblName       = New System.Windows.Forms.Label()
        Me.txtName       = New System.Windows.Forms.TextBox()
        Me.lblContact    = New System.Windows.Forms.Label()
        Me.txtContact    = New System.Windows.Forms.TextBox()
        Me.lblPhone      = New System.Windows.Forms.Label()
        Me.txtPhone      = New System.Windows.Forms.TextBox()
        Me.lblEmail      = New System.Windows.Forms.Label()
        Me.txtEmail      = New System.Windows.Forms.TextBox()
        Me.lblAddress    = New System.Windows.Forms.Label()
        Me.txtAddress    = New System.Windows.Forms.TextBox()
        Me.btnAdd        = New System.Windows.Forms.Button()
        Me.btnUpdate     = New System.Windows.Forms.Button()
        Me.btnDelete     = New System.Windows.Forms.Button()
        Me.btnClear      = New System.Windows.Forms.Button()
        Me.dgvSuppliers  = New System.Windows.Forms.DataGridView()

        Me.pnlForm.SuspendLayout()
        CType(Me.dgvSuppliers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        ' ── lblPageHeader ─────────────────────────────────────────────────
        Me.lblPageHeader.AutoSize  = False
        Me.lblPageHeader.Font      = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblPageHeader.ForeColor = System.Drawing.Color.FromArgb(40, 44, 52)
        Me.lblPageHeader.Location  = New System.Drawing.Point(30, 20)
        Me.lblPageHeader.Name      = "lblPageHeader"
        Me.lblPageHeader.Size      = New System.Drawing.Size(320, 36)
        Me.lblPageHeader.Text      = "Supplier Management"

        ' ── pnlForm (input card) ─────────────────────────────────────────
        Me.pnlForm.BackColor = System.Drawing.Color.White
        Me.pnlForm.Location  = New System.Drawing.Point(30, 72)
        Me.pnlForm.Name      = "pnlForm"
        Me.pnlForm.Size      = New System.Drawing.Size(540, 260)
        Me.pnlForm.Controls.Add(Me.lblName)
        Me.pnlForm.Controls.Add(Me.txtName)
        Me.pnlForm.Controls.Add(Me.lblContact)
        Me.pnlForm.Controls.Add(Me.txtContact)
        Me.pnlForm.Controls.Add(Me.lblPhone)
        Me.pnlForm.Controls.Add(Me.txtPhone)
        Me.pnlForm.Controls.Add(Me.lblEmail)
        Me.pnlForm.Controls.Add(Me.txtEmail)
        Me.pnlForm.Controls.Add(Me.lblAddress)
        Me.pnlForm.Controls.Add(Me.txtAddress)
        Me.pnlForm.Controls.Add(Me.btnAdd)
        Me.pnlForm.Controls.Add(Me.btnUpdate)
        Me.pnlForm.Controls.Add(Me.btnDelete)
        Me.pnlForm.Controls.Add(Me.btnClear)

        Dim lblFont  As New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular)
        Dim lblColor As System.Drawing.Color = System.Drawing.Color.FromArgb(80, 85, 95)
        Dim txtFont  As New System.Drawing.Font("Segoe UI", 10.0!)
        Dim lblSz    As New System.Drawing.Size(110, 20)
        Dim txtSzFull As New System.Drawing.Size(504, 26)
        Dim txtSzHalf As New System.Drawing.Size(240, 26)

        ' Row 1 — Name (full width)
        Me.lblName.AutoSize  = False
        Me.lblName.Font      = lblFont
        Me.lblName.ForeColor = lblColor
        Me.lblName.Location  = New System.Drawing.Point(16, 14)
        Me.lblName.Name      = "lblName"
        Me.lblName.Size      = lblSz
        Me.lblName.Text      = "Supplier Name *"

        Me.txtName.Font      = txtFont
        Me.txtName.Location  = New System.Drawing.Point(16, 36)
        Me.txtName.MaxLength = 100
        Me.txtName.Name      = "txtName"
        Me.txtName.Size      = txtSzFull

        ' Row 2 — Contact | Phone
        Me.lblContact.AutoSize  = False
        Me.lblContact.Font      = lblFont
        Me.lblContact.ForeColor = lblColor
        Me.lblContact.Location  = New System.Drawing.Point(16, 74)
        Me.lblContact.Name      = "lblContact"
        Me.lblContact.Size      = lblSz
        Me.lblContact.Text      = "Contact Person"

        Me.txtContact.Font      = txtFont
        Me.txtContact.Location  = New System.Drawing.Point(16, 96)
        Me.txtContact.MaxLength = 100
        Me.txtContact.Name      = "txtContact"
        Me.txtContact.Size      = txtSzHalf

        Me.lblPhone.AutoSize  = False
        Me.lblPhone.Font      = lblFont
        Me.lblPhone.ForeColor = lblColor
        Me.lblPhone.Location  = New System.Drawing.Point(264, 74)
        Me.lblPhone.Name      = "lblPhone"
        Me.lblPhone.Size      = lblSz
        Me.lblPhone.Text      = "Phone"

        Me.txtPhone.Font      = txtFont
        Me.txtPhone.Location  = New System.Drawing.Point(264, 96)
        Me.txtPhone.MaxLength = 20
        Me.txtPhone.Name      = "txtPhone"
        Me.txtPhone.Size      = txtSzHalf

        ' Row 3 — Email (full width)
        Me.lblEmail.AutoSize  = False
        Me.lblEmail.Font      = lblFont
        Me.lblEmail.ForeColor = lblColor
        Me.lblEmail.Location  = New System.Drawing.Point(16, 134)
        Me.lblEmail.Name      = "lblEmail"
        Me.lblEmail.Size      = lblSz
        Me.lblEmail.Text      = "Email"

        Me.txtEmail.Font      = txtFont
        Me.txtEmail.Location  = New System.Drawing.Point(16, 156)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name      = "txtEmail"
        Me.txtEmail.Size      = txtSzFull

        ' Row 4 — Address (full width)
        Me.lblAddress.AutoSize  = False
        Me.lblAddress.Font      = lblFont
        Me.lblAddress.ForeColor = lblColor
        Me.lblAddress.Location  = New System.Drawing.Point(16, 194)
        Me.lblAddress.Name      = "lblAddress"
        Me.lblAddress.Size      = lblSz
        Me.lblAddress.Text      = "Address"

        Me.txtAddress.Font      = txtFont
        Me.txtAddress.Location  = New System.Drawing.Point(16, 216)
        Me.txtAddress.MaxLength = 255
        Me.txtAddress.Name      = "txtAddress"
        Me.txtAddress.Size      = txtSzFull

        ' ── Buttons ───────────────────────────────────────────────────────
        ' btnAdd
        Me.btnAdd.BackColor  = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.btnAdd.FlatStyle  = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.Font       = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor  = System.Drawing.Color.White
        Me.btnAdd.Location   = New System.Drawing.Point(16, 14)
        Me.btnAdd.Name       = "btnAdd"
        Me.btnAdd.Size       = New System.Drawing.Size(90, 30)
        Me.btnAdd.Text       = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        Me.btnAdd.Cursor     = System.Windows.Forms.Cursors.Hand

        ' btnUpdate
        Me.btnUpdate.BackColor  = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.btnUpdate.FlatStyle  = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.Font       = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnUpdate.ForeColor  = System.Drawing.Color.White
        Me.btnUpdate.Location   = New System.Drawing.Point(114, 14)
        Me.btnUpdate.Name       = "btnUpdate"
        Me.btnUpdate.Size       = New System.Drawing.Size(90, 30)
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
        Me.btnDelete.Location   = New System.Drawing.Point(212, 14)
        Me.btnDelete.Name       = "btnDelete"
        Me.btnDelete.Size       = New System.Drawing.Size(90, 30)
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
        Me.btnClear.Location   = New System.Drawing.Point(310, 14)
        Me.btnClear.Name       = "btnClear"
        Me.btnClear.Size       = New System.Drawing.Size(90, 30)
        Me.btnClear.Text       = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        Me.btnClear.Cursor     = System.Windows.Forms.Cursors.Hand

        ' Move buttons to bottom of panel — reposition after field layout
        Me.btnAdd.Location    = New System.Drawing.Point(16, 252)
        Me.btnUpdate.Location = New System.Drawing.Point(114, 252)
        Me.btnDelete.Location = New System.Drawing.Point(212, 252)
        Me.btnClear.Location  = New System.Drawing.Point(310, 252)
        Me.pnlForm.Size       = New System.Drawing.Size(540, 292)

        ' ── dgvSuppliers ─────────────────────────────────────────────────
        Me.dgvSuppliers.AllowUserToAddRows        = False
        Me.dgvSuppliers.AllowUserToDeleteRows     = False
        Me.dgvSuppliers.BackgroundColor           = System.Drawing.Color.White
        Me.dgvSuppliers.BorderStyle               = System.Windows.Forms.BorderStyle.None
        Me.dgvSuppliers.ColumnHeadersHeight       = 36
        Me.dgvSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSuppliers.Font                      = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dgvSuppliers.GridColor                 = System.Drawing.Color.FromArgb(220, 223, 228)
        Me.dgvSuppliers.Location                  = New System.Drawing.Point(30, 382)
        Me.dgvSuppliers.MultiSelect               = False
        Me.dgvSuppliers.Name                      = "dgvSuppliers"
        Me.dgvSuppliers.ReadOnly                  = True
        Me.dgvSuppliers.RowHeadersVisible         = False
        Me.dgvSuppliers.RowTemplate.Height        = 32
        Me.dgvSuppliers.SelectionMode             = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSuppliers.Size                      = New System.Drawing.Size(900, 220)

        ' ── frmSuppliers ─────────────────────────────────────────────────
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor           = System.Drawing.Color.FromArgb(245, 246, 248)
        Me.ClientSize          = New System.Drawing.Size(980, 640)
        Me.Controls.Add(Me.lblPageHeader)
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.dgvSuppliers)
        Me.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None
        Me.Name                = "frmSuppliers"
        Me.Text                = "Supplier Management"

        Me.pnlForm.ResumeLayout(False)
        CType(Me.dgvSuppliers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents lblPageHeader As System.Windows.Forms.Label
    Friend WithEvents pnlForm       As System.Windows.Forms.Panel
    Friend WithEvents lblName       As System.Windows.Forms.Label
    Friend WithEvents txtName       As System.Windows.Forms.TextBox
    Friend WithEvents lblContact    As System.Windows.Forms.Label
    Friend WithEvents txtContact    As System.Windows.Forms.TextBox
    Friend WithEvents lblPhone      As System.Windows.Forms.Label
    Friend WithEvents txtPhone      As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail      As System.Windows.Forms.Label
    Friend WithEvents txtEmail      As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress    As System.Windows.Forms.Label
    Friend WithEvents txtAddress    As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd        As System.Windows.Forms.Button
    Friend WithEvents btnUpdate     As System.Windows.Forms.Button
    Friend WithEvents btnDelete     As System.Windows.Forms.Button
    Friend WithEvents btnClear      As System.Windows.Forms.Button
    Friend WithEvents dgvSuppliers  As System.Windows.Forms.DataGridView

End Class
