CREATE PROCEDURE [dbo].[sprocCliente_GetById]
    @Id int
AS
BEGIN
    SELECT *
    FROM dbo.Cliente
    WHERE Id = @Id;
END;

