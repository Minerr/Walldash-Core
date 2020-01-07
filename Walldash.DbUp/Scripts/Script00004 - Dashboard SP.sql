-- Get
CREATE OR ALTER PROCEDURE dbo.[Dashboard_Get]
(
	@AccountId int,
	@DashboardId int
)
AS
    SET NOCOUNT ON;

	SELECT
		d.Id,
		d.Alias
	FROM 
		dbo.Dashboard d
	WHERE 
		d.AccountId = @AccountId
	AND d.Id = @DashboardId
GO

-- Get All
CREATE OR ALTER PROCEDURE dbo.[Dashboard_GetAll]
(
	@AccountId int
)
AS
    SET NOCOUNT ON;

	SELECT
		d.Id,
		d.Alias
	FROM 
		dbo.Dashboard d
	WHERE 
		d.AccountId = @AccountId
GO

-- Save
CREATE OR ALTER PROCEDURE dbo.[Dashboard_Save]
(
	@AccountId int,
	@Alias nvarchar(100)
)				
AS
    SET NOCOUNT ON;

    INSERT INTO dbo.Dashboard(AccountId, Alias) 
	VALUES(@AccountId, @Alias)

    SELECT SCOPE_IDENTITY();
GO

-- Update
CREATE OR ALTER PROCEDURE dbo.[Dashboard_Update]
(
	@DashboardId int,
	@AccountId int,
	@Alias nvarchar(100)
)				
AS
    SET NOCOUNT ON;

	BEGIN
		UPDATE d
		SET
			d.Alias = @Alias
		FROM dbo.Dashboard d
		WHERE
			d.AccountId = @AccountId
		AND d.Id = @DashboardId
	END
GO

-- Delete
CREATE OR ALTER PROCEDURE dbo.[Dashboard_Delete]
(
	@DashboardId int,
	@AccountId int
)				
AS
    SET NOCOUNT ON;

	BEGIN
		DELETE 
		FROM 
			dbo.Dashboard
		WHERE 
			AccountId = @AccountId
		AND	Id = @DashboardId
	END
GO