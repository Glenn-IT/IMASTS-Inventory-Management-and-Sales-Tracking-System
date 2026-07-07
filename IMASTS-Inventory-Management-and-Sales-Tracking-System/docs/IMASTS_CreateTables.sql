-- ============================================================
-- IMASTS — Inventory Management and Sales Tracking System
-- Database Setup Script
-- Run this against: Glenn\SQLEXPRESS > IMASTS_DB
-- ============================================================

USE IMASTS_DB;
GO

-- ------------------------------------------------------------
-- tbl_Users
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tbl_Users' AND xtype='U')
CREATE TABLE tbl_Users (
    UserID             INT           IDENTITY(1,1) PRIMARY KEY,
    Username           NVARCHAR(50)  NOT NULL UNIQUE,
    PasswordHash       NVARCHAR(255) NOT NULL,
    UserType           NVARCHAR(20)  NOT NULL DEFAULT 'Staff',  -- 'Admin' or 'Staff'
    CreatedAt          DATETIME      NOT NULL DEFAULT GETDATE(),
    SecurityQuestion   NVARCHAR(255) NULL,
    SecurityAnswerHash NVARCHAR(255) NULL
);
GO

-- Add security question columns to an already-existing tbl_Users (upgrade path)
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('tbl_Users') AND name = 'SecurityQuestion')
ALTER TABLE tbl_Users ADD SecurityQuestion NVARCHAR(255) NULL;
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('tbl_Users') AND name = 'SecurityAnswerHash')
ALTER TABLE tbl_Users ADD SecurityAnswerHash NVARCHAR(255) NULL;
GO

-- ------------------------------------------------------------
-- tbl_Categories
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tbl_Categories' AND xtype='U')
CREATE TABLE tbl_Categories (
    CategoryID   INT           IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL UNIQUE
);
GO

-- ------------------------------------------------------------
-- tbl_Suppliers
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tbl_Suppliers' AND xtype='U')
CREATE TABLE tbl_Suppliers (
    SupplierID    INT           IDENTITY(1,1) PRIMARY KEY,
    Name          NVARCHAR(100) NOT NULL,
    ContactPerson NVARCHAR(100) NULL,
    Phone         NVARCHAR(30)  NULL,
    Email         NVARCHAR(100) NULL,
    Address       NVARCHAR(255) NULL
);
GO

-- ------------------------------------------------------------
-- tbl_Products
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tbl_Products' AND xtype='U')
CREATE TABLE tbl_Products (
    ProductID    INT            IDENTITY(1,1) PRIMARY KEY,
    Name         NVARCHAR(150)  NOT NULL,
    Description  NVARCHAR(500)  NULL,
    CategoryID   INT            NULL REFERENCES tbl_Categories(CategoryID),
    SupplierID   INT            NULL REFERENCES tbl_Suppliers(SupplierID),
    UnitPrice    DECIMAL(18,2)  NOT NULL DEFAULT 0.00,
    StockQty     INT            NOT NULL DEFAULT 0,
    ReorderLevel INT            NOT NULL DEFAULT 0,
    CreatedAt    DATETIME       NOT NULL DEFAULT GETDATE()
);
GO

-- ------------------------------------------------------------
-- tbl_Sales
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tbl_Sales' AND xtype='U')
CREATE TABLE tbl_Sales (
    SaleID      INT           IDENTITY(1,1) PRIMARY KEY,
    SaleDate    DATETIME      NOT NULL DEFAULT GETDATE(),
    CashierID   INT           NOT NULL REFERENCES tbl_Users(UserID),
    TotalAmount DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    Discount    DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    NetAmount   DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    IsVoided    BIT           NOT NULL DEFAULT 0
);
GO

-- ------------------------------------------------------------
-- tbl_SaleItems
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tbl_SaleItems' AND xtype='U')
CREATE TABLE tbl_SaleItems (
    SaleItemID INT           IDENTITY(1,1) PRIMARY KEY,
    SaleID     INT           NOT NULL REFERENCES tbl_Sales(SaleID),
    ProductID  INT           NOT NULL REFERENCES tbl_Products(ProductID),
    Quantity   INT           NOT NULL,
    UnitPrice  DECIMAL(18,2) NOT NULL,
    Subtotal   DECIMAL(18,2) NOT NULL
);
GO

-- ------------------------------------------------------------
-- tbl_StockReceipts
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tbl_StockReceipts' AND xtype='U')
CREATE TABLE tbl_StockReceipts (
    ReceiptID   INT           IDENTITY(1,1) PRIMARY KEY,
    ProductID   INT           NOT NULL REFERENCES tbl_Products(ProductID),
    SupplierID  INT           NULL REFERENCES tbl_Suppliers(SupplierID),
    Quantity    INT           NOT NULL,
    ReceiptDate DATETIME      NOT NULL DEFAULT GETDATE(),
    Notes       NVARCHAR(500) NULL
);
GO

-- ------------------------------------------------------------
-- tbl_ActivityLogs
-- ------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tbl_ActivityLogs' AND xtype='U')
CREATE TABLE tbl_ActivityLogs (
    LogID       INT           IDENTITY(1,1) PRIMARY KEY,
    Username    NVARCHAR(50)  NOT NULL,
    LogDate     DATETIME      NOT NULL DEFAULT GETDATE(),
    Result      NVARCHAR(20)  NOT NULL,   -- 'Success' or 'Failed'
    Description NVARCHAR(500) NOT NULL
);
GO

-- ------------------------------------------------------------
-- Verify all tables created
-- ------------------------------------------------------------
SELECT TABLE_NAME
FROM   INFORMATION_SCHEMA.TABLES
WHERE  TABLE_TYPE = 'BASE TABLE'
ORDER  BY TABLE_NAME;
GO
