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
        txtOverview = New TextBox()
        tabProducts = New TabPage()
        txtProducts = New TextBox()
        tabInventory = New TabPage()
        txtInventory = New TextBox()
        tabNewSale = New TabPage()
        txtNewSale = New TextBox()
        tabSalesHistory = New TabPage()
        txtSalesHistory = New TextBox()
        tabSuppliersCategories = New TabPage()
        txtSuppliersCategories = New TextBox()
        tabReports = New TabPage()
        txtReports = New TextBox()
        tabSettings = New TabPage()
        txtSettings = New TextBox()
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
        tabOverview.Controls.Add(txtOverview)
        tabOverview.Location = New Point(4, 26)
        tabOverview.Name = "tabOverview"
        tabOverview.Padding = New Padding(12)
        tabOverview.Size = New Size(972, 621)
        tabOverview.TabIndex = 0
        tabOverview.Text = "  Overview & Dashboard  "
        ' 
        ' txtOverview
        ' 
        txtOverview.BackColor = Color.White
        txtOverview.BorderStyle = BorderStyle.None
        txtOverview.Dock = DockStyle.Fill
        txtOverview.Font = New Font("Segoe UI", 10F)
        txtOverview.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        txtOverview.Location = New Point(12, 12)
        txtOverview.Multiline = True
        txtOverview.Name = "txtOverview"
        txtOverview.ReadOnly = True
        txtOverview.ScrollBars = ScrollBars.Vertical
        txtOverview.Size = New Size(948, 597)
        txtOverview.TabIndex = 0
        ' 
        ' tabProducts
        ' 
        tabProducts.BackColor = Color.White
        tabProducts.Controls.Add(txtProducts)
        tabProducts.Location = New Point(4, 26)
        tabProducts.Name = "tabProducts"
        tabProducts.Padding = New Padding(12)
        tabProducts.Size = New Size(972, 621)
        tabProducts.TabIndex = 1
        tabProducts.Text = "  Products  "
        ' 
        ' txtProducts
        ' 
        txtProducts.BackColor = Color.White
        txtProducts.BorderStyle = BorderStyle.None
        txtProducts.Dock = DockStyle.Fill
        txtProducts.Font = New Font("Segoe UI", 10F)
        txtProducts.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        txtProducts.Location = New Point(12, 12)
        txtProducts.Multiline = True
        txtProducts.Name = "txtProducts"
        txtProducts.ReadOnly = True
        txtProducts.ScrollBars = ScrollBars.Vertical
        txtProducts.Size = New Size(948, 597)
        txtProducts.TabIndex = 0
        ' 
        ' tabInventory
        ' 
        tabInventory.BackColor = Color.White
        tabInventory.Controls.Add(txtInventory)
        tabInventory.Location = New Point(4, 26)
        tabInventory.Name = "tabInventory"
        tabInventory.Padding = New Padding(12)
        tabInventory.Size = New Size(972, 621)
        tabInventory.TabIndex = 2
        tabInventory.Text = "  Inventory Management  "
        ' 
        ' txtInventory
        ' 
        txtInventory.BackColor = Color.White
        txtInventory.BorderStyle = BorderStyle.None
        txtInventory.Dock = DockStyle.Fill
        txtInventory.Font = New Font("Segoe UI", 10F)
        txtInventory.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        txtInventory.Location = New Point(12, 12)
        txtInventory.Multiline = True
        txtInventory.Name = "txtInventory"
        txtInventory.ReadOnly = True
        txtInventory.ScrollBars = ScrollBars.Vertical
        txtInventory.Size = New Size(948, 597)
        txtInventory.TabIndex = 0
        ' 
        ' tabNewSale
        ' 
        tabNewSale.BackColor = Color.White
        tabNewSale.Controls.Add(txtNewSale)
        tabNewSale.Location = New Point(4, 26)
        tabNewSale.Name = "tabNewSale"
        tabNewSale.Padding = New Padding(12)
        tabNewSale.Size = New Size(972, 621)
        tabNewSale.TabIndex = 3
        tabNewSale.Text = "  New Sale (POS)  "
        ' 
        ' txtNewSale
        ' 
        txtNewSale.BackColor = Color.White
        txtNewSale.BorderStyle = BorderStyle.None
        txtNewSale.Dock = DockStyle.Fill
        txtNewSale.Font = New Font("Segoe UI", 10F)
        txtNewSale.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        txtNewSale.Location = New Point(12, 12)
        txtNewSale.Multiline = True
        txtNewSale.Name = "txtNewSale"
        txtNewSale.ReadOnly = True
        txtNewSale.ScrollBars = ScrollBars.Vertical
        txtNewSale.Size = New Size(948, 597)
        txtNewSale.TabIndex = 0
        ' 
        ' tabSalesHistory
        ' 
        tabSalesHistory.BackColor = Color.White
        tabSalesHistory.Controls.Add(txtSalesHistory)
        tabSalesHistory.Location = New Point(4, 26)
        tabSalesHistory.Name = "tabSalesHistory"
        tabSalesHistory.Padding = New Padding(12)
        tabSalesHistory.Size = New Size(972, 621)
        tabSalesHistory.TabIndex = 4
        tabSalesHistory.Text = "  Sales History  "
        ' 
        ' txtSalesHistory
        ' 
        txtSalesHistory.BackColor = Color.White
        txtSalesHistory.BorderStyle = BorderStyle.None
        txtSalesHistory.Dock = DockStyle.Fill
        txtSalesHistory.Font = New Font("Segoe UI", 10F)
        txtSalesHistory.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        txtSalesHistory.Location = New Point(12, 12)
        txtSalesHistory.Multiline = True
        txtSalesHistory.Name = "txtSalesHistory"
        txtSalesHistory.ReadOnly = True
        txtSalesHistory.ScrollBars = ScrollBars.Vertical
        txtSalesHistory.Size = New Size(948, 597)
        txtSalesHistory.TabIndex = 0
        ' 
        ' tabSuppliersCategories
        ' 
        tabSuppliersCategories.BackColor = Color.White
        tabSuppliersCategories.Controls.Add(txtSuppliersCategories)
        tabSuppliersCategories.Location = New Point(4, 26)
        tabSuppliersCategories.Name = "tabSuppliersCategories"
        tabSuppliersCategories.Padding = New Padding(12)
        tabSuppliersCategories.Size = New Size(972, 621)
        tabSuppliersCategories.TabIndex = 5
        tabSuppliersCategories.Text = "  Suppliers & Categories  "
        ' 
        ' txtSuppliersCategories
        ' 
        txtSuppliersCategories.BackColor = Color.White
        txtSuppliersCategories.BorderStyle = BorderStyle.None
        txtSuppliersCategories.Dock = DockStyle.Fill
        txtSuppliersCategories.Font = New Font("Segoe UI", 10F)
        txtSuppliersCategories.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        txtSuppliersCategories.Location = New Point(12, 12)
        txtSuppliersCategories.Multiline = True
        txtSuppliersCategories.Name = "txtSuppliersCategories"
        txtSuppliersCategories.ReadOnly = True
        txtSuppliersCategories.ScrollBars = ScrollBars.Vertical
        txtSuppliersCategories.Size = New Size(948, 597)
        txtSuppliersCategories.TabIndex = 0
        ' 
        ' tabReports
        ' 
        tabReports.BackColor = Color.White
        tabReports.Controls.Add(txtReports)
        tabReports.Location = New Point(4, 26)
        tabReports.Name = "tabReports"
        tabReports.Padding = New Padding(12)
        tabReports.Size = New Size(972, 621)
        tabReports.TabIndex = 6
        tabReports.Text = "  Reports & Analytics  "
        ' 
        ' txtReports
        ' 
        txtReports.BackColor = Color.White
        txtReports.BorderStyle = BorderStyle.None
        txtReports.Dock = DockStyle.Fill
        txtReports.Font = New Font("Segoe UI", 10F)
        txtReports.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        txtReports.Location = New Point(12, 12)
        txtReports.Multiline = True
        txtReports.Name = "txtReports"
        txtReports.ReadOnly = True
        txtReports.ScrollBars = ScrollBars.Vertical
        txtReports.Size = New Size(948, 597)
        txtReports.TabIndex = 0
        ' 
        ' tabSettings
        ' 
        tabSettings.BackColor = Color.White
        tabSettings.Controls.Add(txtSettings)
        tabSettings.Location = New Point(4, 26)
        tabSettings.Name = "tabSettings"
        tabSettings.Padding = New Padding(12)
        tabSettings.Size = New Size(972, 621)
        tabSettings.TabIndex = 7
        tabSettings.Text = "  Settings & Security  "
        ' 
        ' txtSettings
        ' 
        txtSettings.BackColor = Color.White
        txtSettings.BorderStyle = BorderStyle.None
        txtSettings.Dock = DockStyle.Fill
        txtSettings.Font = New Font("Segoe UI", 10F)
        txtSettings.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        txtSettings.Location = New Point(12, 12)
        txtSettings.Multiline = True
        txtSettings.Name = "txtSettings"
        txtSettings.ReadOnly = True
        txtSettings.ScrollBars = ScrollBars.Vertical
        txtSettings.Size = New Size(948, 597)
        txtSettings.TabIndex = 0
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
        tabOverview.PerformLayout()
        tabProducts.ResumeLayout(False)
        tabProducts.PerformLayout()
        tabInventory.ResumeLayout(False)
        tabInventory.PerformLayout()
        tabNewSale.ResumeLayout(False)
        tabNewSale.PerformLayout()
        tabSalesHistory.ResumeLayout(False)
        tabSalesHistory.PerformLayout()
        tabSuppliersCategories.ResumeLayout(False)
        tabSuppliersCategories.PerformLayout()
        tabReports.ResumeLayout(False)
        tabReports.PerformLayout()
        tabSettings.ResumeLayout(False)
        tabSettings.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblPageHeader As Label
    Friend WithEvents lblPageSub As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabOverview As TabPage
    Friend WithEvents txtOverview As TextBox
    Friend WithEvents tabProducts As TabPage
    Friend WithEvents txtProducts As TextBox
    Friend WithEvents tabInventory As TabPage
    Friend WithEvents txtInventory As TextBox
    Friend WithEvents tabNewSale As TabPage
    Friend WithEvents txtNewSale As TextBox
    Friend WithEvents tabSalesHistory As TabPage
    Friend WithEvents txtSalesHistory As TextBox
    Friend WithEvents tabSuppliersCategories As TabPage
    Friend WithEvents txtSuppliersCategories As TextBox
    Friend WithEvents tabReports As TabPage
    Friend WithEvents txtReports As TextBox
    Friend WithEvents tabSettings As TabPage
    Friend WithEvents txtSettings As TextBox

End Class
