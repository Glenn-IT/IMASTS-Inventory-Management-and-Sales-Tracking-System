Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class ReportRepository

    Public Function GetInventoryStatus() As DataTable
        Dim sql As String =
            "SELECT p.Name, c.CategoryName, p.StockQty, p.ReorderLevel, " &
            "CASE WHEN p.StockQty = 0            THEN 'Out of Stock' " &
            "     WHEN p.StockQty <= p.ReorderLevel THEN 'Low Stock' " &
            "     ELSE 'OK' END AS Status " &
            "FROM tbl_Products p " &
            "LEFT JOIN tbl_Categories c ON p.CategoryID = c.CategoryID " &
            "ORDER BY p.Name"
        Dim dt As New DataTable()
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                conn.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using
        Return dt
    End Function

    Public Function GetSalesSummary(fromDate As Date, toDate As Date) As DataTable
        Dim sql As String =
            "SELECT COUNT(*)            AS TotalSales, " &
            "       ISNULL(SUM(NetAmount), 0) AS TotalRevenue, " &
            "       ISNULL(AVG(NetAmount), 0) AS AvgSaleValue " &
            "FROM tbl_Sales " &
            "WHERE IsVoided = 0 " &
            "  AND CONVERT(DATE, SaleDate) BETWEEN @From AND @To"
        Dim dt As New DataTable()
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@From", fromDate.Date)
                cmd.Parameters.AddWithValue("@To",   toDate.Date)
                conn.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using
        Return dt
    End Function

    Public Function GetTopProducts(fromDate As Date, toDate As Date) As DataTable
        Dim sql As String =
            "SELECT TOP 5 p.Name AS Product, " &
            "       SUM(si.Quantity) AS TotalSold, " &
            "       SUM(si.Subtotal) AS TotalRevenue " &
            "FROM tbl_SaleItems si " &
            "JOIN tbl_Products p ON si.ProductID = p.ProductID " &
            "JOIN tbl_Sales    s ON si.SaleID    = s.SaleID " &
            "WHERE s.IsVoided = 0 " &
            "  AND CONVERT(DATE, s.SaleDate) BETWEEN @From AND @To " &
            "GROUP BY p.ProductID, p.Name " &
            "ORDER BY TotalSold DESC"
        Dim dt As New DataTable()
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@From", fromDate.Date)
                cmd.Parameters.AddWithValue("@To",   toDate.Date)
                conn.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using
        Return dt
    End Function

End Class
