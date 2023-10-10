CREATE PROCEDURE [dbo].[sprocUsuario_Get]
	@Email nvarchar(100)
AS
BEGIN
	SELECT * 
	FROM  dbo.Usuario
	WHERE Email = @Email;
END
