Imports System.Text.RegularExpressions

Public Module InputHelper

    ''' <summary>Trims whitespace and strips angle brackets and null bytes from user input.</summary>
    Public Function SanitizeInput(text As String) As String
        If String.IsNullOrWhiteSpace(text) Then Return String.Empty
        Return text.Trim() _
                   .Replace("<", String.Empty) _
                   .Replace(">", String.Empty) _
                   .Replace(Chr(0), String.Empty)
    End Function

    Public Function IsEmpty(text As String) As Boolean
        Return String.IsNullOrWhiteSpace(text)
    End Function

    Public Function IsValidDecimal(text As String, ByRef result As Decimal) As Boolean
        Return Decimal.TryParse(text, result) AndAlso result >= 0
    End Function

    Public Function IsValidInteger(text As String, ByRef result As Integer) As Boolean
        Return Integer.TryParse(text, result) AndAlso result >= 0
    End Function

    ''' <summary>11-digit numeric phone format, e.g. 09123456789.</summary>
    Public Function IsValidPhone(text As String) As Boolean
        Return Regex.IsMatch(If(text, String.Empty).Trim(), "^\d{11}$")
    End Function

    Public Function IsValidEmail(text As String) As Boolean
        Return Regex.IsMatch(If(text, String.Empty).Trim(), "^[^@\s]+@[^@\s]+\.[^@\s]+$")
    End Function

End Module
