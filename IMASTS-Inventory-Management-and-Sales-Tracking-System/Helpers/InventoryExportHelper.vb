Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms

Public Module InventoryExportHelper

    Public Sub ExportInventory(dataView As DataView, categoryName As String)
        If dataView Is Nothing OrElse dataView.Count = 0 Then
            MessageBox.Show("No inventory records available to export.", "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using sfd As New SaveFileDialog()
            sfd.Title = "Export Inventory to Excel"
            sfd.Filter = "CSV Spreadsheet (*.csv)|*.csv|Excel XML Workbook (*.xls)|*.xls"
            sfd.FilterIndex = 1
            Dim timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss")
            Dim catSlug = If(String.IsNullOrWhiteSpace(categoryName), "All", categoryName.Replace(" ", "_"))
            sfd.FileName = $"IMASTS_Inventory_{catSlug}_{timeStamp}.csv"

            If sfd.ShowDialog() <> DialogResult.OK Then Return

            Try
                Dim filePath = sfd.FileName
                Dim ext = Path.GetExtension(filePath).ToLowerInvariant()

                If ext = ".xls" Then
                    ExportToExcelXml(dataView, categoryName, filePath)
                Else
                    ExportToCsv(dataView, filePath)
                End If

                ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess,
                    $"Exported {dataView.Count} inventory records to {Path.GetFileName(filePath)}")

                Dim askOpen = MessageBox.Show(
                    $"Inventory data exported successfully!{Environment.NewLine}{Environment.NewLine}" &
                    $"Location: {filePath}{Environment.NewLine}{Environment.NewLine}" &
                    $"Would you like to open the exported file now?",
                    "Export Successful",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information)

                If askOpen = DialogResult.Yes Then
                    Process.Start(New ProcessStartInfo(filePath) With {.UseShellExecute = True})
                End If
            Catch ex As Exception
                MessageBox.Show($"Failed to export inventory: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub ExportToCsv(dataView As DataView, filePath As String)
        ' UTF-8 with BOM for Excel compatibility
        Using sw As New StreamWriter(filePath, False, New UTF8Encoding(True))
            ' Header row
            sw.WriteLine("Product ID,Barcode,Product Name,Category,Stock Qty,Unit,Reorder Level,Status")

            For Each drv As DataRowView In dataView
                Dim prodId = drv("ProductID")?.ToString()
                Dim barcode = EscapeCsvField(drv("Barcode")?.ToString())
                Dim name = EscapeCsvField(drv("Name")?.ToString())
                Dim category = EscapeCsvField(drv("CategoryName")?.ToString())
                Dim stock = drv("StockQty")?.ToString()
                Dim unit = EscapeCsvField(drv("Unit")?.ToString())
                Dim reorder = drv("ReorderLevel")?.ToString()
                Dim status = EscapeCsvField(drv("StockStatus")?.ToString())

                sw.WriteLine($"{prodId},{barcode},{name},{category},{stock},{unit},{reorder},{status}")
            Next
        End Using
    End Sub

    Private Function EscapeCsvField(value As String) As String
        If String.IsNullOrEmpty(value) Then Return """"""
        If value.Contains(",") OrElse value.Contains("""") OrElse value.Contains(vbCr) OrElse value.Contains(vbLf) Then
            Return $"""{value.Replace("""", """""")}"""
        End If
        Return $"""{value}"""
    End Function

    Private Sub ExportToExcelXml(dataView As DataView, categoryName As String, filePath As String)
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
        sb.AppendLine("  <Style ss:ID=""DataNumber"">")
        sb.AppendLine("   <Alignment ss:Horizontal=""Right"" ss:Vertical=""Center""/>")
        sb.AppendLine("   <Borders>")
        sb.AppendLine("    <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#E2E8F0""/>")
        sb.AppendLine("   </Borders>")
        sb.AppendLine("   <NumberFormat ss:Format=""#,##0""/>")
        sb.AppendLine("  </Style>")
        sb.AppendLine("  <Style ss:ID=""StatusOk"">")
        sb.AppendLine("   <Alignment ss:Horizontal=""Center"" ss:Vertical=""Center""/>")
        sb.AppendLine("   <Borders>")
        sb.AppendLine("    <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#E2E8F0""/>")
        sb.AppendLine("   </Borders>")
        sb.AppendLine("   <Font ss:FontName=""Segoe UI"" ss:Size=""10"" ss:Bold=""1"" ss:Color=""#16A34A""/>")
        sb.AppendLine("  </Style>")
        sb.AppendLine("  <Style ss:ID=""StatusLow"">")
        sb.AppendLine("   <Alignment ss:Horizontal=""Center"" ss:Vertical=""Center""/>")
        sb.AppendLine("   <Borders>")
        sb.AppendLine("    <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#E2E8F0""/>")
        sb.AppendLine("   </Borders>")
        sb.AppendLine("   <Font ss:FontName=""Segoe UI"" ss:Size=""10"" ss:Bold=""1"" ss:Color=""#D97706""/>")
        sb.AppendLine("  </Style>")
        sb.AppendLine("  <Style ss:ID=""StatusOut"">")
        sb.AppendLine("   <Alignment ss:Horizontal=""Center"" ss:Vertical=""Center""/>")
        sb.AppendLine("   <Borders>")
        sb.AppendLine("    <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1"" ss:Color=""#E2E8F0""/>")
        sb.AppendLine("   </Borders>")
        sb.AppendLine("   <Font ss:FontName=""Segoe UI"" ss:Size=""10"" ss:Bold=""1"" ss:Color=""#DC2626""/>")
        sb.AppendLine("  </Style>")
        sb.AppendLine(" </Styles>")

        ' Worksheet
        sb.AppendLine(" <Worksheet ss:Name=""Inventory"">")
        sb.AppendLine("  <Table>")
        sb.AppendLine("   <Column ss:Width=""50""/>")   ' ID
        sb.AppendLine("   <Column ss:Width=""110""/>")  ' Barcode
        sb.AppendLine("   <Column ss:Width=""220""/>")  ' Product Name
        sb.AppendLine("   <Column ss:Width=""130""/>")  ' Category
        sb.AppendLine("   <Column ss:Width=""85""/>")   ' Stock Qty
        sb.AppendLine("   <Column ss:Width=""60""/>")   ' Unit
        sb.AppendLine("   <Column ss:Width=""85""/>")   ' Reorder Lvl
        sb.AppendLine("   <Column ss:Width=""110""/>")  ' Status

        ' Title rows
        Dim catLabel = If(String.IsNullOrWhiteSpace(categoryName), "All Categories", categoryName)
        sb.AppendLine("   <Row ss:Height=""24""><Cell ss:StyleID=""TitleStyle""><Data ss:Type=""String"">IMASTS Inventory Report</Data></Cell></Row>")
        sb.AppendLine($"   <Row ss:Height=""18""><Cell ss:StyleID=""SubTitleStyle""><Data ss:Type=""String"">Scope: {EscapeXml(catLabel)} | Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss} | Total: {dataView.Count} Records</Data></Cell></Row>")
        sb.AppendLine("   <Row ss:Height=""10""></Row>") ' Spacer

        ' Table Headers
        sb.AppendLine("   <Row ss:Height=""22"">")
        sb.AppendLine("    <Cell ss:StyleID=""HeaderStyle""><Data ss:Type=""String"">ID</Data></Cell>")
        sb.AppendLine("    <Cell ss:StyleID=""HeaderStyle""><Data ss:Type=""String"">Barcode</Data></Cell>")
        sb.AppendLine("    <Cell ss:StyleID=""HeaderStyle""><Data ss:Type=""String"">Product Name</Data></Cell>")
        sb.AppendLine("    <Cell ss:StyleID=""HeaderStyle""><Data ss:Type=""String"">Category</Data></Cell>")
        sb.AppendLine("    <Cell ss:StyleID=""HeaderStyle""><Data ss:Type=""String"">Stock Qty</Data></Cell>")
        sb.AppendLine("    <Cell ss:StyleID=""HeaderStyle""><Data ss:Type=""String"">Unit</Data></Cell>")
        sb.AppendLine("    <Cell ss:StyleID=""HeaderStyle""><Data ss:Type=""String"">Reorder Lvl</Data></Cell>")
        sb.AppendLine("    <Cell ss:StyleID=""HeaderStyle""><Data ss:Type=""String"">Status</Data></Cell>")
        sb.AppendLine("   </Row>")

        ' Data Rows
        For Each drv As DataRowView In dataView
            Dim prodId = drv("ProductID")?.ToString()
            Dim barcode = EscapeXml(drv("Barcode")?.ToString())
            Dim name = EscapeXml(drv("Name")?.ToString())
            Dim category = EscapeXml(drv("CategoryName")?.ToString())
            Dim stockQty As Integer
            Integer.TryParse(drv("StockQty")?.ToString(), stockQty)
            Dim unit = EscapeXml(drv("Unit")?.ToString())
            Dim reorder As Integer
            Integer.TryParse(drv("ReorderLevel")?.ToString(), reorder)
            Dim status = drv("StockStatus")?.ToString()

            Dim statusStyle = "StatusOk"
            If status = "Out of Stock" Then
                statusStyle = "StatusOut"
            ElseIf status = "Low Stock" Then
                statusStyle = "StatusLow"
            End If

            sb.AppendLine("   <Row ss:Height=""19"">")
            sb.AppendLine($"    <Cell ss:StyleID=""DataNumber""><Data ss:Type=""Number"">{prodId}</Data></Cell>")
            sb.AppendLine($"    <Cell ss:StyleID=""DataCell""><Data ss:Type=""String"">{barcode}</Data></Cell>")
            sb.AppendLine($"    <Cell ss:StyleID=""DataCell""><Data ss:Type=""String"">{name}</Data></Cell>")
            sb.AppendLine($"    <Cell ss:StyleID=""DataCell""><Data ss:Type=""String"">{category}</Data></Cell>")
            sb.AppendLine($"    <Cell ss:StyleID=""DataNumber""><Data ss:Type=""Number"">{stockQty}</Data></Cell>")
            sb.AppendLine($"    <Cell ss:StyleID=""DataCell""><Data ss:Type=""String"">{unit}</Data></Cell>")
            sb.AppendLine($"    <Cell ss:StyleID=""DataNumber""><Data ss:Type=""Number"">{reorder}</Data></Cell>")
            sb.AppendLine($"    <Cell ss:StyleID=""{statusStyle}""><Data ss:Type=""String"">{EscapeXml(status)}</Data></Cell>")
            sb.AppendLine("   </Row>")
        Next

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
