BEGIN
    IF NOT EXISTS (SELECT 1 FROM [dbo].[Usuario])
    BEGIN
        INSERT INTO [dbo].[Usuario] ([Email], [Senha])
        VALUES
            ('Luis@example.com', 'senha123'),
            ('Claudio@example.com', 'senha456'),
            ('Kaique@example.com', 'senha789');
    END

    IF NOT EXISTS (SELECT 1 FROM [dbo].[Cliente])
    BEGIN
        INSERT INTO [dbo].[Cliente] ([Nome], [Cpf], [ValorLimite])
        VALUES
            ('Michel', '000.000.000-74', 1000.00),
            ('Juliana', '111.111.111-11', 1500.00),
            ('Bruno', '222.222.222-22', 2000.00);
    END
END
GO
