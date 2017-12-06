IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Books] (
    [BookId] int NOT NULL IDENTITY,
    [Publisher] nvarchar(max) NULL,
    [Title] nvarchar(max) NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([BookId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20171206083215_InitBooks', N'2.0.1-rtm-125');

GO

