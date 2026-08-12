# CURRENT_TASKS.md
**Last Updated:** 2026-07-29
**Current Rollout:** v5.xx series (continues from v4.00) — v5.04 (New Sale & Sales History unlocked; Inventory gated), next is v5.05 (Reports)
**Add-on:** Forgot Password (security question) — BUILT, pending test

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

## Forgot Password (security question) — What Was Built

### DB change
- `tbl_Users` gained `SecurityQuestion` (NVARCHAR 255, NULL) and `SecurityAnswerHash` (NVARCHAR 255, NULL).
- `docs/IMASTS_CreateTables.sql` updated: new columns in the CREATE TABLE plus guarded `ALTER TABLE` statements for existing databases — **run the ALTER block against the existing IMASTS_DB**.

### New files
- `Forms/frmForgotPassword.vb` / `.Designer.vb` — 3-step wizard (enter username → pick security question from dropdown + answer it → set new password), opened via "Forgot Password?" link on `frmLogin`. The question is never shown/pre-filled — the user must pick the correct one from `Constants.SecurityQuestions`, and it must match the one stored for that account.

### Updated
- `Helpers/Constants.vb` — added fixed `SecurityQuestions` list (dropdown source).
- `DataAccess/UserRepository.vb` — added `GetSecurityInfo(username)` and `UpdateSecurityQA(userId, question, answerHash)`.
- `Forms/frmLogin.vb` / `.Designer.vb` — added `lnkForgotPassword` link label.
- `Forms/frmSettings.vb` / `.Designer.vb` — added a new "My Security Question" tab (self-service, all roles) where the logged-in user picks a question and sets/updates their answer. Tab 1 (User Management) and Tab 2 (System Preferences) are now hidden for non-Admin users.
- `Forms/frmMain.vb` — `btnSettings` is now visible to all roles (was Admin-only) so Staff can reach the self-service tab.

### Tests needed
- [ ] Run the `ALTER TABLE` migration against the existing `IMASTS_DB` (or recreate via the updated script) before testing.
- [ ] User with no security question set → Forgot Password shows "contact an administrator" message.
- [ ] User sets security Q&A in Settings → Forgot Password flow succeeds with correct answer, rejects wrong answer.
- [ ] Password reset via Forgot Password → old password rejected, new password works, activity logged.
- [ ] Staff user can open Settings and see only the "My Security Question" tab (no User Management / System Preferences).

---

## Next: Phase 12 — Testing & QA

Full system regression across all modules. See `DevelopmentPhase.md` Phase 12 checklist.

---

## Blocked / Notes

_(none currently)_
