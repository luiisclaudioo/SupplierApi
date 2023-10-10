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
        END
    ELSE
        BEGIN
            SELECT 'Erro: Este cliente já está cadastrado.' AS Mensagem;
        END
END;

