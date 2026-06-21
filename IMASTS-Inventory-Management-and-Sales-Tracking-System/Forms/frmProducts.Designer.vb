<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProducts
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
        Me.lblPageHeader   = New System.Windows.Forms.Label()
        Me.pnlForm         = New System.Windows.Forms.Panel()
        Me.lblName         = New System.Windows.Forms.Label()
        Me.txtName         = New System.Windows.Forms.TextBox()
        Me.lblCategory     = New System.Windows.Forms.Label()
        Me.cboCategory     = New System.Windows.Forms.ComboBox()
        Me.lblSupplier     = New System.Windows.Forms.Label()
        Me.cboSupplier     = New System.Windows.Forms.ComboBox()
        Me.lblDescription  = New System.Windows.Forms.Label()
        Me.txtDescription  = New System.Windows.Forms.TextBox()
        Me.lblUnitPrice    = New System.Windows.Forms.Label()
        Me.txtUnitPrice    = New System.Windows.Forms.TextBox()
        Me.lblStockQty     = New System.Windows.Forms.Label()
        Me.txtStockQty     = New System.Windows.Forms.TextBox()
        Me.lblReorderLevel = New System.Windows.Forms.Label()
        Me.txtReorderLevel = New System.Windows.Forms.TextBox()
        Me.btnAdd          = New System.Windows.Forms.Button()
        Me.btnUpdate       = New System.Windows.Forms.Button()
        Me.btnDelete       = New System.Windows.Forms.Button()
        Me.btnClear        = New System.Windows.Forms.Button()
        Me.dgvProducts     = New System.Windows.Forms.DataGridView()

        Me.pnlForm.SuspendLayout()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        ' ── lblPageHeader ─────────────────────────────────────────────────
        Me.lblPageHeader.AutoSize  = False
        Me.lblPageHeader.Font      = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblPageHeader.ForeColor = System.Drawing.Color.FromArgb(40, 44, 52)
        Me.lblPageHeader.Location  = New System.Drawing.Point(30, 20)
        Me.lblPageHeader.Name      = "lblPageHeader"
        Me.lblPageHeader.Size      = New System.Drawing.Size(300, 36)
        Me.lblPageHeader.Text      = "Product Management"

        ' ── pnlForm ──────────────────────────────────────────────────────
        Me.pnlForm.BackColor = System.Drawing.Color.White
        Me.pnlForm.Location  = New System.Drawing.Point(30, 72)
        Me.pnlForm.Name      = "pnlForm"
        Me.pnlForm.Size      = New System.Drawing.Size(900, 300)
        Me.pnlForm.Controls.Add(Me.lblName)
        Me.pnlForm.Controls.Add(Me.txtName)
        Me.pnlForm.Controls.Add(Me.lblCategory)
        Me.pnlForm.Controls.Add(Me.cboCategory)
        Me.pnlForm.Controls.Add(Me.lblSupplier)
        Me.pnlForm.Controls.Add(Me.cboSupplier)
        Me.pnlForm.Controls.Add(Me.lblDescription)
        Me.pnlForm.Controls.Add(Me.txtDescription)
        Me.pnlForm.Controls.Add(Me.lblUnitPrice)
        Me.pnlForm.Controls.Add(Me.txtUnitPrice)
        Me.pnlForm.Controls.Add(Me.lblStockQty)
        Me.pnlForm.Controls.Add(Me.txtStockQty)
        Me.pnlForm.Controls.Add(Me.lblReorderLevel)
        Me.pnlForm.Controls.Add(Me.txtReorderLevel)
        Me.pnlForm.Controls.Add(Me.btnAdd)
        Me.pnlForm.Controls.Add(Me.btnUpdate)
        Me.pnlForm.Controls.Add(Me.btnDelete)
        Me.pnlForm.Controls.Add(Me.btnClear)

        Dim lblFont  As New System.Drawing.Font("Segoe UI", 9.0!)
        Dim lblColor As System.Drawing.Color = System.Drawing.Color.FromArgb(80, 85, 95)
        Dim txtFont  As New System.Drawing.Font("Segoe UI", 10.0!)

        ' Row 1 — Name (full width)
        Me.lblName.AutoSize  = False
        Me.lblName.Font      = lblFont
        Me.lblName.ForeColor = lblColor
        Me.lblName.Location  = New System.Drawing.Point(16, 14)
        Me.lblName.Name      = "lblName"
        Me.lblName.Size      = New System.Drawing.Size(120, 20)
        Me.lblName.Text      = "Product Name *"

        Me.txtName.Font      = txtFont
        Me.txtName.Location  = New System.Drawing.Point(16, 36)
        Me.txtName.MaxLength = 100
        Me.txtName.Name      = "txtName"
        Me.txtName.Size      = New System.Drawing.Size(868, 26)

        ' Row 2 — Category | Supplier
        Me.lblCategory.AutoSize  = False
        Me.lblCategory.Font      = lblFont
        Me.lblCategory.ForeColor = lblColor
        Me.lblCategory.Location  = New System.Drawing.Point(16, 74)
        Me.lblCategory.Name      = "lblCategory"
        Me.lblCategory.Size      = New System.Drawing.Size(120, 20)
        Me.lblCategory.Text      = "Category *"

        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.Font          = txtFont
        Me.cboCategory.Location      = New System.Drawing.Point(16, 96)
        Me.cboCategory.Name          = "cboCategory"
        Me.cboCategory.Size          = New System.Drawing.Size(420, 28)

        Me.lblSupplier.AutoSize  = False
        Me.lblSupplier.Font      = lblFont
        Me.lblSupplier.ForeColor = lblColor
        Me.lblSupplier.Location  = New System.Drawing.Point(452, 74)
        Me.lblSupplier.Name      = "lblSupplier"
        Me.lblSupplier.Size      = New System.Drawing.Size(120, 20)
        Me.lblSupplier.Text      = "Supplier *"

        Me.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSupplier.Font          = txtFont
        Me.cboSupplier.Location      = New System.Drawing.Point(452, 96)
        Me.cboSupplier.Name          = "cboSupplier"
        Me.cboSupplier.Size          = New System.Drawing.Size(432, 28)

        ' Row 3 — Description (full width)
        Me.lblDescription.AutoSize  = False
        Me.lblDescription.Font      = lblFont
        Me.lblDescription.ForeColor = lblColor
        Me.lblDescription.Location  = New System.Drawing.Point(16, 136)
        Me.lblDescription.Name      = "lblDescription"
        Me.lblDescription.Size      = New System.Drawing.Size(120, 20)
        Me.lblDescription.Text      = "Description"

        Me.txtDescription.Font      = txtFont
        Me.txtDescription.Location  = New System.Drawing.Point(16, 158)
        Me.txtDescription.MaxLength = 255
        Me.txtDescription.Name      = "txtDescription"
        Me.txtDescription.Size      = New System.Drawing.Size(868, 26)

        ' Row 4 — UnitPrice | StockQty | ReorderLevel
        Me.lblUnitPrice.AutoSize  = False
        Me.lblUnitPrice.Font      = lblFont
        Me.lblUnitPrice.ForeColor = lblColor
        Me.lblUnitPrice.Location  = New System.Drawing.Point(16, 196)
        Me.lblUnitPrice.Name      = "lblUnitPrice"
        Me.lblUnitPrice.Size      = New System.Drawing.Size(120, 20)
        Me.lblUnitPrice.Text      = "Unit Price *"

        Me.txtUnitPrice.Font      = txtFont
        Me.txtUnitPrice.Location  = New System.Drawing.Point(16, 218)
        Me.txtUnitPrice.MaxLength = 12
        Me.txtUnitPrice.Name      = "txtUnitPrice"
        Me.txtUnitPrice.Size      = New System.Drawing.Size(260, 26)

        Me.lblStockQty.AutoSize  = False
        Me.lblStockQty.Font      = lblFont
        Me.lblStockQty.ForeColor = lblColor
        Me.lblStockQty.Location  = New System.Drawing.Point(292, 196)
        Me.lblStockQty.Name      = "lblStockQty"
        Me.lblStockQty.Size      = New System.Drawing.Size(120, 20)
        Me.lblStockQty.Text      = "Stock Qty *"

        Me.txtStockQty.Font      = txtFont
        Me.txtStockQty.Location  = New System.Drawing.Point(292, 218)
        Me.txtStockQty.MaxLength = 8
        Me.txtStockQty.Name      = "txtStockQty"
        Me.txtStockQty.Size      = New System.Drawing.Size(260, 26)

        Me.lblReorderLevel.AutoSize  = False
        Me.lblReorderLevel.Font      = lblFont
        Me.lblReorderLevel.ForeColor = lblColor
        Me.lblReorderLevel.Location  = New System.Drawing.Point(568, 196)
        Me.lblReorderLevel.Name      = "lblReorderLevel"
        Me.lblReorderLevel.Size      = New System.Drawing.Size(120, 20)
        Me.lblReorderLevel.Text      = "Reorder Level *"

        Me.txtReorderLevel.Font      = txtFont
        Me.txtReorderLevel.Location  = New System.Drawing.Point(568, 218)
        Me.txtReorderLevel.MaxLength = 8
        Me.txtReorderLevel.Name      = "txtReorderLevel"
        Me.txtReorderLevel.Size      = New System.Drawing.Size(316, 26)

        ' Row 5 — Buttons
        Me.btnAdd.BackColor  = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.btnAdd.FlatStyle  = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.Font       = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor  = System.Drawing.Color.White
        Me.btnAdd.Location   = New System.Drawing.Point(16, 260)
        Me.btnAdd.Name       = "btnAdd"
        Me.btnAdd.Size       = New System.Drawing.Size(90, 30)
        Me.btnAdd.Text       = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        Me.btnAdd.Cursor     = System.Windows.Forms.Cursors.Hand

        Me.btnUpdate.BackColor  = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.btnUpdate.FlatStyle  = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.Font       = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnUpdate.ForeColor  = System.Drawing.Color.White
        Me.btnUpdate.Location   = New System.Drawing.Point(114, 260)
        Me.btnUpdate.Name       = "btnUpdate"
        Me.btnUpdate.Size       = New System.Drawing.Size(90, 30)
        Me.btnUpdate.Text       = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        Me.btnUpdate.Cursor     = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.Enabled    = False

        Me.btnDelete.BackColor  = System.Drawing.Color.FromArgb(192, 57, 43)
        Me.btnDelete.FlatStyle  = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.Font       = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor  = System.Drawing.Color.White
        Me.btnDelete.Location   = New System.Drawing.Point(212, 260)
        Me.btnDelete.Name       = "btnDelete"
        Me.btnDelete.Size       = New System.Drawing.Size(90, 30)
        Me.btnDelete.Text       = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Cursor     = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Enabled    = False

        Me.btnClear.BackColor  = System.Drawing.Color.FromArgb(150, 155, 165)
        Me.btnClear.FlatStyle  = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.Font       = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular)
        Me.btnClear.ForeColor  = System.Drawing.Color.White
        Me.btnClear.Location   = New System.Drawing.Point(310, 260)
        Me.btnClear.Name       = "btnClear"
        Me.btnClear.Size       = New System.Drawing.Size(90, 30)
        Me.btnClear.Text       = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        Me.btnClear.Cursor     = System.Windows.Forms.Cursors.Hand

        ' ── dgvProducts ──────────────────────────────────────────────────
        Me.dgvProducts.AllowUserToAddRows        = False
        Me.dgvProducts.AllowUserToDeleteRows     = False
        Me.dgvProducts.BackgroundColor           = System.Drawing.Color.White
        Me.dgvProducts.BorderStyle               = System.Windows.Forms.BorderStyle.None
        Me.dgvProducts.ColumnHeadersHeight       = 36
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvProducts.Font                      = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dgvProducts.GridColor                 = System.Drawing.Color.FromArgb(220, 223, 228)
        Me.dgvProducts.Location                  = New System.Drawing.Point(30, 390)
        Me.dgvProducts.MultiSelect               = False
        Me.dgvProducts.Name                      = "dgvProducts"
        Me.dgvProducts.ReadOnly                  = True
        Me.dgvProducts.RowHeadersVisible         = False
        Me.dgvProducts.RowTemplate.Height        = 32
        Me.dgvProducts.SelectionMode             = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProducts.Size                      = New System.Drawing.Size(900, 210)

        ' ── frmProducts ──────────────────────────────────────────────────
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor           = System.Drawing.Color.FromArgb(245, 246, 248)
        Me.ClientSize          = New System.Drawing.Size(980, 640)
        Me.Controls.Add(Me.lblPageHeader)
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.dgvProducts)
        Me.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None
        Me.Name                = "frmProducts"
        Me.Text                = "Product Management"

        Me.pnlForm.ResumeLayout(False)
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents lblPageHeader   As System.Windows.Forms.Label
    Friend WithEvents pnlForm         As System.Windows.Forms.Panel
    Friend WithEvents lblName         As System.Windows.Forms.Label
    Friend WithEvents txtName         As System.Windows.Forms.TextBox
    Friend WithEvents lblCategory     As System.Windows.Forms.Label
    Friend WithEvents cboCategory     As System.Windows.Forms.ComboBox
    Friend WithEvents lblSupplier     As System.Windows.Forms.Label
    Friend WithEvents cboSupplier     As System.Windows.Forms.ComboBox
    Friend WithEvents lblDescription  As System.Windows.Forms.Label
    Friend WithEvents txtDescription  As System.Windows.Forms.TextBox
    Friend WithEvents lblUnitPrice    As System.Windows.Forms.Label
    Friend WithEvents txtUnitPrice    As System.Windows.Forms.TextBox
    Friend WithEvents lblStockQty     As System.Windows.Forms.Label
    Friend WithEvents txtStockQty     As System.Windows.Forms.TextBox
    Friend WithEvents lblReorderLevel As System.Windows.Forms.Label
    Friend WithEvents txtReorderLevel As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd          As System.Windows.Forms.Button
    Friend WithEvents btnUpdate       As System.Windows.Forms.Button
    Friend WithEvents btnDelete       As System.Windows.Forms.Button
    Friend WithEvents btnClear        As System.Windows.Forms.Button
    Friend WithEvents dgvProducts     As System.Windows.Forms.DataGridView

End Class
