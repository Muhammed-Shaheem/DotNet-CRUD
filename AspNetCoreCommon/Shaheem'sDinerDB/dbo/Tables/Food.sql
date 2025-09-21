CREATE TABLE [dbo].[Food]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(250) NOT NULL, 
    [Price] MONEY NOT NULL
)
