Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class CategoryRepository

    Public Function GetAll() As DataTable
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

    Public Function Add(name As String) As Boolean
        Dim sql As String = "INSERT INTO tbl_Categories (CategoryName) VALUES (@Name)"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Name", name)
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Update(id As Integer, name As String) As Boolean
        Dim sql As String = "UPDATE tbl_Categories SET CategoryName = @Name WHERE CategoryID = @ID"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Name", name)
                cmd.Parameters.AddWithValue("@ID", id)
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Delete(id As Integer) As Boolean
        Dim sql As String = "DELETE FROM tbl_Categories WHERE CategoryID = @ID"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@ID", id)
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function NameExists(name As String, Optional excludeId As Integer = 0) As Boolean
        Dim sql As String =
            "SELECT COUNT(*) FROM tbl_Categories WHERE CategoryName = @Name AND CategoryID <> @ExcludeID"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Name", name)
                cmd.Parameters.AddWithValue("@ExcludeID", excludeId)
                conn.Open()
                Return CInt(cmd.ExecuteScalar()) > 0
            End Using
        End Using
    End Function

End Class
