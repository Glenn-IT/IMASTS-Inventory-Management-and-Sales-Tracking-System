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
        btnReceiveStock = New Button()
        btnAdjustStock = New Button()
        btnRefresh = New Button()
        dgvInventory = New DataGridView()
        pnlReceive = New Panel()
        lblReceiveTitle = New Label()
        lblRProduct = New Label()
        cboProduct = New ComboBox()
        lblRSupplier = New Label()
        cboSupplier = New ComboBox()
        lblRQty = New Label()
        txtQuantity = New TextBox()
        lblRNotes = New Label()
        txtNotes = New TextBox()
        btnConfirmReceipt = New Button()
        btnCancelReceipt = New Button()
        pnlAdjust = New Panel()
        lblAdjTitle = New Label()
        lblAdjProduct = New Label()
        cboAdjProduct = New ComboBox()
        lblAdjNewQty = New Label()
        txtNewQty = New TextBox()
        lblAdjNotes = New Label()
        txtAdjNotes = New TextBox()
        btnConfirmAdjust = New Button()
        btnCancelAdjust = New Button()
        Panel1 = New Panel()
        Panel2 = New Panel()
        pnlDetail = New Panel()
        pnlActionBar = New Panel()
        CType(dgvInventory, ComponentModel.ISupportInitialize).BeginInit()
        pnlReceive.SuspendLayout()
        pnlAdjust.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        pnlDetail.SuspendLayout()
        pnlActionBar.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblPageHeader
        ' 
        lblPageHeader.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblPageHeader.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        lblPageHeader.Location = New Point(12, 20)
        lblPageHeader.Name = "lblPageHeader"
        lblPageHeader.Size = New Size(400, 41)
        lblPageHeader.TabIndex = 0
        lblPageHeader.Text = "Inventory Management"
        ' 
        ' btnReceiveStock
        ' 
        btnReceiveStock.BackColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        btnReceiveStock.Cursor = Cursors.Hand
        btnReceiveStock.FlatAppearance.BorderSize = 0
        btnReceiveStock.FlatStyle = FlatStyle.Flat
        btnReceiveStock.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnReceiveStock.ForeColor = Color.White
        btnReceiveStock.Location = New Point(12, 10)
        btnReceiveStock.Name = "btnReceiveStock"
        btnReceiveStock.Size = New Size(140, 32)
        btnReceiveStock.TabIndex = 0
        btnReceiveStock.Text = "Receive Stock"
        btnReceiveStock.UseVisualStyleBackColor = False
        ' 
        ' btnAdjustStock
        ' 
        btnAdjustStock.BackColor = Color.FromArgb(CByte(230), CByte(126), CByte(34))
        btnAdjustStock.Cursor = Cursors.Hand
        btnAdjustStock.FlatAppearance.BorderSize = 0
        btnAdjustStock.FlatStyle = FlatStyle.Flat
        btnAdjustStock.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnAdjustStock.ForeColor = Color.White
        btnAdjustStock.Location = New Point(160, 10)
        btnAdjustStock.Name = "btnAdjustStock"
        btnAdjustStock.Size = New Size(140, 32)
        btnAdjustStock.TabIndex = 1
        btnAdjustStock.Text = "Adjust Stock"
        btnAdjustStock.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(CByte(150), CByte(155), CByte(165))
        btnRefresh.Cursor = Cursors.Hand
        btnRefresh.FlatAppearance.BorderSize = 0
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 9F)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(308, 10)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(100, 32)
        btnRefresh.TabIndex = 2
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
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
        dgvInventory.Location = New Point(0, 52)
        dgvInventory.MultiSelect = False
        dgvInventory.Name = "dgvInventory"
        dgvInventory.ReadOnly = True
        dgvInventory.RowHeadersVisible = False
        dgvInventory.RowHeadersWidth = 45
        dgvInventory.RowTemplate.Height = 32
        dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvInventory.Size = New Size(980, 382)
        dgvInventory.TabIndex = 3
        ' 
        ' pnlReceive
        ' 
        pnlReceive.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlReceive.BackColor = Color.White
        pnlReceive.Controls.Add(lblReceiveTitle)
        pnlReceive.Controls.Add(lblRProduct)
        pnlReceive.Controls.Add(cboProduct)
        pnlReceive.Controls.Add(lblRSupplier)
        pnlReceive.Controls.Add(cboSupplier)
        pnlReceive.Controls.Add(lblRQty)
        pnlReceive.Controls.Add(txtQuantity)
        pnlReceive.Controls.Add(lblRNotes)
        pnlReceive.Controls.Add(txtNotes)
        pnlReceive.Controls.Add(btnConfirmReceipt)
        pnlReceive.Controls.Add(btnCancelReceipt)
        pnlReceive.Location = New Point(0, 0)
        pnlReceive.Name = "pnlReceive"
        pnlReceive.Size = New Size(1760, 215)
        pnlReceive.TabIndex = 4
        pnlReceive.Visible = False
        ' 
        ' lblReceiveTitle
        ' 
        lblReceiveTitle.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblReceiveTitle.ForeColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        lblReceiveTitle.Location = New Point(16, 12)
        lblReceiveTitle.Name = "lblReceiveTitle"
        lblReceiveTitle.Size = New Size(200, 22)
        lblReceiveTitle.TabIndex = 0
        lblReceiveTitle.Text = "Receive Stock"
        ' 
        ' lblRProduct
        ' 
        lblRProduct.Font = New Font("Segoe UI", 9F)
        lblRProduct.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblRProduct.Location = New Point(16, 44)
        lblRProduct.Name = "lblRProduct"
        lblRProduct.Size = New Size(150, 20)
        lblRProduct.TabIndex = 1
        lblRProduct.Text = "Product *"
        ' 
        ' cboProduct
        ' 
        cboProduct.DropDownStyle = ComboBoxStyle.DropDownList
        cboProduct.Font = New Font("Segoe UI", 10F)
        cboProduct.Location = New Point(16, 66)
        cboProduct.Name = "cboProduct"
        cboProduct.Size = New Size(420, 28)
        cboProduct.TabIndex = 2
        ' 
        ' lblRSupplier
        ' 
        lblRSupplier.Font = New Font("Segoe UI", 9F)
        lblRSupplier.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblRSupplier.Location = New Point(452, 44)
        lblRSupplier.Name = "lblRSupplier"
        lblRSupplier.Size = New Size(150, 20)
        lblRSupplier.TabIndex = 3
        lblRSupplier.Text = "Supplier *"
        ' 
        ' cboSupplier
        ' 
        cboSupplier.DropDownStyle = ComboBoxStyle.DropDownList
        cboSupplier.Font = New Font("Segoe UI", 10F)
        cboSupplier.Location = New Point(452, 66)
        cboSupplier.Name = "cboSupplier"
        cboSupplier.Size = New Size(452, 28)
        cboSupplier.TabIndex = 4
        ' 
        ' lblRQty
        ' 
        lblRQty.Font = New Font("Segoe UI", 9F)
        lblRQty.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblRQty.Location = New Point(16, 106)
        lblRQty.Name = "lblRQty"
        lblRQty.Size = New Size(150, 20)
        lblRQty.TabIndex = 5
        lblRQty.Text = "Quantity *"
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Font = New Font("Segoe UI", 10F)
        txtQuantity.Location = New Point(16, 128)
        txtQuantity.MaxLength = 8
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(180, 27)
        txtQuantity.TabIndex = 6
        ' 
        ' lblRNotes
        ' 
        lblRNotes.Font = New Font("Segoe UI", 9F)
        lblRNotes.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblRNotes.Location = New Point(212, 106)
        lblRNotes.Name = "lblRNotes"
        lblRNotes.Size = New Size(100, 20)
        lblRNotes.TabIndex = 7
        lblRNotes.Text = "Notes"
        ' 
        ' txtNotes
        ' 
        txtNotes.Font = New Font("Segoe UI", 10F)
        txtNotes.Location = New Point(212, 128)
        txtNotes.MaxLength = 255
        txtNotes.Name = "txtNotes"
        txtNotes.Size = New Size(692, 27)
        txtNotes.TabIndex = 8
        ' 
        ' btnConfirmReceipt
        ' 
        btnConfirmReceipt.BackColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        btnConfirmReceipt.Cursor = Cursors.Hand
        btnConfirmReceipt.FlatAppearance.BorderSize = 0
        btnConfirmReceipt.FlatStyle = FlatStyle.Flat
        btnConfirmReceipt.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnConfirmReceipt.ForeColor = Color.White
        btnConfirmReceipt.Location = New Point(16, 164)
        btnConfirmReceipt.Name = "btnConfirmReceipt"
        btnConfirmReceipt.Size = New Size(130, 30)
        btnConfirmReceipt.TabIndex = 9
        btnConfirmReceipt.Text = "Confirm Receipt"
        btnConfirmReceipt.UseVisualStyleBackColor = False
        ' 
        ' btnCancelReceipt
        ' 
        btnCancelReceipt.BackColor = Color.FromArgb(CByte(150), CByte(155), CByte(165))
        btnCancelReceipt.Cursor = Cursors.Hand
        btnCancelReceipt.FlatAppearance.BorderSize = 0
        btnCancelReceipt.FlatStyle = FlatStyle.Flat
        btnCancelReceipt.Font = New Font("Segoe UI", 9F)
        btnCancelReceipt.ForeColor = Color.White
        btnCancelReceipt.Location = New Point(154, 164)
        btnCancelReceipt.Name = "btnCancelReceipt"
        btnCancelReceipt.Size = New Size(100, 30)
        btnCancelReceipt.TabIndex = 10
        btnCancelReceipt.Text = "Cancel"
        btnCancelReceipt.UseVisualStyleBackColor = False
        ' 
        ' pnlAdjust
        ' 
        pnlAdjust.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlAdjust.BackColor = Color.White
        pnlAdjust.Controls.Add(lblAdjTitle)
        pnlAdjust.Controls.Add(lblAdjProduct)
        pnlAdjust.Controls.Add(cboAdjProduct)
        pnlAdjust.Controls.Add(lblAdjNewQty)
        pnlAdjust.Controls.Add(txtNewQty)
        pnlAdjust.Controls.Add(lblAdjNotes)
        pnlAdjust.Controls.Add(txtAdjNotes)
        pnlAdjust.Controls.Add(btnConfirmAdjust)
        pnlAdjust.Controls.Add(btnCancelAdjust)
        pnlAdjust.Location = New Point(0, 0)
        pnlAdjust.Name = "pnlAdjust"
        pnlAdjust.Size = New Size(1760, 215)
        pnlAdjust.TabIndex = 5
        pnlAdjust.Visible = False
        ' 
        ' lblAdjTitle
        ' 
        lblAdjTitle.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblAdjTitle.ForeColor = Color.FromArgb(CByte(230), CByte(126), CByte(34))
        lblAdjTitle.Location = New Point(16, 12)
        lblAdjTitle.Name = "lblAdjTitle"
        lblAdjTitle.Size = New Size(200, 22)
        lblAdjTitle.TabIndex = 0
        lblAdjTitle.Text = "Adjust Stock"
        ' 
        ' lblAdjProduct
        ' 
        lblAdjProduct.Font = New Font("Segoe UI", 9F)
        lblAdjProduct.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblAdjProduct.Location = New Point(16, 44)
        lblAdjProduct.Name = "lblAdjProduct"
        lblAdjProduct.Size = New Size(150, 20)
        lblAdjProduct.TabIndex = 1
        lblAdjProduct.Text = "Product *"
        ' 
        ' cboAdjProduct
        ' 
        cboAdjProduct.DropDownStyle = ComboBoxStyle.DropDownList
        cboAdjProduct.Font = New Font("Segoe UI", 10F)
        cboAdjProduct.Location = New Point(16, 66)
        cboAdjProduct.Name = "cboAdjProduct"
        cboAdjProduct.Size = New Size(888, 28)
        cboAdjProduct.TabIndex = 2
        ' 
        ' lblAdjNewQty
        ' 
        lblAdjNewQty.Font = New Font("Segoe UI", 9F)
        lblAdjNewQty.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblAdjNewQty.Location = New Point(16, 106)
        lblAdjNewQty.Name = "lblAdjNewQty"
        lblAdjNewQty.Size = New Size(150, 20)
        lblAdjNewQty.TabIndex = 3
        lblAdjNewQty.Text = "New Quantity *"
        ' 
        ' txtNewQty
        ' 
        txtNewQty.Font = New Font("Segoe UI", 10F)
        txtNewQty.Location = New Point(16, 128)
        txtNewQty.MaxLength = 8
        txtNewQty.Name = "txtNewQty"
        txtNewQty.Size = New Size(180, 27)
        txtNewQty.TabIndex = 4
        ' 
        ' lblAdjNotes
        ' 
        lblAdjNotes.Font = New Font("Segoe UI", 9F)
        lblAdjNotes.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblAdjNotes.Location = New Point(212, 106)
        lblAdjNotes.Name = "lblAdjNotes"
        lblAdjNotes.Size = New Size(130, 20)
        lblAdjNotes.TabIndex = 5
        lblAdjNotes.Text = "Reason / Notes"
        ' 
        ' txtAdjNotes
        ' 
        txtAdjNotes.Font = New Font("Segoe UI", 10F)
        txtAdjNotes.Location = New Point(212, 128)
        txtAdjNotes.MaxLength = 255
        txtAdjNotes.Name = "txtAdjNotes"
        txtAdjNotes.Size = New Size(692, 27)
        txtAdjNotes.TabIndex = 6
        ' 
        ' btnConfirmAdjust
        ' 
        btnConfirmAdjust.BackColor = Color.FromArgb(CByte(230), CByte(126), CByte(34))
        btnConfirmAdjust.Cursor = Cursors.Hand
        btnConfirmAdjust.FlatAppearance.BorderSize = 0
        btnConfirmAdjust.FlatStyle = FlatStyle.Flat
        btnConfirmAdjust.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnConfirmAdjust.ForeColor = Color.White
        btnConfirmAdjust.Location = New Point(16, 164)
        btnConfirmAdjust.Name = "btnConfirmAdjust"
        btnConfirmAdjust.Size = New Size(140, 30)
        btnConfirmAdjust.TabIndex = 7
        btnConfirmAdjust.Text = "Confirm Adjustment"
        btnConfirmAdjust.UseVisualStyleBackColor = False
        ' 
        ' btnCancelAdjust
        ' 
        btnCancelAdjust.BackColor = Color.FromArgb(CByte(150), CByte(155), CByte(165))
        btnCancelAdjust.Cursor = Cursors.Hand
        btnCancelAdjust.FlatAppearance.BorderSize = 0
        btnCancelAdjust.FlatStyle = FlatStyle.Flat
        btnCancelAdjust.Font = New Font("Segoe UI", 9F)
        btnCancelAdjust.ForeColor = Color.White
        btnCancelAdjust.Location = New Point(164, 164)
        btnCancelAdjust.Name = "btnCancelAdjust"
        btnCancelAdjust.Size = New Size(100, 30)
        btnCancelAdjust.TabIndex = 8
        btnCancelAdjust.Text = "Cancel"
        btnCancelAdjust.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lblPageHeader)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(980, 76)
        Panel1.TabIndex = 2
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(dgvInventory)
        Panel2.Controls.Add(pnlDetail)
        Panel2.Controls.Add(pnlActionBar)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 76)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(980, 649)
        Panel2.TabIndex = 3
        ' 
        ' pnlDetail
        ' 
        pnlDetail.Controls.Add(pnlReceive)
        pnlDetail.Controls.Add(pnlAdjust)
        pnlDetail.Dock = DockStyle.Bottom
        pnlDetail.Location = New Point(0, 434)
        pnlDetail.Name = "pnlDetail"
        pnlDetail.Size = New Size(980, 215)
        pnlDetail.TabIndex = 7
        pnlDetail.Visible = False
        ' 
        ' pnlActionBar
        ' 
        pnlActionBar.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        pnlActionBar.Controls.Add(btnReceiveStock)
        pnlActionBar.Controls.Add(btnAdjustStock)
        pnlActionBar.Controls.Add(btnRefresh)
        pnlActionBar.Dock = DockStyle.Top
        pnlActionBar.Location = New Point(0, 0)
        pnlActionBar.Name = "pnlActionBar"
        pnlActionBar.Size = New Size(980, 52)
        pnlActionBar.TabIndex = 6
        ' 
        ' frmInventory
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        ClientSize = New Size(980, 725)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmInventory"
        Text = "Inventory Management"
        WindowState = FormWindowState.Maximized
        CType(dgvInventory, ComponentModel.ISupportInitialize).EndInit()
        pnlReceive.ResumeLayout(False)
        pnlReceive.PerformLayout()
        pnlAdjust.ResumeLayout(False)
        pnlAdjust.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        pnlDetail.ResumeLayout(False)
        pnlActionBar.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblPageHeader     As Label
    Friend WithEvents btnReceiveStock   As Button
    Friend WithEvents btnAdjustStock    As Button
    Friend WithEvents btnRefresh        As Button
    Friend WithEvents dgvInventory      As DataGridView
    Friend WithEvents pnlReceive        As Panel
    Friend WithEvents lblReceiveTitle   As Label
    Friend WithEvents lblRProduct       As Label
    Friend WithEvents cboProduct        As ComboBox
    Friend WithEvents lblRSupplier      As Label
    Friend WithEvents cboSupplier       As ComboBox
    Friend WithEvents lblRQty           As Label
    Friend WithEvents txtQuantity       As TextBox
    Friend WithEvents lblRNotes         As Label
    Friend WithEvents txtNotes          As TextBox
    Friend WithEvents btnConfirmReceipt As Button
    Friend WithEvents btnCancelReceipt  As Button
    Friend WithEvents pnlAdjust         As Panel
    Friend WithEvents lblAdjTitle       As Label
    Friend WithEvents lblAdjProduct     As Label
    Friend WithEvents cboAdjProduct     As ComboBox
    Friend WithEvents lblAdjNewQty      As Label
    Friend WithEvents txtNewQty         As TextBox
    Friend WithEvents lblAdjNotes       As Label
    Friend WithEvents txtAdjNotes       As TextBox
    Friend WithEvents btnConfirmAdjust  As Button
    Friend WithEvents btnCancelAdjust   As Button
    Friend WithEvents Panel1            As Panel
    Friend WithEvents Panel2            As Panel
    Friend WithEvents pnlActionBar      As Panel
    Friend WithEvents pnlDetail         As Panel

End Class
