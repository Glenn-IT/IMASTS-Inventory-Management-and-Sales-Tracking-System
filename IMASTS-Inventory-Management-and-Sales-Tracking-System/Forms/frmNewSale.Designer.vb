<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewSale
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
        pnlInput = New Panel()
        lblScanBarcode = New Label()
        txtScanBarcode = New TextBox()
        lblScanHint = New Label()
        lblDivider = New Label()
        lblProduct = New Label()
        cboProduct = New ComboBox()
        lblQty = New Label()
        txtQty = New TextBox()
        btnAddItem = New Button()
        lblScanStatus = New Label()
        dgvSaleItems = New DataGridView()
        pnlTotals = New Panel()
        lblSumTitle = New Label()
        lblSubtotalLbl = New Label()
        txtSubtotal = New TextBox()
        lblDiscountLbl = New Label()
        txtDiscount = New TextBox()
        lblNetLbl = New Label()
        txtNetAmount = New TextBox()
        btnConfirmSale = New Button()
        btnCancelSale = New Button()
        Panel1 = New Panel()
        Panel2 = New Panel()
        pnlInput.SuspendLayout()
        CType(dgvSaleItems, ComponentModel.ISupportInitialize).BeginInit()
        pnlTotals.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
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
        lblPageHeader.Text = "New Sale"
        ' 
        ' pnlInput
        ' 
        pnlInput.BackColor = Color.White
        pnlInput.Controls.Add(lblScanBarcode)
        pnlInput.Controls.Add(txtScanBarcode)
        pnlInput.Controls.Add(lblScanHint)
        pnlInput.Controls.Add(lblDivider)
        pnlInput.Controls.Add(lblProduct)
        pnlInput.Controls.Add(cboProduct)
        pnlInput.Controls.Add(lblQty)
        pnlInput.Controls.Add(txtQty)
        pnlInput.Controls.Add(btnAddItem)
        pnlInput.Controls.Add(lblScanStatus)
        pnlInput.Dock = DockStyle.Left
        pnlInput.Location = New Point(0, 0)
        pnlInput.Name = "pnlInput"
        pnlInput.Size = New Size(265, 649)
        pnlInput.TabIndex = 0
        ' 
        ' lblScanBarcode
        ' 
        lblScanBarcode.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblScanBarcode.ForeColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        lblScanBarcode.Location = New Point(12, 14)
        lblScanBarcode.Name = "lblScanBarcode"
        lblScanBarcode.Size = New Size(241, 20)
        lblScanBarcode.TabIndex = 0
        lblScanBarcode.Text = "Scan Barcode"
        ' 
        ' txtScanBarcode
        ' 
        txtScanBarcode.Font = New Font("Segoe UI", 10.5F)
        txtScanBarcode.Location = New Point(12, 36)
        txtScanBarcode.Name = "txtScanBarcode"
        txtScanBarcode.PlaceholderText = "Ready to scan..."
        txtScanBarcode.Size = New Size(241, 28)
        txtScanBarcode.TabIndex = 1
        ' 
        ' lblScanHint
        ' 
        lblScanHint.Font = New Font("Segoe UI", 8F)
        lblScanHint.ForeColor = Color.FromArgb(CByte(140), CByte(145), CByte(155))
        lblScanHint.Location = New Point(12, 67)
        lblScanHint.Name = "lblScanHint"
        lblScanHint.Size = New Size(241, 16)
        lblScanHint.TabIndex = 2
        lblScanHint.Text = "Scan with reader or press Enter"
        ' 
        ' lblDivider
        ' 
        lblDivider.Font = New Font("Segoe UI", 8.5F)
        lblDivider.ForeColor = Color.FromArgb(CByte(180), CByte(185), CByte(195))
        lblDivider.Location = New Point(12, 90)
        lblDivider.Name = "lblDivider"
        lblDivider.Size = New Size(241, 18)
        lblDivider.TabIndex = 3
        lblDivider.Text = "──────── OR ────────"
        lblDivider.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblProduct
        ' 
        lblProduct.Font = New Font("Segoe UI", 9F)
        lblProduct.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblProduct.Location = New Point(12, 114)
        lblProduct.Name = "lblProduct"
        lblProduct.Size = New Size(180, 20)
        lblProduct.TabIndex = 4
        lblProduct.Text = "Select Product *"
        ' 
        ' cboProduct
        ' 
        cboProduct.DropDownStyle = ComboBoxStyle.DropDownList
        cboProduct.Font = New Font("Segoe UI", 10F)
        cboProduct.Location = New Point(12, 136)
        cboProduct.Name = "cboProduct"
        cboProduct.Size = New Size(241, 28)
        cboProduct.TabIndex = 5
        ' 
        ' lblQty
        ' 
        lblQty.Font = New Font("Segoe UI", 9F)
        lblQty.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblQty.Location = New Point(12, 174)
        lblQty.Name = "lblQty"
        lblQty.Size = New Size(180, 20)
        lblQty.TabIndex = 6
        lblQty.Text = "Quantity *"
        ' 
        ' txtQty
        ' 
        txtQty.Font = New Font("Segoe UI", 10F)
        txtQty.Location = New Point(12, 196)
        txtQty.MaxLength = 6
        txtQty.Name = "txtQty"
        txtQty.Size = New Size(241, 27)
        txtQty.TabIndex = 7
        ' 
        ' btnAddItem
        ' 
        btnAddItem.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnAddItem.Cursor = Cursors.Hand
        btnAddItem.FlatAppearance.BorderSize = 0
        btnAddItem.FlatStyle = FlatStyle.Flat
        btnAddItem.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnAddItem.ForeColor = Color.White
        btnAddItem.Location = New Point(12, 238)
        btnAddItem.Name = "btnAddItem"
        btnAddItem.Size = New Size(241, 34)
        btnAddItem.TabIndex = 8
        btnAddItem.Text = "Add to Sale"
        btnAddItem.UseVisualStyleBackColor = False
        ' 
        ' lblScanStatus
        ' 
        lblScanStatus.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        lblScanStatus.ForeColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        lblScanStatus.Location = New Point(12, 284)
        lblScanStatus.Name = "lblScanStatus"
        lblScanStatus.Size = New Size(241, 45)
        lblScanStatus.TabIndex = 9
        lblScanStatus.TextAlign = ContentAlignment.TopLeft
        ' 
        ' dgvSaleItems
        ' 
        dgvSaleItems.AllowUserToAddRows = False
        dgvSaleItems.AllowUserToDeleteRows = False
        dgvSaleItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvSaleItems.BackgroundColor = Color.White
        dgvSaleItems.BorderStyle = BorderStyle.None
        dgvSaleItems.ColumnHeadersHeight = 36
        dgvSaleItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvSaleItems.Dock = DockStyle.Fill
        dgvSaleItems.Font = New Font("Segoe UI", 9.5F)
        dgvSaleItems.GridColor = Color.FromArgb(CByte(220), CByte(223), CByte(228))
        dgvSaleItems.Location = New Point(265, 0)
        dgvSaleItems.MultiSelect = False
        dgvSaleItems.Name = "dgvSaleItems"
        dgvSaleItems.RowHeadersVisible = False
        dgvSaleItems.RowHeadersWidth = 45
        dgvSaleItems.RowTemplate.Height = 32
        dgvSaleItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSaleItems.Size = New Size(548, 649)
        dgvSaleItems.TabIndex = 1
        ' 
        ' pnlTotals
        ' 
        pnlTotals.BackColor = Color.White
        pnlTotals.Controls.Add(lblSumTitle)
        pnlTotals.Controls.Add(lblSubtotalLbl)
        pnlTotals.Controls.Add(txtSubtotal)
        pnlTotals.Controls.Add(lblDiscountLbl)
        pnlTotals.Controls.Add(txtDiscount)
        pnlTotals.Controls.Add(lblNetLbl)
        pnlTotals.Controls.Add(txtNetAmount)
        pnlTotals.Controls.Add(btnConfirmSale)
        pnlTotals.Controls.Add(btnCancelSale)
        pnlTotals.Dock = DockStyle.Right
        pnlTotals.Location = New Point(813, 0)
        pnlTotals.Name = "pnlTotals"
        pnlTotals.Size = New Size(167, 649)
        pnlTotals.TabIndex = 2
        ' 
        ' lblSumTitle
        ' 
        lblSumTitle.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblSumTitle.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        lblSumTitle.Location = New Point(12, 14)
        lblSumTitle.Name = "lblSumTitle"
        lblSumTitle.Size = New Size(143, 22)
        lblSumTitle.TabIndex = 0
        lblSumTitle.Text = "Sale Summary"
        ' 
        ' lblSubtotalLbl
        ' 
        lblSubtotalLbl.Font = New Font("Segoe UI", 9F)
        lblSubtotalLbl.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblSubtotalLbl.Location = New Point(12, 52)
        lblSubtotalLbl.Name = "lblSubtotalLbl"
        lblSubtotalLbl.Size = New Size(143, 18)
        lblSubtotalLbl.TabIndex = 1
        lblSubtotalLbl.Text = "Subtotal"
        ' 
        ' txtSubtotal
        ' 
        txtSubtotal.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        txtSubtotal.Font = New Font("Segoe UI", 10F)
        txtSubtotal.Location = New Point(12, 72)
        txtSubtotal.Name = "txtSubtotal"
        txtSubtotal.ReadOnly = True
        txtSubtotal.Size = New Size(143, 27)
        txtSubtotal.TabIndex = 2
        txtSubtotal.Text = "0.00"
        txtSubtotal.TextAlign = HorizontalAlignment.Right
        ' 
        ' lblDiscountLbl
        ' 
        lblDiscountLbl.Font = New Font("Segoe UI", 9F)
        lblDiscountLbl.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblDiscountLbl.Location = New Point(12, 112)
        lblDiscountLbl.Name = "lblDiscountLbl"
        lblDiscountLbl.Size = New Size(143, 18)
        lblDiscountLbl.TabIndex = 3
        lblDiscountLbl.Text = "Discount"
        ' 
        ' txtDiscount
        ' 
        txtDiscount.Font = New Font("Segoe UI", 10F)
        txtDiscount.Location = New Point(12, 132)
        txtDiscount.MaxLength = 10
        txtDiscount.Name = "txtDiscount"
        txtDiscount.Size = New Size(143, 27)
        txtDiscount.TabIndex = 4
        txtDiscount.Text = "0"
        txtDiscount.TextAlign = HorizontalAlignment.Right
        ' 
        ' lblNetLbl
        ' 
        lblNetLbl.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblNetLbl.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        lblNetLbl.Location = New Point(12, 174)
        lblNetLbl.Name = "lblNetLbl"
        lblNetLbl.Size = New Size(143, 20)
        lblNetLbl.TabIndex = 5
        lblNetLbl.Text = "Net Amount"
        ' 
        ' txtNetAmount
        ' 
        txtNetAmount.BackColor = Color.FromArgb(CByte(232), CByte(245), CByte(233))
        txtNetAmount.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        txtNetAmount.ForeColor = Color.FromArgb(CByte(27), CByte(94), CByte(32))
        txtNetAmount.Location = New Point(12, 196)
        txtNetAmount.Name = "txtNetAmount"
        txtNetAmount.ReadOnly = True
        txtNetAmount.Size = New Size(143, 31)
        txtNetAmount.TabIndex = 6
        txtNetAmount.Text = "0.00"
        txtNetAmount.TextAlign = HorizontalAlignment.Right
        ' 
        ' btnConfirmSale
        ' 
        btnConfirmSale.BackColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        btnConfirmSale.Cursor = Cursors.Hand
        btnConfirmSale.FlatAppearance.BorderSize = 0
        btnConfirmSale.FlatStyle = FlatStyle.Flat
        btnConfirmSale.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnConfirmSale.ForeColor = Color.White
        btnConfirmSale.Location = New Point(12, 246)
        btnConfirmSale.Name = "btnConfirmSale"
        btnConfirmSale.Size = New Size(143, 36)
        btnConfirmSale.TabIndex = 7
        btnConfirmSale.Text = "Confirm Sale"
        btnConfirmSale.UseVisualStyleBackColor = False
        ' 
        ' btnCancelSale
        ' 
        btnCancelSale.BackColor = Color.FromArgb(CByte(192), CByte(57), CByte(43))
        btnCancelSale.Cursor = Cursors.Hand
        btnCancelSale.FlatAppearance.BorderSize = 0
        btnCancelSale.FlatStyle = FlatStyle.Flat
        btnCancelSale.Font = New Font("Segoe UI", 9F)
        btnCancelSale.ForeColor = Color.White
        btnCancelSale.Location = New Point(12, 290)
        btnCancelSale.Name = "btnCancelSale"
        btnCancelSale.Size = New Size(143, 30)
        btnCancelSale.TabIndex = 8
        btnCancelSale.Text = "Cancel Sale"
        btnCancelSale.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lblPageHeader)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(980, 76)
        Panel1.TabIndex = 1
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(dgvSaleItems)
        Panel2.Controls.Add(pnlTotals)
        Panel2.Controls.Add(pnlInput)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 76)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(980, 649)
        Panel2.TabIndex = 2
        ' 
        ' frmNewSale
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        ClientSize = New Size(980, 725)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmNewSale"
        Text = "New Sale"
        pnlInput.ResumeLayout(False)
        pnlInput.PerformLayout()
        CType(dgvSaleItems, ComponentModel.ISupportInitialize).EndInit()
        pnlTotals.ResumeLayout(False)
        pnlTotals.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblPageHeader   As Label
    Friend WithEvents pnlInput        As Panel
    Friend WithEvents lblScanBarcode  As Label
    Friend WithEvents txtScanBarcode  As TextBox
    Friend WithEvents lblScanHint     As Label
    Friend WithEvents lblDivider      As Label
    Friend WithEvents lblProduct      As Label
    Friend WithEvents cboProduct      As ComboBox
    Friend WithEvents lblQty          As Label
    Friend WithEvents txtQty          As TextBox
    Friend WithEvents btnAddItem      As Button
    Friend WithEvents lblScanStatus   As Label
    Friend WithEvents dgvSaleItems    As DataGridView
    Friend WithEvents pnlTotals       As Panel
    Friend WithEvents lblSumTitle     As Label
    Friend WithEvents lblSubtotalLbl  As Label
    Friend WithEvents txtSubtotal     As TextBox
    Friend WithEvents lblDiscountLbl  As Label
    Friend WithEvents txtDiscount     As TextBox
    Friend WithEvents lblNetLbl       As Label
    Friend WithEvents txtNetAmount    As TextBox
    Friend WithEvents btnConfirmSale  As Button
    Friend WithEvents btnCancelSale   As Button
    Friend WithEvents Panel1          As Panel
    Friend WithEvents Panel2          As Panel

End Class
