Public Class frmDashboard

    Private _repo As New DashboardRepository()

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
Me.Text = "Dashboard"
        LoadDashboard()
    End Sub

    Private Sub LoadDashboard()
        Try
            lblTotalProducts.Text = _repo.GetTotalProducts().ToString()
            lblLowStock.Text = _repo.GetLowStockCount().ToString()
            lblTodaySales.Text = _repo.GetTodaySalesCount().ToString()
            lblTodayRevenue.Text = _repo.GetTodayRevenue().ToString("C2")
        Catch ex As Exception
            MessageBox.Show("Failed to load dashboard data: " & ex.Message,
                            "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadDashboard()
    End Sub

End Class
