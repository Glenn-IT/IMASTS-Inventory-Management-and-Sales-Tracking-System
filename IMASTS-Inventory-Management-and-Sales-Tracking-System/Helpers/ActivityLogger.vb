Public Class ActivityLogger

    Public Shared Sub Log(username As String, result As String, description As String)
        Try
            ActivityLogRepository.Insert(username, result, description)
        Catch
            ' Logging failure must never crash the application
        End Try
    End Sub

End Class
