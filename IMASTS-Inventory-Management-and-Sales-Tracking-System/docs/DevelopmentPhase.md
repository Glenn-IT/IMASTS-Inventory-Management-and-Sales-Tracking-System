```
╔══════════════════════════════════════════════════════════════════╗
║       IMASTS — Inventory Management and Sales Tracking System    ║
║                     DEVELOPMENT PHASE CHECKLIST                  ║
╚══════════════════════════════════════════════════════════════════╝
```

> Task-by-task · Page-by-page build checklist.
> Check off each item as you complete it. Work top to bottom — each phase depends on the one before it.

---

## PHASE 1 — Project Setup & Foundation

> Establish the base structure, NuGet packages, DB connection, and all helper modules before building any form.

### 1.1 — NuGet Packages
- [x] Install `Microsoft.Data.SqlClient` (v5.x)
- [x] Install `BCrypt.Net-Next`

### 1.2 — Database Connection Setup _(see DBConnectionPattern.md)_
- [x] Create `dbconstring.vb` in project root — reads `config.txt` at runtime
- [x] Create `config.txt.example` with connection string template
- [x] Confirm `config.txt` is listed in `.gitignore`
- [x] Create `config.txt` next to the `.exe` (`bin\Debug\net8.0-windows\`) with real connection string

### 1.3 — SQL Server Database
- [x] Create the SQL Server database (`IMASTS_DB`)
- [x] Create `tbl_Users` (UserID · Username · PasswordHash · UserType · CreatedAt)
- [x] Create `tbl_Categories` (CategoryID · CategoryName)
- [x] Create `tbl_Suppliers` (SupplierID · Name · ContactPerson · Phone · Email · Address)
- [x] Create `tbl_Products` (ProductID · Name · CategoryID · SupplierID · UnitPrice · StockQty · ReorderLevel)
- [x] Create `tbl_Sales` (SaleID · SaleDate · CashierID · TotalAmount · Discount · NetAmount · IsVoided)
- [x] Create `tbl_SaleItems` (SaleItemID · SaleID · ProductID · Quantity · UnitPrice · Subtotal)
- [x] Create `tbl_StockReceipts` (ReceiptID · ProductID · Quantity · ReceiptDate · SupplierID · Notes)
- [x] Create `tbl_ActivityLogs` (LogID · Username · LogDate · Result · Description)
- [x] Insert at least one Admin user row — seeded at end of Phase 2 (username: admin / password: Admin@123)

### 1.4 — Folder Structure
- [x] Create `DataAccess/` folder in project
- [x] Create `Helpers/` folder in project
- [x] Create `Forms/` folder (or keep flat — either way, consistent)

### 1.5 — Helper Modules
- [x] Create `Helpers/SessionManager.vb` — `Public Module` with `Username`, `UserType`, `UserCode`, `Clear()`
- [x] Create `Helpers/InputHelper.vb` — `SanitizeInput(text)` trims and strips `<>` and null bytes
- [x] Create `Helpers/PasswordHelper.vb` — `HashPassword(plain)` and `VerifyPassword(plain, hash)` using BCrypt
- [x] Create `Helpers/Constants.vb` — `Public Module Constants` for role strings, status values, etc.
- [x] Create `Helpers/ActivityLogger.vb` — delegates to `ActivityLogRepository`, swallows its own exceptions

### 1.6 — Base Repository Modules
- [x] Create `DataAccess/ActivityLogRepository.vb` — `Insert(username, result, description)`
- [x] Test: manually call `ActivityLogger.Log(...)` and confirm row appears in `tbl_ActivityLogs`

---

## PHASE 2 — Authentication · `frmLogin`

> First working form. Nothing else should be built until login works end-to-end.

### Page: `frmLogin`
- [x] Design login form layout
  - [x] `txtUsername` — username input
  - [x] `txtPassword` — password input (PasswordChar = `*`)
  - [x] `btnLogin` — login button
  - [x] `lblError` — error message label (hidden by default)
  - [x] `chkShowPassword` toggle
- [x] Create `DataAccess/UserRepository.vb`
  - [x] `GetByUsername(username As String) As DataTable`
- [x] Implement login logic in `btnLogin_Click`
  - [x] Sanitize inputs via `InputHelper.SanitizeInput`
  - [x] Fetch user row via `UserRepository.GetByUsername`
  - [x] Verify password via `PasswordHelper.VerifyPassword`
  - [x] On success: populate `SessionManager`, open `frmMain`, hide `frmLogin`
  - [x] On failure: show error message in `lblError`
- [x] Log activity: `ActivityLogger.Log(username, "Success"/"Failed", "...")`
- [x] Seed default Admin user in `tbl_Users` (username: `admin` / password: `Admin@123`)
- [x] Test: valid login opens `frmMain` ✓
- [x] Test: wrong password shows error and does not proceed ✓
- [x] Test: empty fields show validation message ✓

---

## PHASE 3 — Main Shell · `frmMain`

> The MDI parent that hosts all child forms and controls navigation.

### Page: `frmMain`
- [x] Set up `pnlContent` panel as child form host (replaced MDI)
- [x] Design sidebar or top menu navigation
  - [x] Dashboard link
  - [x] Products link
  - [x] Inventory link
  - [x] Sales link (New Sale · Sales History)
  - [x] Suppliers link
  - [x] Categories link
  - [x] Reports link
  - [x] Settings link (Admin only)
  - [x] Logout button
- [x] Apply role-based visibility on form load
  - [x] Hide Settings menu item if `SessionManager.UserType <> "Admin"`
- [x] Add status bar: current user, role, date/time
- [x] Implement logout: call `SessionManager.Clear()`, close `frmMain`, show `frmLogin`
- [x] Open Dashboard as default child form on login
- [x] Test: Admin sees all menu items ✓
- [x] Test: Staff does not see Settings ✓
- [x] Test: Logout clears session and returns to login ✓

---

## PHASE 4 — Dashboard · `frmDashboard`

> Live summary of the system state. Loaded first after login.

### Page: `frmDashboard`
- [x] Design four summary cards
  - [x] Total Products
  - [x] Low Stock Items (count of products where `StockQty <= ReorderLevel`)
  - [x] Today's Sales (count of transactions today)
  - [x] Total Revenue Today
- [x] Create `DataAccess/DashboardRepository.vb`
  - [x] `GetTotalProducts() As Integer`
  - [x] `GetLowStockCount() As Integer`
  - [x] `GetTodaySalesCount() As Integer`
  - [x] `GetTodayRevenue() As Decimal`
- [x] Bind card values on form load
- [x] Add refresh button or auto-refresh
- [x] Test: values match actual DB data

---

## PHASE 5 — Category Management · `frmCategories`

> Simple CRUD. Build this before Products (Products depend on Categories).

### Page: `frmCategories`
- [x] Design form with `DataGridView` (dgvCategories)
- [x] Add panel or section for Add/Edit inputs
  - [x] `txtCategoryName`
  - [x] `btnAdd` · `btnUpdate` · `btnDelete` · `btnClear`
- [x] Create `DataAccess/CategoryRepository.vb`
  - [x] `GetAll() As DataTable`
  - [x] `Add(name As String)`
  - [x] `Update(id As Integer, name As String)`
  - [x] `Delete(id As Integer)`
  - [x] `NameExists(name, excludeId)` — duplicate check
- [x] Load grid on form open
- [x] Clicking a row populates the edit panel
- [x] Input validation: name cannot be empty or duplicate
- [x] Log activity on every Add / Update / Delete
- [x] Test: Add, edit, delete categories; confirm grid refreshes

---

## PHASE 6 — Supplier Management · `frmSuppliers`

### Page: `frmSuppliers`
- [x] Design form with `DataGridView` (dgvSuppliers)
- [x] Add/Edit panel inputs
  - [x] `txtName` · `txtContact` · `txtPhone` · `txtEmail` · `txtAddress`
  - [x] `btnAdd` · `btnUpdate` · `btnDelete` · `btnClear`
- [x] Create `DataAccess/SupplierRepository.vb`
  - [x] `GetAll() As DataTable`
  - [x] `Add(name, contact, phone, email, address)`
  - [x] `Update(id, name, contact, phone, email, address)`
  - [x] `Delete(id As Integer)`
- [x] Load grid on form open
- [x] Clicking a row populates the edit panel
- [x] Input validation: Name is required; optional fields stored as DBNull
- [x] Log activity on every Add / Update / Delete
- [x] Test: Add, edit, delete suppliers; confirm grid refreshes

---

## PHASE 7 — Product Management · `frmProducts`

> Depends on Phase 5 (Categories) and Phase 6 (Suppliers) being complete.

### Page: `frmProducts`
- [x] Design form with `DataGridView` (dgvProducts) showing all product columns
- [x] Add/Edit panel inputs
  - [x] `txtName` · `txtDescription`
  - [x] `txtUnitPrice` · `txtStockQty` · `txtReorderLevel`
  - [x] `cboCategory` · `cboSupplier`
  - [x] `btnAdd` · `btnUpdate` · `btnDelete` · `btnClear`
- [x] Create `DataAccess/ProductRepository.vb`
  - [x] `GetAll() As DataTable` — JOINs Categories and Suppliers
  - [x] `GetCategories() As DataTable` — for ComboBox
  - [x] `GetSuppliers() As DataTable` — for ComboBox
  - [x] `Add(name, categoryId, supplierId, description, unitPrice, stockQty, reorderLevel)`
  - [x] `Update(id, name, categoryId, supplierId, description, unitPrice, stockQty, reorderLevel)`
  - [x] `Delete(id As Integer)`
- [x] Load category and supplier dropdowns on form open
- [x] Clicking a row populates the edit panel (hidden columns for CategoryID, SupplierID, Description)
- [x] Input validation: Name required · UnitPrice >= 0 · StockQty >= 0 · ReorderLevel >= 0
- [x] Log activity on every Add / Update / Delete
- [x] Test: Add product with category and supplier; edit; delete

---

## PHASE 8 — Inventory Management · `frmInventory`

### Page: `frmInventory`
- [ ] Design main grid showing products with current stock levels
  - [ ] Columns: ProductID · Name · Category · StockQty · ReorderLevel · Status
  - [ ] Highlight rows in red/orange where `StockQty <= ReorderLevel`
- [ ] Add **Receive Stock** button → opens inline panel or dialog
  - [ ] Select product (`cboProduct`)
  - [ ] Enter quantity received (`txtQuantity`)
  - [ ] Select supplier (`cboSupplier`)
  - [ ] Notes (`txtNotes`)
  - [ ] `btnConfirmReceipt`
- [ ] Add **Adjust Stock** button → opens inline panel or dialog
  - [ ] Select product
  - [ ] New quantity or adjustment amount
  - [ ] Reason / notes
  - [ ] `btnConfirmAdjustment`
- [ ] Create `DataAccess/InventoryRepository.vb`
  - [ ] `GetAllWithStockLevel() As DataTable`
  - [ ] `ReceiveStock(productID, qty, supplierID, notes)` — inserts `tbl_StockReceipts` + updates `tbl_Products.StockQty`
  - [ ] `AdjustStock(productID, newQty, notes)` — updates `tbl_Products.StockQty`
- [ ] Log activity on every stock change
- [ ] Test: Receive stock increases product qty; Adjust stock sets new qty; Low-stock rows are highlighted

---

## PHASE 9 — Sales · `frmNewSale` + `frmSalesHistory`

### Page: `frmNewSale`
- [ ] Design split layout
  - [ ] Left: product search and add-to-sale panel
    - [ ] `txtProductSearch` or `cboProduct`
    - [ ] `txtQuantity`
    - [ ] `btnAddItem`
  - [ ] Center: sale items `DataGridView` (dgvSaleItems)
    - [ ] Columns: Product · Qty · Unit Price · Subtotal · Remove
  - [ ] Right: totals panel
    - [ ] Subtotal · Discount (`txtDiscount`) · Net Amount
    - [ ] `btnConfirmSale` · `btnCancelSale`
- [ ] Create `DataAccess/SaleRepository.vb`
  - [ ] `CreateSale(cashierID, items As List, discount) As Integer` — inserts `tbl_Sales` + `tbl_SaleItems` + deducts stock, returns SaleID
- [ ] Auto-calculate subtotal and net amount on item add/remove/discount change
- [ ] Prevent confirming sale if no items or qty exceeds available stock
- [ ] Deduct stock for each item on confirm
- [ ] Log activity: `"Sale #[SaleID] confirmed by [Username]"`
- [ ] Test: Add items, apply discount, confirm sale; verify stock decremented; verify rows in tbl_Sales and tbl_SaleItems

### Page: `frmSalesHistory`
- [ ] Design with `DataGridView` (dgvSales) listing past transactions
- [ ] Filter controls: date range (`dtpFrom` · `dtpTo`), cashier search
- [ ] Select a row → show sale line items in detail panel or sub-grid
- [ ] Add `btnVoidSale` (Admin only)
  - [ ] Confirm void dialog
  - [ ] Set `tbl_Sales.IsVoided = True`
  - [ ] Reverse stock deductions for each `tbl_SaleItems` row
  - [ ] Log activity: `"Sale #[SaleID] voided by [Username]"`
- [ ] Create `SaleRepository` methods
  - [ ] `GetAll(from As Date, to As Date) As DataTable`
  - [ ] `GetSaleItems(saleID As Integer) As DataTable`
  - [ ] `VoidSale(saleID As Integer)` — marks voided + restores stock
- [ ] Test: filter by date; view sale details; void a sale and confirm stock restored

---

## PHASE 10 — Reports · `frmReports`

### Page: `frmReports`
- [ ] Design report selection panel (radio buttons or tab control)
- [ ] **Inventory Status Report**
  - [ ] Show all products: Name · Category · StockQty · ReorderLevel · Status
  - [ ] Highlight low-stock rows
  - [ ] `btnPrintPreview` (optional)
- [ ] **Sales Summary Report**
  - [ ] Date range filter (`dtpFrom` · `dtpTo`)
  - [ ] Show: Total Sales Count · Total Revenue · Average Sale Value
  - [ ] Optional: Top 5 selling products table
- [ ] Create `DataAccess/ReportRepository.vb`
  - [ ] `GetInventoryStatus() As DataTable`
  - [ ] `GetSalesSummary(from As Date, to As Date) As DataTable`
- [ ] Test: run each report with real data; verify totals are correct

---

## PHASE 11 — Settings · `frmSettings` _(Admin Only)_

### Page: `frmSettings`
- [ ] Tab 1: **User Management**
  - [ ] `DataGridView` listing all users (Username · UserType · CreatedAt)
  - [ ] Add New User panel: `txtUsername` · `txtPassword` · `cboUserType` · `btnAddUser`
  - [ ] Change Password: select user · enter new password · `btnChangePassword`
  - [ ] Delete User: `btnDeleteUser` (cannot delete own account)
- [ ] Tab 2: **System Preferences**
  - [ ] `txtCompanyName`
  - [ ] `txtCurrencySymbol`
  - [ ] `btnSavePreferences`
- [ ] Extend `DataAccess/UserRepository.vb`
  - [ ] `GetAll() As DataTable`
  - [ ] `Insert(username, passwordHash, userType)`
  - [ ] `UpdatePassword(userID, newPasswordHash)`
  - [ ] `Delete(userID As Integer)`
- [ ] All password changes use `PasswordHelper.HashPassword`
- [ ] Log activity on all user management actions
- [ ] Test: Admin adds user → can log in with new credentials; Admin deletes user → login denied

---

## PHASE 12 — Testing & QA

### Authentication
- [ ] Valid Admin credentials → opens frmMain with full menu
- [ ] Valid Staff credentials → opens frmMain with limited menu (no Settings)
- [ ] Wrong password → shows error, does not proceed
- [ ] Empty fields → shows validation error

### CRUD Modules
- [ ] Categories: Add · Edit · Delete · duplicate name blocked
- [ ] Suppliers: Add · Edit · Delete · required field blocked
- [ ] Products: Add · Edit · Delete · search · category filter
- [ ] Inventory: Receive stock increases qty · Adjust stock sets correct qty · low-stock highlight works
- [ ] Sales: Add items · apply discount · confirm → stock deducted · void → stock restored

### Reports
- [ ] Inventory report shows all products with correct stock
- [ ] Low-stock items highlighted in inventory report
- [ ] Sales summary totals match manual calculation

### Activity Logs
- [ ] Login success/failure logged
- [ ] Every CRUD action logged with username
- [ ] Sale confirmed and voided logged

### Edge Cases
- [ ] Sale with zero items blocked
- [ ] Sale quantity exceeding available stock blocked
- [ ] Deleting a category with linked products handled gracefully
- [ ] Empty search returns full list

---

## PHASE 13 — Deployment

- [ ] Switch build configuration to **Release**
- [ ] Verify `config.txt` is excluded from build output (not committed)
- [ ] Verify `config.txt.example` is present in the repo
- [ ] Run full smoke test on Release build with production `config.txt`
- [ ] Confirm all `DataAccess/` modules compile without warnings
- [ ] Package release executable and dependencies
- [ ] Optional: create installer (ClickOnce or Inno Setup)
- [ ] Optional: write user manual

---

```
┌─────────────────────────────────────────────────────┐
│  PHASE SUMMARY                                      │
│                                                     │
│  Phase 1  ·  Setup & Foundation                     │
│  Phase 2  ·  frmLogin                              │
│  Phase 3  ·  frmMain (MDI Shell)                   │
│  Phase 4  ·  frmDashboard                          │
│  Phase 5  ·  frmCategories                         │
│  Phase 6  ·  frmSuppliers                          │
│  Phase 7  ·  frmProducts                           │
│  Phase 8  ·  frmInventory                          │
│  Phase 9  ·  frmNewSale + frmSalesHistory          │
│  Phase 10 ·  frmReports                            │
│  Phase 11 ·  frmSettings                           │
│  Phase 12 ·  Testing & QA                          │
│  Phase 13 ·  Deployment                            │
└─────────────────────────────────────────────────────┘
```

---

| Date | Version | Notes |
|------|---------|-------|
| 2026-06-22 | 1.0 | Initial development checklist created |
| 2026-06-22 | 1.1 | Phases 1–7 complete; checked off all finished tasks |
