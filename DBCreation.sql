CREATE TABLE [dbo].[ProductionChain] (
    [Id]   NVARCHAR (36) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]) 
)

CREATE TABLE [dbo].[Customer] (
    [Id]    NVARCHAR (36) NOT NULL,
    [Name]  NVARCHAR (30) NOT NULL,
    [Siret] NVARCHAR (14) NOT NULL,
    [Phone] NVARCHAR (10) NOT NULL,
    [Email] NVARCHAR (50) NOT NULL,
	PRIMARY KEY CLUSTERED ([Id]) 
);

CREATE TABLE [dbo].[Employee] (
    [Id]          NVARCHAR (36) NOT NULL,
    [Name]        NVARCHAR (30) NOT NULL,
    [Surname]     NVARCHAR (30) NOT NULL,
    [Phone]       NVARCHAR (10) NOT NULL,
    [DateOfBirth] NVARCHAR (10) NOT NULL,
    [Email]       NVARCHAR (50) NOT NULL,
	PRIMARY KEY CLUSTERED ([Id]) 
);

CREATE TABLE [dbo].[Piece] (
    [Id]   NVARCHAR (36) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
	PRIMARY KEY CLUSTERED ([Id]) 
);

CREATE TABLE [dbo].[Plan] (
    [Id]   NVARCHAR (36) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
	PRIMARY KEY CLUSTERED ([Id]) 
);

CREATE TABLE [dbo].[PlanPiece] (
    [IdPlan]  NVARCHAR (36) NOT NULL,
    [IdPiece] NVARCHAR (36) NOT NULL,
	CONSTRAINT [FK_Plan_PlanPiece] FOREIGN KEY ([IdPlan]) REFERENCES [Plan]([Id]), 
	CONSTRAINT [FK_Piece_PlanPiece] FOREIGN KEY ([IdPiece]) REFERENCES [Piece]([Id]),
);

CREATE TABLE [dbo].[PieceProductionChain]
(
	[IdPiece] NVARCHAR(36) NOT NULL , 
	[IdProductionChain] NVARCHAR(36) NOT NULL ,
	CONSTRAINT [FK_Piece_PieceProductionChain] FOREIGN KEY ([IdPiece]) REFERENCES [Piece]([Id]), 
	CONSTRAINT [FK_ProductionChain_PieceProductionChain] FOREIGN KEY ([IdProductionChain]) REFERENCES [ProductionChain]([Id]),
)

