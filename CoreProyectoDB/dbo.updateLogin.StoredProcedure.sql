USE [CoreProyectoDB]
GO
/****** Object:  StoredProcedure [dbo].[updateLogin]    Script Date: 10/11/2019 9:36:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateLogin]
	@Identifier NVARCHAR(16),
	@Password NVARCHAR(256)
AS
	UPDATE dbo.clientTable
	SET LOGDATE = GETDATE()
	WHERE IDENTIFIER = @Identifier AND PASSWORD = @Password
RETURN 0	
GO
