Imports System.IO
Imports System.Diagnostics
Imports System.Text
Imports System.Data

Public Module InventoryReportHelper

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

    Public Function GenerateReportHtml(dataView As DataView, categoryName As String, searchTerm As String) As String
        SettingsManager.Load()
        Dim customCompany As String = SettingsManager.CompanyName
        Dim logoUri As String = GetLogoBase64()
        Dim showCustomCompany As Boolean = Not String.IsNullOrWhiteSpace(customCompany) AndAlso customCompany.Trim().ToUpperInvariant() <> "MY COMPANY"

        Dim totalItems As Integer = If(dataView IsNot Nothing, dataView.Count, 0)
        Dim totalQty As Long = 0
        Dim lowStockCount As Integer = 0
        Dim outOfStockCount As Integer = 0

        If dataView IsNot Nothing Then
            For Each drv As DataRowView In dataView
                Dim qtyVal As Integer
                If Integer.TryParse(drv("StockQty")?.ToString(), qtyVal) Then
                    totalQty += qtyVal
                End If

                Dim status = If(drv.Row.Table.Columns.Contains("StockStatus"), drv("StockStatus")?.ToString(), If(drv.Row.Table.Columns.Contains("Status"), drv("Status")?.ToString(), ""))
                If status = "Out of Stock" Then
                    outOfStockCount += 1
                ElseIf status = "Low Stock" Then
                    lowStockCount += 1
                End If
            Next
        End If

        Dim catLabel As String = If(String.IsNullOrWhiteSpace(categoryName), "All Categories", categoryName)
        Dim searchNote As String = If(String.IsNullOrWhiteSpace(searchTerm), "", $" (Search: ""{searchTerm}"")")

        Dim sb As New StringBuilder()
        sb.AppendLine("<!DOCTYPE html>")
        sb.AppendLine("<html lang=""en"">")
        sb.AppendLine("<head>")
        sb.AppendLine("  <meta charset=""UTF-8"">")
        sb.AppendLine("  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">")
        sb.AppendLine($"  <title>IMASTS Inventory Report - {DateTime.Now:yyyy-MM-dd}</title>")
        sb.AppendLine("  <style>")
        sb.AppendLine("    * { box-sizing: border-box; margin: 0; padding: 0; font-family: 'Segoe UI', -apple-system, BlinkMacSystemFont, Roboto, sans-serif; }")
        sb.AppendLine("    body { background-color: #f1f5f9; display: flex; flex-direction: column; align-items: center; padding: 25px 15px; min-height: 100vh; color: #1e293b; }")
        sb.AppendLine("    .no-print-toolbar { width: 100%; max-width: 960px; margin-bottom: 15px; display: flex; gap: 12px; }")
        sb.AppendLine("    .btn-action { flex: 1; padding: 12px 18px; font-size: 14px; font-weight: 700; border: none; border-radius: 6px; cursor: pointer; display: flex; align-items: center; justify-content: center; gap: 8px; transition: all 0.2s; box-shadow: 0 2px 5px rgba(0,0,0,0.1); }")
        sb.AppendLine("    .btn-print { background: #27ae60; color: #fff; }")
        sb.AppendLine("    .btn-print:hover { background: #219150; }")
        sb.AppendLine("    .btn-close { background: #64748b; color: #fff; }")
        sb.AppendLine("    .btn-close:hover { background: #475569; }")
        sb.AppendLine("    .report-container { background: #ffffff; width: 100%; max-width: 960px; padding: 35px 30px; border-radius: 10px; box-shadow: 0 8px 24px rgba(0,0,0,0.06); border: 1px solid #e2e8f0; }")
        sb.AppendLine("    .report-header { display: flex; justify-content: space-between; align-items: flex-start; border-bottom: 2px solid #0f172a; padding-bottom: 18px; margin-bottom: 20px; }")
        sb.AppendLine("    .header-left { display: flex; align-items: center; gap: 16px; }")
        sb.AppendLine("    .logo-img { max-width: 130px; max-height: 60px; object-fit: contain; }")
        sb.AppendLine("    .sys-title { font-size: 22px; font-weight: 800; color: #0f172a; letter-spacing: 0.5px; }")
        sb.AppendLine("    .sys-subtitle { font-size: 12px; color: #64748b; margin-top: 2px; }")
        sb.AppendLine("    .custom-co { font-size: 14px; font-weight: 700; color: #2563eb; margin-top: 4px; }")
        sb.AppendLine("    .header-right { text-align: right; }")
        sb.AppendLine("    .report-badge { display: inline-block; font-size: 13px; font-weight: 800; text-transform: uppercase; letter-spacing: 1px; color: #0f172a; background: #e2e8f0; padding: 5px 12px; border-radius: 4px; }")
        sb.AppendLine("    .report-meta { font-size: 11.5px; color: #64748b; margin-top: 6px; line-height: 1.5; }")
        sb.AppendLine("    .stats-grid { display: grid; grid-template-columns: repeat(4, 1fr); gap: 12px; margin-bottom: 22px; }")
        sb.AppendLine("    .stat-card { background: #f8fafc; border: 1px solid #e2e8f0; border-radius: 8px; padding: 12px 14px; text-align: center; }")
        sb.AppendLine("    .stat-val { font-size: 22px; font-weight: 800; color: #0f172a; }")
        sb.AppendLine("    .stat-label { font-size: 11px; text-transform: uppercase; font-weight: 700; letter-spacing: 0.5px; color: #64748b; margin-top: 2px; }")
        sb.AppendLine("    .stat-danger { color: #dc2626; }")
        sb.AppendLine("    .stat-warning { color: #d97706; }")
        sb.AppendLine("    .stat-success { color: #16a34a; }")
        sb.AppendLine("    .table-wrapper { width: 100%; overflow-x: auto; margin-bottom: 20px; }")
        sb.AppendLine("    table.inv-table { width: 100%; border-collapse: collapse; font-size: 12px; }")
        sb.AppendLine("    table.inv-table th { background: #0f172a; color: #ffffff; font-weight: 700; text-transform: uppercase; font-size: 11px; letter-spacing: 0.5px; padding: 10px 8px; text-align: left; }")
        sb.AppendLine("    table.inv-table td { padding: 9px 8px; border-bottom: 1px solid #e2e8f0; }")
        sb.AppendLine("    table.inv-table tr:nth-child(even) { background: #f8fafc; }")
        sb.AppendLine("    .text-right { text-align: right; }")
        sb.AppendLine("    .text-center { text-align: center; }")
        sb.AppendLine("    .badge { display: inline-block; padding: 3px 8px; border-radius: 4px; font-size: 10.5px; font-weight: 700; text-transform: uppercase; }")
        sb.AppendLine("    .badge-ok { background: #dcfce7; color: #15803d; }")
        sb.AppendLine("    .badge-low { background: #fef3c7; color: #b45309; }")
        sb.AppendLine("    .badge-out { background: #fee2e2; color: #b91c1c; }")
        sb.AppendLine("    .report-footer { display: flex; justify-content: space-between; align-items: center; border-top: 1px solid #e2e8f0; padding-top: 14px; font-size: 11px; color: #94a3b8; }")
        sb.AppendLine("    @media print {")
        sb.AppendLine("      body { background: #ffffff !important; padding: 0 !important; color: #000 !important; }")
        sb.AppendLine("      .no-print-toolbar { display: none !important; }")
        sb.AppendLine("      .report-container { box-shadow: none !important; border: none !important; max-width: 100% !important; padding: 0 !important; width: 100% !important; }")
        sb.AppendLine("      table.inv-table th { background: #0f172a !important; color: #fff !important; -webkit-print-color-adjust: exact; print-color-adjust: exact; }")
        sb.AppendLine("      .badge-ok { background: #dcfce7 !important; color: #15803d !important; -webkit-print-color-adjust: exact; print-color-adjust: exact; }")
        sb.AppendLine("      .badge-low { background: #fef3c7 !important; color: #b45309 !important; -webkit-print-color-adjust: exact; print-color-adjust: exact; }")
        sb.AppendLine("      .badge-out { background: #fee2e2 !important; color: #b91c1c !important; -webkit-print-color-adjust: exact; print-color-adjust: exact; }")
        sb.AppendLine("      .stat-card { -webkit-print-color-adjust: exact; print-color-adjust: exact; }")
        sb.AppendLine("      @page { margin: 12mm 10mm; size: auto; }")
        sb.AppendLine("    }")
        sb.AppendLine("  </style>")
        sb.AppendLine("</head>")
        sb.AppendLine("<body>")
        sb.AppendLine("  <div class=""no-print-toolbar"">")
        sb.AppendLine("    <button class=""btn-action btn-print"" onclick=""window.print()"">🖶 Print / Save PDF</button>")
        sb.AppendLine("    <button class=""btn-action btn-close"" onclick=""window.close()"">✕ Close</button>")
        sb.AppendLine("  </div>")
        sb.AppendLine("  <div class=""report-container"">")
        sb.AppendLine("    <div class=""report-header"">")
        sb.AppendLine("      <div class=""header-left"">")
        If Not String.IsNullOrWhiteSpace(logoUri) Then
            sb.AppendLine($"        <img src=""{logoUri}"" alt=""Logo"" class=""logo-img"" />")
        End If
        sb.AppendLine("        <div>")
        sb.AppendLine("          <div class=""sys-title"">IMASTS</div>")
        sb.AppendLine("          <div class=""sys-subtitle"">Inventory Management &amp; Sales Tracking System</div>")
        If showCustomCompany Then
            sb.AppendLine($"          <div class=""custom-co"">{System.Net.WebUtility.HtmlEncode(customCompany)}</div>")
        End If
        sb.AppendLine("        </div>")
        sb.AppendLine("      </div>")
        sb.AppendLine("      <div class=""header-right"">")
        sb.AppendLine("        <div class=""report-badge"">Inventory Status Report</div>")
        sb.AppendLine($"        <div class=""report-meta"">Date: {DateTime.Now:MMMM dd, yyyy  hh:mm tt}<br>Generated By: {System.Net.WebUtility.HtmlEncode(SessionManager.Username)}<br>Scope: {System.Net.WebUtility.HtmlEncode(catLabel)}{System.Net.WebUtility.HtmlEncode(searchNote)}</div>")
        sb.AppendLine("      </div>")
        sb.AppendLine("    </div>")

        ' KPI Stats
        sb.AppendLine("    <div class=""stats-grid"">")
        sb.AppendLine("      <div class=""stat-card"">")
        sb.AppendLine($"        <div class=""stat-val"">{totalItems}</div>")
        sb.AppendLine("        <div class=""stat-label"">Total Products</div>")
        sb.AppendLine("      </div>")
        sb.AppendLine("      <div class=""stat-card"">")
        sb.AppendLine($"        <div class=""stat-val stat-success"">{totalQty:N0}</div>")
        sb.AppendLine("        <div class=""stat-label"">Total Stock Units</div>")
        sb.AppendLine("      </div>")
        sb.AppendLine("      <div class=""stat-card"">")
        sb.AppendLine($"        <div class=""stat-val stat-warning"">{lowStockCount}</div>")
        sb.AppendLine("        <div class=""stat-label"">Low Stock Items</div>")
        sb.AppendLine("      </div>")
        sb.AppendLine("      <div class=""stat-card"">")
        sb.AppendLine($"        <div class=""stat-val stat-danger"">{outOfStockCount}</div>")
        sb.AppendLine("        <div class=""stat-label"">Out of Stock Items</div>")
        sb.AppendLine("      </div>")
        sb.AppendLine("    </div>")

        ' Inventory Table
        sb.AppendLine("    <div class=""table-wrapper"">")
        sb.AppendLine("      <table class=""inv-table"">")
        sb.AppendLine("        <thead>")
        sb.AppendLine("          <tr>")
        sb.AppendLine("            <th style=""width: 40px;"" class=""text-center"">#</th>")
        sb.AppendLine("            <th style=""width: 80px;"">Barcode</th>")
        sb.AppendLine("            <th>Product Name</th>")
        sb.AppendLine("            <th style=""width: 140px;"">Category</th>")
        sb.AppendLine("            <th style=""width: 90px;"" class=""text-right"">Stock Qty</th>")
        sb.AppendLine("            <th style=""width: 60px;"" class=""text-center"">Unit</th>")
        sb.AppendLine("            <th style=""width: 90px;"" class=""text-right"">Reorder Lvl</th>")
        sb.AppendLine("            <th style=""width: 100px;"" class=""text-center"">Status</th>")
        sb.AppendLine("          </tr>")
        sb.AppendLine("        </thead>")
        sb.AppendLine("        <tbody>")

        If dataView IsNot Nothing AndAlso dataView.Count > 0 Then
            Dim rowIdx As Integer = 1
            For Each drv As DataRowView In dataView
                Dim barcode = If(drv.Row.Table.Columns.Contains("Barcode"), System.Net.WebUtility.HtmlEncode(drv("Barcode")?.ToString()), "-")
                Dim name = System.Net.WebUtility.HtmlEncode(drv("Name")?.ToString())
                Dim category = System.Net.WebUtility.HtmlEncode(drv("CategoryName")?.ToString())
                Dim stockQty As Integer
                Integer.TryParse(drv("StockQty")?.ToString(), stockQty)
                Dim unit = If(drv.Row.Table.Columns.Contains("Unit"), System.Net.WebUtility.HtmlEncode(drv("Unit")?.ToString()), "pcs")
                Dim reorder As Integer
                Integer.TryParse(drv("ReorderLevel")?.ToString(), reorder)
                Dim status = If(drv.Row.Table.Columns.Contains("StockStatus"), drv("StockStatus")?.ToString(), If(drv.Row.Table.Columns.Contains("Status"), drv("Status")?.ToString(), "OK"))

                Dim badgeClass = "badge-ok"
                If status = "Out of Stock" Then
                    badgeClass = "badge-out"
                ElseIf status = "Low Stock" Then
                    badgeClass = "badge-low"
                End If

                sb.AppendLine("          <tr>")
                sb.AppendLine($"            <td class=""text-center"">{rowIdx}</td>")
                sb.AppendLine($"            <td>{barcode}</td>")
                sb.AppendLine($"            <td><strong>{name}</strong></td>")
                sb.AppendLine($"            <td>{category}</td>")
                sb.AppendLine($"            <td class=""text-right""><strong>{stockQty:N0}</strong></td>")
                sb.AppendLine($"            <td class=""text-center"">{unit}</td>")
                sb.AppendLine($"            <td class=""text-right"">{reorder:N0}</td>")
                sb.AppendLine($"            <td class=""text-center""><span class=""badge {badgeClass}"">{System.Net.WebUtility.HtmlEncode(status)}</span></td>")
                sb.AppendLine("          </tr>")
                rowIdx += 1
            Next
        Else
            sb.AppendLine("          <tr><td colspan=""8"" style=""text-align: center; padding: 25px; color: #94a3b8;"">No inventory records found.</td></tr>")
        End If

        sb.AppendLine("        </tbody>")
        sb.AppendLine("      </table>")
        sb.AppendLine("    </div>")

        ' Footer
        sb.AppendLine("    <div class=""report-footer"">")
        sb.AppendLine("      <div>IMASTS — Automated Inventory Management System</div>")
        sb.AppendLine($"      <div>Page generated on {DateTime.Now:yyyy-MM-dd HH:mm:ss}</div>")
        sb.AppendLine("    </div>")
        sb.AppendLine("  </div>")

        ' Auto-print script
        sb.AppendLine("  <script>")
        sb.AppendLine("    window.onload = function() {")
        sb.AppendLine("      setTimeout(function() { window.print(); }, 400);")
        sb.AppendLine("    };")
        sb.AppendLine("  </script>")
        sb.AppendLine("</body>")
        sb.AppendLine("</html>")

        Return sb.ToString()
    End Function

    Public Sub OpenReportInChrome(dataView As DataView, categoryName As String, searchTerm As String)
        Try
            Dim html = GenerateReportHtml(dataView, categoryName, searchTerm)
            Dim tempDir = Path.Combine(Path.GetTempPath(), "IMASTS_Reports")
            If Not Directory.Exists(tempDir) Then Directory.CreateDirectory(tempDir)

            Dim filePath = Path.Combine(tempDir, $"InventoryReport_{DateTime.Now:yyyyMMddHHmmss}.html")
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
            MessageBox.Show($"Failed to generate inventory report: {ex.Message}", "Print Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module
