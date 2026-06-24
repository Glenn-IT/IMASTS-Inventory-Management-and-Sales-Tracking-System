Public Class frmInventory

    Private _repo As New InventoryRepository()

    Private Sub frmInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' GATE — remove this block when unlocking for v1.05
        Dim gate As New UnderConstructionForm()
        gate.ShowDialog()
        Me.Close()
        Return
        ' END GATE
        Me.Text = "Inventory Management"
        ConfigureGrid()
        LoadComboBoxes()
        LoadInventory()
        pnlReceive.Visible = False
        pnlAdjust.Visible = False
        pnlDetail.Visible = False
    End Sub

    ' ── Grid ──────────────────────────────────────────────────────────────

    Private Sub ConfigureGrid()
        dgvInventory.AutoGenerateColumns = False
        dgvInventory.Columns.Clear()

        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "ProductID", .DataPropertyName = "ProductID",
            .HeaderText = "ID", .Width = 50, .ReadOnly = True
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Name", .DataPropertyName = "Name",
            .HeaderText = "Product Name", .Width = 220, .ReadOnly = True
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "CategoryName", .DataPropertyName = "CategoryName",
            .HeaderText = "Category", .Width = 150, .ReadOnly = True
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "StockQty", .DataPropertyName = "StockQty",
            .HeaderText = "Stock Qty", .Width = 90, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {
                .Alignment = DataGridViewContentAlignment.MiddleRight
            }
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "ReorderLevel", .DataPropertyName = "ReorderLevel",
            .HeaderText = "Reorder Lvl", .Width = 90, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {
                .Alignment = DataGridViewContentAlignment.MiddleRight
            }
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "StockStatus", .DataPropertyName = "StockStatus",
            .HeaderText = "Status", .Width = 110, .ReadOnly = True
        })
    End Sub

    Private Sub LoadComboBoxes()
        cboProduct.DataSource = Nothing
        cboProduct.DataSource = _repo.GetProducts()
        cboProduct.DisplayMember = "Name"
        cboProduct.ValueMember = "ProductID"
        cboProduct.SelectedIndex = -1

        cboAdjProduct.DataSource = Nothing
        cboAdjProduct.DataSource = _repo.GetProducts()
        cboAdjProduct.DisplayMember = "Name"
        cboAdjProduct.ValueMember = "ProductID"
        cboAdjProduct.SelectedIndex = -1

        cboSupplier.DataSource = Nothing
        cboSupplier.DataSource = _repo.GetSuppliers()
        cboSupplier.DisplayMember = "Name"
        cboSupplier.ValueMember = "SupplierID"
        cboSupplier.SelectedIndex = -1
    End Sub

    Private Sub LoadInventory()
        dgvInventory.DataSource = _repo.GetAllWithStockLevel()
        ColorizeRows()
    End Sub

    Private Sub ColorizeRows()
        For Each row As DataGridViewRow In dgvInventory.Rows
            Dim status = row.Cells("StockStatus").Value?.ToString()
            Select Case status
                Case "Out of Stock"
                    row.DefaultCellStyle.BackColor = Drawing.Color.FromArgb(255, 200, 200)
                    row.DefaultCellStyle.ForeColor = Drawing.Color.FromArgb(150, 0, 0)
                Case "Low Stock"
                    row.DefaultCellStyle.BackColor = Drawing.Color.FromArgb(255, 235, 180)
                    row.DefaultCellStyle.ForeColor = Drawing.Color.FromArgb(140, 80, 0)
                Case Else
                    row.DefaultCellStyle.BackColor = Drawing.Color.White
                    row.DefaultCellStyle.ForeColor = Drawing.Color.FromArgb(40, 44, 52)
            End Select
        Next
    End Sub

    ' ── Panel toggles ─────────────────────────────────────────────────────

    Private Sub btnReceiveStock_Click(sender As Object, e As EventArgs) Handles btnReceiveStock.Click
        pnlAdjust.Visible = False
        pnlReceive.Visible = Not pnlReceive.Visible
        pnlDetail.Visible = pnlReceive.Visible
        If pnlReceive.Visible Then ClearReceiveForm()
    End Sub

    Private Sub btnAdjustStock_Click(sender As Object, e As EventArgs) Handles btnAdjustStock.Click
        pnlReceive.Visible = False
        pnlAdjust.Visible = Not pnlAdjust.Visible
        pnlDetail.Visible = pnlAdjust.Visible
        If pnlAdjust.Visible Then ClearAdjustForm()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadInventory()
    End Sub

    ' ── Receive Stock ─────────────────────────────────────────────────────

    Private Sub ClearReceiveForm()
        cboProduct.SelectedIndex = -1
        cboSupplier.SelectedIndex = -1
        txtQuantity.Clear()
        txtNotes.Clear()
    End Sub

    Private Sub btnConfirmReceipt_Click(sender As Object, e As EventArgs) Handles btnConfirmReceipt.Click
        If cboProduct.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a product.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If cboSupplier.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a supplier.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim qty As Integer
        If Not Integer.TryParse(txtQuantity.Text, qty) OrElse qty <= 0 Then
            MessageBox.Show("Quantity must be a positive integer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim productId = CInt(cboProduct.SelectedValue)
        Dim supplierId = CInt(cboSupplier.SelectedValue)
        Dim notes = InputHelper.SanitizeInput(txtNotes.Text)
        Dim productName = cboProduct.Text

        If _repo.ReceiveStock(productId, qty, supplierId, notes) Then
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess,
                $"Received {qty} unit(s) of ""{productName}"" into stock.")
            LoadInventory()
            pnlReceive.Visible = False
            pnlDetail.Visible = False
        Else
            MessageBox.Show("Failed to receive stock. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCancelReceipt_Click(sender As Object, e As EventArgs) Handles btnCancelReceipt.Click
        pnlReceive.Visible = False
        pnlDetail.Visible = False
    End Sub

    ' ── Adjust Stock ──────────────────────────────────────────────────────

    Private Sub ClearAdjustForm()
        cboAdjProduct.SelectedIndex = -1
        txtNewQty.Clear()
        txtAdjNotes.Clear()
    End Sub

    Private Sub btnConfirmAdjust_Click(sender As Object, e As EventArgs) Handles btnConfirmAdjust.Click
        If cboAdjProduct.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a product.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim newQty As Integer
        If Not Integer.TryParse(txtNewQty.Text, newQty) OrElse newQty < 0 Then
            MessageBox.Show("New quantity must be a valid non-negative integer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim productId = CInt(cboAdjProduct.SelectedValue)
        Dim productName = cboAdjProduct.Text
        Dim notes = InputHelper.SanitizeInput(txtAdjNotes.Text)

        Dim confirm = MessageBox.Show(
            $"Set stock for ""{productName}"" to {newQty} units?",
            "Confirm Adjustment",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        If _repo.AdjustStock(productId, newQty) Then
            Dim logMsg As String = $"Adjusted stock for ""{productName}"" to {newQty} unit(s)."
            If notes <> "" Then logMsg &= $" Reason: {notes}"
            ActivityLogger.Log(SessionManager.Username, Constants.LogSuccess, logMsg)
            LoadInventory()
            pnlAdjust.Visible = False
            pnlDetail.Visible = False
        Else
            MessageBox.Show("Failed to adjust stock. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCancelAdjust_Click(sender As Object, e As EventArgs) Handles btnCancelAdjust.Click
        pnlAdjust.Visible = False
        pnlDetail.Visible = False
    End Sub

    Private Sub dgvInventory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellContentClick

    End Sub
End Class
