Public Module Constants

    ' User roles
    Public Const RoleAdmin As String = "Admin"
    Public Const RoleStaff As String = "Staff"

    ' Activity log results
    Public Const LogSuccess As String = "Success"
    Public Const LogFailed  As String = "Failed"

    ' Sale status
    Public Const SaleActive As String = "Active"
    Public Const SaleVoided As String = "Voided"

    ' Stock status labels
    Public Const StockOk       As String = "OK"
    Public Const StockLow      As String = "Low Stock"
    Public Const StockCritical As String = "Critical"

    ' Security questions for password recovery
    Public ReadOnly SecurityQuestions As String() = {
        "What is your mother's maiden name?",
        "What was the name of your first pet?",
        "What city were you born in?",
        "What was the model of your first car?",
        "What is your favorite teacher's name?",
        "What was the name of your elementary school?"
    }

End Module
