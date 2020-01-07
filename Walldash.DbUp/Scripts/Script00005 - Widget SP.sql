
-- Get
CREATE OR ALTER PROCEDURE dbo.[Widget_Get]
(
	@AccountId int,
	@WidgetId int
)
AS
    SET NOCOUNT ON;

	SELECT
		w.Id,
		w.Alias,
		w.DashboardId,
		w.MetricAlias,
		w.WidgetType,
		w.Width,
		w.Height
	FROM 
		dbo.Widget w
	INNER JOIN dbo.Dashboard d ON  d.Id = w.DashboardId
	WHERE 
		d.AccountId = @AccountId
	AND w.Id = @WidgetId
GO

-- Get All
CREATE OR ALTER PROCEDURE dbo.[Widget_GetByDashboardId]
(
	@AccountId int,
	@DashboardId int
)
AS
    SET NOCOUNT ON;

	SELECT
		w.Id,
		w.Alias,
		w.DashboardId,
		w.MetricAlias,
		w.WidgetType,
		w.Width,
		w.Height
	FROM 
		dbo.Widget w
	INNER JOIN dbo.Dashboard d ON  d.Id = w.DashboardId
	WHERE 
		d.AccountId = @AccountId
	AND w.DashboardId = @DashboardId
GO

-- Save
CREATE OR ALTER PROCEDURE dbo.[Widget_Save]
(
	@AccountId int,
	@Alias nvarchar(100),
	@DashboardId int,
	@MetricAlias nvarchar(100),
	@Type nvarchar(100),
	@Width int,
	@Height int
)				
AS
    SET NOCOUNT ON;

	IF EXISTS(SELECT 1 FROM dbo.Dashboard WHERE AccountId = @AccountId AND Id = @DashboardId)
	BEGIN
		INSERT INTO dbo.Widget(Alias, DashboardId, MetricAlias, WidgetType, Width, Height) 
		VALUES(@Alias, @DashboardId, @MetricAlias, @Type, @Width, @Height)
		SELECT SCOPE_IDENTITY();
	END
GO

-- Update
CREATE OR ALTER PROCEDURE dbo.[Widget_Update]
(
	@WidgetId int,
	@Alias nvarchar(100),
	@AccountId int,
	@DashboardId int,
	@MetricAlias nvarchar(100),
	@Type nvarchar(100),
	@Width int,
	@Height int
)				
AS
    SET NOCOUNT ON;

	IF EXISTS(SELECT 1 FROM dbo.Dashboard WHERE Id = @DashboardId AND AccountId = @AccountId)
	BEGIN
		UPDATE w
		SET
			w.Alias = @Alias,
			w.DashboardId = @DashboardId,
			w.MetricAlias = @MetricAlias,
			w.WidgetType = @Type,
			w.Width = @Width,
			w.Height = @Height
		FROM dbo.Widget w
	INNER JOIN dbo.Dashboard d ON  d.Id = w.DashboardId
	WHERE 
		d.AccountId = @AccountId
	AND w.Id = @WidgetId
	END
GO

-- Delete
CREATE OR ALTER PROCEDURE dbo.[Widget_Delete]
(
	@WidgetId int,
	@AccountId int
)				
AS
    SET NOCOUNT ON;

	DELETE w
	FROM 
		dbo.Widget w
	INNER JOIN dbo.Dashboard d ON  d.Id = w.DashboardId
	WHERE 
		d.AccountId = @AccountId
	AND	w.Id = @WidgetId
GO