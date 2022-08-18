CREATE TABLE [dbo].[Blog] (
	[Id]	INT IDENTITY(1,1) NOT NULL,
	[Url]	NVARCHAR(MAX) NULL
);
GO
ALTER TABLE [dbo].[Blog]
	ADD CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED ([Id] ASC);
GO
INSERT INTO [Blog] (Url) VALUES
('http://www.microsoft.com'),
('http://www.visualstudio.com'),
('http://www.github.com')
GO
CREATE TABLE [dbo].[Post] (
	[Id]		INT IDENTITY(1,1)		NOT NULL,
	[BlogId]	INT						NOT NULL,
	[Content]	NVARCHAR(MAX)			NULL,
	[PublishedDateTime] DATETIME2(7)	NOT NULL,
	[Title]		NVARCHAR(MAX)			NOT NULL
);
GO
CREATE NONCLUSTERED INDEX [IX_Post_BlogId]
	ON [dbo].[Post]([BlogId] ASC);
GO
ALTER TABLE [dbo].[Post]
	ADD CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED ([Id] ASC);
GO
ALTER TABLE [dbo].[Post]
	ADD CONSTRAINT [FK_Post_Blog_BlogId] FOREIGN KEY([BlogId]) REFERENCES [dbo].[Blog]([Id]) ON DELETE CASCADE;
GO
INSERT INTO [Post] (BlogId, Title, Content, PublishedDateTime) VALUES
(1, 'Microsoft', 'Microsoft Contents', '20220911'),
(2, 'Visual Studio', 'Visual Studio Contents', '20220911'),
(2, 'SQL Server', 'SQL Server Contents', '20220911')
GO
