IF OBJECT_ID('dbo.Articles', 'U') IS NOT NULL
  DROP TABLE Articles
GO

CREATE TABLE dbo.Articles
(
	
	[id] int primary key identity(1,1), 
	[name] varchar(256) not null,
	[description] varchar(512) null, 
	[price] numeric (20,2) not null,
	[total_in_shelf] int default 0 not null,
	[total_in_vault] int default 0 not null,
	[store_id] int not null
    CONSTRAINT FK_STORES_ARTICLES FOREIGN KEY ([store_id]) REFERENCES Stores([id])
)
GO
