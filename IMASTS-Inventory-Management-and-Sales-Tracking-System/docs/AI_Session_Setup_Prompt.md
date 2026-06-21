# AI Session Setup Prompt
> Copy-paste this prompt when starting a **new project** with Claude to replicate the AI_Rules + reference docs pattern.
> Fill in every `[PLACEHOLDER]` before sending.

---

## Prompt to Send to Claude

```
I am building a [VB.NET / C# / etc.] [Windows Forms / WPF / Web / etc.] application.

Before doing any work, read the rules below and set up the reference docs for this project.

---

## AI Rules for This Session

- Read this prompt first before doing any work.
- Minimize token and credit usage.
- Do not scan the entire project automatically.
- Do not search for related files unless necessary.
- Ask permission before opening additional files.
- Work only with files I explicitly mention.
- Use PROJECT_STRUCTURE.md as the primary project map.
- Use DATABASE_SCHEMA.md for database references.
- Use CURRENT_TASKS.md for current development status.
- Do not inspect the repository to understand the system if the information exists in those files.
- Analyze first before making changes.
- Show which files need modification.
- Modify only the requested files.
- Preserve existing architecture and naming conventions.
- Do not refactor unrelated code.
- Be concise. Provide exact code changes. Avoid unnecessary explanations.
- If information is missing, ask before searching the project.

Priority order for reference: AI_Rules.md → CURRENT_TASKS.md → PROJECT_STRUCTURE.md → DATABASE_SCHEMA.md → requested file(s) only.

---

## Project Details

**Project Name:** [YOUR PROJECT NAME]
**Platform:** [e.g., VB.NET · Windows Forms · .NET 8.0]
**Database:** [e.g., SQL Server Express — instance: SERVER\INSTANCE — database: DB_NAME]
**Status:** Ongoing
**Author:** [YOUR NAME]

---

## Overview

[1–3 sentences describing what the system does and who it's for.]

---

## Goals

1. [Goal 1]
2. [Goal 2]
3. [Goal 3]

---

## Folder Structure

[Paste your project folder layout here. Example:]

ProjectName/
├── DataAccess/
│   └── (repository modules)
├── Helpers/
│   └── (session, input, password, logging helpers)
├── Forms/
│   └── (all .vb form files)
├── docs/
└── config.txt.example

---

## Architecture Rules

[List the coding rules AI must follow. Example:]

- No SQL in forms — all queries in DataAccess/ modules only
- Always use Using blocks for SqlConnection and SqlCommand
- Always use Parameters.AddWithValue — never concatenate SQL
- Passwords hashed with BCrypt — never stored plain text
- Log every CRUD action via ActivityLogger.Log(user, result, description)
- SanitizeInput() on all user-supplied text

---

## Control Naming Conventions

[List your prefix conventions. Example:]

txt = TextBox, btn = Button, dgv = DataGridView, lbl = Label,
cbo = ComboBox, pnl = Panel, dtp = DateTimePicker, chk = CheckBox

---

## Database Tables

[List your tables and key columns. Example:]

tbl_Users     — UserID · Username · PasswordHash · UserType · CreatedAt
tbl_Products  — ProductID · Name · CategoryID · UnitPrice · StockQty · ReorderLevel
...

---

## Modules / Pages

[List the main forms or modules. Example:]

[1] Authentication   [2] Dashboard   [3] Product Management
[4] Inventory        [5] Sales        [6] Reports

---

## Current Phase / Active Task

[Describe what is done and what needs to be built next. Example:]

- Phase 1 (Setup): DONE
- Phase 2 (Login form): DONE
- Phase 3 (Main shell): DONE
- Phase 4 (Dashboard): NEXT — build frmDashboard with 4 summary cards and DashboardRepository

---

## Connection Pattern (if applicable)

[Describe how DB connections work. Example:]

- Connection string stored in config.txt next to the .exe — never committed to git
- Read at runtime by dbconstring.vb (Public Class dbconstring, Shared ReadOnly Property Connection)
- config.txt.example committed as format reference

---

Now please create the following files in docs/:

1. AI_Rules.md          — the session rules listed above
2. PROJECT_STRUCTURE.md — folder map, architecture rules, conventions, tech stack
3. DATABASE_SCHEMA.md   — all tables with column names, types, FK notes
4. CURRENT_TASKS.md     — phase status table + active task checklist

Use the project details I provided above to populate each file.
From now on, follow the AI Rules for every response in this session.
```

---

## What This Sets Up

| File | Purpose |
|------|---------|
| `docs/AI_Rules.md` | Rules Claude follows every session — read first, minimize scans, ask before opening files |
| `docs/PROJECT_STRUCTURE.md` | Folder layout, architecture rules, naming conventions, tech stack |
| `docs/DATABASE_SCHEMA.md` | All tables with columns, types, FK relationships |
| `docs/CURRENT_TASKS.md` | Phase-by-phase status + active checklist — update this as you progress |

---

## How to Use on a New Project

1. Copy the prompt block above.
2. Fill in every `[PLACEHOLDER]`.
3. Paste it as your **first message** to Claude in a new project session.
4. Claude will create the 4 docs and follow the rules for the rest of the session.
5. At the start of **every future session**, tell Claude: _"Read docs/AI_Rules.md first."_
6. Update `CURRENT_TASKS.md` whenever you finish a phase or start a new one.

---

## Tips

- The more detail you put in the prompt, the better the generated docs will be.
- You don't need to fill in every section — skip what's not relevant to your project.
- After the docs are created, you only need to paste a short reminder at the start of future sessions:
  > _"Read docs/AI_Rules.md. Use PROJECT_STRUCTURE.md, DATABASE_SCHEMA.md, and CURRENT_TASKS.md as your reference — do not scan the project."_
