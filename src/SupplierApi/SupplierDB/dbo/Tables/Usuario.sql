﻿CREATE TABLE [dbo].[Usuario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] NVARCHAR(100) NOT NULL, 
    [Senha] NVARCHAR(50) NOT NULL
)
