# CURRENT_TASKS.md
**Last Updated:** 2026-06-22
**Current Phase:** Phase 11 — Settings (`frmSettings`) — BUILT, pending test
**UI Task:** Layout redesign (all Designer.vb files) — DONE, pending build/test

---

## Status Summary

| Phase | Name | Status |
|-------|------|--------|
| 1 | Project Setup & Foundation | DONE |
| 2 | Authentication — `frmLogin` | DONE |
| 3 | Main Shell — `frmMain` | DONE |
| 4 | Dashboard — `frmDashboard` | DONE |
| 5 | Category Management — `frmCategories` | DONE |
| 6 | Supplier Management — `frmSuppliers` | DONE |
| 7 | Product Management — `frmProducts` | DONE |
| 8 | Inventory Management — `frmInventory` | DONE ✓ tested |
| 9 | Sales — `frmNewSale` + `frmSalesHistory` | DONE ✓ tested |
| 10 | Reports — `frmReports` | DONE ✓ tested |
| **11** | **Settings — `frmSettings`** | **BUILT — pending test** |
| 12 | Testing & QA | Not started |
| 13 | Deployment | Not started |

---

## Phase 11 — What Was Built

### New files
- `Helpers/SettingsManager.vb` — reads/writes `appsettings.txt` next to the exe (CompanyName, CurrencySymbol)
- `Forms/frmSettings.vb` — Admin-only form with two tabs
- `Forms/frmSettings.Designer.vb`

### Tab 1 — User Management
- `dgvUsers` lists all users (Username, Role, Created)
- **Add New User** panel: txtNewUsername · txtNewPassword (masked) · cboNewUserType · btnAddUser
  - Validates: required fields, min 6-char password, duplicate username check
- **Change Password** panel: shows selected user · txtChangePassword · btnChangePass
- **btnDeleteUser** (red, Admin only): blocked if own account selected
- All actions logged via ActivityLogger

### Tab 2 — System Preferences
- `txtCompanyName` · `txtCurrencySymbol` · `btnSavePreferences`
- Loaded from / saved to `appsettings.txt` via SettingsManager

### Updated
- `frmMain.vb` — `btnSettings` wired to `frmSettings`
- `UserRepository.vb` — no changes needed (GetAll, Insert, UpdatePassword, Delete already existed)

---

## Tests needed — Phase 11
- [ ] Admin adds user → new user can log in
- [ ] Admin changes password → old password rejected, new password works
- [ ] Admin cannot delete own account (button disabled)
- [ ] Admin deletes user → login with that account is denied
- [ ] Save preferences → `appsettings.txt` created/updated with correct values

---

## Next: Phase 12 — Testing & QA

Full system regression across all modules. See `DevelopmentPhase.md` Phase 12 checklist.

---

## Blocked / Notes

_(none currently)_
