IF OBJECT_ID(N'dbo.[MetricTag]', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.[MetricTag]
	(
		Id			int				NOT NULL IDENTITY(10000, 1) PRIMARY KEY,
		MetricId	int				NOT NULL FOREIGN KEY REFERENCES dbo.[Metric](Id),
		Alias		nvarchar(100)	NOT NULL,
		Value		nvarchar(100)	NOT NULL,
	);
END
GO

-- Get
CREATE OR ALTER PROCEDURE dbo.[MetricTag_Get]
(
	@TagId int
)
AS
    SET NOCOUNT ON;

	SELECT
		t.Id,
		t.Alias,
		t.Value
	FROM 
		dbo.MetricTag t
	WHERE
		t.Id = @TagId
GO

-- Get All
CREATE OR ALTER PROCEDURE dbo.[MetricTag_GetByMetricId]
(
	@MetrictId int
)
AS
    SET NOCOUNT ON;

	SELECT
		t.Id,
		t.Alias,
		t.Value
	FROM 
		dbo.MetricTag t
	WHERE t.MetricId = @MetrictId
GO

-- Get All
CREATE OR ALTER PROCEDURE dbo.[MetricTag_GetAliasesByMetricId]
(
	@MetrictId int
)
AS
    SET NOCOUNT ON;

	SELECT 
		DISTINCT(t.Alias)
	FROM 
		dbo.MetricTag t
	WHERE t.MetricId = @MetrictId
	ORDER BY t.alias ASC
GO

-- Save
CREATE OR ALTER PROCEDURE dbo.[MetricTag_Save]
(
	@MetricId int,
	@Alias nvarchar(100),			
	@Value nvarchar(100)
)
AS
    SET NOCOUNT ON;

    INSERT INTO dbo.MetricTag(MetricId, Alias, Value) 
	VALUES(@MetricId, @Alias, @Value)

    SELECT SCOPE_IDENTITY();
GO

-- Update
CREATE OR ALTER PROCEDURE dbo.[MetricTag_Update]
(
	@TagId int,
	@Alias nvarchar(100),			
	@Value nvarchar(100)
)				
AS
    SET NOCOUNT ON;

	BEGIN
		UPDATE t
		SET
			t.Alias = @Alias,
			t.Value = @Value
		FROM 
			dbo.MetricTag t
		WHERE t.Id = @TagId
	END
GO

-- Delete
CREATE OR ALTER PROCEDURE dbo.[MetricTag_Delete]
(
	@TagId int
)				
AS
    SET NOCOUNT ON;

	BEGIN
		DELETE 
		FROM 
			dbo.MetricTag
		WHERE 
			Id = @TagId
	END
GO

-- Delete all by the metric id
CREATE OR ALTER PROCEDURE dbo.[MetricTag_DeleteByMetricId]
(
	@AccountId int,
	@MetricId int
)				
AS
    SET NOCOUNT ON;

	BEGIN
		DELETE t
		FROM 
			dbo.MetricTag t
		INNER JOIN dbo.Metric m ON t.MetricId = m.Id 
		WHERE 
			m.AccountId = @AccountId
		AND t.MetricId = @MetricId
	END
GO