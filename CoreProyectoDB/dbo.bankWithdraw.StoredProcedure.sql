USE [CoreProyectoDB]
GO
/****** Object:  StoredProcedure [dbo].[bankWithdraw]    Script Date: 10/11/2019 9:36:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[bankWithdraw]
	@Amount DECIMAL,
	@Identifier NVARCHAR(16),
	@Name NVARCHAR(128),
	@Description NVARCHAR(MAX)
AS
	UPDATE dbo.accountTable
	SET BALANCE = BALANCE - @Amount
	WHERE IDENTIFIER = @Identifier AND ACCOUNT_NAME = @Name

	INSERT INTO dbo.transactionTable (IDENTIFIER_ROOT, IDENTIFIER_AFFECTED, ACCOUNT_ROOT, ACCOUNT_AFFECTED, TYPE, DESCRIPTION, BALANCE)
	VALUES (@Identifier, 'N/A', @Name, 'N/A', 'RETIRO', @Description, @Amount)
RETURN 0
GO
