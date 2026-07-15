# UNLOCK_VERSION_GUIDE.md
Quick reference for unlocking the next v3.xx version. See `Version-Control.md`
for the full rollout plan and history — this file is just the repeatable
checklist.

---

## 0. Before you start

```bash
git status
git branch --show-current
```

Must show `On branch master` with a clean tree. If it says
`HEAD detached at <hash>` (happens after `git checkout vX.XX` to inspect a
tagged version), get back on the branch first:

```bash
git checkout master
```

Never make new commits while detached — they won't belong to any branch and
are easy to lose.

---

## 1. Which version unlocks which form

| Version | Feature | `frmMain.vb` handler(s) to swap |
|---------|---------|----------------------------------|
| v3.01 | Dashboard | `frmMain_Load` **and** `btnDashboard_Click` |
| v3.02 | Categories | `btnCategories_Click` |
| v3.03 | Suppliers | `btnSuppliers_Click` |
| v3.04 | Products | `btnProducts_Click` |
| v3.05 | Inventory | `btnInventory_Click` |
| v3.06 | New Sale | `btnNewSale_Click` |
| v3.07 | Sales History | `btnSalesHistory_Click` |
| v3.08 | Reports | `btnReports_Click` |
| v3.09 | Settings (Full System) | `btnSettings_Click` |

Note: v3.01 is the only version that touches two places — `frmMain_Load`
also opens a form directly (the default view on login), same as
`btnDashboard_Click`.

---

## 2. Swap the gate

In `Forms/frmMain.vb`, find the handler(s) for the version you're unlocking.
It currently looks like:

```vb
Private Sub btnCategories_Click(sender As Object, e As EventArgs) Handles btnCategories.Click
    ' GATE — swap to New frmCategories() when unlocking for v3.02
    OpenChildForm(New UnderConstructionForm())
End Sub
```

Change it to:

```vb
Private Sub btnCategories_Click(sender As Object, e As EventArgs) Handles btnCategories.Click
    OpenChildForm(New frmCategories())
End Sub
```

Just delete the `' GATE —` comment line and the `UnderConstructionForm()`
line, replacing the latter with `New <frmName>()`.

---

## 3. Bump the version constant

In `Forms/UnderConstructionForm.vb`:

```vb
Public Const CURRENT_VERSION As String = "v3.02"
```

---

## 4. Build

```bash
cd IMASTS-Inventory-Management-and-Sales-Tracking-System
dotnet build
```

Must show `Build succeeded. 0 Error(s)` before committing.

---

## 5. Commit, tag, push

```bash
git add Forms/frmMain.vb Forms/UnderConstructionForm.vb
git commit -m "feat: implement v3.XX - unlock [Feature Name]"
git tag v3.XX
git push origin master
git push origin v3.XX
```

Replace `v3.XX` and `[Feature Name]` with the actual version/feature from
the table above.

---

## 6. Record the commit hash in the docs

After pushing, get the short hash of the commit you just made:

```bash
git log -1 --format=%h
```

Then in `docs/Version-Control.md`, under **### GitHub Release Tags (v3.xx)**,
add a row:

```
| v3.XX | v3.XX | <hash> |
```

Also update the **Current Rollout** line near the top of
`docs/CURRENT_TASKS.md` to point at the new version and name the next one
in the sequence. Commit and push both doc files:

```bash
git add docs/Version-Control.md docs/CURRENT_TASKS.md
git commit -m "docs: record vX.XX commit hash and update current rollout status"
git push origin master
```

---

## 7. If a tag needs to be redone (feedback after a demo)

Fix on `master` first, then move the tag — see the
**"When a Prof or Client Requests Changes After a Presentation"** section
in `Version-Control.md` for the exact delete/recreate sequence. Never force
a tag update without deleting it first; `git tag -f` locally without also
deleting the remote tag leaves GitHub pointing at the old commit.
