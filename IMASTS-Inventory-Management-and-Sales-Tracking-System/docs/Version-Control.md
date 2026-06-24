# Version Control — IMASTS Rollout Schedule

## Rollout Plan

| Version | Feature Unlocked | Forms Unlocked | Forms Still Gated |
|---------|-----------------|----------------|-------------------|
| v1.00 | Login + Main Window | frmLogin, frmMain | frmDashboard, frmCategories, frmSuppliers, frmProducts, frmInventory, frmNewSale, frmSalesHistory, frmReports, frmSettings |
| v1.01 | Dashboard | frmDashboard | frmCategories, frmSuppliers, frmProducts, frmInventory, frmNewSale, frmSalesHistory, frmReports, frmSettings |
| v1.02 | Categories | frmCategories | frmSuppliers, frmProducts, frmInventory, frmNewSale, frmSalesHistory, frmReports, frmSettings |
| v1.03 | Suppliers | frmSuppliers | frmProducts, frmInventory, frmNewSale, frmSalesHistory, frmReports, frmSettings |
| v1.04 | Products | frmProducts | frmInventory, frmNewSale, frmSalesHistory, frmReports, frmSettings |
| v1.05 | Inventory | frmInventory | frmNewSale, frmSalesHistory, frmReports, frmSettings |
| v1.06 | New Sale | frmNewSale | frmSalesHistory, frmReports, frmSettings |
| v1.07 | Sales History | frmSalesHistory | frmReports, frmSettings |
| v1.08 | Reports | frmReports | frmSettings |
| v1.09 | Settings (Full System) | frmSettings | — |

---

## Under Construction Strategy

Any form not yet unlocked in the current version has these 6 lines at the very top of its `Form_Load` event:

```vb
' GATE — remove this block when unlocking for vX.XX
Dim gate As New UnderConstructionForm()
gate.ShowDialog()
Me.Close()
Return
' END GATE
```

When a locked form is opened, it immediately shows `UnderConstructionForm` as a blocking dialog, then closes itself. The user sees the Under Construction screen and clicks **← Go Back** to dismiss it. `Me.Close()` runs after the dialog returns, so the caller form also closes — no orphaned windows.

`UnderConstructionForm.vb` holds a single constant:

```vb
Public Const CURRENT_VERSION As String = "v1.00"
```

Update this string each version so the screen always shows the correct version number.

---

## Git Commands Per Version

Each version follows this exact sequence:

```bash
# 1. Remove the GATE block from the Form_Load of the form being unlocked
# 2. Update CURRENT_VERSION in UnderConstructionForm.vb

# Stage only the changed files
git add Forms/<UnlockedForm>.vb Forms/UnderConstructionForm.vb

# Commit
git commit -m "feat: implement vX.XX - unlock [Feature Name]"

# Tag the commit as a permanent snapshot
git tag vX.XX

# Push the commit and the tag
git push origin master
git push origin vX.XX
```

---

## How Git Tags Work

A tag is a permanent, named pointer to a specific commit. Unlike branches (which move forward), a tag never changes — it always points to the exact commit made at that moment. This means:

- Each `vX.XX` tag is a frozen snapshot of the system at that presentation state.
- You can always check out any version: `git checkout v1.02`
- GitHub shows each tag as a downloadable release under **Releases**.

---

## GitHub Release Tags

| Version | Tag Name | Commit Hash |
|---------|----------|-------------|
| v1.00 | v1.00 | |
| v1.01 | v1.01 | |
| v1.02 | v1.02 | |
| v1.03 | v1.03 | |
| v1.04 | v1.04 | |
| v1.05 | v1.05 | |
| v1.06 | v1.06 | |
| v1.07 | v1.07 | |
| v1.08 | v1.08 | |
| v1.09 | v1.09 | |

After all versions are committed and pushed, fill in the hash column with:

```bash
git tag | sort | xargs -I{} git log -1 --format="{} %H" {}
```

Then commit and push the updated docs:

```bash
git add docs/Version-Control.md
git commit -m "docs: add commit hashes to version control table"
git push origin master
```

---

## When a Prof or Client Requests Changes After a Presentation

Fix on master first, then move the tag to point at the new commit:

```bash
# Fix on master
git checkout master
git add <changed-files>
git commit -m "feat: update [form] per feedback"
git push origin master

# Delete the old tag locally and on GitHub, then re-create it
git tag -d vX.XX
git push origin :refs/tags/vX.XX
git tag vX.XX
git push origin vX.XX
```

The tag now points to the updated commit. All other version tags are unaffected.
