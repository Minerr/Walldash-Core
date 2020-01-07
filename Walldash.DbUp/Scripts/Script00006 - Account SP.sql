-- Get
CREATE OR ALTER PROCEDURE dbo.[Account_GetIdByToken]
(
	@Token UNIQUEIDENTIFIER
)
AS
    SET NOCOUNT ON;

	SELECT TOP(1)
		a.Id
	FROM
		dbo.Account a
	WHERE 
		a.Token = @Token
GO