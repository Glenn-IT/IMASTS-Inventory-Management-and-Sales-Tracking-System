<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.components         = New System.ComponentModel.Container()
        Me.pnlTop             = New System.Windows.Forms.Panel()
        Me.lblTitle           = New System.Windows.Forms.Label()
        Me.pnlSidebar         = New System.Windows.Forms.Panel()
        Me.pnlLogoutBar       = New System.Windows.Forms.Panel()
        Me.btnLogout          = New System.Windows.Forms.Button()
        Me.flpNav             = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblNavHeader       = New System.Windows.Forms.Label()
        Me.btnDashboard       = New System.Windows.Forms.Button()
        Me.btnProducts        = New System.Windows.Forms.Button()
        Me.btnInventory       = New System.Windows.Forms.Button()
        Me.lblSalesSep        = New System.Windows.Forms.Label()
        Me.btnNewSale         = New System.Windows.Forms.Button()
        Me.btnSalesHistory    = New System.Windows.Forms.Button()
        Me.lblMgmtSep         = New System.Windows.Forms.Label()
        Me.btnSuppliers       = New System.Windows.Forms.Button()
        Me.btnCategories      = New System.Windows.Forms.Button()
        Me.lblToolsSep        = New System.Windows.Forms.Label()
        Me.btnReports         = New System.Windows.Forms.Button()
        Me.btnSettings        = New System.Windows.Forms.Button()
        Me.pnlStatus          = New System.Windows.Forms.Panel()
        Me.lblStatusUser      = New System.Windows.Forms.Label()
        Me.lblStatusDateTime  = New System.Windows.Forms.Label()
        Me.pnlContent         = New System.Windows.Forms.Panel()
        Me.tmrClock           = New System.Windows.Forms.Timer(Me.components)

        Me.pnlTop.SuspendLayout()
        Me.pnlLogoutBar.SuspendLayout()
        Me.flpNav.SuspendLayout()
        Me.pnlSidebar.SuspendLayout()
        Me.pnlStatus.SuspendLayout()
        Me.SuspendLayout()

        ' ── pnlTop ──────────────────────────────────────────────────
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock   = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Height = 52
        Me.pnlTop.Name   = "pnlTop"

        ' lblTitle
        Me.lblTitle.AutoSize  = False
        Me.lblTitle.Dock      = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Name      = "lblTitle"
        Me.lblTitle.Padding   = New System.Windows.Forms.Padding(16, 0, 0, 0)
        Me.lblTitle.Text      = "IMASTS — Inventory Management and Sales Tracking System"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' ── pnlStatus ───────────────────────────────────────────────
        Me.pnlStatus.Controls.Add(Me.lblStatusDateTime)
        Me.pnlStatus.Controls.Add(Me.lblStatusUser)
        Me.pnlStatus.Dock   = System.Windows.Forms.DockStyle.Bottom
        Me.pnlStatus.Height = 28
        Me.pnlStatus.Name   = "pnlStatus"

        ' lblStatusUser
        Me.lblStatusUser.AutoSize  = False
        Me.lblStatusUser.Dock      = System.Windows.Forms.DockStyle.Left
        Me.lblStatusUser.Name      = "lblStatusUser"
        Me.lblStatusUser.Padding   = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.lblStatusUser.Size      = New System.Drawing.Size(420, 28)
        Me.lblStatusUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' lblStatusDateTime
        Me.lblStatusDateTime.AutoSize  = False
        Me.lblStatusDateTime.Dock      = System.Windows.Forms.DockStyle.Right
        Me.lblStatusDateTime.Name      = "lblStatusDateTime"
        Me.lblStatusDateTime.Padding   = New System.Windows.Forms.Padding(0, 0, 12, 0)
        Me.lblStatusDateTime.Size      = New System.Drawing.Size(270, 28)
        Me.lblStatusDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight

        ' ── pnlSidebar ──────────────────────────────────────────────
        Me.pnlSidebar.Controls.Add(Me.flpNav)
        Me.pnlSidebar.Controls.Add(Me.pnlLogoutBar)
        Me.pnlSidebar.Dock  = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Name  = "pnlSidebar"
        Me.pnlSidebar.Width = 210

        ' pnlLogoutBar
        Me.pnlLogoutBar.Controls.Add(Me.btnLogout)
        Me.pnlLogoutBar.Dock   = System.Windows.Forms.DockStyle.Bottom
        Me.pnlLogoutBar.Height = 52
        Me.pnlLogoutBar.Name   = "pnlLogoutBar"

        ' btnLogout
        Me.btnLogout.Dock     = System.Windows.Forms.DockStyle.Fill
        Me.btnLogout.Name     = "btnLogout"
        Me.btnLogout.Text     = "  Logout"
        Me.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' flpNav
        Me.flpNav.AutoScroll    = False
        Me.flpNav.Dock          = System.Windows.Forms.DockStyle.Fill
        Me.flpNav.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpNav.Name          = "flpNav"
        Me.flpNav.Padding       = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.flpNav.WrapContents  = False
        Me.flpNav.Controls.Add(Me.lblNavHeader)
        Me.flpNav.Controls.Add(Me.btnDashboard)
        Me.flpNav.Controls.Add(Me.btnProducts)
        Me.flpNav.Controls.Add(Me.btnInventory)
        Me.flpNav.Controls.Add(Me.lblSalesSep)
        Me.flpNav.Controls.Add(Me.btnNewSale)
        Me.flpNav.Controls.Add(Me.btnSalesHistory)
        Me.flpNav.Controls.Add(Me.lblMgmtSep)
        Me.flpNav.Controls.Add(Me.btnSuppliers)
        Me.flpNav.Controls.Add(Me.btnCategories)
        Me.flpNav.Controls.Add(Me.lblToolsSep)
        Me.flpNav.Controls.Add(Me.btnReports)
        Me.flpNav.Controls.Add(Me.btnSettings)

        Dim btnSz As New System.Drawing.Size(210, 40)
        Dim sepSz As New System.Drawing.Size(210, 26)
        Dim zero  As New System.Windows.Forms.Padding(0)

        ' lblNavHeader
        Me.lblNavHeader.AutoSize  = False
        Me.lblNavHeader.Margin    = zero
        Me.lblNavHeader.Name      = "lblNavHeader"
        Me.lblNavHeader.Padding   = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.lblNavHeader.Size      = sepSz
        Me.lblNavHeader.Text      = "MAIN MENU"
        Me.lblNavHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' btnDashboard
        Me.btnDashboard.AutoSize  = False
        Me.btnDashboard.Margin    = zero
        Me.btnDashboard.Name      = "btnDashboard"
        Me.btnDashboard.Size      = btnSz
        Me.btnDashboard.Text      = "  Dashboard"
        Me.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' btnProducts
        Me.btnProducts.AutoSize  = False
        Me.btnProducts.Margin    = zero
        Me.btnProducts.Name      = "btnProducts"
        Me.btnProducts.Size      = btnSz
        Me.btnProducts.Text      = "  Products"
        Me.btnProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' btnInventory
        Me.btnInventory.AutoSize  = False
        Me.btnInventory.Margin    = zero
        Me.btnInventory.Name      = "btnInventory"
        Me.btnInventory.Size      = btnSz
        Me.btnInventory.Text      = "  Inventory"
        Me.btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' lblSalesSep
        Me.lblSalesSep.AutoSize  = False
        Me.lblSalesSep.Margin    = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.lblSalesSep.Name      = "lblSalesSep"
        Me.lblSalesSep.Padding   = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.lblSalesSep.Size      = sepSz
        Me.lblSalesSep.Text      = "SALES"
        Me.lblSalesSep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' btnNewSale
        Me.btnNewSale.AutoSize  = False
        Me.btnNewSale.Margin    = zero
        Me.btnNewSale.Name      = "btnNewSale"
        Me.btnNewSale.Size      = btnSz
        Me.btnNewSale.Text      = "  New Sale"
        Me.btnNewSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' btnSalesHistory
        Me.btnSalesHistory.AutoSize  = False
        Me.btnSalesHistory.Margin    = zero
        Me.btnSalesHistory.Name      = "btnSalesHistory"
        Me.btnSalesHistory.Size      = btnSz
        Me.btnSalesHistory.Text      = "  Sales History"
        Me.btnSalesHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' lblMgmtSep
        Me.lblMgmtSep.AutoSize  = False
        Me.lblMgmtSep.Margin    = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.lblMgmtSep.Name      = "lblMgmtSep"
        Me.lblMgmtSep.Padding   = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.lblMgmtSep.Size      = sepSz
        Me.lblMgmtSep.Text      = "MANAGEMENT"
        Me.lblMgmtSep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' btnSuppliers
        Me.btnSuppliers.AutoSize  = False
        Me.btnSuppliers.Margin    = zero
        Me.btnSuppliers.Name      = "btnSuppliers"
        Me.btnSuppliers.Size      = btnSz
        Me.btnSuppliers.Text      = "  Suppliers"
        Me.btnSuppliers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' btnCategories
        Me.btnCategories.AutoSize  = False
        Me.btnCategories.Margin    = zero
        Me.btnCategories.Name      = "btnCategories"
        Me.btnCategories.Size      = btnSz
        Me.btnCategories.Text      = "  Categories"
        Me.btnCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' lblToolsSep
        Me.lblToolsSep.AutoSize  = False
        Me.lblToolsSep.Margin    = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.lblToolsSep.Name      = "lblToolsSep"
        Me.lblToolsSep.Padding   = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.lblToolsSep.Size      = sepSz
        Me.lblToolsSep.Text      = "TOOLS"
        Me.lblToolsSep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' btnReports
        Me.btnReports.AutoSize  = False
        Me.btnReports.Margin    = zero
        Me.btnReports.Name      = "btnReports"
        Me.btnReports.Size      = btnSz
        Me.btnReports.Text      = "  Reports"
        Me.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' btnSettings
        Me.btnSettings.AutoSize  = False
        Me.btnSettings.Margin    = zero
        Me.btnSettings.Name      = "btnSettings"
        Me.btnSettings.Size      = btnSz
        Me.btnSettings.Text      = "  Settings"
        Me.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        ' ── pnlContent ──────────────────────────────────────────────
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(245, 246, 248)
        Me.pnlContent.Dock      = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Name      = "pnlContent"

        ' tmrClock
        Me.tmrClock.Interval = 1000

        ' ── frmMain ─────────────────────────────────────────────────
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize          = New System.Drawing.Size(1200, 700)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.pnlTop)
        Me.IsMdiContainer      = False
        Me.MinimumSize         = New System.Drawing.Size(900, 600)
        Me.Name                = "frmMain"
        Me.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text                = "IMASTS"
        Me.WindowState         = System.Windows.Forms.FormWindowState.Maximized

        Me.pnlTop.ResumeLayout(False)
        Me.pnlLogoutBar.ResumeLayout(False)
        Me.flpNav.ResumeLayout(False)
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlStatus.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents pnlTop            As System.Windows.Forms.Panel
    Friend WithEvents lblTitle          As System.Windows.Forms.Label
    Friend WithEvents pnlSidebar        As System.Windows.Forms.Panel
    Friend WithEvents pnlLogoutBar      As System.Windows.Forms.Panel
    Friend WithEvents btnLogout         As System.Windows.Forms.Button
    Friend WithEvents flpNav            As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblNavHeader      As System.Windows.Forms.Label
    Friend WithEvents btnDashboard      As System.Windows.Forms.Button
    Friend WithEvents btnProducts       As System.Windows.Forms.Button
    Friend WithEvents btnInventory      As System.Windows.Forms.Button
    Friend WithEvents lblSalesSep       As System.Windows.Forms.Label
    Friend WithEvents btnNewSale        As System.Windows.Forms.Button
    Friend WithEvents btnSalesHistory   As System.Windows.Forms.Button
    Friend WithEvents lblMgmtSep        As System.Windows.Forms.Label
    Friend WithEvents btnSuppliers      As System.Windows.Forms.Button
    Friend WithEvents btnCategories     As System.Windows.Forms.Button
    Friend WithEvents lblToolsSep       As System.Windows.Forms.Label
    Friend WithEvents btnReports        As System.Windows.Forms.Button
    Friend WithEvents btnSettings       As System.Windows.Forms.Button
    Friend WithEvents pnlStatus         As System.Windows.Forms.Panel
    Friend WithEvents lblStatusUser     As System.Windows.Forms.Label
    Friend WithEvents lblStatusDateTime As System.Windows.Forms.Label
    Friend WithEvents pnlContent        As System.Windows.Forms.Panel
    Friend WithEvents tmrClock          As System.Windows.Forms.Timer

End Class
