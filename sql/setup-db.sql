-- Step 1: Create the database in SQL Server.
-- Assumes the database doesn't already exist
CREATE DATABASE InsecureWebsite
GO
-- Step 2: Use this database for the rest of the queries we'll do
USE InsecureWebsite
GO
-- Step 3: Create the TABLE
CREATE TABLE [dbo].[User]
(
[UserId] [int] NOT NULL IDENTITY(1, 1),
[Username] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Password] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Salt] [nvarchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsAdmin] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED  ([UserId]) ON [PRIMARY]
GO
-- Step 4: Add data to the table
-- Assumes the table is empty
SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Salt], [IsAdmin]) VALUES (1, N'Adam', N'secret', REPLACE(CAST( NEWID() AS nvarchar(100)), '-', ''), 0)
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Salt], [IsAdmin]) VALUES (2, N'Bob', N'secret', REPLACE(CAST( NEWID() AS nvarchar(100)), '-', ''), 0)
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Salt], [IsAdmin]) VALUES (3, N'Carl', N'password', REPLACE(CAST( NEWID() AS nvarchar(100)), '-', ''), 1)
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Salt], [IsAdmin]) VALUES (4, N'Rob', N'password', REPLACE(CAST( NEWID() AS nvarchar(100)), '-', ''), 0)
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Salt], [IsAdmin]) VALUES (5, N'David', N'secret', REPLACE(CAST( NEWID() AS nvarchar(100)), '-', ''), 0)
SET IDENTITY_INSERT [dbo].[User] OFF


-- When you're done, uncomment these commands to destroy the database you created:
/*
USE Master
GO
DROP DATABASE InsecureWebsite
*/
