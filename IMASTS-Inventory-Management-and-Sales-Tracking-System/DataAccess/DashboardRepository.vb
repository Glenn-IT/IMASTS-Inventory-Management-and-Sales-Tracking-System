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

    Public Function GetDailyRevenue(fromDate As Date, toDate As Date) As DataTable
        Dim sql As String =
            "SELECT CAST(SaleDate AS DATE) AS SaleDay, " &
            "       SUM(NetAmount) AS Revenue " &
            "FROM tbl_Sales " &
            "WHERE IsVoided = 0 " &
            "  AND CAST(SaleDate AS DATE) BETWEEN @From AND @To " &
            "GROUP BY CAST(SaleDate AS DATE) " &
            "ORDER BY SaleDay"
        Dim dt As New DataTable()
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@From", fromDate.Date)
                cmd.Parameters.AddWithValue("@To", toDate.Date)
                conn.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using
        Return dt
    End Function

    Public Function GetSalesByCategory(fromDate As Date, toDate As Date) As DataTable
        Dim sql As String =
            "SELECT ISNULL(c.CategoryName, 'Uncategorized') AS CategoryName, " &
            "       SUM(si.Subtotal) AS Revenue " &
            "FROM tbl_SaleItems si " &
            "JOIN tbl_Sales    s ON si.SaleID    = s.SaleID " &
            "JOIN tbl_Products p ON si.ProductID = p.ProductID " &
            "LEFT JOIN tbl_Categories c ON p.CategoryID = c.CategoryID " &
            "WHERE s.IsVoided = 0 " &
            "  AND CAST(s.SaleDate AS DATE) BETWEEN @From AND @To " &
            "GROUP BY ISNULL(c.CategoryName, 'Uncategorized') " &
            "ORDER BY Revenue DESC"
        Dim dt As New DataTable()
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@From", fromDate.Date)
                cmd.Parameters.AddWithValue("@To", toDate.Date)
                conn.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using
        Return dt
    End Function

End Class
