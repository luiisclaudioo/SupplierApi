CREATE PROCEDURE [dbo].[sprocCliente_Delete]
    @Id int
AS
BEGIN
    DELETE FROM dbo.Cliente
    WHERE Id = @Id;
    SELECT 'Cliente excluído com sucesso.' AS Mensagem;
END;

