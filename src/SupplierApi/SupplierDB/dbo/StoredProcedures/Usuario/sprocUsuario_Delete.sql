CREATE PROCEDURE [dbo].[sprocUsuario_Delete]
    @Email NVARCHAR(100)
AS
BEGIN
    DELETE FROM dbo.Usuario WHERE Email = @Email;
    SELECT 'Usuário excluído com sucesso.' AS Mensagem;
END;
