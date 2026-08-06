Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class CategoryRepository

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

    Public Function Add(name As String, Optional defaultUnit As String = "pcs") As Boolean
        EnsureSchema()
        If String.IsNullOrWhiteSpace(defaultUnit) Then defaultUnit = "pcs"
        Dim sql As String = "INSERT INTO tbl_Categories (CategoryName, DefaultUnit) VALUES (@Name, @DefaultUnit)"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Name", name)
                cmd.Parameters.AddWithValue("@DefaultUnit", defaultUnit)
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Update(id As Integer, name As String, Optional defaultUnit As String = "pcs") As Boolean
        EnsureSchema()
        If String.IsNullOrWhiteSpace(defaultUnit) Then defaultUnit = "pcs"
        Dim sql As String = "UPDATE tbl_Categories SET CategoryName = @Name, DefaultUnit = @DefaultUnit WHERE CategoryID = @ID"
        Using conn As New SqlConnection(dbconstring.Connection)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Name", name)
                cmd.Parameters.AddWithValue("@DefaultUnit", defaultUnit)
                cmd.Parameters.AddWithValue("@ID", id)
                conn.Open()
                Return cmd.ExecuteNonQuery() > 0
            End Using
        End Using
    End Function

    Public Function Delete(id As Integer) As Boolean
        EnsureSchema()
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
