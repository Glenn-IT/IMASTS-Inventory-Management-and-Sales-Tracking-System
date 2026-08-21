Public Class frmInventory

    Private _repo As New InventoryRepository()
    Private _inventoryTable As DataTable
    Private _productsTable As DataTable

    Private Sub frmInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            .HeaderText = "ID", .Width = 50, .AutoSizeMode = DataGridViewAutoSizeColumnMode.None, .ReadOnly = True
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Barcode", .DataPropertyName = "Barcode",
            .HeaderText = "Barcode", .FillWeight = 100, .ReadOnly = True
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Name", .DataPropertyName = "Name",
            .HeaderText = "Product Name", .FillWeight = 200, .ReadOnly = True
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "CategoryName", .DataPropertyName = "CategoryName",
            .HeaderText = "Category", .FillWeight = 130, .ReadOnly = True
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "StockQty", .DataPropertyName = "StockQty",
            .HeaderText = "Stock Qty", .FillWeight = 80, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {
                .Alignment = DataGridViewContentAlignment.MiddleRight
            }
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "Unit", .DataPropertyName = "Unit",
            .HeaderText = "Unit", .FillWeight = 65, .ReadOnly = True
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "ReorderLevel", .DataPropertyName = "ReorderLevel",
            .HeaderText = "Reorder Lvl", .FillWeight = 80, .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {
                .Alignment = DataGridViewContentAlignment.MiddleRight
            }
        })
        dgvInventory.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "StockStatus", .DataPropertyName = "StockStatus",
            .HeaderText = "Status", .FillWeight = 100, .ReadOnly = True
        })
    End Sub

    Private Sub LoadComboBoxes()
        _productsTable = _repo.GetProducts()

        cboProduct.DataSource = Nothing
        cboProduct.DataSource = _productsTable
        cboProduct.DisplayMember = "Name"
        cboProduct.ValueMember = "ProductID"
        cboProduct.SelectedIndex = -1

        cboAdjProduct.DataSource = Nothing
        cboAdjProduct.DataSource = _productsTable.Copy()
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
        _inventoryTable = _repo.GetAllWithStockLevel()
        ApplySearchFilter()
    End Sub

    Private Sub ApplySearchFilter()
        If _inventoryTable Is Nothing Then Return
        Dim search = txtSearch.Text.Trim().Replace("'", "''")
        If String.IsNullOrWhiteSpace(search) Then
            _inventoryTable.DefaultView.RowFilter = ""
        Else
            _inventoryTable.DefaultView.RowFilter = $"Name LIKE '%{search}%' OR Barcode LIKE '%{search}%' OR CategoryName LIKE '%{search}%' OR StockStatus LIKE '%{search}%'"
        End If
        dgvInventory.DataSource = _inventoryTable.DefaultView
        ColorizeRows()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplySearchFilter()
    End Sub

    Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
        txtSearch.Clear()
        txtSearch.Focus()
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
        If pnlReceive.Visible Then
            ClearReceiveForm()
            txtRBarcode.Focus()
        End If
    End Sub

    Private Sub btnAdjustStock_Click(sender As Object, e As EventArgs) Handles btnAdjustStock.Click
        pnlReceive.Visible = False
        pnlAdjust.Visible = Not pnlAdjust.Visible
        pnlDetail.Visible = pnlAdjust.Visible
        If pnlAdjust.Visible Then
            ClearAdjustForm()
            txtAdjBarcode.Focus()
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadInventory()
        LoadComboBoxes()
    End Sub

    ' ── Receive Stock ─────────────────────────────────────────────────────

    Private Sub txtRBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim code = txtRBarcode.Text.Trim()
            If String.IsNullOrWhiteSpace(code) OrElse _productsTable Is Nothing Then Return

            Dim rows = _productsTable.Select($"Barcode = '{code.Replace("'", "''")}'")
            If rows.Length = 0 Then
                Dim numId As Integer
                If Integer.TryParse(code, numId) Then
                    rows = _productsTable.Select($"ProductID = {numId}")
                End If
            End If

            If rows.Length > 0 Then
                cboProduct.SelectedValue = rows(0)("ProductID")
                txtQuantity.Focus()
                Try : Media.SystemSounds.Asterisk.Play() : Catch : End Try
            Else
                MessageBox.Show($"Product with barcode ""{code}"" not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRBarcode.SelectAll()
            End If
        End If
    End Sub

    Private Sub ClearReceiveForm()
        txtRBarcode.Clear()
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

    Private Sub txtAdjBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAdjBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim code = txtAdjBarcode.Text.Trim()
            If String.IsNullOrWhiteSpace(code) OrElse _productsTable Is Nothing Then Return

            Dim rows = _productsTable.Select($"Barcode = '{code.Replace("'", "''")}'")
            If rows.Length = 0 Then
                Dim numId As Integer
                If Integer.TryParse(code, numId) Then
                    rows = _productsTable.Select($"ProductID = {numId}")
                End If
            End If

            If rows.Length > 0 Then
                cboAdjProduct.SelectedValue = rows(0)("ProductID")
                txtNewQty.Focus()
                Try : Media.SystemSounds.Asterisk.Play() : Catch : End Try
            Else
                MessageBox.Show($"Product with barcode ""{code}"" not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAdjBarcode.SelectAll()
            End If
        End If
    End Sub

    Private Sub ClearAdjustForm()
        txtAdjBarcode.Clear()
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
