USE [CoreProyectoDB]
GO
/****** Object:  Table [dbo].[clientTable]    Script Date: 10/11/2019 9:36:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientTable](
	[IDENTIFIER] [nvarchar](16) NOT NULL,
	[NAME] [nvarchar](128) NOT NULL,
	[LAST] [nvarchar](128) NOT NULL,
	[ACCOUNTS] [int] NOT NULL,
	[PASSWORD] [nvarchar](256) NOT NULL,
	[PIN] [nvarchar](8) NOT NULL,
	[DIRECTION] [nvarchar](128) NOT NULL,
	[EMAIL] [nvarchar](64) NOT NULL,
	[STATE] [nvarchar](16) NOT NULL,
	[REGDATE] [datetime] NOT NULL,
	[LOGDATE] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDENTIFIER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[clientTable] ADD  DEFAULT ((0)) FOR [ACCOUNTS]
GO
ALTER TABLE [dbo].[clientTable] ADD  DEFAULT ('SUSCRITO') FOR [STATE]
GO
ALTER TABLE [dbo].[clientTable] ADD  CONSTRAINT [DF_clientTable_REGDATE]  DEFAULT (getdate()) FOR [REGDATE]
GO
