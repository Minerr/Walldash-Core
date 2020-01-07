-- Get
CREATE OR ALTER PROCEDURE dbo.[Metric_Get]
(
	@AccountId int,
	@MetricId int
)
AS
    SET NOCOUNT ON;

	SELECT
		m.Id,
		m.Alias,
		m.Number,
		m.Timestamp
	FROM 
		dbo.Metric m
	WHERE 
		m.AccountId = @AccountId
	AND m.Id = @MetricId
	ORDER BY m.Timestamp DESC
GO

-- Get All
CREATE OR ALTER PROCEDURE dbo.[Metric_GetAll]
(
	@AccountId int
)
AS
    SET NOCOUNT ON;

	SELECT
		m.Id,
		m.Alias,
		m.Number,
		m.Timestamp
	FROM 
		dbo.Metric m
	WHERE 
		m.AccountId = @AccountId
	ORDER BY m.Timestamp DESC
GO

-- Save
CREATE OR ALTER PROCEDURE dbo.[Metric_Save]
(
	@AccountId int,
	@Alias nvarchar(100),			
	@Number float,	
	@Timestamp datetimeoffset
)				
AS
    SET NOCOUNT ON;

    INSERT INTO dbo.Metric(AccountId, Alias, Number, Timestamp) 
	VALUES(@AccountId, @Alias, @Number, @Timestamp)

    SELECT SCOPE_IDENTITY();
GO

-- Update
CREATE OR ALTER PROCEDURE dbo.[Metric_Update]
(
	@MetricId int,
	@AccountId int,
	@Alias nvarchar(100),			
	@Number float,	
	@Timestamp datetimeoffset
)				
AS
    SET NOCOUNT ON;

	BEGIN
		UPDATE m
		SET
			m.Alias = @Alias,
			m.Number = @Number,
			m.Timestamp = @Timestamp
		FROM dbo.Metric m
		WHERE
			m.AccountId = @AccountId
		AND m.Id = @MetricId
	END
GO

-- Delete
CREATE OR ALTER PROCEDURE dbo.[Metric_Delete]
(
	@MetricId int,
	@AccountId int
)				
AS
    SET NOCOUNT ON;

	BEGIN
		DELETE 
		FROM 
			dbo.Metric
		WHERE 
			AccountId = @AccountId
		AND	Id = @MetricId
	END
GO

-- Get all by Alias
CREATE OR ALTER PROCEDURE dbo.[Metric_GetAllByAlias]
(
	@AccountId int,
	@Alias nvarchar(100)
)
AS
    SET NOCOUNT ON;

	SELECT
		m.Id,
		m.Alias,
		m.Number,
		m.Timestamp
	FROM 
		dbo.Metric m
	WHERE 
		m.AccountId = @AccountId
	AND m.Alias = @Alias
	ORDER BY m.Timestamp DESC
GO

-- Get all by datetime
CREATE OR ALTER PROCEDURE dbo.[Metric_GetAllByPeriod]
(
	@AccountId int,
	@Alias nvarchar(100),
	@DateFrom datetimeoffset,
	@DateTo datetimeoffset
)
AS
    SET NOCOUNT ON;

	SELECT
		m.Id,
		m.Alias,
		m.Number,
		m.Timestamp
	FROM 
		dbo.Metric m
	WHERE 
		m.AccountId = @AccountId
	AND m.Alias = @Alias
	AND m.Timestamp BETWEEN @DateFrom AND @DateTo
	ORDER BY m.Timestamp DESC
GO


-- Get all aliases
CREATE OR ALTER PROCEDURE dbo.[Metric_GetAliases]
(
	@AccountId int
)
AS
    SET NOCOUNT ON;

	SELECT
		DISTINCT(m.Alias)
	FROM 
		dbo.Metric m
	WHERE 
		m.AccountId = @AccountId
	ORDER BY m.Alias ASC
GO

-- Get the latest metric
CREATE OR ALTER PROCEDURE dbo.[Metric_GetLatest]
(
	@AccountId int,
	@Alias nvarchar(100)
)
AS
    SET NOCOUNT ON;

	SELECT TOP 1
		m.Id,
		m.Alias,
		m.Number,
		m.Timestamp
	FROM 
		dbo.Metric m
	WHERE 
		m.AccountId = @AccountId
	AND m.Alias = @Alias
	ORDER BY m.Timestamp DESC
GO

-- Get the latest metric
CREATE OR ALTER PROCEDURE dbo.[Metric_GetLatestByTagAlias]
(
	@AccountId int,
	@MetricAlias nvarchar(100),
	@TagAlias nvarchar(100)
)
AS
    SET NOCOUNT ON;

	SELECT TOP 1
		m.Id,
		m.Alias,
		m.Number,
		m.Timestamp
	FROM 
		dbo.Metric m
	INNER JOIN dbo.MetricTag t ON t.MetricId = m.Id
	WHERE 
		m.AccountId = @AccountId
	AND m.Alias = @MetricAlias
	AND t.Alias = @TagAlias
	ORDER BY m.Timestamp DESC
GO


-- Get all by Alias
CREATE OR ALTER PROCEDURE dbo.[Metric_GetAllByTagAlias]
(
	@AccountId int,
	@TagAlias int
)
AS
    SET NOCOUNT ON;

	SELECT
		m.Id,
		m.Alias,
		m.Number,
		m.Timestamp
	FROM 
		dbo.Metric m
	INNER JOIN dbo.MetricTag t ON t.MetricId = m.Id
	WHERE 
		m.AccountId = @AccountId
	AND t.Alias = @TagAlias
	ORDER BY m.Timestamp DESC
GO

-- Get all by Alias
CREATE OR ALTER PROCEDURE dbo.[Metric_GetAllByAliasAndTag]
(
	@AccountId int,
	@MetricAlias int,
	@TagAlias int
)
AS
    SET NOCOUNT ON;

	SELECT
		m.Id,
		m.Alias,
		m.Number,
		m.Timestamp
	FROM 
		dbo.Metric m
	INNER JOIN dbo.MetricTag t ON t.MetricId = m.Id
	WHERE 
		m.AccountId = @AccountId
	AND m.Alias = @MetricAlias
	AND t.Alias = @TagAlias
	ORDER BY m.Timestamp DESC
GO