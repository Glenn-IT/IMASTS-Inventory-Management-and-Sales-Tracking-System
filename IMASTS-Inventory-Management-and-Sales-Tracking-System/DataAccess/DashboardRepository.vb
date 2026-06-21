Imports Microsoft.Data.SqlClient

Public Class DashboardRepository

    Public Function GetTotalProducts() As Integer
        Dim sql As String = "SELECT COUNT(*) FROM tbl_Products"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                conn.Open()
                Return CInt(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    Public Function GetLowStockCount() As Integer
        Dim sql As String = "SELECT COUNT(*) FROM tbl_Products WHERE StockQty <= ReorderLevel"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                conn.Open()
                Return CInt(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    Public Function GetTodaySalesCount() As Integer
        Dim sql As String =
            "SELECT COUNT(*) FROM tbl_Sales " &
            "WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE) AND IsVoided = 0"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                conn.Open()
                Return CInt(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    Public Function GetTodayRevenue() As Decimal
        Dim sql As String =
            "SELECT ISNULL(SUM(NetAmount), 0) FROM tbl_Sales " &
            "WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE) AND IsVoided = 0"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                conn.Open()
                Return CDec(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

End Class
