USE [CoreProyectoDB]
GO
/****** Object:  StoredProcedure [dbo].[accountReactivate]    Script Date: 10/11/2019 9:36:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[accountReactivate]
	@Identifier NVARCHAR(16),
	@Name NVARCHAR(128)
AS
	UPDATE dbo.accountTable
	SET ACCOUNT_STATE = 'ACTIVA'
	WHERE IDENTIFIER = @Identifier AND ACCOUNT_NAME = @Name;
RETURN 0
GO
