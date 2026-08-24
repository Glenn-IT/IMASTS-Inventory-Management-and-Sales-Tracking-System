Public Class frmSystemManual

    Private Sub frmSystemManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "System Manual"
        LoadManualContent()
    End Sub

    Private Sub LoadManualContent()
        LoadOverview()
        LoadProducts()
        LoadInventory()
        LoadNewSale()
        LoadSalesHistory()
        LoadSuppliersCategories()
        LoadReports()
        LoadSettings()
    End Sub

    ' ── Overview ──────────────────────────────────────────────────────────

    Private Sub LoadOverview()
        rtbOverview.Clear()
        AppendTitle(rtbOverview, "IMASTS — System Overview & Dashboard Guide")

        AppendSection(rtbOverview, "1. What is IMASTS?")
        AppendBody(rtbOverview, "IMASTS (Inventory Management and Sales Tracking System) is a comprehensive, enterprise-ready desktop solution designed to automate retail transactions, maintain inventory control, monitor stock valuation, and track business revenue in real time.")

        AppendSection(rtbOverview, "2. Key Modules & Workflow")
        AppendBullet(rtbOverview, "Dashboard: Real-time KPIs, revenue stats, top-selling items, and quick action shortcuts.")
        AppendBullet(rtbOverview, "Products: Catalog management, pricing, units of measure, and auto-generated barcodes.")
        AppendBullet(rtbOverview, "Inventory: Stock receiving (+ Receive Stock), physical count adjustments (✎ Adjust Stock), and low-stock alerts.")
        AppendBullet(rtbOverview, "New Sale (POS): Fast barcode scanner entry, automated cart calculation, and Google Chrome PDF receipt printing.")
        AppendBullet(rtbOverview, "Sales History: Transaction audits, line item breakdowns, and one-click receipt re-printing.")
        AppendBullet(rtbOverview, "Suppliers & Categories: Classification of goods and vendor contact directory.")
        AppendBullet(rtbOverview, "Reports: Detailed sales summaries, inventory valuation, and CSV export capabilities.")
        AppendBullet(rtbOverview, "Settings: User account management, role assignment, and self-service password recovery.")
        rtbOverview.AppendText(Environment.NewLine)

        AppendSection(rtbOverview, "3. User Roles & Security Access")
        AppendStep(rtbOverview, "• Administrator:", "Full system privileges including User Management, Voiding Sales, and Detailed Reports.")
        AppendStep(rtbOverview, "• Staff / Cashier:", "Daily point-of-sale transactions, product lookup, stock receiving, and personal security question setup.")
        rtbOverview.Select(0, 0)
    End Sub

    ' ── Products ──────────────────────────────────────────────────────────

    Private Sub LoadProducts()
        rtbProducts.Clear()
        AppendTitle(rtbProducts, "Product Management Module")

        AppendSection(rtbProducts, "1. Adding a New Product")
        AppendStep(rtbProducts, "Step 1:", "Enter a barcode, or click the [Gen] button to generate a unique random barcode automatically.")
        AppendStep(rtbProducts, "Step 2:", "Enter the complete Product Name.")
        AppendStep(rtbProducts, "Step 3:", "Select the Category and Supplier from the dropdown menus.")
        AppendStep(rtbProducts, "Step 4:", "Enter the Unit Price (selling price), Initial Stock Quantity, and Reorder Level.")
        AppendStep(rtbProducts, "Step 5:", "Select or type the measurement Unit (e.g. pcs, box, kg, pack, liter).")
        AppendStep(rtbProducts, "Step 6:", "Click the [Add] button to save the product to the database.")
        rtbProducts.AppendText(Environment.NewLine)

        AppendSection(rtbProducts, "2. Editing / Updating a Product")
        AppendStep(rtbProducts, "Step 1:", "Click on any product row in the table, or scan its barcode in the search bar.")
        AppendStep(rtbProducts, "Step 2:", "Update any details (Price, Reorder Level, Category, Supplier, etc.) in the left editor panel.")
        AppendStep(rtbProducts, "Step 3:", "Click [Update] to save the modifications.")
        rtbProducts.AppendText(Environment.NewLine)

        AppendSection(rtbProducts, "3. Deleting a Product")
        AppendStep(rtbProducts, "Step 1:", "Select the product from the grid.")
        AppendStep(rtbProducts, "Step 2:", "Click [Delete] and confirm the confirmation prompt.")
        AppendBody(rtbProducts, "Note: Products with existing transaction history (past sales or stock receipts) are protected from deletion to ensure financial audit integrity.")

        AppendSection(rtbProducts, "4. Real-time Search & Barcode Scan")
        AppendBullet(rtbProducts, "Type any product name, barcode, or category in the 'Search / Scan' box to filter instantly.")
        AppendBullet(rtbProducts, "Press Enter while typing to auto-select and load the top matching product.")
        rtbProducts.Select(0, 0)
    End Sub

    ' ── Inventory ─────────────────────────────────────────────────────────

    Private Sub LoadInventory()
        rtbInventory.Clear()
        AppendTitle(rtbInventory, "Inventory & Stock Operations Module")

        AppendSection(rtbInventory, "1. Receiving Stock (+ Receive Stock)")
        AppendBody(rtbInventory, "Use this function when new stock arrives from suppliers to increase inventory quantities:")
        AppendStep(rtbInventory, "Step 1:", "Select the product from the table or scan its barcode into the Barcode field.")
        AppendStep(rtbInventory, "Step 2:", "Verify or select the Supplier.")
        AppendStep(rtbInventory, "Step 3:", "Enter the Quantity to Receive (positive whole number).")
        AppendStep(rtbInventory, "Step 4:", "Optionally enter invoice or delivery notes.")
        AppendStep(rtbInventory, "Step 5:", "Click [+ Receive Stock] and confirm.")
        AppendBody(rtbInventory, "Result: Stock is added to inventory, and a permanent record is written to the stock receipt audit log.")

        AppendSection(rtbInventory, "2. Adjusting Stock (✎ Adjust Stock)")
        AppendBody(rtbInventory, "Use this function during physical inventory audits, cycle counts, or write-offs for damaged goods:")
        AppendStep(rtbInventory, "Step 1:", "Select the product from the list.")
        AppendStep(rtbInventory, "Step 2:", "Enter the exact New Stock Quantity in the Quantity field.")
        AppendStep(rtbInventory, "Step 3:", "Provide an adjustment reason (e.g. 'Monthly audit recount', 'Damaged items').")
        AppendStep(rtbInventory, "Step 4:", "Click [✎ Adjust Stock] and confirm.")
        AppendBody(rtbInventory, "Result: The product stock is set to the exact quantity, and the change is logged in the activity audit trail.")

        AppendSection(rtbInventory, "3. Visual Stock Status Alerts")
        AppendBullet(rtbInventory, "Red Highlight: OUT OF STOCK — Inventory has reached 0 units.")
        AppendBullet(rtbInventory, "Amber Highlight: LOW STOCK — Quantity is at or below the Reorder Level.")
        AppendBullet(rtbInventory, "Standard / White: IN STOCK — Healthy stock levels above reorder threshold.")
        rtbInventory.Select(0, 0)
    End Sub

    ' ── New Sale ──────────────────────────────────────────────────────────

    Private Sub LoadNewSale()
        rtbNewSale.Clear()
        AppendTitle(rtbNewSale, "Point of Sale (POS) & Receipt Printing Guide")

        AppendSection(rtbNewSale, "1. Barcode Scanning & Item Entry")
        AppendBullet(rtbNewSale, "High-Speed Barcode Scanning: Point the barcode scanner at the item. It automatically adds 1 unit to the cart, plays a confirmation chime, and keeps focus on the scan box for the next item.")
        AppendBullet(rtbNewSale, "Manual Selection: Pick an item from the dropdown, enter quantity, and click [Add to Sale].")
        AppendBullet(rtbNewSale, "Stock Validation: The POS automatically checks available inventory to prevent overselling.")
        rtbNewSale.AppendText(Environment.NewLine)

        AppendSection(rtbNewSale, "2. Cart Management & Discounts")
        AppendStep(rtbNewSale, "• Removing Items:", "Click the [Remove] button on any line item to remove it from the cart.")
        AppendStep(rtbNewSale, "• Applying Discounts:", "Enter the discount amount in the Discount field. The Net Total recalculates immediately.")
        rtbNewSale.AppendText(Environment.NewLine)

        AppendSection(rtbNewSale, "3. Confirming Sales & Instant Receipt Printing")
        AppendStep(rtbNewSale, "Step 1:", "Click [Confirm Sale] to finalize the transaction.")
        AppendStep(rtbNewSale, "Step 2:", "Quantities are automatically deducted from the inventory database.")
        AppendStep(rtbNewSale, "Step 3:", "A prompt asks: 'Do you want to print the receipt now in Chrome / PDF?'")
        AppendStep(rtbNewSale, "Step 4:", "Clicking [Yes] (or clicking [🖶 Print Receipt]) opens Google Chrome in print mode, with the system logo, receipt ID, cashier name, line items, and totals ready to print or save to PDF.")
        rtbNewSale.Select(0, 0)
    End Sub

    ' ── Sales History ─────────────────────────────────────────────────────

    Private Sub LoadSalesHistory()
        rtbSalesHistory.Clear()
        AppendTitle(rtbSalesHistory, "Sales History & Transaction Audits")

        AppendSection(rtbSalesHistory, "1. Filtering Past Transactions")
        AppendStep(rtbSalesHistory, "Step 1:", "Select the 'From' and 'To' dates using the date pickers.")
        AppendStep(rtbSalesHistory, "Step 2:", "Click [Filter] to load all matching transactions.")
        AppendBody(rtbSalesHistory, "Each transaction displays Sale ID, Date & Time, Cashier Name, Gross Total, Discount, Net Amount, and Status.")

        AppendSection(rtbSalesHistory, "2. Viewing Itemized Line Items")
        AppendBody(rtbSalesHistory, "Click any sale record in the top grid to inspect the itemized list, quantities, and prices in the bottom 'Sale Items' pane.")

        AppendSection(rtbSalesHistory, "3. Re-Printing Receipts")
        AppendStep(rtbSalesHistory, "Step 1:", "Select the desired sale from the table.")
        AppendStep(rtbSalesHistory, "Step 2:", "Click [🖶 Print Receipt] in the toolbar.")
        AppendBody(rtbSalesHistory, "The system regenerates the receipt with full branding and opens Chrome's print dialog instantly.")

        AppendSection(rtbSalesHistory, "4. Voiding Transactions (Admin Only)")
        AppendStep(rtbSalesHistory, "Step 1:", "Select the transaction to void.")
        AppendStep(rtbSalesHistory, "Step 2:", "Click [Void Sale] and confirm.")
        AppendBody(rtbSalesHistory, "Result: The transaction status updates to 'Voided' (greyed out) and all purchased quantities are returned to inventory stock.")
        rtbSalesHistory.Select(0, 0)
    End Sub

    ' ── Suppliers & Categories ────────────────────────────────────────────

    Private Sub LoadSuppliersCategories()
        rtbSuppliersCategories.Clear()
        AppendTitle(rtbSuppliersCategories, "Suppliers & Categories Guide")

        AppendSection(rtbSuppliersCategories, "1. Categories Module")
        AppendBullet(rtbSuppliersCategories, "Add Category: Enter Category Name and default Unit (pcs, box, kg, pack, etc.).")
        AppendBullet(rtbSuppliersCategories, "Update / Delete: Select a category to modify its name or remove it.")
        AppendBullet(rtbSuppliersCategories, "Benefits: Simplifies inventory filtering and auto-fills default units when adding new products.")
        rtbSuppliersCategories.AppendText(Environment.NewLine)

        AppendSection(rtbSuppliersCategories, "2. Suppliers Module")
        AppendBullet(rtbSuppliersCategories, "Add Supplier: Record company name, contact person, phone number, email, and address.")
        AppendBullet(rtbSuppliersCategories, "Update / Delete: Manage supplier contact information.")
        AppendBullet(rtbSuppliersCategories, "Integration: Suppliers link directly with products and stock replenishment receipts.")
        rtbSuppliersCategories.Select(0, 0)
    End Sub

    ' ── Reports ───────────────────────────────────────────────────────────

    Private Sub LoadReports()
        rtbReports.Clear()
        AppendTitle(rtbReports, "Reports & Analytics Module")

        AppendSection(rtbReports, "1. Sales Reports")
        AppendBullet(rtbReports, "Filter sales by date range to calculate Gross Sales, Total Discounts, and Net Revenue.")
        AppendBullet(rtbReports, "View transaction volume and cashier performance breakdowns.")
        rtbReports.AppendText(Environment.NewLine)

        AppendSection(rtbReports, "2. Inventory Valuation & Stock Reports")
        AppendBullet(rtbReports, "Total Inventory Value: Automatically computes (Quantity * Unit Price) across all catalog items.")
        AppendBullet(rtbReports, "Low Stock / Out of Stock Reports: Export lists of products requiring urgent supplier orders.")
        rtbReports.AppendText(Environment.NewLine)

        AppendSection(rtbReports, "3. Top Selling Products")
        AppendBullet(rtbReports, "Ranks products by sales frequency and total revenue generated.")
        rtbReports.AppendText(Environment.NewLine)

        AppendSection(rtbReports, "4. Exporting Data")
        AppendBullet(rtbReports, "Export to CSV: Generates clean spreadsheets compatible with Microsoft Excel and Google Sheets.")
        AppendBullet(rtbReports, "Print Summary: Generates formatted printable audit tables.")
        rtbReports.Select(0, 0)
    End Sub

    ' ── Settings & Security ───────────────────────────────────────────────

    Private Sub LoadSettings()
        rtbSettings.Clear()
        AppendTitle(rtbSettings, "Settings & Account Security Guide")

        AppendSection(rtbSettings, "1. User Account Management (Admin Role)")
        AppendStep(rtbSettings, "• Adding Users:", "Enter a unique Username, Password (min 6 characters), and assign Role (Admin or Staff).")
        AppendStep(rtbSettings, "• Changing Passwords:", "Select any user account from the grid, enter a new password, and click [Change Password].")
        AppendStep(rtbSettings, "• Deleting Users:", "Select a user and click [Delete Selected User]. Active logged-in users cannot delete themselves.")
        rtbSettings.AppendText(Environment.NewLine)

        AppendSection(rtbSettings, "2. My Security Question (Self-Service)")
        AppendBody(rtbSettings, "All users can configure a personal security question for self-service password recovery:")
        AppendStep(rtbSettings, "Step 1:", "Select a secret question from the dropdown list.")
        AppendStep(rtbSettings, "Step 2:", "Enter your Secret Answer and Confirm Answer.")
        AppendStep(rtbSettings, "Step 3:", "Click [Save Security Question].")
        AppendBody(rtbSettings, "Recovery: If you ever forget your password, click 'Forgot Password?' on the Login screen and answer your security question to instantly reset your password.")
        rtbSettings.Select(0, 0)
    End Sub

    ' ── Formatting Helpers ────────────────────────────────────────────────

    Private Sub AppendTitle(rtb As RichTextBox, text As String)
        rtb.SelectionFont = New Font("Segoe UI", 13.0!, FontStyle.Bold)
        rtb.SelectionColor = Color.FromArgb(28, 43, 74)
        rtb.AppendText(text & Environment.NewLine & Environment.NewLine)
    End Sub

    Private Sub AppendSection(rtb As RichTextBox, text As String)
        rtb.SelectionFont = New Font("Segoe UI", 11.0!, FontStyle.Bold)
        rtb.SelectionColor = Color.FromArgb(41, 128, 185)
        rtb.AppendText(text & Environment.NewLine)
    End Sub

    Private Sub AppendBody(rtb As RichTextBox, text As String)
        rtb.SelectionFont = New Font("Segoe UI", 9.75!, FontStyle.Regular)
        rtb.SelectionColor = Color.FromArgb(44, 62, 80)
        rtb.AppendText(text & Environment.NewLine & Environment.NewLine)
    End Sub

    Private Sub AppendStep(rtb As RichTextBox, stepNum As String, stepText As String)
        rtb.SelectionFont = New Font("Segoe UI", 9.75!, FontStyle.Bold)
        rtb.SelectionColor = Color.FromArgb(39, 174, 96)
        rtb.AppendText("  " & stepNum & " ")
        rtb.SelectionFont = New Font("Segoe UI", 9.75!, FontStyle.Regular)
        rtb.SelectionColor = Color.FromArgb(44, 62, 80)
        rtb.AppendText(stepText & Environment.NewLine)
    End Sub

    Private Sub AppendBullet(rtb As RichTextBox, bulletText As String)
        rtb.SelectionFont = New Font("Segoe UI", 9.75!, FontStyle.Bold)
        rtb.SelectionColor = Color.FromArgb(52, 152, 219)
        rtb.AppendText("  • ")
        rtb.SelectionFont = New Font("Segoe UI", 9.75!, FontStyle.Regular)
        rtb.SelectionColor = Color.FromArgb(44, 62, 80)
        rtb.AppendText(bulletText & Environment.NewLine)
    End Sub

End Class
