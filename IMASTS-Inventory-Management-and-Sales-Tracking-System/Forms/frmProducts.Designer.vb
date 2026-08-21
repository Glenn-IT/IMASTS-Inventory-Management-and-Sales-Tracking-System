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
        lblPageHeader   = New Label()
        pnlForm         = New Panel()
        lblBarcode      = New Label()
        txtBarcode      = New TextBox()
        btnGenBarcode   = New Button()
        lblName         = New Label()
        txtName         = New TextBox()
        lblCategory     = New Label()
        cboCategory     = New ComboBox()
        lblSupplier     = New Label()
        cboSupplier     = New ComboBox()
        lblDescription  = New Label()
        txtDescription  = New TextBox()
        lblUnitPrice    = New Label()
        txtUnitPrice    = New TextBox()
        lblStockQty     = New Label()
        txtStockQty     = New TextBox()
        lblReorderLevel = New Label()
        txtReorderLevel = New TextBox()
        lblUnit         = New Label()
        cboUnit         = New ComboBox()
        btnAdd          = New Button()
        btnUpdate       = New Button()
        btnDelete       = New Button()
        btnClear        = New Button()
        dgvProducts     = New DataGridView()
        Panel1          = New Panel()
        lblSearch       = New Label()
        txtSearch       = New TextBox()
        btnClearSearch  = New Button()
        Panel2          = New Panel()
        Panel3          = New Panel()
        pnlFooter       = New Panel()
        lblTotalRecords = New Label()
        pnlForm.SuspendLayout()
        CType(dgvProducts, ComponentModel.ISupportInitialize).BeginInit()
        pnlFooter.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        '
        ' lblPageHeader
        '
        lblPageHeader.Font      = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblPageHeader.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        lblPageHeader.Location  = New Point(12, 20)
        lblPageHeader.Name      = "lblPageHeader"
        lblPageHeader.Size      = New Size(300, 41)
        lblPageHeader.TabIndex  = 0
        lblPageHeader.Text      = "Product Management"
        '
        ' pnlForm
        '
        pnlForm.BackColor = Color.White
        pnlForm.Controls.Add(lblBarcode)
        pnlForm.Controls.Add(txtBarcode)
        pnlForm.Controls.Add(btnGenBarcode)
        pnlForm.Controls.Add(lblName)
        pnlForm.Controls.Add(txtName)
        pnlForm.Controls.Add(lblCategory)
        pnlForm.Controls.Add(cboCategory)
        pnlForm.Controls.Add(lblSupplier)
        pnlForm.Controls.Add(cboSupplier)
        pnlForm.Controls.Add(lblDescription)
        pnlForm.Controls.Add(txtDescription)
        pnlForm.Controls.Add(lblUnitPrice)
        pnlForm.Controls.Add(txtUnitPrice)
        pnlForm.Controls.Add(lblStockQty)
        pnlForm.Controls.Add(txtStockQty)
        pnlForm.Controls.Add(lblUnit)
        pnlForm.Controls.Add(cboUnit)
        pnlForm.Controls.Add(lblReorderLevel)
        pnlForm.Controls.Add(txtReorderLevel)
        pnlForm.Controls.Add(btnAdd)
        pnlForm.Controls.Add(btnUpdate)
        pnlForm.Controls.Add(btnDelete)
        pnlForm.Controls.Add(btnClear)
        pnlForm.Location = New Point(12, 6)
        pnlForm.Name     = "pnlForm"
        pnlForm.Size     = New Size(900, 300)
        pnlForm.TabIndex = 1

        Dim lblFont  As New Font("Segoe UI", 9F)
        Dim lblColor As Color = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        Dim txtFont  As New Font("Segoe UI", 10F)
        '
        ' Row 1 — Barcode & Name
        '
        lblBarcode.Font      = lblFont
        lblBarcode.ForeColor = lblColor
        lblBarcode.Location  = New Point(16, 14)
        lblBarcode.Name      = "lblBarcode"
        lblBarcode.Size      = New Size(100, 20)
        lblBarcode.TabIndex  = 0
        lblBarcode.Text      = "Barcode"

        txtBarcode.Font      = txtFont
        txtBarcode.Location  = New Point(16, 36)
        txtBarcode.MaxLength = 100
        txtBarcode.Name      = "txtBarcode"
        txtBarcode.PlaceholderText = "Scan or enter barcode"
        txtBarcode.Size      = New Size(220, 27)
        txtBarcode.TabIndex  = 1

        btnGenBarcode.BackColor = Color.FromArgb(CByte(108), CByte(117), CByte(125))
        btnGenBarcode.Cursor    = Cursors.Hand
        btnGenBarcode.FlatAppearance.BorderSize = 0
        btnGenBarcode.FlatStyle = FlatStyle.Flat
        btnGenBarcode.Font      = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnGenBarcode.ForeColor = Color.White
        btnGenBarcode.Location  = New Point(242, 36)
        btnGenBarcode.Name      = "btnGenBarcode"
        btnGenBarcode.Size      = New Size(62, 27)
        btnGenBarcode.TabIndex  = 2
        btnGenBarcode.Text      = "Gen"
        btnGenBarcode.UseVisualStyleBackColor = False

        lblName.Font      = lblFont
        lblName.ForeColor = lblColor
        lblName.Location  = New Point(320, 14)
        lblName.Name      = "lblName"
        lblName.Size      = New Size(140, 20)
        lblName.TabIndex  = 3
        lblName.Text      = "Product Name *"

        txtName.Font      = txtFont
        txtName.Location  = New Point(320, 36)
        txtName.MaxLength = 100
        txtName.Name      = "txtName"
        txtName.Size      = New Size(564, 27)
        txtName.TabIndex  = 4
        '
        ' Row 2 — Category | Supplier
        '
        lblCategory.Font      = lblFont
        lblCategory.ForeColor = lblColor
        lblCategory.Location  = New Point(16, 74)
        lblCategory.Name      = "lblCategory"
        lblCategory.Size      = New Size(120, 20)
        lblCategory.TabIndex  = 2
        lblCategory.Text      = "Category *"

        cboCategory.DropDownStyle = ComboBoxStyle.DropDownList
        cboCategory.Font          = txtFont
        cboCategory.Location      = New Point(16, 96)
        cboCategory.Name          = "cboCategory"
        cboCategory.Size          = New Size(420, 28)
        cboCategory.TabIndex      = 3

        lblSupplier.Font      = lblFont
        lblSupplier.ForeColor = lblColor
        lblSupplier.Location  = New Point(452, 74)
        lblSupplier.Name      = "lblSupplier"
        lblSupplier.Size      = New Size(120, 20)
        lblSupplier.TabIndex  = 4
        lblSupplier.Text      = "Supplier *"

        cboSupplier.DropDownStyle = ComboBoxStyle.DropDownList
        cboSupplier.Font          = txtFont
        cboSupplier.Location      = New Point(452, 96)
        cboSupplier.Name          = "cboSupplier"
        cboSupplier.Size          = New Size(432, 28)
        cboSupplier.TabIndex      = 5
        '
        ' Row 3 — Description (full width)
        '
        lblDescription.Font      = lblFont
        lblDescription.ForeColor = lblColor
        lblDescription.Location  = New Point(16, 136)
        lblDescription.Name      = "lblDescription"
        lblDescription.Size      = New Size(120, 20)
        lblDescription.TabIndex  = 6
        lblDescription.Text      = "Description"

        txtDescription.Font      = txtFont
        txtDescription.Location  = New Point(16, 158)
        txtDescription.MaxLength = 255
        txtDescription.Name      = "txtDescription"
        txtDescription.Size      = New Size(868, 27)
        txtDescription.TabIndex  = 7
        '
        ' Row 4 — UnitPrice | StockQty | Unit | ReorderLevel
        '
        lblUnitPrice.Font      = lblFont
        lblUnitPrice.ForeColor = lblColor
        lblUnitPrice.Location  = New Point(16, 196)
        lblUnitPrice.Name      = "lblUnitPrice"
        lblUnitPrice.Size      = New Size(120, 20)
        lblUnitPrice.TabIndex  = 8
        lblUnitPrice.Text      = "Unit Price *"

        txtUnitPrice.Font      = txtFont
        txtUnitPrice.Location  = New Point(16, 218)
        txtUnitPrice.MaxLength = 12
        txtUnitPrice.Name      = "txtUnitPrice"
        txtUnitPrice.Size      = New Size(200, 27)
        txtUnitPrice.TabIndex  = 9

        lblStockQty.Font      = lblFont
        lblStockQty.ForeColor = lblColor
        lblStockQty.Location  = New Point(232, 196)
        lblStockQty.Name      = "lblStockQty"
        lblStockQty.Size      = New Size(120, 20)
        lblStockQty.TabIndex  = 10
        lblStockQty.Text      = "Stock Qty *"

        txtStockQty.Font      = txtFont
        txtStockQty.Location  = New Point(232, 218)
        txtStockQty.MaxLength = 8
        txtStockQty.Name      = "txtStockQty"
        txtStockQty.Size      = New Size(200, 27)
        txtStockQty.TabIndex  = 11

        lblUnit.Font      = lblFont
        lblUnit.ForeColor = lblColor
        lblUnit.Location  = New Point(448, 196)
        lblUnit.Name      = "lblUnit"
        lblUnit.Size      = New Size(120, 20)
        lblUnit.TabIndex  = 12
        lblUnit.Text      = "Unit (pcs/box/etc)"

        cboUnit.Font      = txtFont
        cboUnit.FormattingEnabled = True
        cboUnit.Items.AddRange(New Object() {"pcs", "box", "case", "pack", "bottle", "can", "kg", "liter", "bag", "set", "roll", "pair"})
        cboUnit.Location  = New Point(448, 218)
        cboUnit.Name      = "cboUnit"
        cboUnit.Size      = New Size(200, 28)
        cboUnit.TabIndex  = 13

        lblReorderLevel.Font      = lblFont
        lblReorderLevel.ForeColor = lblColor
        lblReorderLevel.Location  = New Point(664, 196)
        lblReorderLevel.Name      = "lblReorderLevel"
        lblReorderLevel.Size      = New Size(130, 20)
        lblReorderLevel.TabIndex  = 14
        lblReorderLevel.Text      = "Reorder Level *"

        txtReorderLevel.Font      = txtFont
        txtReorderLevel.Location  = New Point(664, 218)
        txtReorderLevel.MaxLength = 8
        txtReorderLevel.Name      = "txtReorderLevel"
        txtReorderLevel.Size      = New Size(220, 27)
        txtReorderLevel.TabIndex  = 15
        '
        ' Row 5 — Buttons
        '
        btnAdd.BackColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        btnAdd.Cursor    = Cursors.Hand
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font      = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnAdd.ForeColor = Color.White
        btnAdd.Location  = New Point(16, 260)
        btnAdd.Name      = "btnAdd"
        btnAdd.Size      = New Size(78, 32)
        btnAdd.TabIndex  = 14
        btnAdd.Text      = "Add"
        btnAdd.UseVisualStyleBackColor = False

        btnUpdate.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnUpdate.Cursor    = Cursors.Hand
        btnUpdate.Enabled   = False
        btnUpdate.FlatAppearance.BorderSize = 0
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.Font      = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnUpdate.ForeColor = Color.White
        btnUpdate.Location  = New Point(102, 260)
        btnUpdate.Name      = "btnUpdate"
        btnUpdate.Size      = New Size(78, 32)
        btnUpdate.TabIndex  = 15
        btnUpdate.Text      = "Update"
        btnUpdate.UseVisualStyleBackColor = False

        btnDelete.BackColor = Color.FromArgb(CByte(192), CByte(57), CByte(43))
        btnDelete.Cursor    = Cursors.Hand
        btnDelete.Enabled   = False
        btnDelete.FlatAppearance.BorderSize = 0
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font      = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnDelete.ForeColor = Color.White
        btnDelete.Location  = New Point(188, 260)
        btnDelete.Name      = "btnDelete"
        btnDelete.Size      = New Size(78, 32)
        btnDelete.TabIndex  = 16
        btnDelete.Text      = "Delete"
        btnDelete.UseVisualStyleBackColor = False

        btnClear.BackColor = Color.FromArgb(CByte(150), CByte(155), CByte(165))
        btnClear.Cursor    = Cursors.Hand
        btnClear.FlatAppearance.BorderSize = 0
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font      = New Font("Segoe UI", 9F)
        btnClear.ForeColor = Color.White
        btnClear.Location  = New Point(274, 260)
        btnClear.Name      = "btnClear"
        btnClear.Size      = New Size(78, 32)
        btnClear.TabIndex  = 17
        btnClear.Text      = "Clear"
        btnClear.UseVisualStyleBackColor = False
        '
        ' dgvProducts
        '
        dgvProducts.AllowUserToAddRows         = False
        dgvProducts.AllowUserToDeleteRows      = False
        dgvProducts.AutoSizeColumnsMode        = DataGridViewAutoSizeColumnsMode.Fill
        dgvProducts.BackgroundColor            = Color.White
        dgvProducts.BorderStyle                = BorderStyle.None
        dgvProducts.ColumnHeadersHeight        = 36
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvProducts.Dock                       = DockStyle.Fill
        dgvProducts.Font                       = New Font("Segoe UI", 9.5F)
        dgvProducts.GridColor                  = Color.FromArgb(CByte(220), CByte(223), CByte(228))
        dgvProducts.Location                   = New Point(0, 0)
        dgvProducts.MultiSelect                = False
        dgvProducts.Name                       = "dgvProducts"
        dgvProducts.ReadOnly                   = True
        dgvProducts.RowHeadersVisible          = False
        dgvProducts.RowHeadersWidth            = 45
        dgvProducts.RowTemplate.Height         = 32
        dgvProducts.SelectionMode              = DataGridViewSelectionMode.FullRowSelect
        dgvProducts.TabIndex                   = 0
        '
        ' Panel1 — header
        '
        Panel1.Controls.Add(lblPageHeader)
        Panel1.Controls.Add(lblSearch)
        Panel1.Controls.Add(txtSearch)
        Panel1.Controls.Add(btnClearSearch)
        Panel1.Dock     = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name     = "Panel1"
        Panel1.Size     = New Size(980, 76)
        Panel1.TabIndex = 2
        '
        ' lblSearch
        '
        lblSearch.Font      = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblSearch.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblSearch.Location  = New Point(570, 26)
        lblSearch.Name      = "lblSearch"
        lblSearch.Size      = New Size(110, 22)
        lblSearch.TabIndex  = 1
        lblSearch.Text      = "Search / Scan:"
        '
        ' txtSearch
        '
        txtSearch.Font      = New Font("Segoe UI", 10F)
        txtSearch.Location  = New Point(685, 23)
        txtSearch.Name      = "txtSearch"
        txtSearch.PlaceholderText = "Scan barcode or search..."
        txtSearch.Size      = New Size(245, 27)
        txtSearch.TabIndex  = 2
        '
        ' btnClearSearch
        '
        btnClearSearch.BackColor = Color.FromArgb(CByte(220), CByte(223), CByte(228))
        btnClearSearch.Cursor    = Cursors.Hand
        btnClearSearch.FlatAppearance.BorderSize = 0
        btnClearSearch.FlatStyle = FlatStyle.Flat
        btnClearSearch.Font      = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnClearSearch.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        btnClearSearch.Location  = New Point(934, 23)
        btnClearSearch.Name      = "btnClearSearch"
        btnClearSearch.Size      = New Size(27, 27)
        btnClearSearch.TabIndex  = 3
        btnClearSearch.Text      = "X"
        btnClearSearch.UseVisualStyleBackColor = False
        '
        ' Panel2 — input card
        '
        Panel2.Controls.Add(pnlForm)
        Panel2.Dock     = DockStyle.Top
        Panel2.Location = New Point(0, 76)
        Panel2.Name     = "Panel2"
        Panel2.Size     = New Size(980, 320)
        Panel2.TabIndex = 3
        '
        ' Panel3 — grid (fills rest)
        '
        Panel3.Controls.Add(dgvProducts)
        Panel3.Controls.Add(pnlFooter)
        Panel3.Dock     = DockStyle.Fill
        Panel3.Location = New Point(0, 396)
        Panel3.Name     = "Panel3"
        Panel3.TabIndex = 4
        '
        ' pnlFooter
        '
        pnlFooter.BackColor = Color.White
        pnlFooter.Controls.Add(lblTotalRecords)
        pnlFooter.Dock     = DockStyle.Bottom
        pnlFooter.Height   = 36
        pnlFooter.Name     = "pnlFooter"
        '
        ' lblTotalRecords
        '
        lblTotalRecords.AutoSize  = True
        lblTotalRecords.Font      = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblTotalRecords.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblTotalRecords.Location  = New Point(12, 8)
        lblTotalRecords.Name      = "lblTotalRecords"
        lblTotalRecords.Text      = "Total Records: 0"
        '
        ' frmProducts
        '
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode       = AutoScaleMode.Font
        BackColor           = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        ClientSize          = New Size(980, 725)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle     = FormBorderStyle.None
        Name                = "frmProducts"
        Text                = "Product Management"
        pnlForm.ResumeLayout(False)
        pnlForm.PerformLayout()
        CType(dgvProducts, ComponentModel.ISupportInitialize).EndInit()
        pnlFooter.ResumeLayout(False)
        pnlFooter.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblPageHeader   As Label
    Friend WithEvents lblSearch       As Label
    Friend WithEvents txtSearch       As TextBox
    Friend WithEvents btnClearSearch  As Button
    Friend WithEvents pnlForm         As Panel
    Friend WithEvents lblBarcode      As Label
    Friend WithEvents txtBarcode      As TextBox
    Friend WithEvents btnGenBarcode   As Button
    Friend WithEvents lblName         As Label
    Friend WithEvents txtName         As TextBox
    Friend WithEvents lblCategory     As Label
    Friend WithEvents cboCategory     As ComboBox
    Friend WithEvents lblSupplier     As Label
    Friend WithEvents cboSupplier     As ComboBox
    Friend WithEvents lblDescription  As Label
    Friend WithEvents txtDescription  As TextBox
    Friend WithEvents lblUnitPrice    As Label
    Friend WithEvents txtUnitPrice    As TextBox
    Friend WithEvents lblStockQty     As Label
    Friend WithEvents txtStockQty     As TextBox
    Friend WithEvents lblReorderLevel As Label
    Friend WithEvents txtReorderLevel As TextBox
    Friend WithEvents lblUnit         As Label
    Friend WithEvents cboUnit         As ComboBox
    Friend WithEvents btnAdd          As Button
    Friend WithEvents btnUpdate       As Button
    Friend WithEvents btnDelete       As Button
    Friend WithEvents btnClear        As Button
    Friend WithEvents dgvProducts     As DataGridView
    Friend WithEvents Panel1          As Panel
    Friend WithEvents Panel2          As Panel
    Friend WithEvents Panel3          As Panel
    Friend WithEvents pnlFooter       As Panel
    Friend WithEvents lblTotalRecords As Label

End Class
