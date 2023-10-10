CREATE PROCEDURE [dbo].[sprocCliente_UpdateValorLimite]
    @Id int,
    @Nome NVARCHAR(50), 
    @Cpf NVARCHAR(50),
    @ValorLimite NUMERIC
AS
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.Cliente WHERE Id = @Id)
        BEGIN
            UPDATE dbo.Cliente
            SET ValorLimite = @ValorLimite
            WHERE Id = @Id;
            SELECT 'Valor Limite atualizado com sucesso.' AS Mensagem;
        END
    ELSE
        BEGIN
            SELECT 'Erro: Cliente não encontrado.' AS Mensagem;
        END
END;


