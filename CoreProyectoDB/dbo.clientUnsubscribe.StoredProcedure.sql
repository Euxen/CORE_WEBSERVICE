USE [CoreProyectoDB]
GO
/****** Object:  StoredProcedure [dbo].[clientUnsubscribe]    Script Date: 10/11/2019 9:36:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[clientUnsubscribe]
	@Identifier NVARCHAR(16)
AS
	UPDATE dbo.clientTable
	SET STATE = 'INSUSCRITO'
	WHERE IDENTIFIER = @Identifier;

	UPDATE dbo.accountTable
	SET ACCOUNT_STATE = 'ARCHIVADA'
	WHERE IDENTIFIER = @Identifier;
RETURN 0
GO
