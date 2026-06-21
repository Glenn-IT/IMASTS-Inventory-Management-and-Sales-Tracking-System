```
╔══════════════════════════════════════════════════════════════════╗
║       IMASTS — Inventory Management and Sales Tracking System    ║
║                        PROJECT PLAN                              ║
╚══════════════════════════════════════════════════════════════════╝
```

| Field | Detail |
|---|---|
| **Project** | IMASTS — Inventory Management and Sales Tracking System |
| **Platform** | Windows Desktop · VB.NET · Windows Forms · .NET 8.0 |
| **Status** | `ONGOING` |
| **Version** | 1.1 |
| **Started** | 2026-06-22 |
| **Author** | Glenn |

---

## 01  Overview

IMASTS is a desktop application built to help small-to-medium businesses centralize their **inventory management** and **sales tracking** in one place. It provides real-time stock visibility, records sales transactions, alerts on low stock, and generates summary reports — all through a Windows Forms interface backed by SQL Server.

> The system follows the `config.txt` + `dbconstring` connection pattern and the `DataAccess/` repository architecture defined in **`DBConnectionPattern.md`**. All SQL lives in repository modules — no `SqlConnection` inside forms or panels.

---

## 02  Goals

| # | Objective |
|---|-----------|
| 1 | Centralized product and inventory management |
| 2 | Real-time sales transaction recording |
| 3 | Automatic low-stock alerts |
| 4 | Inventory and sales reporting |
| 5 | Supplier and category management |
| 6 | Role-based access control (Admin / Staff) |

---

## 03  Scope

**In Scope**

- Product management (add · edit · delete · search)
- Inventory tracking (stock levels · restock · adjustments · low-stock alerts)
- Sales transactions (new sale · history · void — Admin only)
- Supplier and category management
- Dashboard with live summary metrics
- Reports: Inventory Status · Sales Summary
- User authentication and role-based access

**Out of Scope — Phase 1**

- E-commerce or online storefront
- Multi-branch / multi-warehouse
- Mobile or web interface
- Payroll or HR features

---

## 04  Modules

```
┌─────────────────────────────────────────────────────┐
│  MODULE MAP                                         │
│                                                     │
│  [1] Authentication      [6] Supplier Management   │
│  [2] Dashboard           [7] Category Management   │
│  [3] Product Management  [8] Reports               │
│  [4] Inventory Tracking  [9] Settings              │
│  [5] Sales Management                              │
└─────────────────────────────────────────────────────┘
```

### Module 1 — Authentication
- Login form with username and password
- BCrypt password verification (`BCrypt.Net-Next`)
- Role-based access: Admin and Staff
- `SessionManager` module holds current user state

### Module 2 — Dashboard
- Summary cards: Total Products · Low Stock Items · Today's Sales · Total Revenue
- Loads live data from `DashboardRepository`
- Quick-access navigation links

### Module 3 — Product Management
- Add, edit, delete, search products
- Fields: ProductID · Name · Category · Description · Unit Price · Stock Qty · Reorder Level · Supplier
- Filter by category or name
- `ProductRepository` in `DataAccess/`

### Module 4 — Inventory Management
- View real-time stock levels
- Receive stock (restock entries → `tbl_StockReceipts`)
- Stock adjustments (corrections / write-offs)
- Low-stock row highlighting when `StockQty <= ReorderLevel`

### Module 5 — Sales Management
- New sale: product search → add line items → apply discount → confirm
- Auto-deducts stock on confirmed sale
- Sales history with date/cashier filter
- Void / cancel transaction (Admin only) with stock reversal

### Module 6 — Supplier Management
- Add, edit, delete suppliers
- Fields: SupplierID · Name · Contact Person · Phone · Email · Address

### Module 7 — Category Management
- Add, edit, delete product categories
- Categories linked to products

### Module 8 — Reports
- **Inventory Status Report** — current stock levels, low-stock flagging
- **Sales Summary Report** — daily / weekly / monthly totals
- Print preview (Phase 2: PDF/Excel export)

### Module 9 — Settings _(Admin only)_
- User account management (add · change password · delete)
- System preferences: company name, currency symbol

---

## 05  Technology Stack

| Layer | Technology |
|-------|-----------|
| Language | Visual Basic .NET (VB.NET) |
| UI Framework | Windows Forms |
| Runtime | .NET 8.0 |
| Database | SQL Server (Express or LocalDB) |
| DB Driver | `Microsoft.Data.SqlClient` 5.x |
| Password Hashing | `BCrypt.Net-Next` |
| IDE | Visual Studio 2022 |
| Version Control | Git / GitHub |

---

## 06  Architecture

```
IMASTS/
├── DataAccess/
│   ├── UserRepository.vb
│   ├── ProductRepository.vb
│   ├── CategoryRepository.vb
│   ├── SupplierRepository.vb
│   ├── InventoryRepository.vb
│   ├── SaleRepository.vb
│   ├── DashboardRepository.vb
│   └── ActivityLogRepository.vb
│
├── Helpers/
│   ├── dbconstring.vb          ← reads config.txt at runtime
│   ├── SessionManager.vb       ← holds Username, UserType, UserCode
│   ├── InputHelper.vb          ← SanitizeInput()
│   ├── PasswordHelper.vb       ← HashPassword() / VerifyPassword()
│   ├── ActivityLogger.vb       ← wraps ActivityLogRepository safely
│   └── Constants.vb            ← magic strings (roles, statuses)
│
├── Forms/
│   ├── frmLogin.vb
│   ├── frmMain.vb              ← MDI parent + navigation
│   ├── frmDashboard.vb
│   ├── frmProducts.vb
│   ├── frmInventory.vb
│   ├── frmNewSale.vb
│   ├── frmSalesHistory.vb
│   ├── frmSuppliers.vb
│   ├── frmCategories.vb
│   ├── frmReports.vb
│   └── frmSettings.vb
│
├── docs/
│   ├── ProjectPlan.md          ← this file
│   ├── DBConnectionPattern.md  ← connection & repo standard
│   └── DevelopmentPhase.md     ← task-by-task build checklist
│
├── config.txt.example          ← committed — format reference
└── config.txt                  ← NOT committed (.gitignore)
```

---

## 07  Database Schema

| Table | Key Columns |
|-------|------------|
| `tbl_Users` | UserID · Username · PasswordHash · UserType · CreatedAt |
| `tbl_Categories` | CategoryID · CategoryName |
| `tbl_Suppliers` | SupplierID · Name · ContactPerson · Phone · Email · Address |
| `tbl_Products` | ProductID · Name · CategoryID · SupplierID · UnitPrice · StockQty · ReorderLevel |
| `tbl_Sales` | SaleID · SaleDate · CashierID · TotalAmount · Discount · NetAmount · IsVoided |
| `tbl_SaleItems` | SaleItemID · SaleID · ProductID · Quantity · UnitPrice · Subtotal |
| `tbl_StockReceipts` | ReceiptID · ProductID · Quantity · ReceiptDate · SupplierID · Notes |
| `tbl_ActivityLogs` | LogID · Username · LogDate · Result · Description |

---

## 08  Coding Conventions

| Rule | Detail |
|------|--------|
| Control prefix | `txt` · `btn` · `dgv` · `lbl` · `cbo` · `pnl` |
| Classes / Forms | PascalCase — `frmLogin`, `ProductRepository` |
| Local variables | camelCase — `productList`, `totalAmount` |
| No SQL in forms | All queries in `DataAccess/` repository modules |
| Parameterized SQL | Always use `Parameters.AddWithValue` — never concatenate |
| Connection | Always `Using` blocks for `SqlConnection` and `SqlCommand` |
| Passwords | BCrypt hash/verify via `PasswordHelper` — never store plain text |
| Logging | Call `ActivityLogger.Log(user, result, description)` on every CRUD |

---

## 09  Risks

| Risk | Likelihood | Impact | Mitigation |
|------|-----------|--------|-----------|
| `config.txt` accidentally committed | Low | High | `.gitignore` enforced; `config.txt.example` used as template |
| SQL injection | Low | High | Parameterized queries enforced in all repositories |
| Stock count mismatch | Medium | High | Stock deduction + receipt insert in a single transaction |
| Scope creep | Medium | Medium | Phase gating — defer out-of-scope items |
| UI inconsistency | Medium | Low | Shared constants and control naming conventions |

---

## 10  Document History

| Date | Version | Notes |
|------|---------|-------|
| 2026-06-22 | 1.0 | Initial plan created |
| 2026-06-22 | 1.1 | Updated with DBConnectionPattern architecture, modern layout, and DevelopmentPhase reference |
