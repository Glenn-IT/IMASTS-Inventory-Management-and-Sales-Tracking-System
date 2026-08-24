<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInventory
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
        Panel1 = New Panel()
        lblSearch = New Label()
        txtSearch = New TextBox()
        btnClearSearch = New Button()
        Panel2 = New Panel()
        pnlForm = New Panel()
        lblBarcode = New Label()
        txtBarcode = New TextBox()
        lblProduct = New Label()
        cboProduct = New ComboBox()
        lblCategory = New Label()
        txtCategory = New TextBox()
        lblCurrentStock = New Label()
        txtCurrentStock = New TextBox()
        lblUnit = New Label()
        txtUnit = New TextBox()
        lblSupplier = New Label()
        cboSupplier = New ComboBox()
        lblQuantity = New Label()
        txtQuantity = New TextBox()
        lblNotes = New Label()
        txtNotes = New TextBox()
        btnReceiveStock = New Button()
        btnAdjustStock = New Button()
        btnClear = New Button()
        btnRefresh = New Button()
        Panel3 = New Panel()
        dgvInventory = New DataGridView()
        pnlFooter = New Panel()
        lblTotalRecords = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        pnlForm.SuspendLayout()
        Panel3.SuspendLayout()
        CType(dgvInventory, ComponentModel.ISupportInitialize).BeginInit()
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
        lblPageHeader.Text = "Inventory Management"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lblPageHeader)
        Panel1.Controls.Add(lblSearch)
        Panel1.Controls.Add(txtSearch)
        Panel1.Controls.Add(btnClearSearch)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(980, 76)
        Panel1.TabIndex = 1
        ' 
        ' lblSearch
        ' 
        lblSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblSearch.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblSearch.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblSearch.Location = New Point(570, 26)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(110, 22)
        lblSearch.TabIndex = 1
        lblSearch.Text = "Search / Scan:"
        ' 
        ' txtSearch
        ' 
        txtSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txtSearch.Font = New Font("Segoe UI", 10F)
        txtSearch.Location = New Point(685, 23)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = "Scan barcode or search..."
        txtSearch.Size = New Size(245, 27)
        txtSearch.TabIndex = 2
        ' 
        ' btnClearSearch
        ' 
        btnClearSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClearSearch.BackColor = Color.FromArgb(CByte(220), CByte(223), CByte(228))
        btnClearSearch.Cursor = Cursors.Hand
        btnClearSearch.FlatAppearance.BorderSize = 0
        btnClearSearch.FlatStyle = FlatStyle.Flat
        btnClearSearch.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnClearSearch.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        btnClearSearch.Location = New Point(934, 23)
        btnClearSearch.Name = "btnClearSearch"
        btnClearSearch.Size = New Size(27, 27)
        btnClearSearch.TabIndex = 3
        btnClearSearch.Text = "X"
        btnClearSearch.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(pnlForm)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 76)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(980, 205)
        Panel2.TabIndex = 2
        ' 
        ' pnlForm
        ' 
        pnlForm.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlForm.BackColor = Color.White
        pnlForm.Controls.Add(lblBarcode)
        pnlForm.Controls.Add(txtBarcode)
        pnlForm.Controls.Add(lblProduct)
        pnlForm.Controls.Add(cboProduct)
        pnlForm.Controls.Add(lblCategory)
        pnlForm.Controls.Add(txtCategory)
        pnlForm.Controls.Add(lblCurrentStock)
        pnlForm.Controls.Add(txtCurrentStock)
        pnlForm.Controls.Add(lblUnit)
        pnlForm.Controls.Add(txtUnit)
        pnlForm.Controls.Add(lblSupplier)
        pnlForm.Controls.Add(cboSupplier)
        pnlForm.Controls.Add(lblQuantity)
        pnlForm.Controls.Add(txtQuantity)
        pnlForm.Controls.Add(lblNotes)
        pnlForm.Controls.Add(txtNotes)
        pnlForm.Controls.Add(btnReceiveStock)
        pnlForm.Controls.Add(btnAdjustStock)
        pnlForm.Controls.Add(btnClear)
        pnlForm.Controls.Add(btnRefresh)
        pnlForm.Location = New Point(12, 6)
        pnlForm.Name = "pnlForm"
        pnlForm.Size = New Size(956, 192)
        pnlForm.TabIndex = 0
        ' 
        ' lblBarcode
        ' 
        lblBarcode.Font = New Font("Segoe UI", 9F)
        lblBarcode.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblBarcode.Location = New Point(16, 12)
        lblBarcode.Name = "lblBarcode"
        lblBarcode.Size = New Size(120, 18)
        lblBarcode.TabIndex = 0
        lblBarcode.Text = "Barcode / Scan"
        ' 
        ' txtBarcode
        ' 
        txtBarcode.Font = New Font("Segoe UI", 10F)
        txtBarcode.Location = New Point(16, 32)
        txtBarcode.MaxLength = 100
        txtBarcode.Name = "txtBarcode"
        txtBarcode.PlaceholderText = "Scan or enter barcode"
        txtBarcode.Size = New Size(180, 27)
        txtBarcode.TabIndex = 1
        ' 
        ' lblProduct
        ' 
        lblProduct.Font = New Font("Segoe UI", 9F)
        lblProduct.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblProduct.Location = New Point(206, 12)
        lblProduct.Name = "lblProduct"
        lblProduct.Size = New Size(120, 18)
        lblProduct.TabIndex = 2
        lblProduct.Text = "Product *"
        ' 
        ' cboProduct
        ' 
        cboProduct.DropDownStyle = ComboBoxStyle.DropDownList
        cboProduct.Font = New Font("Segoe UI", 10F)
        cboProduct.Location = New Point(206, 32)
        cboProduct.Name = "cboProduct"
        cboProduct.Size = New Size(290, 28)
        cboProduct.TabIndex = 3
        ' 
        ' lblCategory
        ' 
        lblCategory.Font = New Font("Segoe UI", 9F)
        lblCategory.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblCategory.Location = New Point(506, 12)
        lblCategory.Name = "lblCategory"
        lblCategory.Size = New Size(100, 18)
        lblCategory.TabIndex = 4
        lblCategory.Text = "Category"
        ' 
        ' txtCategory
        ' 
        txtCategory.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        txtCategory.Font = New Font("Segoe UI", 10F)
        txtCategory.Location = New Point(506, 32)
        txtCategory.Name = "txtCategory"
        txtCategory.ReadOnly = True
        txtCategory.Size = New Size(140, 27)
        txtCategory.TabIndex = 5
        ' 
        ' lblCurrentStock
        ' 
        lblCurrentStock.Font = New Font("Segoe UI", 9F)
        lblCurrentStock.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblCurrentStock.Location = New Point(656, 12)
        lblCurrentStock.Name = "lblCurrentStock"
        lblCurrentStock.Size = New Size(110, 18)
        lblCurrentStock.TabIndex = 6
        lblCurrentStock.Text = "Current Stock"
        ' 
        ' txtCurrentStock
        ' 
        txtCurrentStock.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        txtCurrentStock.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        txtCurrentStock.Location = New Point(656, 32)
        txtCurrentStock.Name = "txtCurrentStock"
        txtCurrentStock.ReadOnly = True
        txtCurrentStock.Size = New Size(140, 27)
        txtCurrentStock.TabIndex = 7
        txtCurrentStock.TextAlign = HorizontalAlignment.Right
        ' 
        ' lblUnit
        ' 
        lblUnit.Font = New Font("Segoe UI", 9F)
        lblUnit.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblUnit.Location = New Point(806, 12)
        lblUnit.Name = "lblUnit"
        lblUnit.Size = New Size(80, 18)
        lblUnit.TabIndex = 8
        lblUnit.Text = "Unit"
        ' 
        ' txtUnit
        ' 
        txtUnit.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtUnit.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        txtUnit.Font = New Font("Segoe UI", 10F)
        txtUnit.Location = New Point(806, 32)
        txtUnit.Name = "txtUnit"
        txtUnit.ReadOnly = True
        txtUnit.Size = New Size(134, 27)
        txtUnit.TabIndex = 9
        ' 
        ' lblSupplier
        ' 
        lblSupplier.Font = New Font("Segoe UI", 9F)
        lblSupplier.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblSupplier.Location = New Point(16, 70)
        lblSupplier.Name = "lblSupplier"
        lblSupplier.Size = New Size(170, 18)
        lblSupplier.TabIndex = 10
        lblSupplier.Text = "Supplier (for receiving)"
        ' 
        ' cboSupplier
        ' 
        cboSupplier.DropDownStyle = ComboBoxStyle.DropDownList
        cboSupplier.Font = New Font("Segoe UI", 10F)
        cboSupplier.Location = New Point(16, 92)
        cboSupplier.Name = "cboSupplier"
        cboSupplier.Size = New Size(270, 28)
        cboSupplier.TabIndex = 11
        ' 
        ' lblQuantity
        ' 
        lblQuantity.Font = New Font("Segoe UI", 9F)
        lblQuantity.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblQuantity.Location = New Point(296, 70)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(200, 18)
        lblQuantity.TabIndex = 12
        lblQuantity.Text = "Quantity / New Stock *"
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Font = New Font("Segoe UI", 10F)
        txtQuantity.Location = New Point(296, 92)
        txtQuantity.MaxLength = 8
        txtQuantity.Name = "txtQuantity"
        txtQuantity.PlaceholderText = "Enter quantity"
        txtQuantity.Size = New Size(200, 27)
        txtQuantity.TabIndex = 13
        ' 
        ' lblNotes
        ' 
        lblNotes.Font = New Font("Segoe UI", 9F)
        lblNotes.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblNotes.Location = New Point(506, 70)
        lblNotes.Name = "lblNotes"
        lblNotes.Size = New Size(120, 18)
        lblNotes.TabIndex = 14
        lblNotes.Text = "Reason / Notes"
        ' 
        ' txtNotes
        ' 
        txtNotes.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtNotes.Font = New Font("Segoe UI", 10F)
        txtNotes.Location = New Point(506, 92)
        txtNotes.MaxLength = 255
        txtNotes.Name = "txtNotes"
        txtNotes.PlaceholderText = "Optional notes or adjustment reason..."
        txtNotes.Size = New Size(434, 27)
        txtNotes.TabIndex = 15
        ' 
        ' btnReceiveStock
        ' 
        btnReceiveStock.BackColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        btnReceiveStock.Cursor = Cursors.Hand
        btnReceiveStock.FlatAppearance.BorderSize = 0
        btnReceiveStock.FlatStyle = FlatStyle.Flat
        btnReceiveStock.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnReceiveStock.ForeColor = Color.White
        btnReceiveStock.Location = New Point(16, 138)
        btnReceiveStock.Name = "btnReceiveStock"
        btnReceiveStock.Size = New Size(170, 36)
        btnReceiveStock.TabIndex = 16
        btnReceiveStock.Text = "+ Receive Stock"
        btnReceiveStock.UseVisualStyleBackColor = False
        ' 
        ' btnAdjustStock
        ' 
        btnAdjustStock.BackColor = Color.FromArgb(CByte(230), CByte(126), CByte(34))
        btnAdjustStock.Cursor = Cursors.Hand
        btnAdjustStock.FlatAppearance.BorderSize = 0
        btnAdjustStock.FlatStyle = FlatStyle.Flat
        btnAdjustStock.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnAdjustStock.ForeColor = Color.White
        btnAdjustStock.Location = New Point(196, 138)
        btnAdjustStock.Name = "btnAdjustStock"
        btnAdjustStock.Size = New Size(170, 36)
        btnAdjustStock.TabIndex = 17
        btnAdjustStock.Text = "✎ Adjust Stock"
        btnAdjustStock.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.FromArgb(CByte(150), CByte(155), CByte(165))
        btnClear.Cursor = Cursors.Hand
        btnClear.FlatAppearance.BorderSize = 0
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 9.5F)
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(376, 138)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(90, 36)
        btnClear.TabIndex = 18
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnRefresh.Cursor = Cursors.Hand
        btnRefresh.FlatAppearance.BorderSize = 0
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 9.5F)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(476, 138)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(90, 36)
        btnRefresh.TabIndex = 19
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(dgvInventory)
        Panel3.Controls.Add(pnlFooter)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(0, 281)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(980, 444)
        Panel3.TabIndex = 3
        ' 
        ' dgvInventory
        ' 
        dgvInventory.AllowUserToAddRows = False
        dgvInventory.AllowUserToDeleteRows = False
        dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvInventory.BackgroundColor = Color.White
        dgvInventory.BorderStyle = BorderStyle.None
        dgvInventory.ColumnHeadersHeight = 36
        dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvInventory.Dock = DockStyle.Fill
        dgvInventory.Font = New Font("Segoe UI", 9.5F)
        dgvInventory.GridColor = Color.FromArgb(CByte(220), CByte(223), CByte(228))
        dgvInventory.Location = New Point(0, 0)
        dgvInventory.MultiSelect = False
        dgvInventory.Name = "dgvInventory"
        dgvInventory.ReadOnly = True
        dgvInventory.RowHeadersVisible = False
        dgvInventory.RowHeadersWidth = 45
        dgvInventory.RowTemplate.Height = 32
        dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvInventory.Size = New Size(980, 408)
        dgvInventory.TabIndex = 0
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.White
        pnlFooter.Controls.Add(lblTotalRecords)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 408)
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
        ' frmInventory
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        ClientSize = New Size(980, 725)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmInventory"
        Text = "Inventory Management"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        pnlForm.ResumeLayout(False)
        pnlForm.PerformLayout()
        Panel3.ResumeLayout(False)
        CType(dgvInventory, ComponentModel.ISupportInitialize).EndInit()
        pnlFooter.ResumeLayout(False)
        pnlFooter.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblPageHeader As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnClearSearch As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlForm As Panel
    Friend WithEvents lblBarcode As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents lblProduct As Label
    Friend WithEvents cboProduct As ComboBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents txtCategory As TextBox
    Friend WithEvents lblCurrentStock As Label
    Friend WithEvents txtCurrentStock As TextBox
    Friend WithEvents lblUnit As Label
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents lblSupplier As Label
    Friend WithEvents cboSupplier As ComboBox
    Friend WithEvents lblQuantity As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents lblNotes As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents btnReceiveStock As Button
    Friend WithEvents btnAdjustStock As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dgvInventory As DataGridView
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents lblTotalRecords As Label

End Class
