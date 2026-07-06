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
| v1.00 | v1.00 | 35f52673b7afdd71aa645173023b7fe22c55f77d |
| v1.01 | v1.01 | 70cfdf2ba11af405bf0a7e131f3ee1b146a7e1af |
| v1.02 | v1.02 | 977d81b3c636507e546f31e213f1f60c9e38c811 |
| v1.03 | v1.03 | 56e578b661b867647ab030856043bd03c3928908 |
| v1.04 | v1.04 | ef0c4c65168068904d266aee74cfbce23ea90919 |
| v1.05 | v1.05 | 02b5aca63ef1f828a080da2f6162b7a7be9be119 |
| v1.06 | v1.06 | 4d9cb0dd582e746d2cbf8c4a938981141f430fec |
| v1.07 | v1.07 | 976e71f3cb86577141c092d15e02ea479c02ff68 |
| v1.08 | v1.08 | b67c2190ac8320ea0765837154d0cfecd6082eac |
| v1.09 | v1.09 | 0b94611f63b6a02369caea6cd60f026de8e00591 |

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

---

## v2.xx Series — Docked Gate Rollout

The v1.xx tags above are frozen history from the original rollout. The v2.xx
series redoes the same progressive-unlock idea with a different gate
mechanism: instead of `UnderConstructionForm.ShowDialog()` popping a modal
and closing the host form, `frmMain` now docks `UnderConstructionForm`
directly into `pnlContent` for any feature that isn't unlocked yet — the
same way real feature forms are docked via `OpenChildForm`.

`UnderConstructionForm` was also updated so it displays correctly at any
size: every control has `Anchor = None`, which makes WinForms resize and
reposition them proportionally instead of pinning them top-left, so the
content stays centered whether `pnlContent` is small or maximized.

### Rollout Plan

| Version | Feature Unlocked | Forms Unlocked | Forms Still Gated |
|---------|-----------------|----------------|-------------------|
| v2.00 | Base state (nothing) | frmLogin, frmMain | frmDashboard, frmCategories, frmSuppliers, frmProducts, frmInventory, frmNewSale, frmSalesHistory, frmReports, frmSettings |
| v2.01 | Dashboard | frmDashboard | frmCategories, frmSuppliers, frmProducts, frmInventory, frmNewSale, frmSalesHistory, frmReports, frmSettings |
| v2.02 | Categories | frmCategories | frmSuppliers, frmProducts, frmInventory, frmNewSale, frmSalesHistory, frmReports, frmSettings |
| v2.03 | Suppliers | frmSuppliers | frmProducts, frmInventory, frmNewSale, frmSalesHistory, frmReports, frmSettings |
| v2.04 | Products | frmProducts | frmInventory, frmNewSale, frmSalesHistory, frmReports, frmSettings |
| v2.05 | Inventory | frmInventory | frmNewSale, frmSalesHistory, frmReports, frmSettings |
| v2.06 | New Sale | frmNewSale | frmSalesHistory, frmReports, frmSettings |
| v2.07 | Sales History | frmSalesHistory | frmReports, frmSettings |
| v2.08 | Reports | frmReports | frmSettings |
| v2.09 | Settings (Full System) | frmSettings | — |

### Docked Gate Strategy

The gate now lives in `frmMain`'s own Click handlers (and `frmMain_Load`
for the initial Dashboard open) rather than inside each individual form's
`Load` event:

```vb
Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
    ' GATE — swap to New frmProducts() when unlocking for v2.04
    OpenChildForm(New UnderConstructionForm())
End Sub
```

Unlocking a feature is a one-line swap back to the real form:

```vb
Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
    OpenChildForm(New frmProducts())
End Sub
```

`UnderConstructionForm.vb` still holds the single constant, bumped once per
version:

```vb
Public Const CURRENT_VERSION As String = "v2.09"
```

### Git Commands Per Version (v2.xx)

```bash
# 1. Swap the GATE line in the relevant frmMain Click handler back to the real form
# 2. Update CURRENT_VERSION in UnderConstructionForm.vb

git add Forms/frmMain.vb Forms/UnderConstructionForm.vb
git commit -m "feat: implement v2.XX - unlock [Feature Name]"
git tag v2.XX
git push origin master
git push origin v2.XX
```

### GitHub Release Tags (v2.xx)

| Version | Tag Name | Commit Hash |
|---------|----------|--------------|
| v2.00 | v2.00 | e5017b5f704ebf5541f3b6cf27cac962e3927a8e |
| v2.01 | v2.01 | 1f59f7fdd969d7d06457ca206830bf874cc9bd9c |
| v2.02 | v2.02 | 67238d8b7ee1fbb1e7a8db77c15910bca9ea4539 |
| v2.03 | v2.03 | 795336705ea4f95133835fe7b071eb2451c989ec |
| v2.04 | v2.04 | f7f78beb775e7eadbff38a7c9ceaf53fb95b4693 |
| v2.05 | v2.05 | 31678e8797cad8f4c6604ddbab1dc462f3a7af39 |
| v2.06 | v2.06 | 3b1e19c797d943925a04daabbc2d3d1da3e12bd6 |
| v2.07 | v2.07 | c72e2d9659a0223b5e1e427d9d041ce71b54ccbc |
| v2.08 | v2.08 | 4f265305d493e8528268fe1fd9e4706f94a3109d |
| v2.09 | v2.09 | d046fb7ade61a7d17b5c9f244cdb16e38a097d45 |
