Imports System.IO
Imports System.Diagnostics
Imports System.Text
Imports System.Data

Public Module ReceiptHelper

    Private Function GetLogoBase64() As String
        Try
            Dim rm As New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
            Dim img = CType(rm.GetObject("PictureBox1.Image"), System.Drawing.Image)
            If img IsNot Nothing Then
                Using ms As New MemoryStream()
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                    Return "data:image/png;base64," & Convert.ToBase64String(ms.ToArray())
                End Using
            End If
        Catch
        End Try
        Return ""
    End Function

    Public Function GenerateReceiptHtml(saleId As Integer, cashier As String, saleDate As DateTime,
                                        items As DataTable, subtotal As Decimal,
                                        discount As Decimal, netAmount As Decimal) As String
        SettingsManager.Load()
        Dim customCompany As String = SettingsManager.CompanyName
        Dim currency As String = If(String.IsNullOrWhiteSpace(SettingsManager.CurrencySymbol), "₱", SettingsManager.CurrencySymbol)
        Dim logoUri As String = GetLogoBase64()

        Dim showCustomCompany As Boolean = Not String.IsNullOrWhiteSpace(customCompany) AndAlso customCompany.Trim().ToUpperInvariant() <> "MY COMPANY"

        Dim sb As New StringBuilder()
        sb.AppendLine("<!DOCTYPE html>")
        sb.AppendLine("<html lang=""en"">")
        sb.AppendLine("<head>")
        sb.AppendLine("  <meta charset=""UTF-8"">")
        sb.AppendLine("  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">")
        sb.AppendLine($"  <title>IMASTS Receipt #{saleId:D6}</title>")
        sb.AppendLine("  <style>")
        sb.AppendLine("    * { box-sizing: border-box; margin: 0; padding: 0; font-family: 'Segoe UI', -apple-system, BlinkMacSystemFont, Roboto, sans-serif; }")
        sb.AppendLine("    body { background-color: #eef2f7; display: flex; flex-direction: column; align-items: center; padding: 30px 15px; min-height: 100vh; }")
        sb.AppendLine("    .no-print-toolbar { width: 100%; max-width: 380px; margin-bottom: 15px; display: flex; gap: 10px; }")
        sb.AppendLine("    .btn-action { flex: 1; padding: 12px; font-size: 14px; font-weight: 700; border: none; border-radius: 6px; cursor: pointer; display: flex; align-items: center; justify-content: center; gap: 8px; transition: all 0.2s; box-shadow: 0 2px 5px rgba(0,0,0,0.1); }")
        sb.AppendLine("    .btn-print { background: #27ae60; color: #fff; }")
        sb.AppendLine("    .btn-print:hover { background: #219150; }")
        sb.AppendLine("    .btn-close { background: #7f8c8d; color: #fff; }")
        sb.AppendLine("    .btn-close:hover { background: #6c7a7b; }")
        sb.AppendLine("    .receipt-container { background: #ffffff; width: 100%; max-width: 380px; padding: 25px 22px; border-radius: 10px; box-shadow: 0 8px 24px rgba(0,0,0,0.08); border: 1px solid #e1e8ed; color: #2c3e50; }")
        sb.AppendLine("    .header { text-align: center; margin-bottom: 12px; }")
        sb.AppendLine("    .logo-img { max-width: 160px; max-height: 75px; object-fit: contain; margin-bottom: 8px; filter: drop-shadow(0 2px 4px rgba(0,0,0,0.08)); }")
        sb.AppendLine("    .system-title { font-size: 20px; font-weight: 800; color: #1c2b4a; letter-spacing: 0.8px; margin-bottom: 2px; }")
        sb.AppendLine("    .system-subtitle { font-size: 11.5px; font-weight: 600; color: #475569; margin-bottom: 4px; line-height: 1.3; }")
        sb.AppendLine("    .custom-company { font-size: 13px; font-weight: 700; color: #2980b9; margin-top: 4px; }")
        sb.AppendLine("    .receipt-badge { display: inline-block; font-size: 10.5px; font-weight: 700; text-transform: uppercase; letter-spacing: 1px; color: #64748b; padding: 3px 10px; border-radius: 4px; background: #f1f5f9; margin-top: 6px; }")
        sb.AppendLine("    .dash-line { border-top: 1px dashed #cbd5e1; margin: 14px 0; }")
        sb.AppendLine("    .solid-line { border-top: 2px solid #1c2b4a; margin: 14px 0; }")
        sb.AppendLine("    .info-grid { display: grid; grid-template-columns: 1fr 1fr; gap: 6px; font-size: 12.5px; color: #475569; }")
        sb.AppendLine("    .info-grid .right { text-align: right; }")
        sb.AppendLine("    .items-table { width: 100%; border-collapse: collapse; margin: 12px 0; font-size: 12.5px; }")
        sb.AppendLine("    .items-table th { text-align: left; padding: 8px 4px; border-bottom: 1.5px solid #1c2b4a; font-weight: 700; color: #1c2b4a; text-transform: uppercase; font-size: 11px; }")
        sb.AppendLine("    .items-table td { padding: 8px 4px; vertical-align: top; border-bottom: 1px solid #f1f5f9; }")
        sb.AppendLine("    .text-right { text-align: right; }")
        sb.AppendLine("    .text-center { text-align: center; }")
        sb.AppendLine("    .item-name { font-weight: 600; color: #1e293b; }")
        sb.AppendLine("    .item-sub { font-size: 11px; color: #64748b; }")
        sb.AppendLine("    .summary-row { display: flex; justify-content: space-between; font-size: 13px; color: #475569; margin-bottom: 5px; }")
        sb.AppendLine("    .grand-total { display: flex; justify-content: space-between; font-size: 18px; font-weight: 800; color: #1b5e20; padding-top: 6px; }")
        sb.AppendLine("    .footer { text-align: center; margin-top: 18px; font-size: 11.5px; color: #64748b; line-height: 1.5; }")
        sb.AppendLine("    .barcode-mock { text-align: center; margin: 14px 0 6px 0; font-family: 'Courier New', monospace; letter-spacing: 4px; font-weight: bold; font-size: 15px; color: #334155; }")
        sb.AppendLine("    @media print {")
        sb.AppendLine("      body { background: #fff !important; padding: 0 !important; }")
        sb.AppendLine("      .no-print, .no-print-toolbar { display: none !important; }")
        sb.AppendLine("      .receipt-container { box-shadow: none !important; border: none !important; width: 100% !important; max-width: 80mm !important; padding: 10px !important; margin: 0 auto; }")
        sb.AppendLine("      @page { margin: 5mm; size: auto; }")
        sb.AppendLine("    }")
        sb.AppendLine("  </style>")
        sb.AppendLine("</head>")
        sb.AppendLine("<body>")
        sb.AppendLine("  <div class=""no-print-toolbar"">")
        sb.AppendLine("    <button class=""btn-action btn-print"" onclick=""window.print()"">🖶 Print / Save PDF</button>")
        sb.AppendLine("    <button class=""btn-action btn-close"" onclick=""window.close()"">✕ Close</button>")
        sb.AppendLine("  </div>")
        sb.AppendLine("  <div class=""receipt-container"">")
        sb.AppendLine("    <div class=""header"">")

        If Not String.IsNullOrWhiteSpace(logoUri) Then
            sb.AppendLine($"      <img src=""{logoUri}"" alt=""IMASTS Logo"" class=""logo-img"" />")
        End If

        sb.AppendLine("      <div class=""system-title"">IMASTS</div>")
        sb.AppendLine("      <div class=""system-subtitle"">Inventory Management &amp; Sales Tracking System</div>")

        If showCustomCompany Then
            sb.AppendLine($"      <div class=""custom-company"">{System.Net.WebUtility.HtmlEncode(customCompany)}</div>")
        End If

        sb.AppendLine("      <div class=""receipt-badge"">Official Sales Receipt</div>")
        sb.AppendLine("    </div>")
        sb.AppendLine("    <div class=""dash-line""></div>")
        sb.AppendLine("    <div class=""info-grid"">")
        sb.AppendLine($"      <div><strong>Receipt #:</strong> {saleId:D6}</div>")
        sb.AppendLine($"      <div class=""right""><strong>Date:</strong> {saleDate:yyyy-MM-dd}</div>")
        sb.AppendLine($"      <div><strong>Cashier:</strong> {System.Net.WebUtility.HtmlEncode(cashier)}</div>")
        sb.AppendLine($"      <div class=""right""><strong>Time:</strong> {saleDate:hh:mm:ss tt}</div>")
        sb.AppendLine("    </div>")
        sb.AppendLine("    <div class=""dash-line""></div>")
        sb.AppendLine("    <table class=""items-table"">")
        sb.AppendLine("      <thead>")
        sb.AppendLine("        <tr>")
        sb.AppendLine("          <th style=""width: 50%"">Item</th>")
        sb.AppendLine("          <th class=""text-right"" style=""width: 15%"">Qty</th>")
        sb.AppendLine("          <th class=""text-right"" style=""width: 35%"">Amount</th>")
        sb.AppendLine("        </tr>")
        sb.AppendLine("      </thead>")
        sb.AppendLine("      <tbody>")

        For Each row As DataRow In items.Rows
            Dim name As String = ""
            If row.Table.Columns.Contains("ProductName") Then
                name = row("ProductName").ToString()
            ElseIf row.Table.Columns.Contains("Product") Then
                name = row("Product").ToString()
            ElseIf row.Table.Columns.Contains("Name") Then
                name = row("Name").ToString()
            End If

            Dim qty As Integer = Convert.ToInt32(row("Quantity"))
            Dim unitPrice As Decimal = Convert.ToDecimal(row("UnitPrice"))
            Dim lineSub As Decimal = Convert.ToDecimal(row("Subtotal"))

            sb.AppendLine("        <tr>")
            sb.AppendLine("          <td>")
            sb.AppendLine($"            <div class=""item-name"">{System.Net.WebUtility.HtmlEncode(name)}</div>")
            sb.AppendLine($"            <div class=""item-sub"">@{currency}{unitPrice:N2}</div>")
            sb.AppendLine("          </td>")
            sb.AppendLine($"          <td class=""text-right"" style=""font-weight: 600;"">{qty}</td>")
            sb.AppendLine($"          <td class=""text-right"" style=""font-weight: 600;"">{currency}{lineSub:N2}</td>")
            sb.AppendLine("        </tr>")
        Next

        sb.AppendLine("      </tbody>")
        sb.AppendLine("    </table>")
        sb.AppendLine("    <div class=""dash-line""></div>")
        sb.AppendLine("    <div class=""summary-row"">")
        sb.AppendLine("      <span>Subtotal</span>")
        sb.AppendLine($"      <span style=""font-weight: 600;"">{currency}{subtotal:N2}</span>")
        sb.AppendLine("    </div>")

        If discount > 0 Then
            sb.AppendLine("    <div class=""summary-row"" style=""color: #c0392b;"">")
            sb.AppendLine("      <span>Discount</span>")
            sb.AppendLine($"      <span style=""font-weight: 600;"">-{currency}{discount:N2}</span>")
            sb.AppendLine("    </div>")
        End If

        sb.AppendLine("    <div class=""solid-line""></div>")
        sb.AppendLine("    <div class=""grand-total"">")
        sb.AppendLine("      <span>NET TOTAL</span>")
        sb.AppendLine($"      <span>{currency}{netAmount:N2}</span>")
        sb.AppendLine("    </div>")
        sb.AppendLine("    <div class=""solid-line""></div>")
        sb.AppendLine($"    <div class=""barcode-mock"">*{saleId:D8}*</div>")
        sb.AppendLine("    <div class=""footer"">")
        sb.AppendLine("      <p><strong>Thank you for your purchase!</strong></p>")
        sb.AppendLine("      <p>Please keep this receipt for your records.</p>")
        sb.AppendLine("      <p style=""margin-top: 8px; font-size: 10px; color: #94a3b8;"">Powered by IMASTS</p>")
        sb.AppendLine("    </div>")
        sb.AppendLine("  </div>")
        sb.AppendLine("  <script>")
        sb.AppendLine("    // Automatically prompt Chrome print dialog")
        sb.AppendLine("    window.onload = function() {")
        sb.AppendLine("      setTimeout(function() { window.print(); }, 400);")
        sb.AppendLine("    };")
        sb.AppendLine("  </script>")
        sb.AppendLine("</body>")
        sb.AppendLine("</html>")

        Return sb.ToString()
    End Function

    Public Sub OpenReceiptInChrome(saleId As Integer, cashier As String, saleDate As DateTime,
                                  items As DataTable, subtotal As Decimal,
                                  discount As Decimal, netAmount As Decimal)
        Try
            Dim html = GenerateReceiptHtml(saleId, cashier, saleDate, items, subtotal, discount, netAmount)
            Dim tempDir = Path.Combine(Path.GetTempPath(), "IMASTS_Receipts")
            If Not Directory.Exists(tempDir) Then Directory.CreateDirectory(tempDir)

            Dim filePath = Path.Combine(tempDir, $"Receipt_{saleId:D6}_{DateTime.Now:yyyyMMddHHmmss}.html")
            File.WriteAllText(filePath, html, Encoding.UTF8)

            ' Look for Google Chrome
            Dim chromePaths = {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Google\Chrome\Application\chrome.exe"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Google\Chrome\Application\chrome.exe"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google\Chrome\Application\chrome.exe")
            }

            Dim launched = False
            For Each cp In chromePaths
                If File.Exists(cp) Then
                    Try
                        Process.Start(New ProcessStartInfo(cp, $"--app=""file:///{filePath.Replace("\", "/")}""") With {
                            .UseShellExecute = False
                        })
                        launched = True
                        Exit For
                    Catch
                        Try
                            Process.Start(New ProcessStartInfo(cp, $"""{filePath}""") With {
                                .UseShellExecute = False
                            })
                            launched = True
                            Exit For
                        Catch
                        End Try
                    End Try
                End If
            Next

            ' Fallback to system default browser
            If Not launched Then
                Process.Start(New ProcessStartInfo(filePath) With {
                    .UseShellExecute = True
                })
            End If
        Catch ex As Exception
            MessageBox.Show($"Failed to generate receipt: {ex.Message}", "Receipt Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module
