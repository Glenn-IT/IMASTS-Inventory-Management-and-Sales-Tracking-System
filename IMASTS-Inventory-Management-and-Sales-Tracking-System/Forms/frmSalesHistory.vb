Public Class frmSalesHistory

    Private _repo           As New SaleRepository()
    Private _selectedSaleId As Integer = 0
    Private _selectedVoided As Boolean = False

    Private Sub frmSalesHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' GATE — remove this block when unlocking for v1.07
        Dim gate As New UnderConstructionForm()
        gate.ShowDialog()
        Me.Close()
        Return
        ' END GATE
        Me.Text = "Sales History"
        ConfigureGrids()
        dtpFrom.Value         = DateTime.Today.AddDays(-30)
        dtpTo.Value           = DateTime.Today
        btnVoidSale.Visible   = (SessionManager.UserType = Constants.RoleAdmin)
        btnVoidSale.Enabled   = False
        LoadSales()
    End Sub

    ' ── Grid setup ────────────────────────────────────────────────────────

    Private Sub ConfigureGrids()
        ' Sales grid
        dgvSales.AutoGenerateColumns = False
        dgvSales.Columns.Clear()

        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "SaleID", .DataPropertyName = "SaleID",
            .HeaderText = "ID", .Width = 55, .ReadOnly = True
        })
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "SaleDate", .DataPropertyName = "SaleDate",
            .HeaderText = "Date & Time", .Width = 160, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "dd MMM yyyy  hh:mm tt"}
        })
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Cashier", .DataPropertyName = "Cashier",
            .HeaderText = "Cashier", .Width = 120, .ReadOnly = True
        })
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "TotalAmount", .DataPropertyName = "TotalAmount",
            .HeaderText = "Total", .Width = 90, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Discount", .DataPropertyName = "Discount",
            .HeaderText = "Discount", .Width = 80, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "NetAmount", .DataPropertyName = "NetAmount",
            .HeaderText = "Net Amount", .Width = 100, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Status", .DataPropertyName = "Status",
            .HeaderText = "Status", .Width = 80, .ReadOnly = True
        })
        dgvSales.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "IsVoided", .DataPropertyName = "IsVoided",
            .Visible = False
        })

        ' Sale items detail grid
        dgvSaleItems.AutoGenerateColumns = False
        dgvSaleItems.Columns.Clear()

        dgvSaleItems.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Product", .DataPropertyName = "Product",
            .HeaderText = "Product", .Width = 280, .ReadOnly = True
        })
        dgvSaleItems.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Quantity", .DataPropertyName = "Quantity",
            .HeaderText = "Qty", .Width = 80, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvSaleItems.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "UnitPrice", .DataPropertyName = "UnitPrice",
            .HeaderText = "Unit Price", .Width = 100, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}
        })
        dgvSaleItems.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Subtotal", .DataPropertyName = "Subtotal",
            .HeaderText = "Subtotal", .Width = 100, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}
        })
    End Sub

    ' ── Load / filter ─────────────────────────────────────────────────────

    Private Sub LoadSales()
        dgvSales.DataSource  = _repo.GetAll(dtpFrom.Value, dtpTo.Value)
        dgvSaleItems.DataSource = Nothing
        _selectedSaleId      = 0
        _selectedVoided      = False
        btnVoidSale.Enabled  = False
        ColorizeStatusRows()
    End Sub

    Private Sub ColorizeStatusRows()
        For Each row As DataGridViewRow In dgvSales.Rows
            Dim voided = row.Cells("IsVoided").Value
            If voided IsNot Nothing AndAlso CBool(voided) Then
                row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245)
            Else
                row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(40, 44, 52)
                row.DefaultCellStyle.BackColor = System.Drawing.Color.White
            End If
        Next
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        LoadSales()
    End Sub

    ' ── Grid selection ────────────────────────────────────────────────────

    Private Sub dgvSales_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSales.SelectionChanged
        If dgvSales.CurrentRow Is Nothing Then Return
        Dim row = dgvSales.CurrentRow
        _selectedSaleId  = CInt(row.Cells("SaleID").Value)
        _selectedVoided  = CBool(row.Cells("IsVoided").Value)
        dgvSaleItems.DataSource = _repo.GetSaleItems(_selectedSaleId)
        btnVoidSale.Enabled = (SessionManager.UserType = Constants.RoleAdmin) AndAlso Not _selectedVoided
    End Sub

    ' ── Void sale ─────────────────────────────────────────────────────────

    Private Sub btnVoidSale_Click(sender As Object, e As EventArgs) Handles btnVoidSale.Click
        If _selectedSaleId = 0 Then Return

        Dim confirm = MessageBox.Show(
            $"Void Sale #{_selectedSaleId}? This will restore stock for all line items.",
            "Confirm Void",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)
        If confirm <> DialogResult.Yes Then Return

        If _repo.VoidSale(_selectedSaleId) Then
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess,
                $"Sale #{_selectedSaleId} voided.")
            LoadSales()
        Else
            MessageBox.Show("Failed to void the sale. Please try again.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class
