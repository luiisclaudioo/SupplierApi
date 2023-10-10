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
