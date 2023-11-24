CREATE TABLE [WeatherRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](30) NOT NULL,
	[Time] [nvarchar](30) NOT NULL,
	[Temperature] [decimal](6, 3) NULL,
	[Humidity] [decimal](6, 3) NULL,
	[DewPoint] [decimal](6, 3) NULL,
	[Pressure] [int] NULL,
	[WindDirection] [nvarchar](30) NULL,
	[WindSpeed] [int] NULL,
	[Cloudiness] [int] NULL,
	[CloudinessLowerBound] [int] NULL,
	[HorizontalVisibility] [int] NULL,
	[WeatherConditions] [nvarchar](100) NULL,
	PRIMARY KEY (Id)
);