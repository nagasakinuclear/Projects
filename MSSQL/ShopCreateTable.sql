CREATE TABLE [dbo].[Customers] (
    [Id] INT NOT NULL,
    [Name] NVARCHAR(50) NOT NULL, 
    [Fname] NVARCHAR(50) NOT NULL, 
    [PhoneNumber] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
CREATE TABLE [dbo].[Groups] (
    [Id]     INT           NOT NULL,
    [Name]   NVARCHAR (50) NOT NULL,
    [ImgSrc] NCHAR (40)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Date] DATE NOT NULL, 
    [ProductId] INT NOT NULL, 
    [CustomerId] INT NOT NULL, 
    CONSTRAINT fk_PerProduct FOREIGN KEY (ProductId)
	REFERENCES Products(Id),
	CONSTRAINT fk_PerCustomer FOREIGN KEY (CustomerId)
	REFERENCES Customers(Id)

)
GO
CREATE TABLE [dbo].[Products] (
    [Id]          INT            NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [GroupId]     INT            NOT NULL,
    [Price]       FLOAT (53)     NOT NULL,
    [Count]       INT            NOT NULL,
    [Description] NVARCHAR (900) NOT NULL,
    [ImgSrc]      NCHAR (50)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT fk_PerGroup  FOREIGN KEY (GroupId) 
	REFERENCES Groups(Id)
);

GO
