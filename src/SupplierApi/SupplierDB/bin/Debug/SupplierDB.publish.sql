﻿/*
Deployment script for SupplierDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SupplierDB"
:setvar DefaultFilePrefix "SupplierDB"
:setvar DefaultDataPath "/var/opt/mssql/data/"
:setvar DefaultLogPath "/var/opt/mssql/data/"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
PRINT N'Creating Table [dbo].[Cliente]...';


GO
CREATE TABLE [dbo].[Cliente] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Nome]        NVARCHAR (50) NOT NULL,
    [Cpf]         NVARCHAR (50) NOT NULL,
    [ValorLimite] NUMERIC (18)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Transacao]...';


GO
CREATE TABLE [dbo].[Transacao] (
    [IdTransacao]    UNIQUEIDENTIFIER NOT NULL,
    [IdCliente]      INT              NOT NULL,
    [Cpf]            NVARCHAR (50)    NOT NULL,
    [ValorTransacao] NUMERIC (18)     NOT NULL,
    [ValorLimite]    NUMERIC (18)     NOT NULL,
    PRIMARY KEY CLUSTERED ([IdTransacao] ASC)
);


GO
PRINT N'Creating Table [dbo].[Usuario]...';


GO
CREATE TABLE [dbo].[Usuario] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Email] NVARCHAR (100) NOT NULL,
    [Senha] NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Transacao_Cliente]...';


GO
ALTER TABLE [dbo].[Transacao] WITH NOCHECK
    ADD CONSTRAINT [FK_Transacao_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([Id]);


GO
PRINT N'Creating Procedure [dbo].[sprocCliente_Delete]...';


GO
CREATE PROCEDURE [dbo].[sprocCliente_Delete]
    @Id int
AS
BEGIN
    DELETE FROM dbo.Cliente
    WHERE Id = @Id;
    SELECT 'Cliente excluído com sucesso.' AS Mensagem;
END;
GO
PRINT N'Creating Procedure [dbo].[sprocCliente_GetAll]...';


GO
CREATE PROCEDURE [dbo].[sprocCliente_GetAll]
AS
BEGIN
    SELECT *
    FROM dbo.Cliente;
END;
GO
PRINT N'Creating Procedure [dbo].[sprocCliente_GetById]...';


GO
CREATE PROCEDURE [dbo].[sprocCliente_GetById]
    @Id int
AS
BEGIN
    SELECT *
    FROM dbo.Cliente
    WHERE Id = @Id;
END;
GO
PRINT N'Creating Procedure [dbo].[sprocCliente_Insert]...';


GO
CREATE PROCEDURE [dbo].[sprocCliente_Insert]
    @Nome NVARCHAR(50),
    @Cpf NVARCHAR(50),
    @ValorLimite NUMERIC
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM dbo.Cliente WHERE Cpf = @Cpf)
        BEGIN
            INSERT INTO dbo.Cliente (Nome, Cpf, ValorLimite)
            VALUES (@Nome, @Cpf, @ValorLimite);
            SELECT 'Cliente inserido com sucesso.' AS Mensagem;
        END
    ELSE
        BEGIN
            SELECT 'Erro: Este cliente já está cadastrado.' AS Mensagem;
        END
END;
GO
PRINT N'Creating Procedure [dbo].[sprocCliente_UpdateValorLimite]...';


GO
CREATE PROCEDURE [dbo].[sprocCliente_UpdateValorLimite]
    @Cpf NVARCHAR(50),
    @NovoValorLimite NUMERIC
AS
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.Cliente WHERE Cpf = @Cpf)
        BEGIN
            UPDATE dbo.Cliente
            SET ValorLimite = @NovoValorLimite
            WHERE Cpf = @Cpf;
            SELECT 'Valor Limite atualizado com sucesso.' AS Mensagem;
        END
    ELSE
        BEGIN
            SELECT 'Erro: Cliente não encontrado.' AS Mensagem;
        END
END;
GO
PRINT N'Creating Procedure [dbo].[sprocTransacao_Insert]...';


GO
CREATE PROCEDURE [dbo].[sprocTransacao_Insert]
    @IdTransacao UNIQUEIDENTIFIER,
    @IdCliente INT,
    @Cpf NVARCHAR(50),
    @ValorTransacao NUMERIC,
    @ValorLimite NUMERIC
AS
BEGIN
        INSERT INTO [dbo].[Transacao] ([IdTransacao], [IdCliente], [Cpf], [ValorTransacao], [ValorLimite])
        VALUES (@IdTransacao, @IdCliente, @Cpf, @ValorTransacao, @ValorLimite);
        SELECT 'Transação inserida com sucesso.' AS Mensagem;
END;
GO
PRINT N'Creating Procedure [dbo].[sprocUsuario_Delete]...';


GO
CREATE PROCEDURE [dbo].[sprocUsuario_Delete]
    @Email NVARCHAR(100)
AS
BEGIN
    DELETE FROM dbo.Usuario WHERE Email = @Email;
    SELECT 'Usuário excluído com sucesso.' AS Mensagem;
END;
GO
PRINT N'Creating Procedure [dbo].[sprocUsuario_Get]...';


GO
CREATE PROCEDURE [dbo].[sprocUsuario_Get]
	@Email nvarchar(100)
AS
BEGIN
	SELECT * 
	FROM  dbo.Usuario
	WHERE Email = @Email;
END
GO
PRINT N'Creating Procedure [dbo].[sprocUsuario_GetAll]...';


GO
CREATE PROCEDURE [dbo].[sprocUsuario_GetAll]
AS
BEGIN
	SELECT * FROM  dbo.Usuario;
END
GO
PRINT N'Creating Procedure [dbo].[sprocUsuario_Insert]...';


GO
CREATE PROCEDURE [dbo].[sprocUsuario_Insert]
    @Email NVARCHAR(100),
    @Senha NVARCHAR(50)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE Email = @Email)
        BEGIN
            INSERT INTO dbo.Usuario (Email, Senha)
            VALUES (@Email, @Senha);
            SELECT 'Usuário inserido com sucesso.' AS Mensagem;
        END
    ELSE
        BEGIN        
        SELECT 'Erro: Este usuário já está cadastrado.' AS Mensagem;
        END
END;
GO
PRINT N'Creating Procedure [dbo].[sprocUsuario_Update]...';


GO
CREATE PROCEDURE [dbo].[sprocUsuario_Update]
    @Email NVARCHAR(100),
    @Senha NVARCHAR(50)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.Usuario WHERE Email = @Email)
    BEGIN
        UPDATE dbo.Usuario
        SET Senha = @Senha
        WHERE Email = @Email;
        SELECT 'Usuário atualizada com sucesso.' AS Mensagem;
    END
    ELSE
    BEGIN        
        SELECT 'Erro: Usuário não encontrado.' AS Mensagem;
    END
END;
GO
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [dbo].[Usuario])
    BEGIN
        INSERT INTO [dbo].[Usuario] ([Email], [Senha])
        VALUES
            ('Luis@example.com', 'senha123'),
            ('Claudio@example.com', 'senha456'),
            ('Kaique@example.com', 'senha789');
    END

    IF NOT EXISTS (SELECT 1 FROM [dbo].[Cliente])
    BEGIN
        INSERT INTO [dbo].[Cliente] ([Nome], [Cpf], [ValorLimite])
        VALUES
            ('Michel', '000.000.000-74', 1000.00),
            ('Juliana', '111.111.111-11', 1500.00),
            ('Bruno', '222.222.222-22', 2000.00);
    END
END
GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Transacao] WITH CHECK CHECK CONSTRAINT [FK_Transacao_Cliente];


GO
PRINT N'Update complete.';


GO
