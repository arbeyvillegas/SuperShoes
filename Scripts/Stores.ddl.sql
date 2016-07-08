IF OBJECT_ID('dbo.Stores', 'U') IS NOT NULL
  DROP TABLE Stores
GO

CREATE TABLE dbo.Stores
(
	[id] int primary key identity(1,1), 
	[name] varchar(256) not null,
	[address] varchar(512) null
)
GO
