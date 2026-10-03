IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DeskFlowDb')
BEGIN
    CREATE DATABASE DeskFlowDb;
END
GO

USE DeskFlowDb;
GO


IF OBJECT_ID(N'dbo.Categories', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Categories (
        id INT IDENTITY(1,1) NOT NULL,
        name VARCHAR(100) NOT NULL,
        CONSTRAINT PK_Categories PRIMARY KEY CLUSTERED (id ASC)
    );
END
GO

IF OBJECT_ID(N'dbo.Tickets', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Tickets (
        Id INT IDENTITY(1,1) NOT NULL,
        title VARCHAR(150) NOT NULL,
        description VARCHAR(MAX) NOT NULL,
        requester_name VARCHAR(100) NOT NULL,
        status VARCHAR(20) NOT NULL,
        priority VARCHAR(20) NOT NULL,
        opened_date DATETIME NOT NULL,
        closed_date DATETIME NOT NULL,
        solution VARCHAR(MAX) NULL,
        category_id INT NOT NULL,
        CONSTRAINT PK_Tickets PRIMARY KEY CLUSTERED (Id ASC),
        CONSTRAINT FK_Tickets_Categories_category_id FOREIGN KEY (category_id) 
            REFERENCES dbo.Categories (id) 
            ON DELETE CASCADE
    );

    CREATE NONCLUSTERED INDEX IX_Tickets_category_id 
        ON dbo.Tickets (category_id ASC);
END
GO

IF OBJECT_ID(N'dbo.Interactions', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Interactions (
        id INT IDENTITY(1,1) NOT NULL,
        message VARCHAR(MAX) NOT NULL,
        author VARCHAR(100) NOT NULL,
        created_date DATETIME NOT NULL,
        ticket_id INT NOT NULL,
        CONSTRAINT PK_Interactions PRIMARY KEY CLUSTERED (id ASC),
        CONSTRAINT FK_Interactions_Tickets_ticket_id FOREIGN KEY (ticket_id) 
            REFERENCES dbo.Tickets (Id) 
            ON DELETE CASCADE
    );

    CREATE NONCLUSTERED INDEX IX_Interactions_ticket_id 
        ON dbo.Interactions (ticket_id ASC);
END
GO