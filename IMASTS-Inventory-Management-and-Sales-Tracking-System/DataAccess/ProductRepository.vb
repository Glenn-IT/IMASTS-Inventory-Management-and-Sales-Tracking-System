Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class ProductRepository

    Private Shared Sub EnsureSchema()
        Try
            Dim sql As String =
                "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('tbl_Categories') AND name = 'DefaultUnit') " &
                "ALTER TABLE tbl_Categories ADD DefaultUnit NVARCHAR(20) NOT NULL DEFAULT 'pcs'; " &
                "IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('tbl_Products') AND name = 'Unit') " &
                "ALTER TABLE tbl_Products ADD Unit NVARCHAR(20) NOT NULL DEFAULT 'pcs';"
            Using conn As New SqlConnection(dbconstring.Connection)
                Using cmd As New SqlCommand(sql, conn)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Public Function GetAll() As DataTable
        EnsureSchema()
        Dim sql As String =
            "SELECT p.ProductID, p.Name, c.CategoryName, s.Name AS SupplierName, " &
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
                        stockQty As Integer, reorderLevel As Integer, Optional unit As String = "pcs") As Boolean
        EnsureSchema()
        If String.IsNullOrWhiteSpace(unit) Then unit = "pcs"
        Dim sql As String =
            "INSERT INTO tbl_Products (Name, CategoryID, SupplierID, Description, UnitPrice, StockQty, ReorderLevel, Unit) " &
            "VALUES (@Name, @CategoryID, @SupplierID, @Description, @UnitPrice, @StockQty, @ReorderLevel, @Unit)"
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
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Update(id As Integer, name As String, categoryId As Integer, supplierId As Integer,
                           description As String, unitPrice As Decimal,
                           stockQty As Integer, reorderLevel As Integer, Optional unit As String = "pcs") As Boolean
        EnsureSchema()
        If String.IsNullOrWhiteSpace(unit) Then unit = "pcs"
        Dim sql As String =
            "UPDATE tbl_Products SET Name = @Name, CategoryID = @CategoryID, SupplierID = @SupplierID, " &
            "Description = @Description, UnitPrice = @UnitPrice, StockQty = @StockQty, " &
            "ReorderLevel = @ReorderLevel, Unit = @Unit WHERE ProductID = @ID"
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

End Class
