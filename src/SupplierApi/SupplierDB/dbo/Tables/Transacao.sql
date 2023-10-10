CREATE TABLE [dbo].[Transacao]
(
    [IdTransacao] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [IdCliente] INT NOT NULL,
    [Cpf] NVARCHAR(50) NOT NULL,
    [ValorTransacao] NUMERIC NOT NULL,
    [ValorLimite] NUMERIC NOT NULL,
    CONSTRAINT FK_Transacao_Cliente FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([Id])
);