USE [CoreProyectoDB]
GO
/****** Object:  StoredProcedure [dbo].[getAccountState]    Script Date: 10/11/2019 9:36:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getAccountState]
(
	@Identifier nvarchar(16),
	@Account_Name nvarchar(128)
)
AS
	SET NOCOUNT ON;
SELECT        ACCOUNT_STATE
FROM            accountTable
WHERE        (IDENTIFIER = @Identifier) AND (ACCOUNT_NAME = @Account_Name)
GO
