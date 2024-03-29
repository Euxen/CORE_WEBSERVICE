USE [CoreProyectoDB]
GO
/****** Object:  StoredProcedure [dbo].[getAccountByIdentification]    Script Date: 10/11/2019 9:36:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getAccountByIdentification]
(
	@Identifier nvarchar(16)
)
AS
	SET NOCOUNT ON;
SELECT        ACCOUNT_NAME, ACCOUNT_TYPE, ACCOUNT_STATE, BALANCE, OPENDATE
FROM            accountTable
WHERE        (IDENTIFIER = @Identifier)
GO
