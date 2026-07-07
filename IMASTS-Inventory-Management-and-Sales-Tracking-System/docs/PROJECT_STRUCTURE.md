# PROJECT_STRUCTURE.md
**Project:** IMASTS — Inventory Management and Sales Tracking System
**Platform:** VB.NET · Windows Forms · .NET 8.0 · SQL Server

---

## Folder Layout

```
IMASTS-Inventory-Management-and-Sales-Tracking-System/
│
├── DataAccess/                         ← All SQL lives here — never in forms
│   ├── ActivityLogRepository.vb        ✓ done
│   ├── UserRepository.vb               ✓ done
│   ├── CategoryRepository.vb           (Phase 5)
│   ├── SupplierRepository.vb           (Phase 6)
│   ├── ProductRepository.vb            (Phase 7)
│   ├── InventoryRepository.vb          (Phase 8)
│   ├── SaleRepository.vb               (Phase 9)
│   ├── DashboardRepository.vb          (Phase 4)
│   └── ReportRepository.vb             (Phase 10)
│
├── Helpers/
│   ├── dbconstring.vb                  ✓ done — reads config.txt at runtime
│   ├── SessionManager.vb               ✓ done — Username, UserType, UserCode, Clear()
│   ├── InputHelper.vb                  ✓ done — SanitizeInput()
│   ├── PasswordHelper.vb               ✓ done — HashPassword() / VerifyPassword()
│   ├── ActivityLogger.vb               ✓ done — wraps ActivityLogRepository, swallows exceptions
│   └── Constants.vb                    ✓ done — role strings, status values
│
├── Forms/
│   ├── frmLogin.vb                     ✓ done
│   ├── frmForgotPassword.vb            ✓ done — security-question password reset
│   ├── frmMain.vb                      ✓ done — MDI parent + navigation
│   ├── frmDashboard.vb                 (Phase 4 — next)
│   ├── frmProducts.vb                  (Phase 7)
│   ├── frmInventory.vb                 (Phase 8)
│   ├── frmNewSale.vb                   (Phase 9)
│   ├── frmSalesHistory.vb              (Phase 9)
│   ├── frmSuppliers.vb                 (Phase 6)
│   ├── frmCategories.vb                (Phase 5)
│   ├── frmReports.vb                   (Phase 10)
│   └── frmSettings.vb                  (Phase 11)
│
├── docs/
│   ├── AI_Rules.md                     ← rules for AI sessions
│   ├── PROJECT_STRUCTURE.md            ← this file
│   ├── DATABASE_SCHEMA.md              ← table/column reference
│   ├── CURRENT_TASKS.md                ← active development status
│   ├── ProjectPlan.md                  ← full project plan
│   ├── DevelopmentPhase.md             ← task-by-task checklist
│   └── DBConnectionPattern.md          ← connection & repo standard
│
├── Program.vb                          ← app entry point
├── config.txt.example                  ← committed format reference
└── config.txt                          ← NOT committed (.gitignore)
```

---

## Architecture Rules

| Rule | Detail |
|------|--------|
| No SQL in forms | All queries in `DataAccess/` modules only |
| Connection | `dbconstring.Connection` — reads `config.txt` at runtime |
| Always `Using` | Wrap `SqlConnection` and `SqlCommand` in `Using` blocks |
| Parameterized SQL | `Parameters.AddWithValue` — never string-concatenate |
| Passwords | BCrypt via `PasswordHelper` — never store plain text |
| Logging | `ActivityLogger.Log(user, result, description)` on every CRUD |
| Session | `SessionManager.Username`, `.UserType`, `.UserCode` |
| Input | `InputHelper.SanitizeInput()` on all user-supplied text |

---

## Control Naming Conventions

| Prefix | Control |
|--------|---------|
| `txt` | TextBox |
| `btn` | Button |
| `dgv` | DataGridView |
| `lbl` | Label |
| `cbo` | ComboBox |
| `pnl` | Panel |
| `dtp` | DateTimePicker |
| `chk` | CheckBox |

---

## Technology Stack

| Layer | Technology |
|-------|-----------|
| Language | Visual Basic .NET |
| UI | Windows Forms |
| Runtime | .NET 8.0 |
| Database | SQL Server (Express or LocalDB) |
| DB Driver | `Microsoft.Data.SqlClient` 5.x |
| Password Hashing | `BCrypt.Net-Next` |
| IDE | Visual Studio 2022 |
| Version Control | Git / GitHub |
