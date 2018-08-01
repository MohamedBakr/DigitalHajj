CREATE TABLE [dbo].[CameraEvent]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [camera_id] INT NULL, 
	[channel_id] NVARCHAR(50) NULL, 
    [channel_name] NVARCHAR(250) NULL, 
    [event_id] NVARCHAR(250) NULL, 
    [object_id] NVARCHAR(250) NULL, 
    [origin] NVARCHAR(250) NULL, 
    [rule_id] NVARCHAR(250) NULL, 
    [rule_name] NVARCHAR(250) NULL, 
    [snapshot_path] NVARCHAR(250) NULL, 
    [time] DATETIME NULL, 
    [timestamp] NVARCHAR(250) NULL, 
    [type] NVARCHAR(250) NULL, 
    [video_file_name] NVARCHAR(250) NULL, 
    [video_file_time] NVARCHAR(250) NULL
)
