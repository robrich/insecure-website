SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Salt], [IsAdmin]) VALUES (1, N'Adam', N'secret', REPLACE(CAST( NEWID() AS nvarchar(100)), '-', ''), 0)
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Salt], [IsAdmin]) VALUES (2, N'Bob', N'secret', REPLACE(CAST( NEWID() AS nvarchar(100)), '-', ''), 0)
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Salt], [IsAdmin]) VALUES (3, N'Carl', N'password', REPLACE(CAST( NEWID() AS nvarchar(100)), '-', ''), 1)
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Salt], [IsAdmin]) VALUES (4, N'Rob', N'password', REPLACE(CAST( NEWID() AS nvarchar(100)), '-', ''), 0)
INSERT INTO [dbo].[User] ([UserId], [Username], [Password], [Salt], [IsAdmin]) VALUES (5, N'David', N'secret', REPLACE(CAST( NEWID() AS nvarchar(100)), '-', ''), 0)
SET IDENTITY_INSERT [dbo].[User] OFF
