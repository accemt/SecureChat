CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY,
	Name nvarchar(50) NOT NULL,
	Chats int NOT NULL,
	PasswordHash nvarchar(50) NOT NULL,
    token nvarchar(50) NOT NULL
)
