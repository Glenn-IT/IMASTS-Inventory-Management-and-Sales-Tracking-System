Imports System.IO

Public Module SettingsManager

    Private ReadOnly FilePath As String =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.txt")

    Public Property CompanyName    As String = "My Company"
    Public Property CurrencySymbol As String = "₱"

    Public Sub Load()
        If Not File.Exists(FilePath) Then Return
        For Each line As String In File.ReadAllLines(FilePath)
            Dim parts = line.Split({"="c}, 2)
            If parts.Length < 2 Then Continue For
            Select Case parts(0).Trim().ToUpperInvariant()
                Case "COMPANYNAME"    : CompanyName    = parts(1).Trim()
                Case "CURRENCYSYMBOL" : CurrencySymbol = parts(1).Trim()
            End Select
        Next
    End Sub

    Public Sub Save()
        Dim content As String =
            $"CompanyName={CompanyName}" & Environment.NewLine &
            $"CurrencySymbol={CurrencySymbol}"
        File.WriteAllText(FilePath, content, System.Text.Encoding.UTF8)
    End Sub

End Module
