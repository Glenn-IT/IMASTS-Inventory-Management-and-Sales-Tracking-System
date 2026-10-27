1. [x] New Sale Tab - on the quantity it should not accept a letter there only numbers ok
   - Added `txtQty_KeyPress` in `frmNewSale.vb` to allow digits and control characters only.

2. [x] add restriction on the staff it should not have the full function of the system draft a plan on that ok
   - Implemented role-based restrictions based on `SessionManager.IsAdmin`:
     - `frmMain`: Hidden `btnSettings`, `btnReports`, `lblMgmtSep`, `btnSuppliers`, `btnCategories` for Staff.
     - `frmProducts`: Edit form hidden for Staff (view/search-only catalog mode); disabled update & delete buttons.
     - `frmInventory`: Hidden `btnAdjustStock` and `btnExportExcel` for Staff (Stock In / receive stock remains available).
     - `frmSalesHistory`: `btnVoidSale` remains restricted to Admin only. 