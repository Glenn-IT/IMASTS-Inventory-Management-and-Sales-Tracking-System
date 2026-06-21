Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class SupplierRepository

    Public Function GetAll() As DataTable
        Dim sql As String =
            "SELECT SupplierID, Name, ContactPerson, Phone, Email, Address " &
            "FROM tbl_Suppliers ORDER BY Name"
        Dim dt As New DataTable()
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                conn.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using
        Return dt
    End Function

    Public Function Add(name As String, contact As String, phone As String,
                        email As String, address As String) As Boolean
        Dim sql As String =
            "INSERT INTO tbl_Suppliers (Name, ContactPerson, Phone, Email, Address) " &
            "VALUES (@Name, @Contact, @Phone, @Email, @Address)"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Name",    name)
                cmd.Parameters.AddWithValue("@Contact", If(contact  = "", DBNull.Value, contact))
                cmd.Parameters.AddWithValue("@Phone",   If(phone    = "", DBNull.Value, phone))
                cmd.Parameters.AddWithValue("@Email",   If(email    = "", DBNull.Value, email))
                cmd.Parameters.AddWithValue("@Address", If(address  = "", DBNull.Value, address))
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Update(id As Integer, name As String, contact As String,
                           phone As String, email As String, address As String) As Boolean
        Dim sql As String =
            "UPDATE tbl_Suppliers SET Name = @Name, ContactPerson = @Contact, " &
            "Phone = @Phone, Email = @Email, Address = @Address WHERE SupplierID = @ID"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Name",    name)
                cmd.Parameters.AddWithValue("@Contact", If(contact  = "", DBNull.Value, contact))
                cmd.Parameters.AddWithValue("@Phone",   If(phone    = "", DBNull.Value, phone))
                cmd.Parameters.AddWithValue("@Email",   If(email    = "", DBNull.Value, email))
                cmd.Parameters.AddWithValue("@Address", If(address  = "", DBNull.Value, address))
                cmd.Parameters.AddWithValue("@ID",      id)
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Delete(id As Integer) As Boolean
        Dim sql As String = "DELETE FROM tbl_Suppliers WHERE SupplierID = @ID"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@ID", id)
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

End Class
