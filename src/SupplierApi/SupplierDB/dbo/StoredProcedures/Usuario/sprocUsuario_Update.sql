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

