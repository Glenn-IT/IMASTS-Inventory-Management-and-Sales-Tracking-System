Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class ProductRepository

    Public Function GetAll() As DataTable
        Dim sql As String =
            "SELECT p.ProductID, p.Name, c.CategoryName, s.Name AS SupplierName, " &
            "p.Description, p.UnitPrice, p.StockQty, p.ReorderLevel, " &
            "p.CategoryID, p.SupplierID " &
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
        Dim sql As String = "SELECT CategoryID, CategoryName FROM tbl_Categories ORDER BY CategoryName"
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
                        stockQty As Integer, reorderLevel As Integer) As Boolean
        Dim sql As String =
            "INSERT INTO tbl_Products (Name, CategoryID, SupplierID, Description, UnitPrice, StockQty, ReorderLevel) " &
            "VALUES (@Name, @CategoryID, @SupplierID, @Description, @UnitPrice, @StockQty, @ReorderLevel)"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Name",         name)
                cmd.Parameters.AddWithValue("@CategoryID",   categoryId)
                cmd.Parameters.AddWithValue("@SupplierID",   supplierId)
                cmd.Parameters.AddWithValue("@Description",  If(description = "", DBNull.Value, description))
                cmd.Parameters.AddWithValue("@UnitPrice",    unitPrice)
                cmd.Parameters.AddWithValue("@StockQty",     stockQty)
                cmd.Parameters.AddWithValue("@ReorderLevel", reorderLevel)
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Update(id As Integer, name As String, categoryId As Integer, supplierId As Integer,
                           description As String, unitPrice As Decimal,
                           stockQty As Integer, reorderLevel As Integer) As Boolean
        Dim sql As String =
            "UPDATE tbl_Products SET Name = @Name, CategoryID = @CategoryID, SupplierID = @SupplierID, " &
            "Description = @Description, UnitPrice = @UnitPrice, StockQty = @StockQty, " &
            "ReorderLevel = @ReorderLevel WHERE ProductID = @ID"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Name",         name)
                cmd.Parameters.AddWithValue("@CategoryID",   categoryId)
                cmd.Parameters.AddWithValue("@SupplierID",   supplierId)
                cmd.Parameters.AddWithValue("@Description",  If(description = "", DBNull.Value, description))
                cmd.Parameters.AddWithValue("@UnitPrice",    unitPrice)
                cmd.Parameters.AddWithValue("@StockQty",     stockQty)
                cmd.Parameters.AddWithValue("@ReorderLevel", reorderLevel)
                cmd.Parameters.AddWithValue("@ID",           id)
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Delete(id As Integer) As Boolean
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
