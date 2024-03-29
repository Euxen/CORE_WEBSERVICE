USE [CoreProyectoDB]
GO
/****** Object:  Table [dbo].[transactionTable]    Script Date: 10/11/2019 9:36:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transactionTable](
	[IDENTIFIER_ROOT] [nvarchar](16) NOT NULL,
	[IDENTIFIER_AFFECTED] [nvarchar](16) NOT NULL,
	[ACCOUNT_ROOT] [nvarchar](128) NOT NULL,
	[ACCOUNT_AFFECTED] [nvarchar](128) NOT NULL,
	[TYPE] [nvarchar](16) NOT NULL,
	[TRANSDATE] [datetime] NOT NULL,
	[DESCRIPTION] [nvarchar](max) NOT NULL,
	[BALANCE] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_transactionTable] PRIMARY KEY CLUSTERED 
(
	[TRANSDATE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[transactionTable] ADD  CONSTRAINT [DF_transactionTable_TRANSDATE]  DEFAULT (getdate()) FOR [TRANSDATE]
GO
