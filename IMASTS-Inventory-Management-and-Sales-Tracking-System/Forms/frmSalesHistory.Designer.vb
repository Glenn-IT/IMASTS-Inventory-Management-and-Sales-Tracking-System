<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSalesHistory
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
        lblFrom = New Label()
        dtpFrom = New DateTimePicker()
        lblTo = New Label()
        dtpTo = New DateTimePicker()
        btnFilter = New Button()
        btnPrintReceipt = New Button()
        btnVoidSale = New Button()
        pnlGrandTotal = New Panel()
        lblGrandTotalTit = New Label()
        lblGrandTotalVal = New Label()
        dgvSales = New DataGridView()
        lblDetailHeader = New Label()
        dgvSaleItems = New DataGridView()
        Panel1 = New Panel()
        Panel2 = New Panel()
        pnlSaleDetail = New Panel()
        pnlFilter = New Panel()
        CType(dgvSales, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvSaleItems, ComponentModel.ISupportInitialize).BeginInit()
        pnlGrandTotal.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        pnlSaleDetail.SuspendLayout()
        pnlFilter.SuspendLayout()
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
        lblPageHeader.Text = "Sales History"
        ' 
        ' lblFrom
        ' 
        lblFrom.Font = New Font("Segoe UI", 9F)
        lblFrom.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblFrom.Location = New Point(12, 10)
        lblFrom.Name = "lblFrom"
        lblFrom.Size = New Size(50, 18)
        lblFrom.TabIndex = 0
        lblFrom.Text = "From:"
        ' 
        ' dtpFrom
        ' 
        dtpFrom.Font = New Font("Segoe UI", 10F)
        dtpFrom.Format = DateTimePickerFormat.Short
        dtpFrom.Location = New Point(12, 30)
        dtpFrom.Name = "dtpFrom"
        dtpFrom.Size = New Size(160, 27)
        dtpFrom.TabIndex = 1
        ' 
        ' lblTo
        ' 
        lblTo.Font = New Font("Segoe UI", 9F)
        lblTo.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblTo.Location = New Point(184, 10)
        lblTo.Name = "lblTo"
        lblTo.Size = New Size(30, 18)
        lblTo.TabIndex = 2
        lblTo.Text = "To:"
        ' 
        ' dtpTo
        ' 
        dtpTo.Font = New Font("Segoe UI", 10F)
        dtpTo.Format = DateTimePickerFormat.Short
        dtpTo.Location = New Point(184, 30)
        dtpTo.Name = "dtpTo"
        dtpTo.Size = New Size(160, 27)
        dtpTo.TabIndex = 3
        ' 
        ' btnFilter
        ' 
        btnFilter.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnFilter.Cursor = Cursors.Hand
        btnFilter.FlatAppearance.BorderSize = 0
        btnFilter.FlatStyle = FlatStyle.Flat
        btnFilter.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnFilter.ForeColor = Color.White
        btnFilter.Location = New Point(356, 28)
        btnFilter.Name = "btnFilter"
        btnFilter.Size = New Size(90, 30)
        btnFilter.TabIndex = 4
        btnFilter.Text = "Filter"
        btnFilter.UseVisualStyleBackColor = False
        ' 
        ' btnPrintReceipt
        ' 
        btnPrintReceipt.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        btnPrintReceipt.Cursor = Cursors.Hand
        btnPrintReceipt.Enabled = False
        btnPrintReceipt.FlatAppearance.BorderSize = 0
        btnPrintReceipt.FlatStyle = FlatStyle.Flat
        btnPrintReceipt.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnPrintReceipt.ForeColor = Color.White
        btnPrintReceipt.Location = New Point(454, 28)
        btnPrintReceipt.Name = "btnPrintReceipt"
        btnPrintReceipt.Size = New Size(130, 30)
        btnPrintReceipt.TabIndex = 5
        btnPrintReceipt.Text = "🖶 Print Receipt"
        btnPrintReceipt.UseVisualStyleBackColor = False
        ' 
        ' btnVoidSale
        ' 
        btnVoidSale.BackColor = Color.FromArgb(CByte(192), CByte(57), CByte(43))
        btnVoidSale.Cursor = Cursors.Hand
        btnVoidSale.Enabled = False
        btnVoidSale.FlatAppearance.BorderSize = 0
        btnVoidSale.FlatStyle = FlatStyle.Flat
        btnVoidSale.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnVoidSale.ForeColor = Color.White
        btnVoidSale.Location = New Point(592, 28)
        btnVoidSale.Name = "btnVoidSale"
        btnVoidSale.Size = New Size(110, 30)
        btnVoidSale.TabIndex = 6
        btnVoidSale.Text = "Void Sale"
        btnVoidSale.UseVisualStyleBackColor = False
        btnVoidSale.Visible = False
        ' 
        ' pnlGrandTotal
        ' 
        pnlGrandTotal.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        pnlGrandTotal.BackColor = Color.White
        pnlGrandTotal.Controls.Add(lblGrandTotalTit)
        pnlGrandTotal.Controls.Add(lblGrandTotalVal)
        pnlGrandTotal.Location = New Point(716, 10)
        pnlGrandTotal.Name = "pnlGrandTotal"
        pnlGrandTotal.Size = New Size(252, 50)
        pnlGrandTotal.TabIndex = 7
        ' 
        ' lblGrandTotalTit
        ' 
        lblGrandTotalTit.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblGrandTotalTit.ForeColor = Color.FromArgb(CByte(120), CByte(125), CByte(135))
        lblGrandTotalTit.Location = New Point(8, 6)
        lblGrandTotalTit.Name = "lblGrandTotalTit"
        lblGrandTotalTit.Size = New Size(236, 15)
        lblGrandTotalTit.TabIndex = 0
        lblGrandTotalTit.Text = "GRAND TOTAL"
        lblGrandTotalTit.TextAlign = ContentAlignment.TopRight
        ' 
        ' lblGrandTotalVal
        ' 
        lblGrandTotalVal.Font = New Font("Segoe UI", 13.5F, FontStyle.Bold)
        lblGrandTotalVal.ForeColor = Color.FromArgb(CByte(27), CByte(94), CByte(32))
        lblGrandTotalVal.Location = New Point(8, 22)
        lblGrandTotalVal.Name = "lblGrandTotalVal"
        lblGrandTotalVal.Size = New Size(236, 24)
        lblGrandTotalVal.TabIndex = 1
        lblGrandTotalVal.Text = "₱0.00"
        lblGrandTotalVal.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' dgvSales
        ' 
        dgvSales.AllowUserToAddRows = False
        dgvSales.AllowUserToDeleteRows = False
        dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvSales.BackgroundColor = Color.White
        dgvSales.BorderStyle = BorderStyle.None
        dgvSales.ColumnHeadersHeight = 36
        dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvSales.Dock = DockStyle.Fill
        dgvSales.Font = New Font("Segoe UI", 9.5F)
        dgvSales.GridColor = Color.FromArgb(CByte(220), CByte(223), CByte(228))
        dgvSales.Location = New Point(0, 70)
        dgvSales.MultiSelect = False
        dgvSales.Name = "dgvSales"
        dgvSales.ReadOnly = True
        dgvSales.RowHeadersVisible = False
        dgvSales.RowHeadersWidth = 45
        dgvSales.RowTemplate.Height = 32
        dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSales.Size = New Size(980, 249)
        dgvSales.TabIndex = 7
        ' 
        ' lblDetailHeader
        ' 
        lblDetailHeader.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblDetailHeader.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblDetailHeader.Location = New Point(12, 8)
        lblDetailHeader.Name = "lblDetailHeader"
        lblDetailHeader.Size = New Size(600, 20)
        lblDetailHeader.TabIndex = 0
        lblDetailHeader.Text = "Sale Items"
        ' 
        ' dgvSaleItems
        ' 
        dgvSaleItems.AllowUserToAddRows = False
        dgvSaleItems.AllowUserToDeleteRows = False
        dgvSaleItems.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvSaleItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvSaleItems.BackgroundColor = Color.White
        dgvSaleItems.BorderStyle = BorderStyle.None
        dgvSaleItems.ColumnHeadersHeight = 32
        dgvSaleItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvSaleItems.Font = New Font("Segoe UI", 9.5F)
        dgvSaleItems.GridColor = Color.FromArgb(CByte(220), CByte(223), CByte(228))
        dgvSaleItems.Location = New Point(12, 32)
        dgvSaleItems.MultiSelect = False
        dgvSaleItems.Name = "dgvSaleItems"
        dgvSaleItems.ReadOnly = True
        dgvSaleItems.RowHeadersVisible = False
        dgvSaleItems.RowHeadersWidth = 45
        dgvSaleItems.RowTemplate.Height = 30
        dgvSaleItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSaleItems.Size = New Size(956, 286)
        dgvSaleItems.TabIndex = 1
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
        Panel2.Controls.Add(dgvSales)
        Panel2.Controls.Add(pnlSaleDetail)
        Panel2.Controls.Add(pnlFilter)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 76)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(980, 649)
        Panel2.TabIndex = 2
        ' 
        ' pnlSaleDetail
        ' 
        pnlSaleDetail.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        pnlSaleDetail.Controls.Add(lblDetailHeader)
        pnlSaleDetail.Controls.Add(dgvSaleItems)
        pnlSaleDetail.Dock = DockStyle.Bottom
        pnlSaleDetail.Location = New Point(0, 319)
        pnlSaleDetail.Name = "pnlSaleDetail"
        pnlSaleDetail.Size = New Size(980, 330)
        pnlSaleDetail.TabIndex = 10
        ' 
        ' pnlFilter
        ' 
        pnlFilter.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        pnlFilter.Controls.Add(lblFrom)
        pnlFilter.Controls.Add(dtpFrom)
        pnlFilter.Controls.Add(lblTo)
        pnlFilter.Controls.Add(dtpTo)
        pnlFilter.Controls.Add(btnFilter)
        pnlFilter.Controls.Add(btnPrintReceipt)
        pnlFilter.Controls.Add(btnVoidSale)
        pnlFilter.Controls.Add(pnlGrandTotal)
        pnlFilter.Dock = DockStyle.Top
        pnlFilter.Location = New Point(0, 0)
        pnlFilter.Name = "pnlFilter"
        pnlFilter.Size = New Size(980, 70)
        pnlFilter.TabIndex = 9
        ' 
        ' frmSalesHistory
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        ClientSize = New Size(980, 725)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmSalesHistory"
        Text = "Sales History"
        CType(dgvSales, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvSaleItems, ComponentModel.ISupportInitialize).EndInit()
        pnlGrandTotal.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        pnlSaleDetail.ResumeLayout(False)
        pnlFilter.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblPageHeader   As Label
    Friend WithEvents lblFrom         As Label
    Friend WithEvents dtpFrom         As DateTimePicker
    Friend WithEvents lblTo           As Label
    Friend WithEvents dtpTo           As DateTimePicker
    Friend WithEvents btnFilter       As Button
    Friend WithEvents btnPrintReceipt As Button
    Friend WithEvents btnVoidSale     As Button
    Friend WithEvents pnlGrandTotal   As Panel
    Friend WithEvents lblGrandTotalTit As Label
    Friend WithEvents lblGrandTotalVal As Label
    Friend WithEvents dgvSales        As DataGridView
    Friend WithEvents lblDetailHeader As Label
    Friend WithEvents dgvSaleItems    As DataGridView
    Friend WithEvents Panel1          As Panel
    Friend WithEvents Panel2          As Panel
    Friend WithEvents pnlFilter       As Panel
    Friend WithEvents pnlSaleDetail   As Panel

End Class
