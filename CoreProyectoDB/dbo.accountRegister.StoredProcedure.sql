USE [CoreProyectoDB]
GO
/****** Object:  StoredProcedure [dbo].[accountRegister]    Script Date: 10/11/2019 9:36:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[accountRegister]
	@Identifier NVARCHAR(16),
	@Name NVARCHAR(128),
	@Type NVARCHAR(64)
AS
	INSERT INTO dbo.accountTable (IDENTIFIER, ACCOUNT_NAME, ACCOUNT_TYPE) 
	VALUES (@Identifier, @Name, @Type)

	UPDATE dbo.clientTable
	SET ACCOUNTS = ACCOUNTS + 1
	WHERE IDENTIFIER = @Identifier
RETURN 0
GO
