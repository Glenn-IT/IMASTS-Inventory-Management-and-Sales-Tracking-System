Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms

Public Module SalesReportHelper

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

    Public Function GenerateSalesReportHtml(fromDate As Date, toDate As Date,
                                           totalSales As Integer, totalRevenue As Decimal,
                                           avgSaleValue As Decimal, topProducts As DataTable) As String
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
        sb.AppendLine($"  <title>IMASTS Sales Summary Report - {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}</title>")
        sb.AppendLine("  <style>")
        sb.AppendLine("    * { box-sizing: border-box; margin: 0; padding: 0; font-family: 'Segoe UI', -apple-system, BlinkMacSystemFont, Roboto, sans-serif; }")
        sb.AppendLine("    body { background-color: #f1f5f9; display: flex; flex-direction: column; align-items: center; padding: 25px 15px; min-height: 100vh; color: #1e293b; }")
        sb.AppendLine("    .no-print-toolbar { width: 100%; max-width: 900px; margin-bottom: 15px; display: flex; gap: 12px; }")
        sb.AppendLine("    .btn-action { flex: 1; padding: 12px 18px; font-size: 14px; font-weight: 700; border: none; border-radius: 6px; cursor: pointer; display: flex; align-items: center; justify-content: center; gap: 8px; transition: all 0.2s; box-shadow: 0 2px 5px rgba(0,0,0,0.1); }")
        sb.AppendLine("    .btn-print { background: #27ae60; color: #fff; }")
        sb.AppendLine("    .btn-print:hover { background: #219150; }")
        sb.AppendLine("    .btn-close { background: #64748b; color: #fff; }")
        sb.AppendLine("    .btn-close:hover { background: #475569; }")
        sb.AppendLine("    .report-container { background: #ffffff; width: 100%; max-width: 900px; padding: 35px 30px; border-radius: 10px; box-shadow: 0 8px 24px rgba(0,0,0,0.06); border: 1px solid #e2e8f0; }")
        sb.AppendLine("    .report-header { display: flex; justify-content: space-between; align-items: flex-start; border-bottom: 2px solid #0f172a; padding-bottom: 18px; margin-bottom: 20px; }")
        sb.AppendLine("    .header-left { display: flex; align-items: center; gap: 16px; }")
        sb.AppendLine("    .logo-img { max-width: 130px; max-height: 60px; object-fit: contain; }")
        sb.AppendLine("    .sys-title { font-size: 22px; font-weight: 800; color: #0f172a; letter-spacing: 0.5px; }")
        sb.AppendLine("    .sys-subtitle { font-size: 12px; color: #64748b; margin-top: 2px; }")
        sb.AppendLine("    .custom-co { font-size: 14px; font-weight: 700; color: #2563eb; margin-top: 4px; }")
        sb.AppendLine("    .header-right { text-align: right; }")
        sb.AppendLine("    .report-badge { display: inline-block; font-size: 13px; font-weight: 800; text-transform: uppercase; letter-spacing: 1px; color: #0f172a; background: #e2e8f0; padding: 5px 12px; border-radius: 4px; }")
        sb.AppendLine("    .report-meta { font-size: 11.5px; color: #64748b; margin-top: 6px; line-height: 1.5; }")
        sb.AppendLine("    .stats-grid { display: grid; grid-template-columns: repeat(3, 1fr); gap: 16px; margin-bottom: 26px; }")
        sb.AppendLine("    .stat-card { background: #f8fafc; border: 1px solid #e2e8f0; border-radius: 8px; padding: 16px 18px; text-align: center; }")
        sb.AppendLine("    .stat-val { font-size: 24px; font-weight: 800; color: #0f172a; }")
        sb.AppendLine("    .stat-label { font-size: 11px; text-transform: uppercase; font-weight: 700; letter-spacing: 0.5px; color: #64748b; margin-top: 4px; }")
        sb.AppendLine("    .stat-green { color: #16a34a; }")
        sb.AppendLine("    .stat-blue { color: #2563eb; }")
        sb.AppendLine("    .section-title { font-size: 15px; font-weight: 700; color: #1e293b; margin-bottom: 12px; display: flex; align-items: center; gap: 8px; }")
        sb.AppendLine("    .table-wrapper { width: 100%; overflow-x: auto; margin-bottom: 24px; }")
        sb.AppendLine("    table.sales-table { width: 100%; border-collapse: collapse; font-size: 13px; }")
        sb.AppendLine("    table.sales-table th { background: #0f172a; color: #ffffff; font-weight: 700; text-transform: uppercase; font-size: 11.5px; letter-spacing: 0.5px; padding: 11px 10px; text-align: left; }")
        sb.AppendLine("    table.sales-table td { padding: 11px 10px; border-bottom: 1px solid #e2e8f0; }")
        sb.AppendLine("    table.sales-table tr:nth-child(even) { background: #f8fafc; }")
        sb.AppendLine("    .text-right { text-align: right; }")
        sb.AppendLine("    .text-center { text-align: center; }")
        sb.AppendLine("    .rank-badge { display: inline-block; width: 24px; height: 24px; line-height: 24px; background: #e2e8f0; border-radius: 50%; font-weight: 700; font-size: 11px; color: #1e293b; text-align: center; }")
        sb.AppendLine("    .rank-1 { background: #fef08a; color: #854d0e; }")
        sb.AppendLine("    .rank-2 { background: #e2e8f0; color: #334155; }")
        sb.AppendLine("    .rank-3 { background: #fed7aa; color: #9a3412; }")
        sb.AppendLine("    .report-footer { display: flex; justify-content: space-between; align-items: center; border-top: 1px solid #e2e8f0; padding-top: 14px; font-size: 11px; color: #94a3b8; }")
        sb.AppendLine("    @media print {")
        sb.AppendLine("      body { background: #ffffff !important; padding: 0 !important; color: #000 !important; }")
        sb.AppendLine("      .no-print-toolbar { display: none !important; }")
        sb.AppendLine("      .report-container { box-shadow: none !important; border: none !important; max-width: 100% !important; padding: 0 !important; width: 100% !important; }")
        sb.AppendLine("      table.sales-table th { background: #0f172a !important; color: #fff !important; -webkit-print-color-adjust: exact; print-color-adjust: exact; }")
        sb.AppendLine("      .stat-card { -webkit-print-color-adjust: exact; print-color-adjust: exact; }")
        sb.AppendLine("      .rank-1, .rank-2, .rank-3 { -webkit-print-color-adjust: exact; print-color-adjust: exact; }")
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
        sb.AppendLine("        <div class=""report-badge"">Sales Summary Report</div>")
        sb.AppendLine($"        <div class=""report-meta"">Date Period: {fromDate:MMM dd, yyyy} to {toDate:MMM dd, yyyy}<br>Generated By: {System.Net.WebUtility.HtmlEncode(SessionManager.Username)}<br>Generated On: {DateTime.Now:MMM dd, yyyy  hh:mm tt}</div>")
        sb.AppendLine("      </div>")
        sb.AppendLine("    </div>")

        ' Executive KPI Grid
        sb.AppendLine("    <div class=""stats-grid"">")
        sb.AppendLine("      <div class=""stat-card"">")
        sb.AppendLine($"        <div class=""stat-val"">{totalSales:N0}</div>")
        sb.AppendLine("        <div class=""stat-label"">Total Sales Recorded</div>")
        sb.AppendLine("      </div>")
        sb.AppendLine("      <div class=""stat-card"">")
        sb.AppendLine($"        <div class=""stat-val stat-green"">{currency}{totalRevenue:N2}</div>")
        sb.AppendLine("        <div class=""stat-label"">Total Revenue</div>")
        sb.AppendLine("      </div>")
        sb.AppendLine("      <div class=""stat-card"">")
        sb.AppendLine($"        <div class=""stat-val stat-blue"">{currency}{avgSaleValue:N2}</div>")
        sb.AppendLine("        <div class=""stat-label"">Average Sale Value</div>")
        sb.AppendLine("      </div>")
        sb.AppendLine("    </div>")

        ' Top Products Table
        sb.AppendLine("    <div class=""section-title"">🏆 Top Products by Units Sold</div>")
        sb.AppendLine("    <div class=""table-wrapper"">")
        sb.AppendLine("      <table class=""sales-table"">")
        sb.AppendLine("        <thead>")
        sb.AppendLine("          <tr>")
        sb.AppendLine("            <th style=""width: 55px;"" class=""text-center"">Rank</th>")
        sb.AppendLine("            <th>Product</th>")
        sb.AppendLine("            <th style=""width: 140px;"" class=""text-right"">Units Sold</th>")
        sb.AppendLine("            <th style=""width: 170px;"" class=""text-right"">Revenue</th>")
        sb.AppendLine("          </tr>")
        sb.AppendLine("        </thead>")
        sb.AppendLine("        <tbody>")

        If topProducts IsNot Nothing AndAlso topProducts.Rows.Count > 0 Then
            Dim rank As Integer = 1
            For Each row As DataRow In topProducts.Rows
                Dim prodName = System.Net.WebUtility.HtmlEncode(row("Product")?.ToString())
                Dim unitsSold As Integer
                Integer.TryParse(row("TotalSold")?.ToString(), unitsSold)
                Dim rev As Decimal
                Decimal.TryParse(row("TotalRevenue")?.ToString(), rev)

                Dim rankClass = ""
                If rank = 1 Then
                    rankClass = "rank-1"
                ElseIf rank = 2 Then
                    rankClass = "rank-2"
                ElseIf rank = 3 Then
                    rankClass = "rank-3"
                End If

                sb.AppendLine("          <tr>")
                sb.AppendLine($"            <td class=""text-center""><span class=""rank-badge {rankClass}"">{rank}</span></td>")
                sb.AppendLine($"            <td><strong>{prodName}</strong></td>")
                sb.AppendLine($"            <td class=""text-right""><strong>{unitsSold:N0}</strong></td>")
                sb.AppendLine($"            <td class=""text-right""><strong>{currency}{rev:N2}</strong></td>")
                sb.AppendLine("          </tr>")
                rank += 1
            Next
        Else
            sb.AppendLine("          <tr><td colspan=""4"" style=""text-align: center; padding: 25px; color: #94a3b8;"">No sales recorded for the selected period.</td></tr>")
        End If

        sb.AppendLine("        </tbody>")
        sb.AppendLine("      </table>")
        sb.AppendLine("    </div>")

        ' Footer
        sb.AppendLine("    <div class=""report-footer"">")
        sb.AppendLine("      <div>IMASTS — Automated Inventory Management &amp; Sales Tracking System</div>")
        sb.AppendLine($"      <div>Generated on {DateTime.Now:yyyy-MM-dd HH:mm:ss}</div>")
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

    Public Sub OpenSalesReportInChrome(fromDate As Date, toDate As Date,
                                       totalSales As Integer, totalRevenue As Decimal,
                                       avgSaleValue As Decimal, topProducts As DataTable)
        Try
            Dim html = GenerateSalesReportHtml(fromDate, toDate, totalSales, totalRevenue, avgSaleValue, topProducts)
            Dim tempDir = Path.Combine(Path.GetTempPath(), "IMASTS_Reports")
            If Not Directory.Exists(tempDir) Then Directory.CreateDirectory(tempDir)

            Dim filePath = Path.Combine(tempDir, $"SalesSummary_{fromDate:yyyyMMdd}_{toDate:yyyyMMdd}_{DateTime.Now:HHmmss}.html")
            File.WriteAllText(filePath, html, Encoding.UTF8)

            ' Chrome detection
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

            If Not launched Then
                Process.Start(New ProcessStartInfo(filePath) With {.UseShellExecute = True})
            End If
        Catch ex As Exception
            MessageBox.Show($"Failed to generate sales report: {ex.Message}", "Print Sales Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub ExportSalesReport(fromDate As Date, toDate As Date,
                                 totalSales As Integer, totalRevenue As Decimal,
                                 avgSaleValue As Decimal, topProducts As DataTable)
        Using sfd As New SaveFileDialog()
            sfd.Title = "Export Sales Summary to Excel"
            sfd.Filter = "CSV Spreadsheet (*.csv)|*.csv|Excel XML Workbook (*.xls)|*.xls"
            sfd.FilterIndex = 1
            sfd.FileName = $"IMASTS_SalesSummary_{fromDate:yyyyMMdd}_to_{toDate:yyyyMMdd}.csv"

            If sfd.ShowDialog() <> DialogResult.OK Then Return

            Try
                Dim filePath = sfd.FileName
                Dim ext = Path.GetExtension(filePath).ToLowerInvariant()

                If ext = ".xls" Then
                    ExportSalesToExcelXml(fromDate, toDate, totalSales, totalRevenue, avgSaleValue, topProducts, filePath)
                Else
                    ExportSalesToCsv(fromDate, toDate, totalSales, totalRevenue, avgSaleValue, topProducts, filePath)
                End If

                ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess,
                    $"Exported sales summary report ({fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}) to {Path.GetFileName(filePath)}")

                Dim askOpen = MessageBox.Show(
                    $"Sales report exported successfully!{Environment.NewLine}{Environment.NewLine}" &
                    $"Location: {filePath}{Environment.NewLine}{Environment.NewLine}" &
                    $"Would you like to open the exported file now?",
                    "Export Successful",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information)

                If askOpen = DialogResult.Yes Then
                    Process.Start(New ProcessStartInfo(filePath) With {.UseShellExecute = True})
                End If
            Catch ex As Exception
                MessageBox.Show($"Failed to export sales report: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub ExportSalesToCsv(fromDate As Date, toDate As Date,
                                 totalSales As Integer, totalRevenue As Decimal,
                                 avgSaleValue As Decimal, topProducts As DataTable, filePath As String)
        Using sw As New StreamWriter(filePath, False, New UTF8Encoding(True))
            sw.WriteLine("IMASTS Sales Summary Report")
            sw.WriteLine($"Period: {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}")
            sw.WriteLine($"Generated On: {DateTime.Now:yyyy-MM-dd HH:mm:ss}")
            sw.WriteLine()
            sw.WriteLine("Metric,Value")
            sw.WriteLine($"Total Sales,{totalSales}")
            sw.WriteLine($"Total Revenue,{totalRevenue:F2}")
            sw.WriteLine($"Average Sale Value,{avgSaleValue:F2}")
            sw.WriteLine()
            sw.WriteLine("Top Products by Units Sold")
            sw.WriteLine("Rank,Product,Units Sold,Total Revenue")

            If topProducts IsNot Nothing Then
                Dim rank = 1
                For Each row As DataRow In topProducts.Rows
                    Dim prodName = row("Product")?.ToString().Replace("""", """""")
                    Dim unitsSold = row("TotalSold")?.ToString()
                    Dim rev = If(IsNumeric(row("TotalRevenue")), CDec(row("TotalRevenue")).ToString("F2"), "0.00")
                    sw.WriteLine($"{rank},""{prodName}"",{unitsSold},{rev}")
                    rank += 1
                Next
            End If
        End Using
    End Sub

    Private Sub ExportSalesToExcelXml(fromDate As Date, toDate As Date,
                                      totalSales As Integer, totalRevenue As Decimal,
                                      avgSaleValue As Decimal, topProducts As DataTable, filePath As String)
        Dim sb As New StringBuilder()
        sb.AppendLine("<?xml version=""1.0"" encoding=""utf-8""?>")
        sb.AppendLine("<?mso-application progid=""Excel.Sheet""?>")
        sb.AppendLine("<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""")
        sb.AppendLine(" xmlns:o=""urn:schemas-microsoft-com:office:office""")
        sb.AppendLine(" xmlns:x=""urn:schemas-microsoft-com:office:excel""")
        sb.AppendLine(" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet""")
        sb.AppendLine(" xmlns:html=""http://www.w3.org/TR/REC-html40"">")

        ' Styles
        sb.AppendLine(" <Styles>")
        sb.AppendLine("  <Style ss:ID=""Default"" ss:Name=""Normal"">")
        sb.AppendLine("   <Alignment ss:Vertical=""Center""/>")
        sb.AppendLine("   <Font ss:FontName=""Segoe UI"" ss:Size=""10""/>")
        sb.AppendLine("  </Style>")
        sb.AppendLine("  <Style ss:ID=""TitleStyle"">")
        sb.AppendLine("   <Font ss:FontName=""Segoe UI"" ss:Size=""16"" ss:Bold=""1"" ss:Color=""#1E293B""/>")
        sb.AppendLine("  </Style>")
        sb.AppendLine("  <Style ss:ID=""SubTitleStyle"">")
        sb.AppendLine("   <Font ss:FontName=""Segoe UI"" ss:Size=""10"" ss:Italic=""1"" ss:Color=""#64748B""/>")
        sb.AppendLine("  </Style>")
        sb.AppendLine("  <Style ss:ID=""SectionHeader"">")
        sb.AppendLine("   <Font ss:FontName=""Segoe UI"" ss:Size=""11"" ss:Bold=""1"" ss:Color=""#1E293B""/>")
        sb.AppendLine("  </Style>")
        sb.AppendLine("  <Style ss:ID=""HeaderStyle"">")
        sb.AppendLine("   <Alignment ss:Horizontal=""Center"" ss:Vertical=""Center""/>")
        sb.AppendLine("   <Borders>")
        sb.AppendLine("    <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#000000""/>")
        sb.AppendLine("   </Borders>")
        sb.AppendLine("   <Font ss:FontName=""Segoe UI"" ss:Size=""10"" ss:Bold=""1"" ss:Color=""#FFFFFF""/>")
        sb.AppendLine("   <Interior ss:Color=""#1E293B"" ss:Pattern=""Solid""/>")
        sb.AppendLine("  </Style>")
        sb.AppendLine("  <Style ss:ID=""DataCell"">")
        sb.AppendLine("   <Borders>")
        sb.AppendLine("    <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#E2E8F0""/>")
        sb.AppendLine("   </Borders>")
        sb.AppendLine("  </Style>")
        sb.AppendLine("  <Style ss:ID=""DataCenter"">")
        sb.AppendLine("   <Alignment ss:Horizontal=""Center"" ss:Vertical=""Center""/>")
        sb.AppendLine("   <Borders>")
        sb.AppendLine("    <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#E2E8F0""/>")
        sb.AppendLine("   </Borders>")
        sb.AppendLine("  </Style>")
        sb.AppendLine("  <Style ss:ID=""DataNumber"">")
        sb.AppendLine("   <Alignment ss:Horizontal=""Right"" ss:Vertical=""Center""/>")
        sb.AppendLine("   <Borders>")
        sb.AppendLine("    <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#E2E8F0""/>")
        sb.AppendLine("   </Borders>")
        sb.AppendLine("   <NumberFormat ss:Format=""#,##0""/>")
        sb.AppendLine("  </Style>")
        sb.AppendLine("  <Style ss:ID=""DataCurrency"">")
        sb.AppendLine("   <Alignment ss:Horizontal=""Right"" ss:Vertical=""Center""/>")
        sb.AppendLine("   <Borders>")
        sb.AppendLine("    <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#E2E8F0""/>")
        sb.AppendLine("   </Borders>")
        sb.AppendLine("   <NumberFormat ss:Format=""#,##0.00""/>")
        sb.AppendLine("  </Style>")
        sb.AppendLine(" </Styles>")

        ' Worksheet
        sb.AppendLine(" <Worksheet ss:Name=""SalesSummary"">")
        sb.AppendLine("  <Table>")
        sb.AppendLine("   <Column ss:Width=""50""/>")
        sb.AppendLine("   <Column ss:Width=""220""/>")
        sb.AppendLine("   <Column ss:Width=""100""/>")
        sb.AppendLine("   <Column ss:Width=""120""/>")

        ' Headers
        sb.AppendLine("   <Row ss:Height=""24""><Cell ss:StyleID=""TitleStyle""><Data ss:Type=""String"">IMASTS Sales Summary Report</Data></Cell></Row>")
        sb.AppendLine($"   <Row ss:Height=""18""><Cell ss:StyleID=""SubTitleStyle""><Data ss:Type=""String"">Period: {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd} | Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}</Data></Cell></Row>")
        sb.AppendLine("   <Row ss:Height=""10""></Row>")

        ' Metrics
        sb.AppendLine("   <Row ss:Height=""20""><Cell ss:StyleID=""HeaderStyle""><Data ss:Type=""String"">Metric</Data></Cell><Cell ss:StyleID=""HeaderStyle""><Data ss:Type=""String"">Value</Data></Cell></Row>")
        sb.AppendLine($"   <Row ss:Height=""19""><Cell ss:StyleID=""DataCell""><Data ss:Type=""String"">Total Sales</Data></Cell><Cell ss:StyleID=""DataNumber""><Data ss:Type=""Number"">{totalSales}</Data></Cell></Row>")
        sb.AppendLine($"   <Row ss:Height=""19""><Cell ss:StyleID=""DataCell""><Data ss:Type=""String"">Total Revenue</Data></Cell><Cell ss:StyleID=""DataCurrency""><Data ss:Type=""Number"">{totalRevenue}</Data></Cell></Row>")
        sb.AppendLine($"   <Row ss:Height=""19""><Cell ss:StyleID=""DataCell""><Data ss:Type=""String"">Average Sale Value</Data></Cell><Cell ss:StyleID=""DataCurrency""><Data ss:Type=""Number"">{avgSaleValue}</Data></Cell></Row>")
        sb.AppendLine("   <Row ss:Height=""15""></Row>")

        ' Top products
        sb.AppendLine("   <Row ss:Height=""20""><Cell ss:StyleID=""SectionHeader""><Data ss:Type=""String"">Top Products by Units Sold</Data></Cell></Row>")
        sb.AppendLine("   <Row ss:Height=""22"">")
        sb.AppendLine("    <Cell ss:StyleID=""HeaderStyle""><Data ss:Type=""String"">Rank</Data></Cell>")
        sb.AppendLine("    <Cell ss:StyleID=""HeaderStyle""><Data ss:Type=""String"">Product</Data></Cell>")
        sb.AppendLine("    <Cell ss:StyleID=""HeaderStyle""><Data ss:Type=""String"">Units Sold</Data></Cell>")
        sb.AppendLine("    <Cell ss:StyleID=""HeaderStyle""><Data ss:Type=""String"">Total Revenue</Data></Cell>")
        sb.AppendLine("   </Row>")

        If topProducts IsNot Nothing Then
            Dim rank = 1
            For Each row As DataRow In topProducts.Rows
                Dim prodName = EscapeXml(row("Product")?.ToString())
                Dim unitsSold As Integer
                Integer.TryParse(row("TotalSold")?.ToString(), unitsSold)
                Dim rev As Decimal
                Decimal.TryParse(row("TotalRevenue")?.ToString(), rev)

                sb.AppendLine("   <Row ss:Height=""19"">")
                sb.AppendLine($"    <Cell ss:StyleID=""DataCenter""><Data ss:Type=""Number"">{rank}</Data></Cell>")
                sb.AppendLine($"    <Cell ss:StyleID=""DataCell""><Data ss:Type=""String"">{prodName}</Data></Cell>")
                sb.AppendLine($"    <Cell ss:StyleID=""DataNumber""><Data ss:Type=""Number"">{unitsSold}</Data></Cell>")
                sb.AppendLine($"    <Cell ss:StyleID=""DataCurrency""><Data ss:Type=""Number"">{rev}</Data></Cell>")
                sb.AppendLine("   </Row>")
                rank += 1
            Next
        End If

        sb.AppendLine("  </Table>")
        sb.AppendLine(" </Worksheet>")
        sb.AppendLine("</Workbook>")

        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8)
    End Sub

    Private Function EscapeXml(value As String) As String
        If String.IsNullOrEmpty(value) Then Return ""
        Return value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("""", "&quot;").Replace("'", "&apos;")
    End Function

End Module
