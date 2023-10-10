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