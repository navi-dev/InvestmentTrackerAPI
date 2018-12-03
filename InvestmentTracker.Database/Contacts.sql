CREATE TABLE [dbo].[Contacts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Mobile] NVARCHAR(50) NULL, 
    [ContactType] SMALLINT NOT NULL, 
    [CreatedDate] DATETIME NULL, 
    [CreatedBy] INT NULL, 
    [EmailId] NVARCHAR(50) NULL
)
