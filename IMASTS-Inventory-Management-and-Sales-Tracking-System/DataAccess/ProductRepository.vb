Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class ProductRepository

    Public Shared Sub EnsureSchema()
        Try
            Using conn As New SqlConnection(dbconstring.Connection)
                conn.Open()
                Dim stmts As String() = {
                    "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('tbl_Categories') AND name = 'DefaultUnit') ALTER TABLE tbl_Categories ADD DefaultUnit NVARCHAR(20) NOT NULL DEFAULT 'pcs';",
                    "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('tbl_Products') AND name = 'Unit') ALTER TABLE tbl_Products ADD Unit NVARCHAR(20) NOT NULL DEFAULT 'pcs';",
                    "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('tbl_Products') AND name = 'Barcode') ALTER TABLE tbl_Products ADD Barcode NVARCHAR(100) NULL;",
                    "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_tbl_Products_Barcode' AND object_id = OBJECT_ID('tbl_Products')) CREATE NONCLUSTERED INDEX IX_tbl_Products_Barcode ON tbl_Products(Barcode) WHERE Barcode IS NOT NULL;"
                }
                For Each sql In stmts
                    Try
                        Using cmd As New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                        End Using
                    Catch exInner As Exception
                    End Try
                Next
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Public Function GetAll() As DataTable
        EnsureSchema()
        Dim sql As String =
            "SELECT p.ProductID, ISNULL(p.Barcode, '') AS Barcode, p.Name, c.CategoryName, s.Name AS SupplierName, " &
            "p.Description, p.UnitPrice, p.StockQty, p.ReorderLevel, " &
            "p.CategoryID, p.SupplierID, ISNULL(p.Unit, 'pcs') AS Unit " &
            "FROM tbl_Products p " &
            "LEFT JOIN tbl_Categories c ON p.CategoryID = c.CategoryID " &
            "LEFT JOIN tbl_Suppliers  s ON p.SupplierID = s.SupplierID " &
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

    Public Function GetCategories() As DataTable
        EnsureSchema()
        Dim sql As String = "SELECT CategoryID, CategoryName, ISNULL(DefaultUnit, 'pcs') AS DefaultUnit FROM tbl_Categories ORDER BY CategoryName"
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

    Public Function Add(name As String, categoryId As Integer, supplierId As Integer,
                        description As String, unitPrice As Decimal,
                        stockQty As Integer, reorderLevel As Integer,
                        Optional unit As String = "pcs", Optional barcode As String = "") As Boolean
        EnsureSchema()
        If String.IsNullOrWhiteSpace(unit) Then unit = "pcs"
        Dim sql As String =
            "INSERT INTO tbl_Products (Name, CategoryID, SupplierID, Description, UnitPrice, StockQty, ReorderLevel, Unit, Barcode) " &
            "VALUES (@Name, @CategoryID, @SupplierID, @Description, @UnitPrice, @StockQty, @ReorderLevel, @Unit, @Barcode)"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Name",         name)
                cmd.Parameters.AddWithValue("@CategoryID",   categoryId)
                cmd.Parameters.AddWithValue("@SupplierID",   supplierId)
                cmd.Parameters.AddWithValue("@Description",  If(description = "", DBNull.Value, description))
                cmd.Parameters.AddWithValue("@UnitPrice",    unitPrice)
                cmd.Parameters.AddWithValue("@StockQty",     stockQty)
                cmd.Parameters.AddWithValue("@ReorderLevel", reorderLevel)
                cmd.Parameters.AddWithValue("@Unit",         unit)
                cmd.Parameters.AddWithValue("@Barcode",      If(String.IsNullOrWhiteSpace(barcode), DBNull.Value, barcode.Trim()))
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Update(id As Integer, name As String, categoryId As Integer, supplierId As Integer,
                           description As String, unitPrice As Decimal,
                           stockQty As Integer, reorderLevel As Integer,
                           Optional unit As String = "pcs", Optional barcode As String = "") As Boolean
        EnsureSchema()
        If String.IsNullOrWhiteSpace(unit) Then unit = "pcs"
        Dim sql As String =
            "UPDATE tbl_Products SET Name = @Name, CategoryID = @CategoryID, SupplierID = @SupplierID, " &
            "Description = @Description, UnitPrice = @UnitPrice, StockQty = @StockQty, " &
            "ReorderLevel = @ReorderLevel, Unit = @Unit, Barcode = @Barcode WHERE ProductID = @ID"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Name",         name)
                cmd.Parameters.AddWithValue("@CategoryID",   categoryId)
                cmd.Parameters.AddWithValue("@SupplierID",   supplierId)
                cmd.Parameters.AddWithValue("@Description",  If(description = "", DBNull.Value, description))
                cmd.Parameters.AddWithValue("@UnitPrice",    unitPrice)
                cmd.Parameters.AddWithValue("@StockQty",     stockQty)
                cmd.Parameters.AddWithValue("@ReorderLevel", reorderLevel)
                cmd.Parameters.AddWithValue("@Unit",         unit)
                cmd.Parameters.AddWithValue("@Barcode",      If(String.IsNullOrWhiteSpace(barcode), DBNull.Value, barcode.Trim()))
                cmd.Parameters.AddWithValue("@ID",           id)
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Delete(id As Integer) As Boolean
        EnsureSchema()
        Dim sql As String = "DELETE FROM tbl_Products WHERE ProductID = @ID"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@ID", id)
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function BarcodeExists(barcode As String, Optional excludeProductId As Integer = 0) As Boolean
        If String.IsNullOrWhiteSpace(barcode) Then Return False
        EnsureSchema()
        Dim sql As String = "SELECT COUNT(*) FROM tbl_Products WHERE Barcode = @Barcode AND ProductID <> @ExcludeID"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Barcode", barcode.Trim())
                cmd.Parameters.AddWithValue("@ExcludeID", excludeProductId)
                conn.Open()
                Return CInt(cmd.ExecuteScalar()) > 0
            End Using
        End Using
    End Function

    Public Function GetByBarcode(barcode As String) As DataTable
        EnsureSchema()
        Dim sql As String =
            "SELECT p.ProductID, ISNULL(p.Barcode, '') AS Barcode, p.Name, c.CategoryName, s.Name AS SupplierName, " &
            "p.Description, p.UnitPrice, p.StockQty, p.ReorderLevel, " &
            "p.CategoryID, p.SupplierID, ISNULL(p.Unit, 'pcs') AS Unit " &
            "FROM tbl_Products p " &
            "LEFT JOIN tbl_Categories c ON p.CategoryID = c.CategoryID " &
            "LEFT JOIN tbl_Suppliers  s ON p.SupplierID = s.SupplierID " &
            "WHERE p.Barcode = @Barcode"
        Dim dt As New DataTable()
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Barcode", barcode.Trim())
                conn.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using
        Return dt
    End Function

End Class
