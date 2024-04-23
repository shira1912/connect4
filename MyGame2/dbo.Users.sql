CREATE TABLE [dbo].[Users]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [username] NVARCHAR(50) NULL,
    [password] NVARCHAR(50) NULL,
    [firstName] NVARCHAR(50),
    [lastName] NVARCHAR(50),
    [email] NVARCHAR(50),
    [city] NVARCHAR(50),
    [gender] NVARCHAR(10)
);
