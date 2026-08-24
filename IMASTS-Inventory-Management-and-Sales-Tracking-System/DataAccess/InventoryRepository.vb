Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class InventoryRepository

    Public Shared Sub EnsureSchema()
        Try
            ProductRepository.EnsureSchema()
            Using conn As New SqlConnection(dbconstring.Connection)
                conn.Open()
                Dim sql As String =
                    "IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'tbl_StockReceipts') " &
                    "CREATE TABLE tbl_StockReceipts ( " &
                    "    ReceiptID INT IDENTITY(1,1) PRIMARY KEY, " &
                    "    ProductID INT NOT NULL FOREIGN KEY REFERENCES tbl_Products(ProductID), " &
                    "    Quantity INT NOT NULL, " &
                    "    ReceiptDate DATETIME NOT NULL DEFAULT GETDATE(), " &
                    "    SupplierID INT NULL FOREIGN KEY REFERENCES tbl_Suppliers(SupplierID), " &
                    "    Notes NVARCHAR(255) NULL " &
                    ");"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Public Function GetAllWithStockLevel() As DataTable
        EnsureSchema()
        Dim sql As String =
            "SELECT p.ProductID, ISNULL(p.Barcode, '') AS Barcode, p.Name, ISNULL(c.CategoryName, 'Unassigned') AS CategoryName, p.StockQty, p.ReorderLevel, ISNULL(p.Unit, 'pcs') AS Unit, " &
            "CASE WHEN p.StockQty = 0            THEN 'Out of Stock' " &
            "     WHEN p.StockQty <= p.ReorderLevel THEN 'Low Stock' " &
            "     ELSE 'OK' END AS StockStatus " &
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

    Public Function GetProducts() As DataTable
        EnsureSchema()
        Dim sql As String =
            "SELECT p.ProductID, ISNULL(p.Barcode, '') AS Barcode, p.Name, p.SupplierID, p.StockQty, " &
            "ISNULL(p.Unit, 'pcs') AS Unit, ISNULL(c.CategoryName, 'Unassigned') AS CategoryName " &
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

    Public Function GetSuppliers() As DataTable
        Dim sql As String = "SELECT SupplierID, Name FROM tbl_Suppliers ORDER BY Name"
        Dim dt As New DataTable()
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                conn.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using
        Return dt
    End Function

    Public Function ReceiveStock(productId As Integer, qty As Integer,
                                 supplierId As Integer, notes As String) As Boolean
        EnsureSchema()
        Using conn As New SqlConnection(dbconstring.Connection)
            conn.Open()
            Using tran = conn.BeginTransaction()
                Try
                    Using cmd As New SqlCommand(
                        "INSERT INTO tbl_StockReceipts (ProductID, Quantity, ReceiptDate, SupplierID, Notes) " &
                        "VALUES (@ProductID, @Qty, GETDATE(), @SupplierID, @Notes)", conn, tran)
                        cmd.Parameters.AddWithValue("@ProductID",  productId)
                        cmd.Parameters.AddWithValue("@Qty",        qty)
                        cmd.Parameters.AddWithValue("@SupplierID", If(supplierId > 0, supplierId, DBNull.Value))
                        cmd.Parameters.AddWithValue("@Notes",      If(String.IsNullOrWhiteSpace(notes), DBNull.Value, notes))
                        cmd.ExecuteNonQuery()
                    End Using
                    Using cmd As New SqlCommand(
                        "UPDATE tbl_Products SET StockQty = StockQty + @Qty WHERE ProductID = @ProductID",
                        conn, tran)
                        cmd.Parameters.AddWithValue("@Qty",       qty)
                        cmd.Parameters.AddWithValue("@ProductID", productId)
                        cmd.ExecuteNonQuery()
                    End Using
                    tran.Commit()
                    Return True
                Catch ex As Exception
                    tran.Rollback()
                    Return False
                End Try
            End Using
        End Using
    End Function

    Public Function AdjustStock(productId As Integer, newQty As Integer) As Boolean
        EnsureSchema()
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(
                "UPDATE tbl_Products SET StockQty = @NewQty WHERE ProductID = @ProductID", conn)
                cmd.Parameters.AddWithValue("@NewQty",    newQty)
                cmd.Parameters.AddWithValue("@ProductID", productId)
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

End Class
