Imports Microsoft.Data.SqlClient

Public Module UserRepository

    Public Function GetByUsername(username As String) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "SELECT UserID, Username, PasswordHash, UserType " &
                "FROM tbl_Users WHERE Username = @username", con)
                cmd.Parameters.AddWithValue("@username", username)
                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "SELECT UserID, Username, UserType, CreatedAt " &
                "FROM tbl_Users ORDER BY CreatedAt DESC", con)
                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Public Sub Insert(username As String, passwordHash As String, userType As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "INSERT INTO tbl_Users (Username, PasswordHash, UserType) " &
                "VALUES (@username, @hash, @type)", con)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@hash",     passwordHash)
                cmd.Parameters.AddWithValue("@type",     userType)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub UpdatePassword(userID As Integer, newPasswordHash As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Users SET PasswordHash = @hash WHERE UserID = @id", con)
                cmd.Parameters.AddWithValue("@hash", newPasswordHash)
                cmd.Parameters.AddWithValue("@id",   userID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Delete(userID As Integer)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "DELETE FROM tbl_Users WHERE UserID = @id", con)
                cmd.Parameters.AddWithValue("@id", userID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' ── Security Question / Forgot Password ─────────────────────────────

    Public Function GetSecurityInfo(username As String) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "SELECT UserID, Username, SecurityQuestion, SecurityAnswerHash " &
                "FROM tbl_Users WHERE Username = @username", con)
                cmd.Parameters.AddWithValue("@username", username)
                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Public Sub UpdateSecurityQA(userID As Integer, question As String, answerHash As String)
        Using con As New SqlConnection(dbconstring.Connection)
            con.Open()
            Using cmd As New SqlCommand(
                "UPDATE tbl_Users SET SecurityQuestion = @question, SecurityAnswerHash = @hash " &
                "WHERE UserID = @id", con)
                cmd.Parameters.AddWithValue("@question", question)
                cmd.Parameters.AddWithValue("@hash",     answerHash)
                cmd.Parameters.AddWithValue("@id",       userID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Module
