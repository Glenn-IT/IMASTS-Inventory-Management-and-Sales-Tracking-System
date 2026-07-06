Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyTheme()
        Me.Text            = $"IMASTS  —  {SessionManager.Username}  ({SessionManager.UserType})"
        btnSettings.Visible = (SessionManager.UserType = Constants.RoleAdmin)
        UpdateStatusBar()
        tmrClock.Start()
        OpenChildForm(New frmDashboard())
    End Sub

    ' ── Theme ────────────────────────────────────────────────────────────

    Private Sub ApplyTheme()
        Dim navy     As Drawing.Color = Drawing.Color.FromArgb(28, 43, 74)
        Dim navyDark As Drawing.Color = Drawing.Color.FromArgb(20, 33, 58)
        Dim btnText  As Drawing.Color = Drawing.Color.FromArgb(210, 220, 235)
        Dim sepText  As Drawing.Color = Drawing.Color.FromArgb(100, 128, 160)
        Dim hover    As Drawing.Color = Drawing.Color.FromArgb(45, 65, 105)
        Dim barBg    As Drawing.Color = Drawing.Color.FromArgb(232, 235, 240)
        Dim barText  As Drawing.Color = Drawing.Color.FromArgb(80, 80, 80)

        pnlTop.BackColor    = navy
        lblTitle.Font       = New Drawing.Font("Segoe UI", 13.0!, Drawing.FontStyle.Bold)
        lblTitle.ForeColor  = Drawing.Color.White

        pnlSidebar.BackColor = navy
        flpNav.BackColor     = Drawing.Color.Transparent

        For Each lbl As Label In {lblNavHeader, lblSalesSep, lblMgmtSep, lblToolsSep}
            lbl.Font      = New Drawing.Font("Segoe UI", 7.5!, Drawing.FontStyle.Bold)
            lbl.ForeColor = sepText
            lbl.BackColor = Drawing.Color.Transparent
        Next

        Dim navFont As New Drawing.Font("Segoe UI", 9.5!)
        For Each btn As Button In {btnDashboard, btnProducts, btnInventory,
                                   btnNewSale, btnSalesHistory,
                                   btnSuppliers, btnCategories,
                                   btnReports, btnSettings}
            btn.BackColor = Drawing.Color.Transparent
            btn.Cursor    = Cursors.Hand
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderSize          = 0
            btn.FlatAppearance.MouseOverBackColor  = hover
            btn.Font      = navFont
            btn.ForeColor = btnText
        Next

        pnlLogoutBar.BackColor                        = navyDark
        btnLogout.BackColor                           = Drawing.Color.FromArgb(192, 57, 43)
        btnLogout.Cursor                              = Cursors.Hand
        btnLogout.FlatStyle                           = FlatStyle.Flat
        btnLogout.FlatAppearance.BorderSize           = 0
        btnLogout.FlatAppearance.MouseOverBackColor   = Drawing.Color.FromArgb(160, 40, 30)
        btnLogout.Font                                = New Drawing.Font("Segoe UI", 9.5!, Drawing.FontStyle.Bold)
        btnLogout.ForeColor                           = Drawing.Color.White

        pnlStatus.BackColor         = barBg
        lblStatusUser.Font          = New Drawing.Font("Segoe UI", 8.5!)
        lblStatusUser.ForeColor     = barText
        lblStatusDateTime.Font      = New Drawing.Font("Segoe UI", 8.5!)
        lblStatusDateTime.ForeColor = barText
    End Sub

    ' ── Status bar ───────────────────────────────────────────────────────

    Private Sub UpdateStatusBar()
        lblStatusUser.Text     = $"Logged in as:  {SessionManager.Username}  |  Role: {SessionManager.UserType}"
        lblStatusDateTime.Text = DateTime.Now.ToString("ddd, MMM d, yyyy   h:mm:ss tt")
    End Sub

    Private Sub tmrClock_Tick(sender As Object, e As EventArgs) Handles tmrClock.Tick
        lblStatusDateTime.Text = DateTime.Now.ToString("ddd, MMM d, yyyy   h:mm:ss tt")
    End Sub

    ' ── MDI helper ───────────────────────────────────────────────────────

    Private Sub OpenChildForm(form As Form)
        pnlContent.Controls.Clear()
        form.TopLevel         = False
        form.FormBorderStyle  = FormBorderStyle.None
        form.Dock             = DockStyle.Fill
        pnlContent.Controls.Add(form)
        form.Show()
    End Sub

    ' ── Navigation ───────────────────────────────────────────────────────

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        OpenChildForm(New frmDashboard())
    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        ' GATE — swap to New frmProducts() when unlocking for v2.04
        OpenChildForm(New UnderConstructionForm())
    End Sub

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        ' GATE — swap to New frmInventory() when unlocking for v2.05
        OpenChildForm(New UnderConstructionForm())
    End Sub

    Private Sub btnNewSale_Click(sender As Object, e As EventArgs) Handles btnNewSale.Click
        ' GATE — swap to New frmNewSale() when unlocking for v2.06
        OpenChildForm(New UnderConstructionForm())
    End Sub

    Private Sub btnSalesHistory_Click(sender As Object, e As EventArgs) Handles btnSalesHistory.Click
        ' GATE — swap to New frmSalesHistory() when unlocking for v2.07
        OpenChildForm(New UnderConstructionForm())
    End Sub

    Private Sub btnSuppliers_Click(sender As Object, e As EventArgs) Handles btnSuppliers.Click
        OpenChildForm(New frmSuppliers())
    End Sub

    Private Sub btnCategories_Click(sender As Object, e As EventArgs) Handles btnCategories.Click
        OpenChildForm(New frmCategories())
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        ' GATE — swap to New frmReports() when unlocking for v2.08
        OpenChildForm(New UnderConstructionForm())
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        ' GATE — swap to New frmSettings() when unlocking for v2.09
        OpenChildForm(New UnderConstructionForm())
    End Sub

    ' ── Logout ───────────────────────────────────────────────────────────

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim confirm = MessageBox.Show(
            "Are you sure you want to log out?",
            "Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, "User logged out.")
            SessionManager.Clear()
            Me.Close()
        End If
    End Sub

End Class
