USE [SelfServe];

ALTER DATABASE [SelfServe] COLLATE Chinese_PRC_CI_AS;
--ALTER DATABASE [SelfServe] COLLATE SQL_Latin1_General_CP1_CI_AS;

/*
	Partner
*/
IF OBJECT_ID('[dbo].[Partner]') IS NOT NULL DROP TABLE [dbo].[Partner];

CREATE TABLE [dbo].[Partner]
(
	[PartnerId] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[Url] NVARCHAR(256) NULL,
	[TileName] NVARCHAR(256) NULL,
	[TileImageUrl] NVARCHAR(256) NULL,
	[TileLink] NVARCHAR(256) NULL,
	[TileDescription] NVARCHAR(MAX) NULL,
	[CreateTime] DATETIME NULL DEFAULT GETDATE(),
    [UpdateTime] DATETIME  NULL DEFAULT GETDATE()
);

CREATE NONCLUSTERED INDEX [IDX_Partner] ON [dbo].[Partner]([PartnerId] ASC);

INSERT INTO [dbo].[Partner] (Url, TileName, TileImageUrl, TileLink, TileDescription) VALUES 
(
    'https://www.hello.world.com',
    'hello world',
    'https://www.hello.world.com',
    'https://www.hello.world.com',
    '你好'
),
(
    'https://www.hello.world.com',
    'hello world',
    'https://www.hello.world.com',
    'https://www.hello.world.com',
    '你好'
);

SELECT * FROM [dbo].[Partner];