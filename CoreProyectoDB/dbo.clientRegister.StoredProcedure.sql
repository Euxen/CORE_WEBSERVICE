USE [CoreProyectoDB]
GO
/****** Object:  StoredProcedure [dbo].[clientRegister]    Script Date: 10/11/2019 9:36:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[clientRegister]
	@Identifier NVARCHAR(16),
	@Name NVARCHAR(128),
	@Last NVARCHAR(128),
	@Password NVARCHAR(256),
	@Pin NVARCHAR(8),
	@Direction NVARCHAR(128),
	@Email NVARCHAR(64)
AS
	INSERT INTO dbo.clientTable (IDENTIFIER, NAME, LAST, PASSWORD, PIN, DIRECTION, EMAIL)
	VALUES (@Identifier, @Name, @Last, @Password, @Pin, @Direction, @Email)
GO
