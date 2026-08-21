Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class SaleRepository

    Public Function GetProductsForSale() As DataTable
        ProductRepository.EnsureSchema()
        Dim sql As String =
            "SELECT ProductID, ISNULL(Barcode, '') AS Barcode, Name, UnitPrice, StockQty " &
            "FROM tbl_Products " &
            "ORDER BY Name"
        Dim dt As New DataTable()
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                conn.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using
        Return dt
    End Function

    Public Function CreateSale(username As String, items As DataTable, discount As Decimal) As Integer
        Dim subtotal As Decimal = 0
        For Each row As DataRow In items.Rows
            subtotal += CDec(row("Subtotal"))
        Next
        Dim netAmount As Decimal = subtotal - discount

        Using conn As New SqlConnection(dbconstring.Connection)
            conn.Open()
            Using tran = conn.BeginTransaction()
                Try
                    ' Insert sale header
                    Dim saleId As Integer
                    Using cmd As New SqlCommand(
                        "INSERT INTO tbl_Sales (SaleDate, CashierID, TotalAmount, Discount, NetAmount, IsVoided) " &
                        "VALUES (GETDATE(), (SELECT UserID FROM tbl_Users WHERE Username = @Username), " &
                        "@Total, @Discount, @Net, 0); SELECT CAST(SCOPE_IDENTITY() AS INT)", conn, tran)
                        cmd.Parameters.AddWithValue("@Username", username)
                        cmd.Parameters.AddWithValue("@Total",    subtotal)
                        cmd.Parameters.AddWithValue("@Discount", discount)
                        cmd.Parameters.AddWithValue("@Net",      netAmount)
                        saleId = CInt(cmd.ExecuteScalar())
                    End Using

                    ' Insert line items and deduct stock
                    For Each row As DataRow In items.Rows
                        Dim productId   = CInt(row("ProductID"))
                        Dim qty         = CInt(row("Quantity"))
                        Dim unitPrice   = CDec(row("UnitPrice"))
                        Dim lineSub     = CDec(row("Subtotal"))

                        Using cmd As New SqlCommand(
                            "INSERT INTO tbl_SaleItems (SaleID, ProductID, Quantity, UnitPrice, Subtotal) " &
                            "VALUES (@SaleID, @ProductID, @Qty, @UnitPrice, @Subtotal)", conn, tran)
                            cmd.Parameters.AddWithValue("@SaleID",    saleId)
                            cmd.Parameters.AddWithValue("@ProductID", productId)
                            cmd.Parameters.AddWithValue("@Qty",       qty)
                            cmd.Parameters.AddWithValue("@UnitPrice", unitPrice)
                            cmd.Parameters.AddWithValue("@Subtotal",  lineSub)
                            cmd.ExecuteNonQuery()
                        End Using

                        Using cmd As New SqlCommand(
                            "UPDATE tbl_Products SET StockQty = StockQty - @Qty WHERE ProductID = @ProductID",
                            conn, tran)
                            cmd.Parameters.AddWithValue("@Qty",       qty)
                            cmd.Parameters.AddWithValue("@ProductID", productId)
                            cmd.ExecuteNonQuery()
                        End Using
                    Next

                    tran.Commit()
                    Return saleId
                Catch
                    tran.Rollback()
                    Return -1
                End Try
            End Using
        End Using
    End Function

    Public Function GetAll(fromDate As Date, toDate As Date) As DataTable
        Dim sql As String =
            "SELECT s.SaleID, s.SaleDate, u.Username AS Cashier, " &
            "s.TotalAmount, s.Discount, s.NetAmount, s.IsVoided, " &
            "CASE WHEN s.IsVoided = 1 THEN 'Voided' ELSE 'Active' END AS Status " &
            "FROM tbl_Sales s " &
            "LEFT JOIN tbl_Users u ON s.CashierID = u.UserID " &
            "WHERE CONVERT(DATE, s.SaleDate) BETWEEN @From AND @To " &
            "ORDER BY s.SaleDate DESC"
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

    Public Function GetSaleItems(saleId As Integer) As DataTable
        Dim sql As String =
            "SELECT p.Name AS Product, si.Quantity, si.UnitPrice, si.Subtotal " &
            "FROM tbl_SaleItems si " &
            "JOIN tbl_Products p ON si.ProductID = p.ProductID " &
            "WHERE si.SaleID = @SaleID " &
            "ORDER BY p.Name"
        Dim dt As New DataTable()
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@SaleID", saleId)
                conn.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using
        Return dt
    End Function

    Public Function VoidSale(saleId As Integer) As Boolean
        Using conn As New SqlConnection(dbconstring.Connection)
            conn.Open()
            Using tran = conn.BeginTransaction()
                Try
                    ' Restore stock for each line item
                    Using cmd As New SqlCommand(
                        "UPDATE tbl_Products SET StockQty = StockQty + si.Quantity " &
                        "FROM tbl_Products p " &
                        "INNER JOIN tbl_SaleItems si ON p.ProductID = si.ProductID " &
                        "WHERE si.SaleID = @SaleID", conn, tran)
                        cmd.Parameters.AddWithValue("@SaleID", saleId)
                        cmd.ExecuteNonQuery()
                    End Using

                    ' Mark sale as voided
                    Using cmd As New SqlCommand(
                        "UPDATE tbl_Sales SET IsVoided = 1 WHERE SaleID = @SaleID", conn, tran)
                        cmd.Parameters.AddWithValue("@SaleID", saleId)
                        cmd.ExecuteNonQuery()
                    End Using

                    tran.Commit()
                    Return True
                Catch
                    tran.Rollback()
                    Return False
                End Try
            End Using
        End Using
    End Function

End Class
