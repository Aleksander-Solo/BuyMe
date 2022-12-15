IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE TABLE [BooksCategory] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_BooksCategory] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE TABLE [Categories] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE TABLE [FilmsCategory] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_FilmsCategory] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE TABLE [GamesCategory] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_GamesCategory] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE TABLE [Roles] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE TABLE [Books] (
        [Id] int NOT NULL IDENTITY,
        [Image] varbinary(max) NOT NULL,
        [Title] nvarchar(50) NOT NULL,
        [Author] nvarchar(max) NOT NULL,
        [Publishinghosue] nvarchar(max) NOT NULL,
        [Releasedate] date NOT NULL,
        [NumOfPag] int NOT NULL,
        [Description] text NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [BookCategoryId] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Books] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Books_BooksCategory_BookCategoryId] FOREIGN KEY ([BookCategoryId]) REFERENCES [BooksCategory] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [Image] varbinary(max) NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Description] text NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [CategoryId] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE TABLE [Films] (
        [Id] int NOT NULL IDENTITY,
        [Image] varbinary(max) NOT NULL,
        [Title] nvarchar(50) NOT NULL,
        [Director] nvarchar(max) NOT NULL,
        [Duration] int NOT NULL,
        [Releasedate] date NOT NULL,
        [Description] text NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [FilmCategoryId] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Films] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Films_FilmsCategory_FilmCategoryId] FOREIGN KEY ([FilmCategoryId]) REFERENCES [FilmsCategory] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE TABLE [Games] (
        [Id] int NOT NULL IDENTITY,
        [Image] varbinary(max) NOT NULL,
        [Title] nvarchar(50) NOT NULL,
        [Producer] nvarchar(max) NULL,
        [Releasedate] date NOT NULL,
        [Description] text NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [Carrier] nvarchar(max) NOT NULL,
        [GameCategoryId] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Games] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Games_GamesCategory_GameCategoryId] FOREIGN KEY ([GameCategoryId]) REFERENCES [GamesCategory] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(40) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [HashPassword] nvarchar(max) NOT NULL,
        [Picture] varbinary(max) NOT NULL,
        [DateofBirth] date NULL,
        [RoleId] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE TABLE [BooksComment] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [UserId] int NOT NULL,
        [Stars] tinyint NOT NULL,
        [BookId] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_BooksComment] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BooksComment_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_BooksComment_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE TABLE [Comments] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [UserId] int NOT NULL,
        [Stars] tinyint NOT NULL,
        [ProductId] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Comments_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE TABLE [FilmsComment] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [UserId] int NOT NULL,
        [Stars] tinyint NOT NULL,
        [FilmId] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_FilmsComment] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_FilmsComment_Films_FilmId] FOREIGN KEY ([FilmId]) REFERENCES [Films] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_FilmsComment_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE TABLE [GamesComment] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [UserId] int NOT NULL,
        [Stars] tinyint NOT NULL,
        [GameId] int NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_GamesComment] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_GamesComment_Games_GameId] FOREIGN KEY ([GameId]) REFERENCES [Games] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_GamesComment_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE INDEX [IX_Books_BookCategoryId] ON [Books] ([BookCategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE INDEX [IX_BooksComment_BookId] ON [BooksComment] ([BookId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE INDEX [IX_BooksComment_UserId] ON [BooksComment] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE INDEX [IX_Comments_ProductId] ON [Comments] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE INDEX [IX_Comments_UserId] ON [Comments] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE INDEX [IX_Films_FilmCategoryId] ON [Films] ([FilmCategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE INDEX [IX_FilmsComment_FilmId] ON [FilmsComment] ([FilmId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE INDEX [IX_FilmsComment_UserId] ON [FilmsComment] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE INDEX [IX_Games_GameCategoryId] ON [Games] ([GameCategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE INDEX [IX_GamesComment_GameId] ON [GamesComment] ([GameId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE INDEX [IX_GamesComment_UserId] ON [GamesComment] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    CREATE INDEX [IX_Users_RoleId] ON [Users] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117210658_Init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221117210658_Init', N'7.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221213185146_deleteProductTable')
BEGIN
    DROP TABLE [Comments];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221213185146_deleteProductTable')
BEGIN
    DROP TABLE [Products];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221213185146_deleteProductTable')
BEGIN
    DROP TABLE [Categories];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221213185146_deleteProductTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221213185146_deleteProductTable', N'7.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221213190918_seeder')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateDate', N'Name') AND [object_id] = OBJECT_ID(N'[BooksCategory]'))
        SET IDENTITY_INSERT [BooksCategory] ON;
    EXEC(N'INSERT INTO [BooksCategory] ([Id], [CreateDate], [Name])
    VALUES (1, ''2022-12-13T20:09:18.5331503+01:00'', N''Fantazy''),
    (2, ''2022-12-13T20:09:18.5331538+01:00'', N''Historyczny''),
    (3, ''2022-12-13T20:09:18.5331540+01:00'', N''Sci-fi''),
    (4, ''2022-12-13T20:09:18.5331541+01:00'', N''Thriller''),
    (5, ''2022-12-13T20:09:18.5331543+01:00'', N''Horror''),
    (6, ''2022-12-13T20:09:18.5331544+01:00'', N''Biografia i reportaż''),
    (7, ''2022-12-13T20:09:18.5331545+01:00'', N''Literatura dziecięca'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateDate', N'Name') AND [object_id] = OBJECT_ID(N'[BooksCategory]'))
        SET IDENTITY_INSERT [BooksCategory] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221213190918_seeder')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateDate', N'Name') AND [object_id] = OBJECT_ID(N'[FilmsCategory]'))
        SET IDENTITY_INSERT [FilmsCategory] ON;
    EXEC(N'INSERT INTO [FilmsCategory] ([Id], [CreateDate], [Name])
    VALUES (1, ''2022-12-13T20:09:18.5331679+01:00'', N''Fantazy''),
    (2, ''2022-12-13T20:09:18.5331681+01:00'', N''Historyczny''),
    (3, ''2022-12-13T20:09:18.5331682+01:00'', N''Sci-fi''),
    (4, ''2022-12-13T20:09:18.5331684+01:00'', N''Thriller''),
    (5, ''2022-12-13T20:09:18.5331685+01:00'', N''Horror''),
    (6, ''2022-12-13T20:09:18.5331686+01:00'', N''Komedia''),
    (7, ''2022-12-13T20:09:18.5331687+01:00'', N''Kryminał''),
    (8, ''2022-12-13T20:09:18.5331689+01:00'', N''Muzyczny''),
    (9, ''2022-12-13T20:09:18.5331690+01:00'', N''Przygodowy'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateDate', N'Name') AND [object_id] = OBJECT_ID(N'[FilmsCategory]'))
        SET IDENTITY_INSERT [FilmsCategory] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221213190918_seeder')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateDate', N'Name') AND [object_id] = OBJECT_ID(N'[GamesCategory]'))
        SET IDENTITY_INSERT [GamesCategory] ON;
    EXEC(N'INSERT INTO [GamesCategory] ([Id], [CreateDate], [Name])
    VALUES (1, ''2022-12-13T20:09:18.5331656+01:00'', N''Zręcznościowe''),
    (2, ''2022-12-13T20:09:18.5331658+01:00'', N''Przygodowe''),
    (3, ''2022-12-13T20:09:18.5331659+01:00'', N''Fabularne''),
    (4, ''2022-12-13T20:09:18.5331661+01:00'', N''Strategiczne''),
    (5, ''2022-12-13T20:09:18.5331662+01:00'', N''Symulacyjne''),
    (6, ''2022-12-13T20:09:18.5331663+01:00'', N''Sportowe''),
    (7, ''2022-12-13T20:09:18.5331664+01:00'', N''Edukacyjne''),
    (8, ''2022-12-13T20:09:18.5331666+01:00'', N''Logiczne'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreateDate', N'Name') AND [object_id] = OBJECT_ID(N'[GamesCategory]'))
        SET IDENTITY_INSERT [GamesCategory] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221213190918_seeder')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221213190918_seeder', N'7.0.0');
END;
GO

COMMIT;
GO

