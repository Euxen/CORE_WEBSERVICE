USE [CoreProyectoDB]
GO
/****** Object:  StoredProcedure [dbo].[clientSubscribe]    Script Date: 10/11/2019 9:36:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[clientSubscribe]
	@Identifier NVARCHAR(16)
AS
	UPDATE dbo.clientTable
	SET STATE = 'SUSCRITO'
	WHERE IDENTIFIER = @Identifier;

	UPDATE dbo.accountTable
	SET ACCOUNT_STATE = 'ACTIVA'
	WHERE IDENTIFIER = @Identifier;
RETURN 0
GO
