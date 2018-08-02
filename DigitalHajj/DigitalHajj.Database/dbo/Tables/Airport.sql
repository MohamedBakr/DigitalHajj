CREATE TABLE [dbo].[Airport]
(
	[airport_id] INT NOT NULL PRIMARY KEY, 
    [airport_title] NVARCHAR(250) NOT NULL, 
    [lat] NVARCHAR(50) NULL, 
    [lng] NVARCHAR(50) NULL
)
