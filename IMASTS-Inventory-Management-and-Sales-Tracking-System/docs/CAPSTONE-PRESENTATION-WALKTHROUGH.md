# IMASTS — Capstone Defense Presentation Walkthrough & Panelist Demonstration Guide
<!-- System: Inventory Management and Sales Tracking System (IMASTS) -->
<!-- Platform: Windows Desktop · VB.NET · Windows Forms · .NET 8.0 · Microsoft SQL Server -->
<!-- Target Audience: Capstone Defense Panelists, Advisers, Deans, and Technical Evaluators -->

---

## 🧭 Executive Summary & Timing Strategy

| Phase | Section | Recommended Duration | Primary Interface / Code Link |
| :--- | :--- | :--- | :--- |
| **Phase 1** | Project Rationale, Business Problem Statement & Retail Context | 1.5 mins | Title Slide / [`frmLogin.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmLogin.vb) |
| **Phase 2** | Technical Architecture, 3-Tier Repository Pattern & Database Baseline | 1.5 mins | [`ProjectPlan.md`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/docs/ProjectPlan.md) / [`DBConnectionPattern.md`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/docs/DBConnectionPattern.md) |
| **Phase 3** | Secure Authentication, Lockout Protection & Security Question Wizard | 1.0 min | [`frmLogin.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmLogin.vb) & [`frmForgotPassword.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmForgotPassword.vb) |
| **Phase 4** | Executive Dashboard & Real-Time GDI+ Business Intelligence Charts | 1.5 mins | [`frmDashboard.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmDashboard.vb) |
| **Phase 5** | Product Catalog Management, Barcode Generation & Pricing Engine | 1.5 mins | [`frmProducts.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmProducts.vb) |
| **Phase 6** | Inventory Stock Control, Visual Alerts (OK / Low / Out) & Receiving | 1.5 mins | [`frmInventory.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmInventory.vb) |
| **Phase 7** | Physical Audit Stock Adjustments & Transactional Write-Offs | 1.0 min | [`frmInventory.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmInventory.vb) |
| **Phase 8** | Point of Sale (POS) Checkout, Hardware Barcode Scanning & Stock Caps | 2.0 mins | [`frmNewSale.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmNewSale.vb) |
| **Phase 9** | Automated Thermal Receipt Generation & Chrome/PDF Print Pipeline | 1.0 min | [`ReceiptHelper.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Helpers/ReceiptHelper.vb) |
| **Phase 10** | Sales Audit Trail, Line-Item Breakdown & Receipt Re-printing | 1.0 min | [`frmSalesHistory.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmSalesHistory.vb) |
| **Phase 11** | Administrative Transaction Voiding & ACID Inventory Rollback | 1.0 min | [`frmSalesHistory.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmSalesHistory.vb) & [`SaleRepository.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/DataAccess/SaleRepository.vb) |
| **Phase 12** | Supplier Directory & Product Category Classification | 0.5 min | [`frmSuppliers.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmSuppliers.vb) & [`frmCategories.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmCategories.vb) |
| **Phase 13** | Business Analytics, Inventory Valuation & Excel/CSV Export Engine | 1.5 mins | [`frmReports.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmReports.vb) |
| **Phase 14** | Role-Based Access Control, User Governance & System Preferences | 1.0 min | [`frmSettings.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmSettings.vb) |
| **Phase 15** | Embedded System Documentation Manual & Developer Team Credits | 0.5 min | [`frmSystemManual.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmSystemManual.vb) & [`frmDevelopers.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmDevelopers.vb) |
| **Phase 16** | Defensive Architecture Summary, Conclusion & Panel Defense Transition | 0.5 min | Concluding Remarks / Open Q&A |
| **Total** | **Full System Defense Presentation** | **~18.0 mins** | — |

---

## 🛠️ Pre-Defense Staging & Credentials Setup

Before stepping in front of the capstone panel, ensure the demonstration workstation is prepared:

1. **Database & Configuration Readiness**:
   * Verify SQL Server (Express or LocalDB) instance is running.
   * Confirm [`config.txt`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/config.txt) points to the target database:
     ```text
     Server=.\SQLEXPRESS;Database=IMASTS_DB;Trusted_Connection=True;TrustServerCertificate=True;
     ```
   * Ensure schema tables (`tbl_Users`, `tbl_Categories`, `tbl_Suppliers`, `tbl_Products`, `tbl_Sales`, `tbl_SaleItems`, `tbl_StockReceipts`, `tbl_ActivityLogs`) are initialized using [`docs/IMASTS_CreateTables.sql`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/docs/IMASTS_CreateTables.sql).
2. **Browser & Print Preview Tool**:
   * Google Chrome installed and set as accessible on the default system path.
   * Default thermal/standard printer or "Save as PDF" selected for receipt and report demonstrations.
3. **Hardware Barcode Setup**:
   * Have a USB/wireless handheld barcode scanner ready (or practice barcode keyboard entry: typing the code into the scan box and pressing Enter).
4. **Standard Demonstration Accounts**:
   * **Admin Account:** Username: `admin` | Password: `Admin@123` | Role: `Admin`
   * **Staff Account:** Username: `cashier1` | Password: `Staff@123` | Role: `Staff`
5. **Security Question Reset Staging**:
   * For the forgot-password test account, assign Question: *"What is the name of your first school?"* | Answer: *"sample"*.

### 👥 Seeded Demonstration Accounts

| # | Username | Password | Role | Security Question Configured | Access Scope |
| :- | :--- | :--- | :--- | :--- | :--- |
| 1 | **admin** | `Admin@123` | **Admin** | *"What was your favorite food as a child?"* (`pizza`) | Full Privileges (Settings, Void Sales, All Reports) |
| 2 | **cashier1** | `Staff@123` | **Staff** | *"What is the name of your first school?"* (`sample`) | POS Sales, Stock Lookup, Receive Stock, Self-Service Security |
| 3 | **supervisor** | `Super@123` | **Admin** | *"What city were you born in?"* (`manila`) | Auxiliary Management & Audit Compliance |

### 📦 Seeded Demonstration Inventory Catalog

| Barcode | Product Name | Category | Supplier | Unit Price | Stock Qty | Reorder Lvl | Unit | Live Stock Status |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| `4800016644810` | **San Miguel Pale Pilsen 330ml** | Beverages | San Miguel Brewery | ₱65.00 | **120** | 24 | bottle | `OK` (In Stock) |
| `4800047820115` | **Lucky Me! Instant Pancit Canton Kalamansi** | Instant Food | Monde Nissin Corp | ₱16.50 | **8** | 20 | pack | `Low Stock` (Warning) |
| `4806511012345` | **Great Taste White Twin Pack 50g** | Beverages | Universal Robina Corp | ₱14.00 | **0** | 15 | pack | `Out of Stock` (Critical) |
| `7480112233445` | **Purefoods Corned Beef 150g** | Canned Goods | San Miguel Foods | ₱85.00 | **45** | 10 | can | `OK` (In Stock) |
| `4807770270016` | **Silver Swan Soy Sauce 1L** | Condiments | NutriAsia Inc | ₱52.00 | **5** | 12 | bottle | `Low Stock` (Warning) |
| `8901030381014` | **Surf Powder Sun Fresh 1kg** | Household | Unilever Philippines | ₱125.00 | **22** | 8 | pack | `OK` (In Stock) |

---

## 🎬 Step-by-Step Presentation Script (From First to Last)

---

### Step 1: Project Rationale, Business Problem Statement & Retail Context
* **Screen Display:** Login Screen — [`frmLogin.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmLogin.vb)
* **Estimated Time:** 1.5 minutes
* **Screen Action:** Launch the application; show the login window with professional navy branding, masked password inputs, and clean interface hierarchy.
* **🗣️ Verbal Script:**
  > *"Good morning, distinguished members of the defense panel, technical evaluators, and project advisers. We are pleased to present **IMASTS — the Inventory Management and Sales Tracking System**.
  >
  > *In today's retail and wholesale retail environment, small to medium enterprises (SMEs) face severe operational bottlenecks: manual stock keeping on paper ledgers or static spreadsheets, slow customer checkout queues during peak retail hours, unexpected stock-outs due to lack of real-time replenishment alerts, and unauthorized shrinkage or discrepancies in cash reconciliation.
  >
  > *Generic off-the-shelf software often burdens local business owners with recurring cloud subscriptions, internet dependency, complex configurations, or inadequate hardware integration for barcode scanners and receipt printers.
  >
  > *IMASTS was purpose-built as an enterprise-grade, high-performance desktop system that bridges this gap. It provides real-time stock tracking, lightning-fast barcode POS transactions, automated thermal receipt generation, role-based governance, and instant management analytics — operating reliably 100% offline on local enterprise database architecture."*

---

### Step 2: Technical Architecture, 3-Tier Repository Pattern & Database Baseline
* **Screen Display:** Technical Architecture Slide or [`ProjectPlan.md`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/docs/ProjectPlan.md) / [`DBConnectionPattern.md`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/docs/DBConnectionPattern.md)
* **Estimated Time:** 1.5 minutes
* **Screen Action:** Highlight the clean separation of concerns and architectural diagram.
* **🗣️ Verbal Script:**
  > *"Before diving into the operational workflows, let us review the technical engineering foundation of IMASTS:
  >
  > 1. **Modern .NET 8.0 Windows Forms Runtime:** Built with Visual Basic .NET on .NET 8.0, delivering responsive native desktop execution with compiled performance and zero browser lag.
  > 2. **Strict 3-Tier Separation of Concerns:** Following our `DBConnectionPattern.md` engineering standard, **zero SQL queries reside inside forms or panels**. All data transactions are encapsulated inside dedicated repository classes within the [`DataAccess/`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/DataAccess/) namespace (`UserRepository`, `ProductRepository`, `InventoryRepository`, `SaleRepository`, `DashboardRepository`, and `ReportRepository`).
  > 3. **ACID Transaction Guarantees:** Multi-step financial and inventory operations — such as completing a sale, receiving stock, or voiding an invoice — are wrapped in strict SQL Server transactions (`conn.BeginTransaction()`). If any single line item fails, the entire transaction rolls back cleanly, guaranteeing zero orphaned rows or inventory drift.
  > 4. **Defensive Data Security:** Passwords and security recovery answers are hashed using industry-standard **BCrypt (`BCrypt.Net-Next`)** with randomized cryptographic salts. All SQL calls strictly use parameterized `SqlCommand` objects, rendering SQL injection impossible.
  > 5. **Decoupled Configuration Management:** Database connectivity is dynamically resolved via [`dbconstring.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Helpers/dbconstring.vb) reading an external `config.txt` file, allowing seamless portability between LocalDB, SQL Server Express, and network-hosted database instances without code recompilation."*

---

### Step 3: Secure Authentication, Lockout Protection & Security Question Wizard
* **Screen Display:** [`frmLogin.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmLogin.vb) & [`frmForgotPassword.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmForgotPassword.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Demonstrate the login validation by intentionally typing an incorrect password to trigger the attempt counter (*"Invalid username or password. 2 attempt(s) left."*).
  2. Highlight the automatic lockout timer (`tmrLockout`) enforcing temporary account lock after 3 consecutive failed attempts to thwart brute-force attacks.
  3. Click **"Forgot Password?"** to launch `frmForgotPassword.vb`.
  4. Walk through the **3-Step Recovery Wizard**:
     * **Step 1:** Enter username (`cashier1`) and click **"Find Account"**.
     * **Step 2:** Point out that the system **deliberately does not reveal** which question was chosen. The user must actively select their registered question from the dropdown and supply the matching answer, neutralizing shoulder-surfing and social engineering.
     * **Step 3:** Enter and confirm the new password (enforcing minimum 6 characters), updating the BCrypt hash.
  5. Return to `frmLogin.vb`, sign in with `admin` / `Admin@123`, and press Enter.
* **🗣️ Verbal Script:**
  > *"Access to IMASTS begins at our defense-in-depth Authentication Gateway. The system enforces sanitized input handling, masked passwords with toggle visibility, and an automated brute-force lockout mechanism after 3 failed attempts.
  >
  > *For password recovery, we implemented a privacy-preserving 3-step security question wizard. Unlike standard systems that reveal the stored question on screen, IMASTS forces the applicant to pick their question from our institutional list and verify the answer against a BCrypt hash before permitting a reset.
  >
  > *Every successful login or failed attempt is recorded in `tbl_ActivityLogs`. Now, let us log in as Administrator."*

---

### Step 4: Executive Dashboard & Real-Time GDI+ Business Intelligence Charts
* **Screen Display:** Main Shell — [`frmMain.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmMain.vb) & [`frmDashboard.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmDashboard.vb)
* **Estimated Time:** 1.5 minutes
* **Screen Action:**
  1. Highlight the MDI parent navigation shell with user badge, role display, live clock, and navy visual identity.
  2. Review the top **KPI Metric Cards**: *Total Products*, *Low Stock Items*, *Today's Sales Count*, and *Today's Revenue (₱)*.
  3. Showcase the 3 custom **GDI+ interactive graphics**:
     * **Sales Trend (7-Day Line Chart):** Hover cursor over data points on `pnlTrendCanvas` to demonstrate dynamic tooltips showing exact day and revenue.
     * **Sales by Category (Pie Chart):** Hover over pie slices and color-coded legend rectangles on `pnlCategoryCanvas` to demonstrate category revenue percentages.
     * **Top 5 Selling Products (Bar Chart):** Hover over horizontal bars on `pnlTopProductsCanvas` to inspect revenue and unit volume for top performers.
* **🗣️ Verbal Script:**
  > *"Upon authentication, the administrator is greeted by the Executive Dashboard. Rather than relying on external web chart dependencies, our dashboard is powered by a high-performance **native GDI+ rendering engine** (`System.Drawing.Drawing2D`) with double-buffering.
  >
  > *At a glance, management observes live inventory health and fiscal KPIs. Hovering over the Sales Trend reveals daily revenue curves, the Category Breakdown displays product diversity, and the Top 5 Bar Chart identifies high-velocity products driving store profitability.
  >
  > *Notice that whenever sales or inventory adjustments occur, this dashboard aggregates real-time data directly from `DashboardRepository` without latency."*

---

### Step 5: Product Catalog Management, Barcode Generation & Pricing Engine
* **Screen Display:** [`frmProducts.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmProducts.vb)
* **Estimated Time:** 1.5 minutes
* **Screen Action:**
  1. Click **"Products"** in the sidebar navigation.
  2. Demonstrate the live search/filter bar: type `Pancit` or scan a barcode to immediately isolate the matching row in the grid.
  3. Demonstrate the **"Add Product"** workflow:
     * Click the **[Gen]** button beside the Barcode field to auto-generate a unique 13-digit retail barcode string.
     * Enter Product Name (e.g., *Nissin Cup Noodles Seafood 60g*).
     * Select Category (*Instant Food*) and Supplier (*Monde Nissin Corp*).
     * Set Unit Price (`₱32.00`), Initial Stock (`50`), Unit (`cup`), and Reorder Level (`15`).
     * Click **"Add"** to persist to `tbl_Products`.
  4. Select an existing product from the table, modify its Unit Price or Reorder Level, and click **"Update"**.
  5. Address audit protection: explain why products with historical transactions are protected against accidental hard deletion.
* **🗣️ Verbal Script:**
  > *"The Product Management module acts as the master catalog for the enterprise.
  >
  > *Products are mapped to standardized categories and trusted suppliers. For items without manufacturer UPC codes, our built-in **[Gen] Barcode Generator** automatically generates compliant identifiers.
  >
  > *Critical business rules are strictly enforced here: Unit Prices and Reorder Levels are validated against negative values, and products tied to past sales invoices or stock receipts are protected by referential integrity to prevent historical financial corruption."*

---

### Step 6: Inventory Stock Control, Visual Alerts (OK / Low / Out) & Receiving
* **Screen Display:** [`frmInventory.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmInventory.vb)
* **Estimated Time:** 1.5 minutes
* **Screen Action:**
  1. Navigate to **"Inventory"**.
  2. Point out the color-coded inventory data grid:
     * **Red Rows:** `Out of Stock` (0 units remaining, e.g., *Great Taste White Twin Pack*).
     * **Amber/Yellow Rows:** `Low Stock` (StockQty ≤ ReorderLevel, e.g., *Lucky Me! Instant Pancit Canton*).
     * **Standard Rows:** `OK` (Healthy stock buffer).
  3. Filter inventory using the Category sidebar list (e.g., click *Beverages* or *Instant Food*).
  4. Execute a **Stock Receiving (+ Receive Stock)** operation:
     * Select *Great Taste White Twin Pack* (currently 0 units / Out of Stock).
     * Select Supplier (*Universal Robina Corp*).
     * Enter Quantity to Receive: `100` units.
     * Enter Delivery Notes: `Delivery DR #55491 - Restock Batch A`.
     * Click **"+ Receive Stock"** and confirm.
     * Watch the grid instantly update: stock becomes 100, the status badge flips from red `Out of Stock` to green `OK`, and a permanent audit record is committed to `tbl_StockReceipts`.
* **🗣️ Verbal Script:**
  > *"In the Inventory Management module, warehouse clerks and store supervisors maintain absolute stock visibility.
  >
  > *Our color-coded visual alert engine automatically flags depleted and vulnerable inventory based on configurable reorder thresholds.
  >
  > *When vendor deliveries arrive, the clerk uses '+ Receive Stock'. In a single atomic transaction, the stock level increments immediately, and a detailed audit entry recording the supplier ID, delivery receipt notes, timestamp, and quantity is logged in `tbl_StockReceipts` for supplier reconciliation."*

---

### Step 7: Physical Audit Stock Adjustments & Transactional Write-Offs
* **Screen Display:** [`frmInventory.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmInventory.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Select a product for audit reconciliation (e.g., *San Miguel Pale Pilsen 330ml*, current stock: 120).
  2. In the stock control editor, select **"✎ Adjust Stock"**.
  3. Enter New Stock Quantity: `118`.
  4. Provide adjustment rationale in notes: `Physical cycle count discrepancy: 2 bottles broken in transit`.
  5. Click **"✎ Adjust Stock"** and confirm.
  6. Explain how this updates the exact ledger balance and creates an audit entry in `tbl_ActivityLogs`.
* **🗣️ Verbal Script:**
  > *"Every retail business faces real-world variances: expired goods, breakage, or physical inventory audit discrepancies.
  >
  > *The 'Adjust Stock' function allows authorized managers to calibrate the system stock to the exact physical shelf count. Instead of creating fake sales or undocumented deductions, every adjustment requires explicit confirmation and logs an immutable audit trail in `tbl_ActivityLogs` with the operator's username and rationale."*

---

### Step 8: Point of Sale (POS) Checkout, Hardware Barcode Scanning & Stock Caps
* **Screen Display:** [`frmNewSale.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmNewSale.vb)
* **Estimated Time:** 2.0 minutes
* **Screen Action:**
  1. Navigate to **"New Sale"**.
  2. Point out that focus is automatically set to the `txtScanBarcode` input.
  3. **Simulate/Execute Barcode Scanning**:
     * Scan or type `4800016644810` (San Miguel Pale Pilsen) and press Enter.
     * Show how it instantly adds 1 unit to the cart, recalculates subtotal, plays an audible confirmation tone (`SystemSounds.Asterisk`), and keeps focus ready for the next item.
     * Scan the same barcode a second time: show quantity automatically incrementing from 1 to 2, with subtotal updating in real time.
  4. **Stock Limit Validation Defense**:
     * Try adding a quantity that exceeds available inventory (e.g., attempt to add 20 units of an item with only 5 in stock).
     * Show how the POS blocks the addition, plays a warning sound, and alerts: *"✗ Stock limit: Only 5 left"*, preventing overselling.
  5. Add an item manually using the product dropdown to show dual-entry flexibility.
  6. **Discount Calculation**:
     * Enter a promotional or senior discount of `₱10.00` in `txtDiscount`.
     * Demonstrate how Net Total dynamically recalculates (`TotalAmount - Discount = NetAmount`).
  7. Click **"Confirm Sale"**:
     * Explain that the backend opens an ACID transaction, creates the invoice in `tbl_Sales`, writes every item to `tbl_SaleItems`, deducts stock from `tbl_Products`, and prompts for receipt printing.
* **🗣️ Verbal Script:**
  > *"Now entering the heartbeat of daily retail operations: the Point of Sale module.
  >
  > *Our POS is engineered for high-throughput retail checkout. It supports standard hardware USB and wireless barcode scanners operating in keyboard-wedge mode. Scanning an item adds it to the cart in milliseconds with audible operator feedback and automatically keeps the scan cursor active.
  >
  > *Crucially, IMASTS prevents accidental overselling. The system checks on-hand inventory before permitting any item into the cart.
  >
  > *Discounts are computed live. When the cashier clicks 'Confirm Sale', our backend executes an atomic transaction: the sale header is generated, line items are logged, stock quantities are subtracted simultaneously, and an automated prompt offers instant receipt printing."*

---

### Step 9: Automated Thermal Receipt Generation & Chrome/PDF Print Pipeline
* **Screen Display:** Print Preview Window launched by [`ReceiptHelper.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Helpers/ReceiptHelper.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Click **"Yes"** on the completion prompt (or click **"🖶 Print Receipt"**).
  2. Showcase the responsive, standalone receipt rendered via Google Chrome:
     * Company Name / System Logo (dynamically extracted and embedded as clean Base64).
     * Official Receipt Control Number (e.g., `#000042`).
     * Cashier Username, Date, and Timestamp.
     * Itemized table with Product Names, Quantities, Unit Prices, and Line Subtotals.
     * Subtotal, Applied Discount, and Grand Net Total.
     * Formatted barcode mock footer and customer thank-you message.
  3. Explain the CSS print media query (`@media print`) pre-configured for standard **80mm thermal receipt printers** and PDF export.
* **🗣️ Verbal Script:**
  > *"Rather than forcing business owners to purchase expensive proprietary report-printing components, IMASTS employs a lightweight, modern **HTML5/CSS print pipeline** via `ReceiptHelper`.
  >
  > *The system compiles a standalone, beautifully styled thermal receipt formatted specifically for standard 80mm point-of-sale thermal printers. The application logo is converted into Base64 inline data, meaning the receipt is 100% self-contained and renders identically on any machine.
  >
  > *It opens Google Chrome in application mode with automated print triggering (`window.print()`), enabling immediate physical thermal printing or archiving to digital PDF with a single keystroke."*

---

### Step 10: Sales Audit Trail, Line-Item Breakdown & Receipt Re-printing
* **Screen Display:** [`frmSalesHistory.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmSalesHistory.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Navigate to **"Sales History"**.
  2. Filter by Date Range (From / To pickers) and click **"Filter"**.
  3. Point out the live **Grand Total summary tile** displaying net active sales volume.
  4. Select a transaction row in the top grid:
     * Show how the bottom pane (`dgvSaleItems`) instantly loads the itemized line items, unit prices, and quantities for that exact invoice.
  5. Click **"🖶 Print Receipt"** from the Sales History toolbar to prove that past receipts can be reprinted at any future date with complete audit fidelity.
* **🗣️ Verbal Script:**
  > *"Under Sales History, management and cashiers review full transaction records.
  >
  > *Selecting any past invoice immediately displays its exact line-item composition in the lower audit pane.
  >
  > *If a customer returns requesting a replacement receipt, the cashier can click 'Print Receipt' at any time to regenerate an exact duplicate voucher."*

---

### Step 11: Administrative Transaction Voiding & ACID Inventory Rollback
* **Screen Display:** [`frmSalesHistory.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmSalesHistory.vb) & [`SaleRepository.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/DataAccess/SaleRepository.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Point out that the **"Void Sale"** button is visible exclusively to users with the `Admin` role. (If logged in as Staff, the button is hidden).
  2. Select the sale created in Step 8.
  3. Click **"Void Sale"** and review the confirmation dialog: *"Void Sale #X? This will restore stock for all line items."*
  4. Click **"Yes"**:
     * Notice the transaction row immediately turns grey with status `Voided`.
     * The Grand Total revenue card automatically deducts the voided amount so revenue metrics remain mathematically honest.
  5. Return to `frmInventory.vb` or `frmProducts.vb` to verify that the items sold in that invoice were automatically restored back to stock inventory!
* **🗣️ Verbal Script:**
  > *"Handling customer cancellations or cashier errors requires strict financial controls.
  >
  > *In IMASTS, transaction voiding is restricted exclusively to Administrators. When an invoice is voided, `SaleRepository.VoidSale` executes an atomic rollback: each purchased item quantity is added back into `tbl_Products`, the invoice is marked `IsVoided = 1`, and the event is recorded in the activity log.
  >
  > *The transaction is never hard-deleted; it is preserved as an audit artifact to ensure that dishonest staff cannot erase sales records to pocket cash."*

---

### Step 12: Supplier Directory & Product Category Classification
* **Screen Display:** [`frmSuppliers.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmSuppliers.vb) & [`frmCategories.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmCategories.vb)
* **Estimated Time:** 0.5 minute
* **Screen Action:**
  1. Briefly open **Suppliers**: showcase directory fields (Company Name, Contact Person, Phone, Email, Address) used for restocking purchase orders.
  2. Briefly open **Categories**: showcase category nomenclature and default measurement units (pcs, box, kg, pack, bottle, can).
* **🗣️ Verbal Script:**
  > *"The Suppliers and Categories modules provide organized relational structure to our inventory catalog.
  >
  > *Suppliers maintain comprehensive contact profiles for procurement, while categories standardize product classifications and default units of measure across the enterprise."*

---

### Step 13: Business Analytics, Inventory Valuation & Excel/CSV Export Engine
* **Screen Display:** [`frmReports.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmReports.vb)
* **Estimated Time:** 1.5 minutes
* **Screen Action:**
  1. Navigate to **"Reports"**.
  2. **Tab 1: Inventory Status & Valuation**:
     * Show total catalog count and real-time category filtering.
     * Click **"🖶 Print Inventory"** to preview the print-ready institutional inventory audit report with color status badges.
     * Click **"Export to Excel"** to demonstrate CSV / Excel XML generation via [`InventoryExportHelper.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Helpers/InventoryExportHelper.vb). Open the generated `.csv` spreadsheet to show clean headers and formatting.
  3. **Tab 2: Sales Summary & Top Products**:
     * Select a date range and click **"Generate"**.
     * Inspect key aggregate metrics: *Total Sales Count*, *Total Gross Revenue*, and *Average Transaction Value*.
     * Review the **Top 5 Selling Products** ranking table.
     * Click **"Print Summary"** and **"Export CSV"** to demonstrate executive sales reporting.
* **🗣️ Verbal Script:**
  > *"For end-of-month accounting, tax preparation, and business intelligence, IMASTS features an advanced Reporting & Export Engine.
  >
  > *The Inventory Status report computes total stock availability, highlighting critical shortage areas. With one click, managers can export the complete catalog into standard CSV or Excel-compatible XML spreadsheets for accounting integration.
  >
  > *The Sales Summary report computes gross revenue, discounts, and average customer basket value, alongside top-performing products. All reports include standardized print layouts ready for administrative signatures."*

---

### Step 14: Role-Based Access Control, User Governance & System Preferences
* **Screen Display:** [`frmSettings.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmSettings.vb)
* **Estimated Time:** 1.0 minute
* **Screen Action:**
  1. Open **"Settings"** as Admin:
     * **Tab 1: User Management (Admin Only)** — Show registered users list. Point out the safety guard: the currently logged-in account cannot be deleted (`btnDeleteUser` disabled when self is selected).
     * Demonstrate adding a new Staff account with validated password requirements.
     * **Tab 2: System Preferences (Admin Only)** — Show customization fields: `Company Name` and `Currency Symbol` (e.g., changing from `₱` to `$`), which immediately update all printed receipts and reports via [`SettingsManager.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Helpers/SettingsManager.vb).
     * **Tab 3: My Security Question (Self-Service)** — Show how any logged-in user can update their secret question and answer hash.
  2. Briefly demonstrate role security: if a Staff user logs in, Tabs 1 and 2 are hidden, allowing Staff to access only their personal security settings.
* **🗣️ Verbal Script:**
  > *"In System Settings, administrators govern user access and institutional branding.
  >
  > *Role-based permissions strictly partition capabilities: Staff can only perform sales and stock receiving, while Administrators maintain user accounts, alter system preferences, and void transactions.
  >
  > *To prevent administrative lockout, the system prevents users from deleting their own active profile. Through `SettingsManager`, store owners can tailor their business name and currency symbol without touching source code."*

---

### Step 15: Embedded System Documentation Manual & Developer Team Credits
* **Screen Display:** [`frmSystemManual.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmSystemManual.vb) & [`frmDevelopers.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmDevelopers.vb)
* **Estimated Time:** 0.5 minute
* **Screen Action:**
  1. Click **"System Manual"**: showcase the comprehensive, embedded RichText user guide organized across 8 modular tabs (Overview, Products, Inventory, New Sale, Sales History, Suppliers/Categories, Reports, Settings).
  2. Click **"Developers"**: display the developer attribution card detailing project architecture, core responsibilities, tech stack, and version release (`v5.06`).
* **🗣️ Verbal Script:**
  > *"To ensure seamless user onboarding and training without requiring printed physical manuals, IMASTS embeds an interactive, 8-chapter System Manual directly inside the application.
  >
  > *Finally, our Developers module provides official project attribution, detailing system versioning and architecture credits."*

---

### Step 16: Defensive Architecture Summary, Conclusion & Panel Defense Transition
* **Screen Display:** Dashboard or Title Screen
* **Estimated Time:** 0.5 minute
* **Screen Action:** Present concluding summary slide and address the panel directly.
* **🗣️ Verbal Script:**
  > *"In conclusion, IMASTS delivers an integrated, dependable, and highly secure retail management platform. By marrying the speed of native .NET desktop architecture with the reliability of Microsoft SQL Server transactions and modern HTML5 thermal printing, IMASTS eliminates retail bottlenecks, prevents inventory shrinkage, and provides business owners with real-time financial control.
  >
  > *Honorable members of the panel, we thank you for your time and expertise, and we are now ready to answer your questions."*

---

## 🛡️ Capstone Defense Panelist Q&A Cheat Sheet

| # | Panelist Question | Recommended Technical & Architectural Answer |
| :- | :--- | :--- |
| **Q1** | **Why choose a Windows Forms desktop application over a web-based or mobile application for inventory and sales?** | *"Retail point-of-sale environments demand **zero-latency execution, hardware-level peripheral integration, and 100% offline survivability**. Web applications suffer when internet connections fluctuate, and browser sandboxes introduce friction when communicating directly with local USB barcode scanners and thermal receipt printers. A compiled .NET 8.0 desktop client interacting directly with a local or LAN-hosted SQL Server database guarantees that the cashier can scan items and print receipts without experiencing browser latency, page reloads, or external downtime."* |
| **Q2** | **How does the system ensure ACID transaction compliance when confirming a sale? What happens if power is cut during checkout?** | *"In [`SaleRepository.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/DataAccess/SaleRepository.vb), sale processing is enclosed within an **explicit SQL Server transaction** (`conn.BeginTransaction()`). In this atomic block, the system executes three steps: (1) Inserts the invoice into `tbl_Sales` and retrieves `SCOPE_IDENTITY()`; (2) Iterates through every cart item to insert into `tbl_SaleItems`; and (3) Executes an atomic decrement on `tbl_Products`: `UPDATE tbl_Products SET StockQty = StockQty - @Qty WHERE ProductID = @ProductID`. If power fails or an error occurs on item 5 of 10, `tran.Rollback()` triggers automatically. The database remains in a consistent state — no partial sales, no ghost deductions, and no orphaned line items."* |
| **Q3** | **How does the POS interface handle barcode scanners without requiring third-party drivers or proprietary vendor SDKs?** | *"Standard retail handheld barcode scanners (such as Honeywell, Zebra, or Datalogic) function as **Human Interface Devices (HID) utilizing keyboard wedge emulation**. When a barcode is scanned, the device transmits the ASCII characters followed by a terminating carriage return (`Keys.Enter`). In [`frmNewSale.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmNewSale.vb), our `txtScanBarcode_KeyDown` handler captures `Keys.Enter`, suppresses the key press, queries the pre-loaded in-memory product cache by barcode or numeric ID, performs instantaneous stock validation, adds the item to the cart, and retains input focus. This enables plug-and-play compatibility with virtually any barcode scanner on the market."* |
| **Q4** | **Why does the system open Google Chrome for receipt printing rather than using Crystal Reports, Microsoft Report Viewer (RDLC), or Windows PrintDocument?** | *"Legacy reporting frameworks like Crystal Reports or RDLC require heavy runtime redistributables (.msi packages), frequently fail during Windows updates, and present severe formatting quirks across different printer driver margins. In [`ReceiptHelper.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Helpers/ReceiptHelper.vb), we generate a lightweight, standard **HTML5/CSS print document** with inline Base64 branding and an `@media print` rule configured for standard 80mm thermal paper. We launch Chrome in application mode (`--app=file:///...`) with automated print triggering (`window.print()`). This ensures pixel-perfect receipts, zero external runtime dependencies, built-in PDF saving, and universal thermal printer support."* |
| **Q5** | **How does the system prevent SQL injection and cross-site tampering?** | *"We maintain a zero-tolerance policy against dynamic string concatenation in SQL. Across all repository classes in [`DataAccess/`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/DataAccess/), 100% of SQL commands are constructed with **parameterized queries** (`cmd.Parameters.AddWithValue(...)`). Furthermore, all user inputs pass through [`InputHelper.SanitizeInput`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Helpers/InputHelper.vb) to strip dangerous characters. Database operations are strictly partitioned behind repository abstractions, preventing presentation forms from directly manipulating database connections."* |
| **Q6** | **Explain the security design behind your Forgot Password mechanism. Why is the security question not pre-filled when a username is entered?** | *"In [`frmForgotPassword.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmForgotPassword.vb), we intentionally designed a **zero-knowledge question selection protocol**. In common flawed implementations, typing an admin's username reveals their question (e.g., 'What is your mother's maiden name?'), which allows attackers to conduct social engineering attacks. In IMASTS, the user must independently pick the matching question from our fixed dropdown and supply the answer. The entered answer is trimmed, lowercased, and verified against the stored **BCrypt hash** (`SecurityAnswerHash`). The plain-text answer is never stored in the database."* |
| **Q7** | **What prevents a dishonest cashier from selling items, printing the receipt, collecting cash, and then voiding the transaction to steal money?** | *"We enforce strict role-based segregation and immutable auditing. First, the **'Void Sale' capability is restricted exclusively to Administrators**; the button is completely invisible to Staff accounts in [`frmSalesHistory.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmSalesHistory.vb). Second, when an Administrator voids a transaction, the record is **never deleted**; its status flips to `IsVoided = 1`, and an immutable entry is recorded in `tbl_ActivityLogs` with the supervisor's username, timestamp, and transaction ID. During daily register reconciliation, any voided invoice must match physical un-sold stock or management write-off slips."* |
| **Q8** | **How are stock quantities prevented from dropping into negative numbers?** | *"Protection is enforced on two levels: (1) **Presentation Guard in POS:** In [`frmNewSale.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmNewSale.vb), before an item is added to the cart, the system checks `cartQty + requestedQty > stockQty`. If the cart exceeds available stock, the system refuses the addition and triggers an audible error alert; (2) **Database Integrity:** In `tbl_Products`, stock adjustments and sale deductions are constrained to valid inventory amounts. During receiving and adjustments, quantities are validated as positive whole numbers."* |
| **Q9** | **How does the system calculate Inventory Valuation and Average Basket Value in reports?** | *"In [`ReportRepository.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/DataAccess/ReportRepository.vb), inventory valuation is derived by querying the active catalog and computing the sum of `(StockQty * UnitPrice)` across all active items. For sales analytics, the system calculates `COUNT(*)` for total transaction volume, `SUM(NetAmount)` for total net revenue, and `AVG(NetAmount)` for the average customer spend, excluding voided transactions (`WHERE IsVoided = 0`)."* |
| **Q10** | **Why did you use GDI+ for charts in the Dashboard rather than third-party controls or web embeds?** | *"Many external chart packages (such as LiveCharts or web browser wrappers) introduce substantial binary overhead, dependency conflicts, or rendering latency on older Windows hardware. By writing custom GDI+ drawing routines (`System.Drawing.Drawing2D`) in [`frmDashboard.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Forms/frmDashboard.vb), we achieved **instantaneous 60fps chart rendering**, zero external DLL dependencies, full color control matching our navy design system, and pixel-precise interactive hover tooltips with double-buffering."* |
| **Q11** | **Can this system be deployed across multiple cashier terminals connecting to a central database?** | *"Yes. Because database connectivity is abstracted inside [`dbconstring.vb`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/Helpers/dbconstring.vb) via [`config.txt`](file:///C:/Users/GLENN/source/repos/IMASTS-Inventory-Management-and-Sales-Tracking-System/IMASTS-Inventory-Management-and-Sales-Tracking-System/config.txt), deploying multiple POS terminals requires simply changing the `Server=` parameter in `config.txt` to point to the central SQL Server IP address (e.g., `Server=192.168.1.100\SQLEXPRESS;Database=IMASTS_DB;...`). SQL Server handles multi-user row-level locking and transaction isolation out of the box."* |
| **Q12** | **What are the future enhancements planned for IMASTS?** | *"Our architectural roadmap includes: (1) **Customer Loyalty Management:** Tracking customer purchase history and loyalty reward points; (2) **Automated Low-Stock Email/SMS Alerts:** Dispatching automatic SMS notifications to procurement officers when stock reaches reorder levels; (3) **Multi-Branch Warehouse Synchronization:** Replicating inventory databases across multiple geographic branch locations using SQL Server replication or secure REST sync."* |

---

## 💡 Pro-Tips for Defense Day

1. **The 'Live POS-to-Inventory' Demonstration Sequence**:
   * **Step A:** Open `frmInventory.vb` and point out *Great Taste White Twin Pack* at **0 units** (highlighted in red as `Out of Stock`).
   * **Step B:** Execute **+ Receive Stock** for **50 units**. Watch it flip to green `OK` with 50 units.
   * **Step C:** Open `frmNewSale.vb`, scan its barcode, sell **2 units**, and confirm the sale.
   * **Step D:** Click **Print Receipt** to display the generated thermal receipt in Google Chrome.
   * **Step E:** Return to `frmInventory.vb`: show the stock immediately decremented to **48 units**.
   * *Panelists love seeing this closed-loop transactional consistency across modules!*
2. **Barcode Scanner Preparation**:
   * If bringing a physical USB barcode scanner, test it beforehand on `txtScanBarcode`.
   * If presenting without a physical scanner, have the sample barcodes (`4800016644810`, `4800047820115`) written on a notepad or pre-copied so you can type or paste them and press Enter seamlessly.
3. **Showcase the Chrome Thermal Receipt & PDF Preview**:
   * Keep Chrome installed and ready. When the receipt launches, emphasize how cleanly the receipt scales to 80mm POS thermal width with the system logo, itemized rows, discounts, and barcode footer.
4. **Demonstrate Role Security Live**:
   * Show `frmSettings.vb` and `frmSalesHistory.vb` as **Admin**: point out full user management and the **Void Sale** button.
   * Log out and log in as **`cashier1` (Staff)**: show how user management is hidden and the **Void Sale** button is completely disabled. This provides proof of robust Role-Based Access Control (RBAC).
5. **Offline Independence**:
   * Make sure your local SQL Server instance is running. Reiterate to the panel that the entire demonstration is executing 100% offline, proving enterprise survivability during power or internet outages.
