<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSystemManual
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
        lblPageSub = New Label()
        Panel1 = New Panel()
        Panel2 = New Panel()
        tabControl = New TabControl()
        tabOverview = New TabPage()
        rtbOverview = New RichTextBox()
        tabProducts = New TabPage()
        rtbProducts = New RichTextBox()
        tabInventory = New TabPage()
        rtbInventory = New RichTextBox()
        tabNewSale = New TabPage()
        rtbNewSale = New RichTextBox()
        tabSalesHistory = New TabPage()
        rtbSalesHistory = New RichTextBox()
        tabSuppliersCategories = New TabPage()
        rtbSuppliersCategories = New RichTextBox()
        tabReports = New TabPage()
        rtbReports = New RichTextBox()
        tabSettings = New TabPage()
        rtbSettings = New RichTextBox()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        tabControl.SuspendLayout()
        tabOverview.SuspendLayout()
        tabProducts.SuspendLayout()
        tabInventory.SuspendLayout()
        tabNewSale.SuspendLayout()
        tabSalesHistory.SuspendLayout()
        tabSuppliersCategories.SuspendLayout()
        tabReports.SuspendLayout()
        tabSettings.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblPageHeader
        ' 
        lblPageHeader.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblPageHeader.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        lblPageHeader.Location = New Point(12, 14)
        lblPageHeader.Name = "lblPageHeader"
        lblPageHeader.Size = New Size(400, 32)
        lblPageHeader.TabIndex = 0
        lblPageHeader.Text = "System Manual"
        ' 
        ' lblPageSub
        ' 
        lblPageSub.Font = New Font("Segoe UI", 9F)
        lblPageSub.ForeColor = Color.FromArgb(CByte(100), CByte(110), CByte(125))
        lblPageSub.Location = New Point(14, 46)
        lblPageSub.Name = "lblPageSub"
        lblPageSub.Size = New Size(600, 20)
        lblPageSub.TabIndex = 1
        lblPageSub.Text = "Comprehensive guide and operational instructions for IMASTS modules"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lblPageHeader)
        Panel1.Controls.Add(lblPageSub)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(980, 74)
        Panel1.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(tabControl)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 74)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(980, 651)
        Panel2.TabIndex = 1
        ' 
        ' tabControl
        ' 
        tabControl.Controls.Add(tabOverview)
        tabControl.Controls.Add(tabProducts)
        tabControl.Controls.Add(tabInventory)
        tabControl.Controls.Add(tabNewSale)
        tabControl.Controls.Add(tabSalesHistory)
        tabControl.Controls.Add(tabSuppliersCategories)
        tabControl.Controls.Add(tabReports)
        tabControl.Controls.Add(tabSettings)
        tabControl.Dock = DockStyle.Fill
        tabControl.Font = New Font("Segoe UI", 9.5F)
        tabControl.Location = New Point(0, 0)
        tabControl.Name = "tabControl"
        tabControl.SelectedIndex = 0
        tabControl.Size = New Size(980, 651)
        tabControl.TabIndex = 0
        ' 
        ' tabOverview
        ' 
        tabOverview.BackColor = Color.White
        tabOverview.Controls.Add(rtbOverview)
        tabOverview.Location = New Point(4, 26)
        tabOverview.Name = "tabOverview"
        tabOverview.Padding = New Padding(16)
        tabOverview.Size = New Size(972, 621)
        tabOverview.TabIndex = 0
        tabOverview.Text = "  Overview & Dashboard  "
        ' 
        ' rtbOverview
        ' 
        rtbOverview.BackColor = Color.White
        rtbOverview.BorderStyle = BorderStyle.None
        rtbOverview.Dock = DockStyle.Fill
        rtbOverview.Font = New Font("Segoe UI", 10F)
        rtbOverview.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        rtbOverview.Location = New Point(16, 16)
        rtbOverview.Name = "rtbOverview"
        rtbOverview.ReadOnly = True
        rtbOverview.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbOverview.Size = New Size(940, 589)
        rtbOverview.TabIndex = 0
        rtbOverview.Text = ""
        ' 
        ' tabProducts
        ' 
        tabProducts.BackColor = Color.White
        tabProducts.Controls.Add(rtbProducts)
        tabProducts.Location = New Point(4, 26)
        tabProducts.Name = "tabProducts"
        tabProducts.Padding = New Padding(16)
        tabProducts.Size = New Size(972, 621)
        tabProducts.TabIndex = 1
        tabProducts.Text = "  Products  "
        ' 
        ' rtbProducts
        ' 
        rtbProducts.BackColor = Color.White
        rtbProducts.BorderStyle = BorderStyle.None
        rtbProducts.Dock = DockStyle.Fill
        rtbProducts.Font = New Font("Segoe UI", 10F)
        rtbProducts.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        rtbProducts.Location = New Point(16, 16)
        rtbProducts.Name = "rtbProducts"
        rtbProducts.ReadOnly = True
        rtbProducts.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbProducts.Size = New Size(940, 589)
        rtbProducts.TabIndex = 0
        rtbProducts.Text = ""
        ' 
        ' tabInventory
        ' 
        tabInventory.BackColor = Color.White
        tabInventory.Controls.Add(rtbInventory)
        tabInventory.Location = New Point(4, 26)
        tabInventory.Name = "tabInventory"
        tabInventory.Padding = New Padding(16)
        tabInventory.Size = New Size(972, 621)
        tabInventory.TabIndex = 2
        tabInventory.Text = "  Inventory Management  "
        ' 
        ' rtbInventory
        ' 
        rtbInventory.BackColor = Color.White
        rtbInventory.BorderStyle = BorderStyle.None
        rtbInventory.Dock = DockStyle.Fill
        rtbInventory.Font = New Font("Segoe UI", 10F)
        rtbInventory.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        rtbInventory.Location = New Point(16, 16)
        rtbInventory.Name = "rtbInventory"
        rtbInventory.ReadOnly = True
        rtbInventory.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbInventory.Size = New Size(940, 589)
        rtbInventory.TabIndex = 0
        rtbInventory.Text = ""
        ' 
        ' tabNewSale
        ' 
        tabNewSale.BackColor = Color.White
        tabNewSale.Controls.Add(rtbNewSale)
        tabNewSale.Location = New Point(4, 26)
        tabNewSale.Name = "tabNewSale"
        tabNewSale.Padding = New Padding(16)
        tabNewSale.Size = New Size(972, 621)
        tabNewSale.TabIndex = 3
        tabNewSale.Text = "  New Sale (POS)  "
        ' 
        ' rtbNewSale
        ' 
        rtbNewSale.BackColor = Color.White
        rtbNewSale.BorderStyle = BorderStyle.None
        rtbNewSale.Dock = DockStyle.Fill
        rtbNewSale.Font = New Font("Segoe UI", 10F)
        rtbNewSale.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        rtbNewSale.Location = New Point(16, 16)
        rtbNewSale.Name = "rtbNewSale"
        rtbNewSale.ReadOnly = True
        rtbNewSale.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbNewSale.Size = New Size(940, 589)
        rtbNewSale.TabIndex = 0
        rtbNewSale.Text = ""
        ' 
        ' tabSalesHistory
        ' 
        tabSalesHistory.BackColor = Color.White
        tabSalesHistory.Controls.Add(rtbSalesHistory)
        tabSalesHistory.Location = New Point(4, 26)
        tabSalesHistory.Name = "tabSalesHistory"
        tabSalesHistory.Padding = New Padding(16)
        tabSalesHistory.Size = New Size(972, 621)
        tabSalesHistory.TabIndex = 4
        tabSalesHistory.Text = "  Sales History  "
        ' 
        ' rtbSalesHistory
        ' 
        rtbSalesHistory.BackColor = Color.White
        rtbSalesHistory.BorderStyle = BorderStyle.None
        rtbSalesHistory.Dock = DockStyle.Fill
        rtbSalesHistory.Font = New Font("Segoe UI", 10F)
        rtbSalesHistory.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        rtbSalesHistory.Location = New Point(16, 16)
        rtbSalesHistory.Name = "rtbSalesHistory"
        rtbSalesHistory.ReadOnly = True
        rtbSalesHistory.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbSalesHistory.Size = New Size(940, 589)
        rtbSalesHistory.TabIndex = 0
        rtbSalesHistory.Text = ""
        ' 
        ' tabSuppliersCategories
        ' 
        tabSuppliersCategories.BackColor = Color.White
        tabSuppliersCategories.Controls.Add(rtbSuppliersCategories)
        tabSuppliersCategories.Location = New Point(4, 26)
        tabSuppliersCategories.Name = "tabSuppliersCategories"
        tabSuppliersCategories.Padding = New Padding(16)
        tabSuppliersCategories.Size = New Size(972, 621)
        tabSuppliersCategories.TabIndex = 5
        tabSuppliersCategories.Text = "  Suppliers & Categories  "
        ' 
        ' rtbSuppliersCategories
        ' 
        rtbSuppliersCategories.BackColor = Color.White
        rtbSuppliersCategories.BorderStyle = BorderStyle.None
        rtbSuppliersCategories.Dock = DockStyle.Fill
        rtbSuppliersCategories.Font = New Font("Segoe UI", 10F)
        rtbSuppliersCategories.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        rtbSuppliersCategories.Location = New Point(16, 16)
        rtbSuppliersCategories.Name = "rtbSuppliersCategories"
        rtbSuppliersCategories.ReadOnly = True
        rtbSuppliersCategories.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbSuppliersCategories.Size = New Size(940, 589)
        rtbSuppliersCategories.TabIndex = 0
        rtbSuppliersCategories.Text = ""
        ' 
        ' tabReports
        ' 
        tabReports.BackColor = Color.White
        tabReports.Controls.Add(rtbReports)
        tabReports.Location = New Point(4, 26)
        tabReports.Name = "tabReports"
        tabReports.Padding = New Padding(16)
        tabReports.Size = New Size(972, 621)
        tabReports.TabIndex = 6
        tabReports.Text = "  Reports & Analytics  "
        ' 
        ' rtbReports
        ' 
        rtbReports.BackColor = Color.White
        rtbReports.BorderStyle = BorderStyle.None
        rtbReports.Dock = DockStyle.Fill
        rtbReports.Font = New Font("Segoe UI", 10F)
        rtbReports.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        rtbReports.Location = New Point(16, 16)
        rtbReports.Name = "rtbReports"
        rtbReports.ReadOnly = True
        rtbReports.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbReports.Size = New Size(940, 589)
        rtbReports.TabIndex = 0
        rtbReports.Text = ""
        ' 
        ' tabSettings
        ' 
        tabSettings.BackColor = Color.White
        tabSettings.Controls.Add(rtbSettings)
        tabSettings.Location = New Point(4, 26)
        tabSettings.Name = "tabSettings"
        tabSettings.Padding = New Padding(16)
        tabSettings.Size = New Size(972, 621)
        tabSettings.TabIndex = 7
        tabSettings.Text = "  Settings & Security  "
        ' 
        ' rtbSettings
        ' 
        rtbSettings.BackColor = Color.White
        rtbSettings.BorderStyle = BorderStyle.None
        rtbSettings.Dock = DockStyle.Fill
        rtbSettings.Font = New Font("Segoe UI", 10F)
        rtbSettings.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        rtbSettings.Location = New Point(16, 16)
        rtbSettings.Name = "rtbSettings"
        rtbSettings.ReadOnly = True
        rtbSettings.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbSettings.Size = New Size(940, 589)
        rtbSettings.TabIndex = 0
        rtbSettings.Text = ""
        ' 
        ' frmSystemManual
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        ClientSize = New Size(980, 725)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmSystemManual"
        Text = "System Manual"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        tabControl.ResumeLayout(False)
        tabOverview.ResumeLayout(False)
        tabProducts.ResumeLayout(False)
        tabInventory.ResumeLayout(False)
        tabNewSale.ResumeLayout(False)
        tabSalesHistory.ResumeLayout(False)
        tabSuppliersCategories.ResumeLayout(False)
        tabReports.ResumeLayout(False)
        tabSettings.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblPageHeader As Label
    Friend WithEvents lblPageSub As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabOverview As TabPage
    Friend WithEvents rtbOverview As RichTextBox
    Friend WithEvents tabProducts As TabPage
    Friend WithEvents rtbProducts As RichTextBox
    Friend WithEvents tabInventory As TabPage
    Friend WithEvents rtbInventory As RichTextBox
    Friend WithEvents tabNewSale As TabPage
    Friend WithEvents rtbNewSale As RichTextBox
    Friend WithEvents tabSalesHistory As TabPage
    Friend WithEvents rtbSalesHistory As RichTextBox
    Friend WithEvents tabSuppliersCategories As TabPage
    Friend WithEvents rtbSuppliersCategories As RichTextBox
    Friend WithEvents tabReports As TabPage
    Friend WithEvents rtbReports As RichTextBox
    Friend WithEvents tabSettings As TabPage
    Friend WithEvents rtbSettings As RichTextBox

End Class
