<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDashboard
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
        pnlTotalProducts = New Panel()
        lblTitleProducts = New Label()
        lblTotalProducts = New Label()
        pnlLowStock = New Panel()
        lblTitleLowStock = New Label()
        lblLowStock = New Label()
        pnlTodaySales = New Panel()
        lblTitleSales = New Label()
        lblTodaySales = New Label()
        pnlTodayRevenue = New Panel()
        lblTitleRevenue = New Label()
        lblTodayRevenue = New Label()
        lblPageHeader = New Label()
        btnRefresh = New Button()
        pnlSalesTrendChart = New Panel()
        pnlTrendCanvas = New Panel()
        lblTrendChartTitle = New Label()
        pnlCategoryChart = New Panel()
        pnlCategoryCanvas = New Panel()
        lblCategoryChartTitle = New Label()
        pnlTopProductsChart = New Panel()
        pnlTopProductsCanvas = New Panel()
        lblTopProductsChartTitle = New Label()
        pnlTotalProducts.SuspendLayout()
        pnlLowStock.SuspendLayout()
        pnlTodaySales.SuspendLayout()
        pnlTodayRevenue.SuspendLayout()
        pnlSalesTrendChart.SuspendLayout()
        pnlCategoryChart.SuspendLayout()
        pnlTopProductsChart.SuspendLayout()
        SuspendLayout()
        '
        ' pnlTotalProducts
        '
        pnlTotalProducts.BackColor = Color.White
        pnlTotalProducts.Controls.Add(lblTitleProducts)
        pnlTotalProducts.Controls.Add(lblTotalProducts)
        pnlTotalProducts.Location = New Point(18, 103)
        pnlTotalProducts.Margin = New Padding(20, 3, 3, 3)
        pnlTotalProducts.Name = "pnlTotalProducts"
        pnlTotalProducts.Size = New Size(210, 136)
        pnlTotalProducts.TabIndex = 2
        '
        ' lblTitleProducts
        '
        lblTitleProducts.Font = New Font("Segoe UI", 9.5F)
        lblTitleProducts.ForeColor = Color.FromArgb(CByte(130), CByte(135), CByte(145))
        lblTitleProducts.Location = New Point(16, 20)
        lblTitleProducts.Name = "lblTitleProducts"
        lblTitleProducts.Size = New Size(180, 23)
        lblTitleProducts.TabIndex = 0
        lblTitleProducts.Text = "Total Products"
        '
        ' lblTotalProducts
        '
        lblTotalProducts.Font = New Font("Segoe UI", 32F, FontStyle.Bold)
        lblTotalProducts.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        lblTotalProducts.Location = New Point(16, 50)
        lblTotalProducts.Name = "lblTotalProducts"
        lblTotalProducts.Size = New Size(178, 68)
        lblTotalProducts.TabIndex = 1
        lblTotalProducts.Text = "0"
        '
        ' pnlLowStock
        '
        pnlLowStock.BackColor = Color.White
        pnlLowStock.Controls.Add(lblTitleLowStock)
        pnlLowStock.Controls.Add(lblLowStock)
        pnlLowStock.Location = New Point(747, 103)
        pnlLowStock.Margin = New Padding(20, 3, 3, 3)
        pnlLowStock.Name = "pnlLowStock"
        pnlLowStock.Size = New Size(210, 136)
        pnlLowStock.TabIndex = 3
        '
        ' lblTitleLowStock
        '
        lblTitleLowStock.Font = New Font("Segoe UI", 9.5F)
        lblTitleLowStock.ForeColor = Color.FromArgb(CByte(130), CByte(135), CByte(145))
        lblTitleLowStock.Location = New Point(16, 20)
        lblTitleLowStock.Name = "lblTitleLowStock"
        lblTitleLowStock.Size = New Size(180, 23)
        lblTitleLowStock.TabIndex = 0
        lblTitleLowStock.Text = "Low Stock Items"
        '
        ' lblLowStock
        '
        lblLowStock.Font = New Font("Segoe UI", 32F, FontStyle.Bold)
        lblLowStock.ForeColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        lblLowStock.Location = New Point(16, 50)
        lblLowStock.Name = "lblLowStock"
        lblLowStock.Size = New Size(178, 68)
        lblLowStock.TabIndex = 1
        lblLowStock.Text = "0"
        '
        ' pnlTodaySales
        '
        pnlTodaySales.BackColor = Color.White
        pnlTodaySales.Controls.Add(lblTitleSales)
        pnlTodaySales.Controls.Add(lblTodaySales)
        pnlTodaySales.Location = New Point(514, 103)
        pnlTodaySales.Margin = New Padding(20, 3, 3, 3)
        pnlTodaySales.Name = "pnlTodaySales"
        pnlTodaySales.Size = New Size(210, 136)
        pnlTodaySales.TabIndex = 4
        '
        ' lblTitleSales
        '
        lblTitleSales.Font = New Font("Segoe UI", 9.5F)
        lblTitleSales.ForeColor = Color.FromArgb(CByte(130), CByte(135), CByte(145))
        lblTitleSales.Location = New Point(16, 20)
        lblTitleSales.Name = "lblTitleSales"
        lblTitleSales.Size = New Size(180, 23)
        lblTitleSales.TabIndex = 0
        lblTitleSales.Text = "Today's Sales"
        '
        ' lblTodaySales
        '
        lblTodaySales.Font = New Font("Segoe UI", 32F, FontStyle.Bold)
        lblTodaySales.ForeColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        lblTodaySales.Location = New Point(16, 50)
        lblTodaySales.Name = "lblTodaySales"
        lblTodaySales.Size = New Size(178, 68)
        lblTodaySales.TabIndex = 1
        lblTodaySales.Text = "0"
        '
        ' pnlTodayRevenue
        '
        pnlTodayRevenue.BackColor = Color.White
        pnlTodayRevenue.Controls.Add(lblTitleRevenue)
        pnlTodayRevenue.Controls.Add(lblTodayRevenue)
        pnlTodayRevenue.Location = New Point(251, 103)
        pnlTodayRevenue.Margin = New Padding(20, 3, 3, 3)
        pnlTodayRevenue.Name = "pnlTodayRevenue"
        pnlTodayRevenue.Size = New Size(240, 136)
        pnlTodayRevenue.TabIndex = 5
        '
        ' lblTitleRevenue
        '
        lblTitleRevenue.Font = New Font("Segoe UI", 9.5F)
        lblTitleRevenue.ForeColor = Color.FromArgb(CByte(130), CByte(135), CByte(145))
        lblTitleRevenue.Location = New Point(16, 20)
        lblTitleRevenue.Name = "lblTitleRevenue"
        lblTitleRevenue.Size = New Size(210, 23)
        lblTitleRevenue.TabIndex = 0
        lblTitleRevenue.Text = "Today's Revenue"
        '
        ' lblTodayRevenue
        '
        lblTodayRevenue.Font = New Font("Segoe UI", 26F, FontStyle.Bold)
        lblTodayRevenue.ForeColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        lblTodayRevenue.Location = New Point(16, 50)
        lblTodayRevenue.Name = "lblTodayRevenue"
        lblTodayRevenue.Size = New Size(210, 68)
        lblTodayRevenue.TabIndex = 1
        lblTodayRevenue.Text = "₱0.00"
        '
        ' lblPageHeader
        '
        lblPageHeader.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblPageHeader.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        lblPageHeader.Location = New Point(30, 23)
        lblPageHeader.Name = "lblPageHeader"
        lblPageHeader.Size = New Size(300, 41)
        lblPageHeader.TabIndex = 0
        lblPageHeader.Text = "Dashboard"
        '
        ' btnRefresh
        '
        btnRefresh.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefresh.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnRefresh.Cursor = Cursors.Hand
        btnRefresh.FlatAppearance.BorderSize = 0
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 9F)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(870, 25)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(90, 36)
        btnRefresh.TabIndex = 1
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        '
        ' pnlSalesTrendChart
        '
        pnlSalesTrendChart.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        pnlSalesTrendChart.BackColor = Color.White
        pnlSalesTrendChart.Controls.Add(pnlTrendCanvas)
        pnlSalesTrendChart.Controls.Add(lblTrendChartTitle)
        pnlSalesTrendChart.Location = New Point(18, 260)
        pnlSalesTrendChart.Margin = New Padding(20, 3, 3, 3)
        pnlSalesTrendChart.Name = "pnlSalesTrendChart"
        pnlSalesTrendChart.Size = New Size(390, 430)
        pnlSalesTrendChart.TabIndex = 6
        '
        ' lblTrendChartTitle
        '
        lblTrendChartTitle.Font = New Font("Segoe UI", 9.5F)
        lblTrendChartTitle.ForeColor = Color.FromArgb(CByte(130), CByte(135), CByte(145))
        lblTrendChartTitle.Location = New Point(16, 16)
        lblTrendChartTitle.Name = "lblTrendChartTitle"
        lblTrendChartTitle.Size = New Size(358, 23)
        lblTrendChartTitle.TabIndex = 0
        lblTrendChartTitle.Text = "Sales Trend (Last 7 Days)"
        '
        ' pnlTrendCanvas
        '
        pnlTrendCanvas.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlTrendCanvas.BackColor = Color.White
        pnlTrendCanvas.Location = New Point(16, 50)
        pnlTrendCanvas.Name = "pnlTrendCanvas"
        pnlTrendCanvas.Size = New Size(358, 364)
        pnlTrendCanvas.TabIndex = 1
        '
        ' pnlCategoryChart
        '
        pnlCategoryChart.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        pnlCategoryChart.BackColor = Color.White
        pnlCategoryChart.Controls.Add(pnlCategoryCanvas)
        pnlCategoryChart.Controls.Add(lblCategoryChartTitle)
        pnlCategoryChart.Location = New Point(423, 260)
        pnlCategoryChart.Margin = New Padding(20, 3, 3, 3)
        pnlCategoryChart.Name = "pnlCategoryChart"
        pnlCategoryChart.Size = New Size(300, 430)
        pnlCategoryChart.TabIndex = 7
        '
        ' lblCategoryChartTitle
        '
        lblCategoryChartTitle.Font = New Font("Segoe UI", 9.5F)
        lblCategoryChartTitle.ForeColor = Color.FromArgb(CByte(130), CByte(135), CByte(145))
        lblCategoryChartTitle.Location = New Point(16, 16)
        lblCategoryChartTitle.Name = "lblCategoryChartTitle"
        lblCategoryChartTitle.Size = New Size(268, 23)
        lblCategoryChartTitle.TabIndex = 0
        lblCategoryChartTitle.Text = "Sales by Category (This Month)"
        '
        ' pnlCategoryCanvas
        '
        pnlCategoryCanvas.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlCategoryCanvas.BackColor = Color.White
        pnlCategoryCanvas.Location = New Point(16, 50)
        pnlCategoryCanvas.Name = "pnlCategoryCanvas"
        pnlCategoryCanvas.Size = New Size(268, 364)
        pnlCategoryCanvas.TabIndex = 1
        '
        ' pnlTopProductsChart
        '
        pnlTopProductsChart.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlTopProductsChart.BackColor = Color.White
        pnlTopProductsChart.Controls.Add(pnlTopProductsCanvas)
        pnlTopProductsChart.Controls.Add(lblTopProductsChartTitle)
        pnlTopProductsChart.Location = New Point(738, 260)
        pnlTopProductsChart.Margin = New Padding(20, 3, 3, 3)
        pnlTopProductsChart.Name = "pnlTopProductsChart"
        pnlTopProductsChart.Size = New Size(219, 430)
        pnlTopProductsChart.TabIndex = 8
        '
        ' lblTopProductsChartTitle
        '
        lblTopProductsChartTitle.Font = New Font("Segoe UI", 9.5F)
        lblTopProductsChartTitle.ForeColor = Color.FromArgb(CByte(130), CByte(135), CByte(145))
        lblTopProductsChartTitle.Location = New Point(16, 16)
        lblTopProductsChartTitle.Name = "lblTopProductsChartTitle"
        lblTopProductsChartTitle.Size = New Size(187, 23)
        lblTopProductsChartTitle.TabIndex = 0
        lblTopProductsChartTitle.Text = "Top 5 Products (This Month)"
        '
        ' pnlTopProductsCanvas
        '
        pnlTopProductsCanvas.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlTopProductsCanvas.BackColor = Color.White
        pnlTopProductsCanvas.Location = New Point(16, 50)
        pnlTopProductsCanvas.Name = "pnlTopProductsCanvas"
        pnlTopProductsCanvas.Size = New Size(187, 364)
        pnlTopProductsCanvas.TabIndex = 1
        '
        ' frmDashboard
        '
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        ClientSize = New Size(980, 725)
        Controls.Add(pnlSalesTrendChart)
        Controls.Add(pnlCategoryChart)
        Controls.Add(pnlTopProductsChart)
        Controls.Add(pnlTotalProducts)
        Controls.Add(pnlTodayRevenue)
        Controls.Add(pnlTodaySales)
        Controls.Add(lblPageHeader)
        Controls.Add(pnlLowStock)
        Controls.Add(btnRefresh)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmDashboard"
        Text = "Dashboard"
        WindowState = FormWindowState.Maximized
        pnlTotalProducts.ResumeLayout(False)
        pnlLowStock.ResumeLayout(False)
        pnlTodaySales.ResumeLayout(False)
        pnlTodayRevenue.ResumeLayout(False)
        pnlSalesTrendChart.ResumeLayout(False)
        pnlCategoryChart.ResumeLayout(False)
        pnlTopProductsChart.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlTotalProducts As System.Windows.Forms.Panel
    Friend WithEvents pnlLowStock      As System.Windows.Forms.Panel
    Friend WithEvents pnlTodaySales    As System.Windows.Forms.Panel
    Friend WithEvents pnlTodayRevenue  As System.Windows.Forms.Panel
    Friend WithEvents pnlSalesTrendChart  As System.Windows.Forms.Panel
    Friend WithEvents pnlTrendCanvas      As System.Windows.Forms.Panel
    Friend WithEvents pnlCategoryChart    As System.Windows.Forms.Panel
    Friend WithEvents pnlCategoryCanvas   As System.Windows.Forms.Panel
    Friend WithEvents pnlTopProductsChart As System.Windows.Forms.Panel
    Friend WithEvents pnlTopProductsCanvas As System.Windows.Forms.Panel

    Friend WithEvents lblPageHeader    As System.Windows.Forms.Label
    Friend WithEvents btnRefresh       As System.Windows.Forms.Button

    Friend WithEvents lblTitleProducts As System.Windows.Forms.Label
    Friend WithEvents lblTitleLowStock As System.Windows.Forms.Label
    Friend WithEvents lblTitleSales    As System.Windows.Forms.Label
    Friend WithEvents lblTitleRevenue  As System.Windows.Forms.Label
    Friend WithEvents lblTrendChartTitle       As System.Windows.Forms.Label
    Friend WithEvents lblCategoryChartTitle    As System.Windows.Forms.Label
    Friend WithEvents lblTopProductsChartTitle As System.Windows.Forms.Label

    Friend WithEvents lblTotalProducts As System.Windows.Forms.Label
    Friend WithEvents lblLowStock      As System.Windows.Forms.Label
    Friend WithEvents lblTodaySales    As System.Windows.Forms.Label
    Friend WithEvents lblTodayRevenue  As System.Windows.Forms.Label

End Class
