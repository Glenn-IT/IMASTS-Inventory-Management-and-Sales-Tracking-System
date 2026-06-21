Public Module SessionManager

    Public UserID   As Integer = 0
    Public Username As String = String.Empty
    Public UserType As String = String.Empty

    Public Sub Clear()
        UserID   = 0
        Username = String.Empty
        UserType = String.Empty
    End Sub

    Public ReadOnly Property IsAdmin As Boolean
        Get
            Return UserType = Constants.RoleAdmin
        End Get
    End Property

    Public ReadOnly Property IsLoggedIn As Boolean
        Get
            Return UserID > 0
        End Get
    End Property

End Module
