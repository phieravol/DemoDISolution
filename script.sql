USE [ChatHubLab3]
GO
/****** Object:  User [phinq]    Script Date: 3/15/2023 10:05:10 AM ******/
CREATE USER [phinq] FOR LOGIN [phinq] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 3/15/2023 10:05:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[MessageContent] [nvarchar](1000) NULL,
	[SendUser] [nchar](50) NULL,
	[ReceivedUser] [nchar](50) NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/15/2023 10:05:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserName] [nchar](50) NOT NULL,
	[FullName] [nvarchar](150) NULL,
	[ConnectionId] [varchar](250) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[User] ([UserName], [FullName], [ConnectionId]) VALUES (N'ductv                                             ', N'Tran Van Duc', NULL)
INSERT [dbo].[User] ([UserName], [FullName], [ConnectionId]) VALUES (N'lamnt                                             ', N'Nguyen Thanh Lam', NULL)
INSERT [dbo].[User] ([UserName], [FullName], [ConnectionId]) VALUES (N'phinq                                             ', N'Nguyen Quoc Phi', NULL)
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_User] FOREIGN KEY([SendUser])
REFERENCES [dbo].[User] ([UserName])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_User]
GO
