CREATE TABLE [dbo].[Camera]
(
	[camera_id] INT NOT NULL PRIMARY KEY, 
    [airport_id] INT NOT NULL, 
    [halltype_id] INT NOT NULL, 
    [camera_name] NVARCHAR(250) NULL
)
