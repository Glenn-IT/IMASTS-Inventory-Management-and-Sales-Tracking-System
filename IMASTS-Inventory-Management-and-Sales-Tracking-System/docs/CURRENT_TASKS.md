# CURRENT_TASKS.md
**Last Updated:** 2026-06-22
**Current Phase:** Phase 8 — Inventory Management (`frmInventory`)

---

## Status Summary

| Phase | Name | Status |
|-------|------|--------|
| 1 | Project Setup & Foundation | DONE |
| 2 | Authentication — `frmLogin` | DONE (tests pending) |
| 3 | Main Shell — `frmMain` | DONE (tests pending) |
| 4 | Dashboard — `frmDashboard` | DONE (tests pending) |
| 5 | Category Management — `frmCategories` | DONE (tests pending) |
| 6 | Supplier Management — `frmSuppliers` | DONE (tests pending) |
| 7 | Product Management — `frmProducts` | DONE (tests pending) |
| **8** | **Inventory Management** | **NEXT** |
| 9 | Sales | Not started |
| 10 | Reports | Not started |
| 11 | Settings | Not started |
| 12 | Testing & QA | Not started |
| 13 | Deployment | Not started |

---

## Completed Work

### Phase 1 — Foundation (DONE)
- NuGet: `Microsoft.Data.SqlClient` + `BCrypt.Net-Next` installed
- `Helpers/dbconstring.vb` — reads `config.txt` at runtime
- `config.txt.example` committed; `config.txt` in `.gitignore`
- `IMASTS_DB` created with all 8 tables
- Admin seed user inserted (`admin` / `Admin@123`)
- `Helpers/SessionManager.vb`, `InputHelper.vb`, `PasswordHelper.vb`, `Constants.vb`, `ActivityLogger.vb`
- `DataAccess/ActivityLogRepository.vb`
- `DataAccess/UserRepository.vb`

### Phase 2 — frmLogin (DONE — tests pending)
- Login form designed with `txtUsername`, `txtPassword`, `btnLogin`, `lblError`, `chkShowPassword`
- Login logic: sanitize → fetch user → BCrypt verify → populate SessionManager → open frmMain
- Activity logging on success and failure

### Phase 3 — frmMain (DONE — tests pending)
- Sidebar/menu navigation with `pnlContent` panel hosting child forms
- Role-based visibility: Settings hidden for Staff
- Status bar: current user, role, date/time
- Logout: clears SessionManager, returns to frmLogin
- Opens frmDashboard as default child on login

### Phase 4 — frmDashboard (DONE — tests pending)
- `DataAccess/DashboardRepository.vb` — four query methods
- `Forms/frmDashboard.vb` — binds values on load, refresh button
- `Forms/frmDashboard.Designer.vb` — four summary cards (Products, Low Stock, Sales, Revenue)

### Phase 5 — frmCategories (DONE — tests pending)
- `DataAccess/CategoryRepository.vb` — GetAll, Add, Update, Delete, NameExists
- `Forms/frmCategories.vb` — CRUD with validation, duplicate check, activity logging, confirm on delete
- `Forms/frmCategories.Designer.vb` — input card + DataGridView
- `frmMain.vb` — btnCategories wired to open frmCategories

### Phase 6 — frmSuppliers (DONE — tests pending)
- `DataAccess/SupplierRepository.vb` — GetAll, Add, Update, Delete; optional fields use DBNull
- `Forms/frmSuppliers.vb` — CRUD with validation, activity logging, confirm on delete
- `Forms/frmSuppliers.Designer.vb` — two-column input card + DataGridView
- `frmMain.vb` — btnSuppliers wired to open frmSuppliers

### Phase 7 — frmProducts (DONE — tests pending)
- `DataAccess/ProductRepository.vb` — GetAll (with JOIN), Add, Update, Delete, GetCategories, GetSuppliers
- `Forms/frmProducts.vb` — CRUD with ComboBox binding, validation, hidden columns fix for Description/CategoryID/SupplierID
- `Forms/frmProducts.Designer.vb` — 4-row input card + DataGridView
- `frmMain.vb` — btnProducts wired to open frmProducts

---

## Pending Tests (Phases 2–6)

- [x] Valid login opens `frmMain`
- [x] Wrong password shows error and does not proceed
- [x] Empty fields show validation message
- [x] Admin sees all menu items
- [x] Staff does not see Settings
- [x] Logout clears session and returns to login

---

## Active Task — Phase 8: frmInventory

Build inventory management — receive stock into products:

- [ ] Create `DataAccess/InventoryRepository.vb`
  - [ ] `GetReceipts() As DataTable` — all stock receipts with product/supplier names
  - [ ] `AddReceipt(productId, supplierId, quantity, notes) As Boolean` — inserts into tbl_StockReceipts and increments tbl_Products.StockQty
  - [ ] `GetProducts() As DataTable` — for ComboBox
  - [ ] `GetSuppliers() As DataTable` — for ComboBox
- [ ] Design `Forms/frmInventory.vb`
  - [ ] `dgvReceipts` — lists stock receipt history
  - [ ] Input fields: `cboProduct`, `cboSupplier`, `txtQuantity`, `txtNotes`
  - [ ] `btnReceive`, `btnClear`
- [ ] Bind grid on load; ComboBoxes populated on load
- [ ] Validate: Product, Supplier, Quantity (positive integer) required
- [ ] Activity log on receive
- [ ] Wire `btnInventory` in `frmMain`
- [ ] Test: receiving stock increments product StockQty in DB

---

## Blocked / Notes

_(none currently)_
