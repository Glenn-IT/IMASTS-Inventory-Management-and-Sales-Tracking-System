# DATABASE_SCHEMA.md
**Database:** `IMASTS_DB` · SQL Server (Express or LocalDB)

---

## tbl_Users

| Column | Type | Notes |
|--------|------|-------|
| UserID | INT | PK, IDENTITY |
| Username | NVARCHAR(50) | UNIQUE, NOT NULL |
| PasswordHash | NVARCHAR(255) | BCrypt hash — never plain text |
| UserType | NVARCHAR(10) | `'Admin'` or `'Staff'` |
| CreatedAt | DATETIME | default GETDATE() |
| SecurityQuestion | NVARCHAR(255) | NULL until user sets it in Settings; one of `Constants.SecurityQuestions` |
| SecurityAnswerHash | NVARCHAR(255) | BCrypt hash of the (trimmed, lowercased) answer — never plain text |

---

## tbl_Categories

| Column | Type | Notes |
|--------|------|-------|
| CategoryID | INT | PK, IDENTITY |
| CategoryName | NVARCHAR(100) | UNIQUE, NOT NULL |
| DefaultUnit | NVARCHAR(20) | default `'pcs'` (e.g. `'pcs'`, `'box'`, `'case'`, `'pack'`, `'bottle'`, `'can'`, `'kg'`) |

---

## tbl_Suppliers

| Column | Type | Notes |
|--------|------|-------|
| SupplierID | INT | PK, IDENTITY |
| Name | NVARCHAR(100) | NOT NULL |
| ContactPerson | NVARCHAR(100) | |
| Phone | NVARCHAR(20) | |
| Email | NVARCHAR(100) | |
| Address | NVARCHAR(255) | |

---

## tbl_Products

| Column | Type | Notes |
|--------|------|-------|
| ProductID | INT | PK, IDENTITY |
| Name | NVARCHAR(100) | NOT NULL |
| CategoryID | INT | FK → tbl_Categories |
| SupplierID | INT | FK → tbl_Suppliers |
| Description | NVARCHAR(255) | |
| UnitPrice | DECIMAL(10,2) | NOT NULL |
| StockQty | INT | NOT NULL, default 0 |
| Unit | NVARCHAR(20) | default `'pcs'` (e.g. `'pcs'`, `'box'`, `'case'`, `'pack'`) |
| ReorderLevel | INT | NOT NULL, default 0 |

Low-stock condition: `StockQty <= ReorderLevel`

---

## tbl_Sales

| Column | Type | Notes |
|--------|------|-------|
| SaleID | INT | PK, IDENTITY |
| SaleDate | DATETIME | default GETDATE() |
| CashierID | INT | FK → tbl_Users |
| TotalAmount | DECIMAL(10,2) | sum before discount |
| Discount | DECIMAL(10,2) | default 0 |
| NetAmount | DECIMAL(10,2) | TotalAmount − Discount |
| IsVoided | BIT | default 0; set to 1 on void |

---

## tbl_SaleItems

| Column | Type | Notes |
|--------|------|-------|
| SaleItemID | INT | PK, IDENTITY |
| SaleID | INT | FK → tbl_Sales |
| ProductID | INT | FK → tbl_Products |
| Quantity | INT | NOT NULL |
| UnitPrice | DECIMAL(10,2) | price at time of sale |
| Subtotal | DECIMAL(10,2) | Quantity × UnitPrice |

---

## tbl_StockReceipts

| Column | Type | Notes |
|--------|------|-------|
| ReceiptID | INT | PK, IDENTITY |
| ProductID | INT | FK → tbl_Products |
| Quantity | INT | NOT NULL |
| ReceiptDate | DATETIME | default GETDATE() |
| SupplierID | INT | FK → tbl_Suppliers |
| Notes | NVARCHAR(255) | |

---

## tbl_ActivityLogs

| Column | Type | Notes |
|--------|------|-------|
| LogID | INT | PK, IDENTITY |
| Username | NVARCHAR(50) | NOT NULL |
| LogDate | DATETIME | default GETDATE() |
| Result | NVARCHAR(20) | e.g. `'Success'`, `'Failed'` |
| Description | NVARCHAR(255) | human-readable action description |

---

## Seed Data

```sql
-- Default Admin user (password: Admin@123)
INSERT INTO tbl_Users (Username, PasswordHash, UserType)
VALUES ('admin', '<bcrypt_hash_of_Admin@123>', 'Admin')
```

Hash is generated via `PasswordHelper.HashPassword("Admin@123")` at first run.
