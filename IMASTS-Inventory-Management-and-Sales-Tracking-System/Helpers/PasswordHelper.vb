Public Module PasswordHelper

    Public Function HashPassword(plainText As String) As String
        Return BCrypt.Net.BCrypt.HashPassword(plainText, workFactor:=11)
    End Function

    Public Function VerifyPassword(plainText As String, hash As String) As Boolean
        Try
            Return BCrypt.Net.BCrypt.Verify(plainText, hash)
        Catch
            Return False
        End Try
    End Function

End Module
