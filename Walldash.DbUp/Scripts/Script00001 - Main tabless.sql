IF OBJECT_ID(N'dbo.[Account]', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.[Account]
	(
		Id		int					NOT NULL IDENTITY(10000, 1) PRIMARY KEY,
		Token	UNIQUEIDENTIFIER	NOT NULL default NEWID(),
		Alias	nvarchar(100)		NOT NULL,
	);
END
GO

IF OBJECT_ID(N'dbo.[Metric]', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.[Metric]
	(
		Id			int				NOT NULL IDENTITY(10000, 1) PRIMARY KEY,
		AccountId	int				NOT NULL FOREIGN KEY REFERENCES dbo.[Account](Id),
		Alias		nvarchar(100)	NOT NULL,
		Number		float			NOT NULL,
		Timestamp	datetimeoffset	NOT NULL
	);
END
GO

IF OBJECT_ID(N'dbo.[Dashboard]', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.[Dashboard]
	(
		Id			int				NOT NULL IDENTITY(10000, 1) PRIMARY KEY,
		AccountId	int				NOT NULL FOREIGN KEY REFERENCES dbo.[Account](Id),
		Alias		nvarchar(100)	NOT NULL,
		DateCreated	datetimeoffset	NOT NULL DEFAULT SYSDATETIMEOFFSET()
	);
END
GO


IF OBJECT_ID(N'dbo.[Widget]', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.[Widget]
	(
		Id			int				NOT NULL IDENTITY(10000, 1) PRIMARY KEY,
		DashboardId	int				NOT NULL FOREIGN KEY REFERENCES dbo.[Dashboard](Id),
		MetricAlias nvarchar(100)	NOT NULL,
		WidgetType	nvarchar(100)	NOT NULL,
		Width		int				NOT NULL,
		Height		int				NOT NULL,
		DateCreated	datetimeoffset	NOT NULL DEFAULT SYSDATETIMEOFFSET()
	);
END
GO