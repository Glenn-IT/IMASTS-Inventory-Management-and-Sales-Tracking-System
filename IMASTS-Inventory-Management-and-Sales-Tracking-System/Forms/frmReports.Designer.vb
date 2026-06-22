<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReports
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
        tabControl = New TabControl()
        tabInventory = New TabPage()
        dgvInventory = New DataGridView()
        pnlInvBar = New Panel()
        btnRefreshInventory = New Button()
        tabSales = New TabPage()
        dgvTopProducts = New DataGridView()
        pnlSalesHeader = New Panel()
        lblFrom = New Label()
        dtpFrom = New DateTimePicker()
        lblTo = New Label()
        dtpTo = New DateTimePicker()
        btnGenerate = New Button()
        pnlSummary = New Panel()
        lblTotalSalesTit = New Label()
        lblTotalSalesVal = New Label()
        lblRevenueTit = New Label()
        lblRevenueVal = New Label()
        lblAvgTit = New Label()
        lblAvgVal = New Label()
        lblTopHeader = New Label()
        Panel1 = New Panel()
        Panel2 = New Panel()
        tabControl.SuspendLayout()
        tabInventory.SuspendLayout()
        CType(dgvInventory, ComponentModel.ISupportInitialize).BeginInit()
        pnlInvBar.SuspendLayout()
        tabSales.SuspendLayout()
        CType(dgvTopProducts, ComponentModel.ISupportInitialize).BeginInit()
        pnlSalesHeader.SuspendLayout()
        pnlSummary.SuspendLayout()
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
        lblPageHeader.Text = "Reports"
        ' 
        ' tabControl
        ' 
        tabControl.Controls.Add(tabInventory)
        tabControl.Controls.Add(tabSales)
        tabControl.Dock = DockStyle.Fill
        tabControl.Font = New Font("Segoe UI", 9.5F)
        tabControl.Location = New Point(0, 0)
        tabControl.Name = "tabControl"
        tabControl.SelectedIndex = 0
        tabControl.Size = New Size(980, 649)
        tabControl.TabIndex = 0
        ' 
        ' tabInventory
        ' 
        tabInventory.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        tabInventory.Controls.Add(dgvInventory)
        tabInventory.Controls.Add(pnlInvBar)
        tabInventory.Location = New Point(4, 28)
        tabInventory.Name = "tabInventory"
        tabInventory.Padding = New Padding(12)
        tabInventory.Size = New Size(972, 617)
        tabInventory.TabIndex = 0
        tabInventory.Text = "  Inventory Status  "
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
        dgvInventory.Location = New Point(12, 62)
        dgvInventory.MultiSelect = False
        dgvInventory.Name = "dgvInventory"
        dgvInventory.ReadOnly = True
        dgvInventory.RowHeadersVisible = False
        dgvInventory.RowHeadersWidth = 45
        dgvInventory.RowTemplate.Height = 32
        dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvInventory.Size = New Size(948, 543)
        dgvInventory.TabIndex = 1
        ' 
        ' pnlInvBar
        ' 
        pnlInvBar.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        pnlInvBar.Controls.Add(btnRefreshInventory)
        pnlInvBar.Dock = DockStyle.Top
        pnlInvBar.Location = New Point(12, 12)
        pnlInvBar.Name = "pnlInvBar"
        pnlInvBar.Size = New Size(948, 50)
        pnlInvBar.TabIndex = 2
        ' 
        ' btnRefreshInventory
        ' 
        btnRefreshInventory.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnRefreshInventory.Cursor = Cursors.Hand
        btnRefreshInventory.FlatAppearance.BorderSize = 0
        btnRefreshInventory.FlatStyle = FlatStyle.Flat
        btnRefreshInventory.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnRefreshInventory.ForeColor = Color.White
        btnRefreshInventory.Location = New Point(12, 12)
        btnRefreshInventory.Name = "btnRefreshInventory"
        btnRefreshInventory.Size = New Size(130, 30)
        btnRefreshInventory.TabIndex = 0
        btnRefreshInventory.Text = "Refresh"
        btnRefreshInventory.UseVisualStyleBackColor = False
        ' 
        ' tabSales
        ' 
        tabSales.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        tabSales.Controls.Add(dgvTopProducts)
        tabSales.Controls.Add(pnlSalesHeader)
        tabSales.Location = New Point(4, 28)
        tabSales.Name = "tabSales"
        tabSales.Padding = New Padding(12)
        tabSales.Size = New Size(192, 68)
        tabSales.TabIndex = 1
        tabSales.Text = "  Sales Summary  "
        ' 
        ' dgvTopProducts
        ' 
        dgvTopProducts.AllowUserToAddRows = False
        dgvTopProducts.AllowUserToDeleteRows = False
        dgvTopProducts.BackgroundColor = Color.White
        dgvTopProducts.BorderStyle = BorderStyle.None
        dgvTopProducts.ColumnHeadersHeight = 34
        dgvTopProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvTopProducts.Dock = DockStyle.Fill
        dgvTopProducts.Font = New Font("Segoe UI", 9.5F)
        dgvTopProducts.GridColor = Color.FromArgb(CByte(220), CByte(223), CByte(228))
        dgvTopProducts.Location = New Point(12, 217)
        dgvTopProducts.MultiSelect = False
        dgvTopProducts.Name = "dgvTopProducts"
        dgvTopProducts.ReadOnly = True
        dgvTopProducts.RowHeadersVisible = False
        dgvTopProducts.RowHeadersWidth = 45
        dgvTopProducts.RowTemplate.Height = 30
        dgvTopProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTopProducts.Size = New Size(168, 0)
        dgvTopProducts.TabIndex = 7
        ' 
        ' pnlSalesHeader
        ' 
        pnlSalesHeader.BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        pnlSalesHeader.Controls.Add(lblFrom)
        pnlSalesHeader.Controls.Add(dtpFrom)
        pnlSalesHeader.Controls.Add(lblTo)
        pnlSalesHeader.Controls.Add(dtpTo)
        pnlSalesHeader.Controls.Add(btnGenerate)
        pnlSalesHeader.Controls.Add(pnlSummary)
        pnlSalesHeader.Controls.Add(lblTopHeader)
        pnlSalesHeader.Dock = DockStyle.Top
        pnlSalesHeader.Location = New Point(12, 12)
        pnlSalesHeader.Name = "pnlSalesHeader"
        pnlSalesHeader.Size = New Size(168, 205)
        pnlSalesHeader.TabIndex = 8
        ' 
        ' lblFrom
        ' 
        lblFrom.Font = New Font("Segoe UI", 9F)
        lblFrom.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblFrom.Location = New Point(12, 14)
        lblFrom.Name = "lblFrom"
        lblFrom.Size = New Size(50, 18)
        lblFrom.TabIndex = 0
        lblFrom.Text = "From:"
        ' 
        ' dtpFrom
        ' 
        dtpFrom.Font = New Font("Segoe UI", 10F)
        dtpFrom.Format = DateTimePickerFormat.Short
        dtpFrom.Location = New Point(12, 34)
        dtpFrom.Name = "dtpFrom"
        dtpFrom.Size = New Size(160, 27)
        dtpFrom.TabIndex = 1
        ' 
        ' lblTo
        ' 
        lblTo.Font = New Font("Segoe UI", 9F)
        lblTo.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblTo.Location = New Point(184, 14)
        lblTo.Name = "lblTo"
        lblTo.Size = New Size(30, 18)
        lblTo.TabIndex = 2
        lblTo.Text = "To:"
        ' 
        ' dtpTo
        ' 
        dtpTo.Font = New Font("Segoe UI", 10F)
        dtpTo.Format = DateTimePickerFormat.Short
        dtpTo.Location = New Point(184, 34)
        dtpTo.Name = "dtpTo"
        dtpTo.Size = New Size(160, 27)
        dtpTo.TabIndex = 3
        ' 
        ' btnGenerate
        ' 
        btnGenerate.BackColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        btnGenerate.Cursor = Cursors.Hand
        btnGenerate.FlatAppearance.BorderSize = 0
        btnGenerate.FlatStyle = FlatStyle.Flat
        btnGenerate.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnGenerate.ForeColor = Color.White
        btnGenerate.Location = New Point(356, 32)
        btnGenerate.Name = "btnGenerate"
        btnGenerate.Size = New Size(130, 30)
        btnGenerate.TabIndex = 4
        btnGenerate.Text = "Generate Report"
        btnGenerate.UseVisualStyleBackColor = False
        ' 
        ' pnlSummary
        ' 
        pnlSummary.BackColor = Color.White
        pnlSummary.Controls.Add(lblTotalSalesTit)
        pnlSummary.Controls.Add(lblTotalSalesVal)
        pnlSummary.Controls.Add(lblRevenueTit)
        pnlSummary.Controls.Add(lblRevenueVal)
        pnlSummary.Controls.Add(lblAvgTit)
        pnlSummary.Controls.Add(lblAvgVal)
        pnlSummary.Location = New Point(12, 76)
        pnlSummary.Name = "pnlSummary"
        pnlSummary.Size = New Size(892, 90)
        pnlSummary.TabIndex = 5
        ' 
        ' lblTotalSalesTit
        ' 
        lblTotalSalesTit.Font = New Font("Segoe UI", 8.5F)
        lblTotalSalesTit.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblTotalSalesTit.Location = New Point(20, 12)
        lblTotalSalesTit.Name = "lblTotalSalesTit"
        lblTotalSalesTit.Size = New Size(220, 18)
        lblTotalSalesTit.TabIndex = 0
        lblTotalSalesTit.Text = "TOTAL SALES"
        ' 
        ' lblTotalSalesVal
        ' 
        lblTotalSalesVal.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblTotalSalesVal.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        lblTotalSalesVal.Location = New Point(20, 34)
        lblTotalSalesVal.Name = "lblTotalSalesVal"
        lblTotalSalesVal.Size = New Size(220, 40)
        lblTotalSalesVal.TabIndex = 1
        lblTotalSalesVal.Text = "—"
        ' 
        ' lblRevenueTit
        ' 
        lblRevenueTit.Font = New Font("Segoe UI", 8.5F)
        lblRevenueTit.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblRevenueTit.Location = New Point(316, 12)
        lblRevenueTit.Name = "lblRevenueTit"
        lblRevenueTit.Size = New Size(220, 18)
        lblRevenueTit.TabIndex = 2
        lblRevenueTit.Text = "TOTAL REVENUE"
        ' 
        ' lblRevenueVal
        ' 
        lblRevenueVal.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblRevenueVal.ForeColor = Color.FromArgb(CByte(27), CByte(94), CByte(32))
        lblRevenueVal.Location = New Point(316, 34)
        lblRevenueVal.Name = "lblRevenueVal"
        lblRevenueVal.Size = New Size(220, 40)
        lblRevenueVal.TabIndex = 3
        lblRevenueVal.Text = "—"
        ' 
        ' lblAvgTit
        ' 
        lblAvgTit.Font = New Font("Segoe UI", 8.5F)
        lblAvgTit.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblAvgTit.Location = New Point(612, 12)
        lblAvgTit.Name = "lblAvgTit"
        lblAvgTit.Size = New Size(240, 18)
        lblAvgTit.TabIndex = 4
        lblAvgTit.Text = "AVG SALE VALUE"
        ' 
        ' lblAvgVal
        ' 
        lblAvgVal.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblAvgVal.ForeColor = Color.FromArgb(CByte(28), CByte(43), CByte(74))
        lblAvgVal.Location = New Point(612, 34)
        lblAvgVal.Name = "lblAvgVal"
        lblAvgVal.Size = New Size(240, 40)
        lblAvgVal.TabIndex = 5
        lblAvgVal.Text = "—"
        ' 
        ' lblTopHeader
        ' 
        lblTopHeader.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblTopHeader.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblTopHeader.Location = New Point(12, 180)
        lblTopHeader.Name = "lblTopHeader"
        lblTopHeader.Size = New Size(300, 20)
        lblTopHeader.TabIndex = 6
        lblTopHeader.Text = "Top 5 Products by Units Sold"
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
        Panel2.Controls.Add(tabControl)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 76)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(980, 649)
        Panel2.TabIndex = 2
        ' 
        ' frmReports
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        ClientSize = New Size(980, 725)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmReports"
        Text = "Reports"
        tabControl.ResumeLayout(False)
        tabInventory.ResumeLayout(False)
        CType(dgvInventory, ComponentModel.ISupportInitialize).EndInit()
        pnlInvBar.ResumeLayout(False)
        tabSales.ResumeLayout(False)
        CType(dgvTopProducts, ComponentModel.ISupportInitialize).EndInit()
        pnlSalesHeader.ResumeLayout(False)
        pnlSummary.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblPageHeader       As Label
    Friend WithEvents tabControl          As TabControl
    Friend WithEvents tabInventory        As TabPage
    Friend WithEvents btnRefreshInventory As Button
    Friend WithEvents dgvInventory        As DataGridView
    Friend WithEvents tabSales            As TabPage
    Friend WithEvents lblFrom             As Label
    Friend WithEvents dtpFrom             As DateTimePicker
    Friend WithEvents lblTo               As Label
    Friend WithEvents dtpTo               As DateTimePicker
    Friend WithEvents btnGenerate         As Button
    Friend WithEvents pnlSummary          As Panel
    Friend WithEvents lblTotalSalesTit    As Label
    Friend WithEvents lblTotalSalesVal    As Label
    Friend WithEvents lblRevenueTit       As Label
    Friend WithEvents lblRevenueVal       As Label
    Friend WithEvents lblAvgTit           As Label
    Friend WithEvents lblAvgVal           As Label
    Friend WithEvents lblTopHeader        As Label
    Friend WithEvents dgvTopProducts      As DataGridView
    Friend WithEvents Panel1              As Panel
    Friend WithEvents Panel2              As Panel
    Friend WithEvents pnlInvBar           As Panel
    Friend WithEvents pnlSalesHeader      As Panel

End Class
