CREATE TABLE [dbo].[Employee] (
    [Id]          NVARCHAR (36) NOT NULL,
    [Name]        NVARCHAR (30) NOT NULL,
    [Surname]     NVARCHAR (30) NOT NULL,
    [Phone]       NVARCHAR (10) NOT NULL,
    [DateOfBirth] NVARCHAR (10) NOT NULL,
    [Email]       NVARCHAR (50) NOT NULL,
	PRIMARY KEY CLUSTERED ([Id]) 
);

CREATE TABLE [dbo].[Customer] (
    [Id]    NVARCHAR (36) NOT NULL,
    [Name]  NVARCHAR (30) NOT NULL,
    [Siret] NVARCHAR (14) NOT NULL,
    [Phone] NVARCHAR (10) NOT NULL,
    [Email] NVARCHAR (50) NOT NULL,
	PRIMARY KEY CLUSTERED ([Id]) 
);

CREATE TABLE [dbo].[Command] (
    [Id]   NVARCHAR (36) NOT NULL,
	[IdCustomer] NVARCHAR (36) NOT NULL,
    [IdPlan] NVARCHAR (36) NOT NULL,
	[PlanAmount] INT NOT NULL,
	[DeliveryDate] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Plan_Command] FOREIGN KEY ([IdPlan]) REFERENCES [Plan]([Id]), 
	CONSTRAINT [FK_Customer_Command] FOREIGN KEY ([IdCustomer]) REFERENCES [Customer]([Id])
);

CREATE TABLE [dbo].[Plan] (
    [Id]   NVARCHAR (36) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
	[Time] TIME NOT NULL,
	[IdPiece] NVARCHAR (36) NOT NULL,
	PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Piece_Plan] FOREIGN KEY ([IdPiece]) REFERENCES [Piece]([Id]), 
);

CREATE TABLE [dbo].[Piece] (
    [Id]   NVARCHAR (36) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
	[Stock] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([Id]) 
);

CREATE TABLE [dbo].[ProductionChain] (
    [Id]   NVARCHAR (36) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]) 
);

CREATE TABLE [dbo].[PieceProductionChain]
(
	[IdPiece] NVARCHAR(36) NOT NULL , 
	[IdProductionChain] NVARCHAR(36) NOT NULL ,
	
	CONSTRAINT [FK_Piece_PieceProductionChain] FOREIGN KEY ([IdPiece]) REFERENCES [Piece]([Id]), 
	CONSTRAINT [FK_ProductionChain_PieceProductionChain] FOREIGN KEY ([IdProductionChain]) REFERENCES [ProductionChain]([Id]),
);

DROP TABLE [dbo].[PieceProductionChain]

ALTER TABLE [dbo].[Piece]
ADD IdProductionChain NVARCHAR (36) NOT NULL