Public Class frmSystemManual

    Private Sub frmSystemManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "System Manual"
        LoadManualContent()
    End Sub

    Private Sub LoadManualContent()
        ' Overview & Dashboard
        txtOverview.Text =
"================================================================================
  IMASTS — INVENTORY MANAGEMENT AND SALES TRACKING SYSTEM
  SYSTEM USER MANUAL & OPERATIONAL GUIDE
================================================================================

1. SYSTEM OVERVIEW
--------------------------------------------------------------------------------
IMASTS is an integrated desktop application designed to streamline daily retail
operations, inventory tracking, point-of-sale transactions, and business analytics.

2. DASHBOARD MODULE
--------------------------------------------------------------------------------
The Dashboard serves as the central operational hub, providing real-time visibility:

  • Key Performance Indicators (KPIs):
      - Total Products in Catalog
      - Low Stock Alert Count
      - Out of Stock Count
      - Today's Total Sales Revenue

  • Quick Actions:
      - Instant navigation to New Sale, Products, Inventory, and Reports.

  • Top Selling Products & Low Stock Lists:
      - Fast identification of inventory reorder needs and top-performing items.

3. USER ROLES & ACCESS
--------------------------------------------------------------------------------
  • Administrator: Full access to all modules, User Management, Reports, and Voiding.
  • Staff / Cashier: Access to Point of Sale, Product lookup, Inventory, and Password recovery."

        ' Products
        txtProducts.Text =
"================================================================================
  PRODUCT MANAGEMENT MODULE
================================================================================

1. ADDING A NEW PRODUCT
--------------------------------------------------------------------------------
  Step 1: Enter or scan a Barcode (or click 'Gen' to auto-generate a unique barcode).
  Step 2: Type the Product Name.
  Step 3: Select Category and Supplier from the dropdown lists.
  Step 4: Enter Unit Price (selling price), Initial Stock Quantity, and Reorder Level.
  Step 5: Select or type the measurement Unit (pcs, box, kg, liter, etc.).
  Step 6: Click 'Add' to save the product to the database.

2. UPDATING A PRODUCT
--------------------------------------------------------------------------------
  Step 1: Select the product row in the table (or scan its barcode in the search bar).
  Step 2: Modify the desired fields (name, price, category, supplier, reorder level).
  Step 3: Click 'Update' to save changes.

3. DELETING A PRODUCT
--------------------------------------------------------------------------------
  Step 1: Select the product from the grid.
  Step 2: Click 'Delete' and confirm the prompt.
  Note: If a product is already referenced by past sales or stock receipts, deletion
        will be protected to maintain historical transaction integrity.

4. SEARCH & BARCODE SCANNING
--------------------------------------------------------------------------------
  • Type in the 'Search / Scan' box to filter in real-time by Name, Barcode, or Category.
  • Press Enter to select the top matching product immediately."

        ' Inventory
        txtInventory.Text =
"================================================================================
  INVENTORY & STOCK OPERATIONS MODULE
================================================================================

1. RECEIVING NEW STOCK (+ Receive Stock)
--------------------------------------------------------------------------------
Use this feature when a new delivery or replenishment shipment arrives:

  Step 1: Click the product in the table or scan its barcode in the Barcode field.
  Step 2: Select the Supplier (optional/auto-filled).
  Step 3: Enter the Quantity to Receive (positive whole number).
  Step 4: Enter optional invoice or delivery notes.
  Step 5: Click '+ Receive Stock' and confirm.
  Result: Stock is incremented, and a receipt audit record is saved in tbl_StockReceipts.

2. ADJUSTING STOCK (✎ Adjust Stock)
--------------------------------------------------------------------------------
Use this feature during physical stock audits, inventory recount, or damaged goods write-offs:

  Step 1: Select the product from the list.
  Step 2: Enter the exact New Stock Quantity in the Quantity field.
  Step 3: Enter a Reason (e.g. 'Monthly count variance', 'Damaged items removed').
  Step 4: Click '✎ Adjust Stock' and confirm.
  Result: Stock level is set to the exact number and logged to the Activity Log.

3. COLOR CODING & STOCK STATUS
--------------------------------------------------------------------------------
  • Red Highlight: OUT OF STOCK (Stock Qty = 0)
  • Amber Highlight: LOW STOCK (Stock Qty <= Reorder Level)
  • White / Normal: IN STOCK (Stock Qty > Reorder Level)"

        ' New Sale (POS)
        txtNewSale.Text =
"================================================================================
  POINT OF SALE (POS) & RECEIPT PRINTING MODULE
================================================================================

1. BARCODE SCANNING & CART ENTRY
--------------------------------------------------------------------------------
  • Fast Scanning: Point your barcode scanner at the product barcode.
    Each scan automatically adds 1 unit to the cart and plays a confirmation beep.
  • Manual Selection: Select product from the dropdown, enter quantity, and click 'Add to Sale'.
  • Stock Validation: The system prevents adding more items than available in stock.

2. MANAGING CART ITEMS
--------------------------------------------------------------------------------
  • Removing an Item: Click the 'Remove' button next to any line item.
  • Applying Discounts: Enter a discount amount in the Discount field.
    The Net Total updates automatically in real-time.

3. CONFIRMING SALE & PRINTING RECEIPT
--------------------------------------------------------------------------------
  Step 1: Click 'Confirm Sale'.
  Step 2: Stock is automatically deducted from inventory.
  Step 3: The system prompts: 'Do you want to print the receipt now in Chrome / PDF?'
  Step 4: Clicking 'Yes' (or clicking '🖶 Print Receipt') generates a thermal receipt
          with the company logo, receipt number, items, and totals, opening Google Chrome's
          Print & PDF dialog automatically."

        ' Sales History
        txtSalesHistory.Text =
"================================================================================
  SALES HISTORY & VOID MANAGEMENT MODULE
================================================================================

1. BROWSING TRANSACTION HISTORY
--------------------------------------------------------------------------------
  • Select the 'From' and 'To' date range, then click 'Filter'.
  • View all transactions with Sale ID, Date & Time, Cashier, Total, Discount, Net, and Status.

2. VIEWING LINE ITEMS
--------------------------------------------------------------------------------
  • Click any sale row to display the detailed itemized list in the bottom panel.

3. RE-PRINTING PAST RECEIPTS
--------------------------------------------------------------------------------
  • Select any past sale, then click '🖶 Print Receipt' in the top toolbar.
  • The receipt opens in Chrome ready to print or save to PDF.

4. VOIDING A SALE (Admin Only)
--------------------------------------------------------------------------------
  • Select the transaction and click 'Void Sale'.
  • Confirming the prompt marks the transaction as Voided and automatically restores
    all item quantities back into the inventory stock."

        ' Suppliers & Categories
        txtSuppliersCategories.Text =
"================================================================================
  SUPPLIERS & CATEGORIES MANAGEMENT MODULE
================================================================================

1. CATEGORIES MANAGEMENT
--------------------------------------------------------------------------------
  • Add Category: Enter category name and default measurement unit (pcs, box, kg, etc.).
  • Update / Delete: Select category from table to edit name or delete.
  • Used for classifying items and auto-populating units during product creation.

2. SUPPLIERS MANAGEMENT
--------------------------------------------------------------------------------
  • Record supplier name, contact person, phone number, email, and address.
  • Suppliers are linked with products for seamless purchase and stock receiving."

        ' Reports
        txtReports.Text =
"================================================================================
  REPORTS & ANALYTICS MODULE
================================================================================

1. SALES REPORT
--------------------------------------------------------------------------------
  • Filter by date range to calculate Total Gross Revenue, Total Discounts, Net Revenue,
    and Completed Transactions.
  • View breakdown by date and cashier.

2. INVENTORY STATUS REPORT
--------------------------------------------------------------------------------
  • Complete valuation of on-hand inventory (Total Stock Value = StockQty * UnitPrice).
  • Highlights low stock and out-of-stock items needing immediate purchase orders.

3. TOP SELLING PRODUCTS REPORT
--------------------------------------------------------------------------------
  • Identifies fastest-moving products by quantity sold and revenue generated.

4. EXPORT OPTIONS
--------------------------------------------------------------------------------
  • Export to CSV: Opens in Microsoft Excel for further analysis.
  • Print / PDF: Generates printable summary tables."

        ' Settings & Security
        txtSettings.Text =
"================================================================================
  SETTINGS & ACCOUNT SECURITY MODULE
================================================================================

1. USER MANAGEMENT (Administrator Only)
--------------------------------------------------------------------------------
  • Add New User: Enter username, secure password (min 6 chars), and assign Role (Admin/Staff).
  • Change Password: Reset password for any user account.
  • Delete User: Remove user accounts (protects deleting the currently active user).

2. MY SECURITY QUESTION (All Users)
--------------------------------------------------------------------------------
  • Self-service password recovery setup.
  • Choose a secret question (e.g. 'What is your mother''s maiden name?') and provide an answer.
  • Used on the Login screen via 'Forgot Password?' to securely reset passwords."
    End Sub

End Class
