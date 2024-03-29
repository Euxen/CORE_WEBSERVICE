USE [CoreProyectoDB]
GO
/****** Object:  StoredProcedure [dbo].[bankTransfer]    Script Date: 10/11/2019 9:36:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[bankTransfer]
	@Amount DECIMAL,
	@Identifier1 NVARCHAR(16),
	@Name1 NVARCHAR(128),
	@Identifier2 NVARCHAR(16),
	@Name2 NVARCHAR(128),
	@Description NVARCHAR(MAX)
AS
	UPDATE dbo.accountTable
	SET BALANCE = BALANCE - @Amount
	WHERE IDENTIFIER = @Identifier1 AND ACCOUNT_NAME = @Name1

	UPDATE dbo.accountTable
	SET BALANCE = BALANCE + @Amount
	WHERE IDENTIFIER = @Identifier2 AND ACCOUNT_NAME = @Name2

	INSERT INTO dbo.transactionTable (IDENTIFIER_ROOT, IDENTIFIER_AFFECTED, ACCOUNT_ROOT, ACCOUNT_AFFECTED, TYPE, DESCRIPTION, BALANCE)
	VALUES (@Identifier1, @Identifier2, @Name1, @Name2, 'TRANSFERENCIA', @Description, @Amount)
RETURN 0
GO
