CREATE PROCEDURE [dbo].[sprocTransacao_Get]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT *
    FROM dbo.Transacao
    WHERE IdTransacao = @Id;
END;
