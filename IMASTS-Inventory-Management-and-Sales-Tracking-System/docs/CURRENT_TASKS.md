# CURRENT_TASKS.md
**Last Updated:** 2026-06-22
**Current Phase:** Phase 4 — Dashboard (`frmDashboard`)

---

## Status Summary

| Phase | Name | Status |
|-------|------|--------|
| 1 | Project Setup & Foundation | DONE |
| 2 | Authentication — `frmLogin` | DONE (tests pending) |
| 3 | Main Shell — `frmMain` | DONE (tests pending) |
| **4** | **Dashboard — `frmDashboard`** | **NEXT** |
| 5 | Category Management | Not started |
| 6 | Supplier Management | Not started |
| 7 | Product Management | Not started |
| 8 | Inventory Management | Not started |
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
- MDI parent with sidebar/menu navigation
- Role-based visibility: Settings hidden for Staff
- Status bar: current user, role, date/time
- Logout: clears SessionManager, returns to frmLogin
- Opens frmDashboard as default child on login

---

## Pending Tests (Phase 2 & 3)

- [ ] Valid login opens `frmMain`
- [ ] Wrong password shows error and does not proceed
- [ ] Empty fields show validation message
- [ ] Admin sees all menu items
- [ ] Staff does not see Settings
- [ ] Logout clears session and returns to login

---

## Active Task — Phase 4: frmDashboard

Build the dashboard with four live summary cards:

- [ ] Design four summary cards
  - [ ] Total Products
  - [ ] Low Stock Items (`StockQty <= ReorderLevel`)
  - [ ] Today's Sales count
  - [ ] Total Revenue Today
- [ ] Create `DataAccess/DashboardRepository.vb`
  - [ ] `GetTotalProducts() As Integer`
  - [ ] `GetLowStockCount() As Integer`
  - [ ] `GetTodaySalesCount() As Integer`
  - [ ] `GetTodayRevenue() As Decimal`
- [ ] Bind card values on form load
- [ ] Add refresh button or auto-refresh
- [ ] Test: values match actual DB data

---

## Blocked / Notes

_(none currently)_
