IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211011201424_EstadoRemovido')
BEGIN
    CREATE TABLE [Avaliacao] (
        [Id] int NOT NULL IDENTITY,
        [Nome] varchar(80) NOT NULL,
        [Descricao] varchar(500) NOT NULL,
        CONSTRAINT [PK_Avaliacao] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211011201424_EstadoRemovido')
BEGIN
    CREATE TABLE [Candidato] (
        [Id] int NOT NULL IDENTITY,
        [Nome] varchar(80) NOT NULL,
        [DataNascimento] datetime2 NOT NULL,
        [CPF] char(11) NOT NULL,
        [Email] varchar(80) NULL,
        [Telefone] char(11) NOT NULL,
        [Cidade] varchar(60) NOT NULL,
        [Sexo] char(2) NOT NULL,
        [Disponibilidade] varchar(20) NOT NULL,
        CONSTRAINT [PK_Candidato] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211011201424_EstadoRemovido')
BEGIN
    CREATE TABLE [Cliente] (
        [Id] int NOT NULL IDENTITY,
        [Nome] varchar(80) NOT NULL,
        [Telefone] char(11) NOT NULL,
        [Rua] varchar(60) NOT NULL,
        [Bairro] varchar(60) NOT NULL,
        [Numero] varchar(4) NOT NULL,
        [Complemento] varchar(200) NULL,
        CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211011201424_EstadoRemovido')
BEGIN
    CREATE TABLE [Produto] (
        [Id] int NOT NULL IDENTITY,
        [Nome] varchar(80) NOT NULL,
        [Preco] decimal(10,2) NOT NULL,
        [Descricao] varchar(200) NULL,
        CONSTRAINT [PK_Produto] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211011201424_EstadoRemovido')
BEGIN
    CREATE TABLE [Pedido] (
        [Id] int NOT NULL IDENTITY,
        [ClienteId] int NOT NULL,
        [Data] datetime NOT NULL DEFAULT (getdate()),
        CONSTRAINT [PK_Pedido] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Pedido_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211011201424_EstadoRemovido')
BEGIN
    CREATE TABLE [PedidoItem] (
        [Id] int NOT NULL IDENTITY,
        [ProdutoId] int NOT NULL,
        [PedidoId] int NOT NULL,
        [Valor] decimal(10,2) NOT NULL,
        [Quantidade] int NOT NULL,
        CONSTRAINT [PK_PedidoItem] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PedidoItem_Pedido_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [Pedido] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_PedidoItem_Produto_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produto] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211011201424_EstadoRemovido')
BEGIN
    CREATE INDEX [IX_Pedido_ClienteId] ON [Pedido] ([ClienteId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211011201424_EstadoRemovido')
BEGIN
    CREATE INDEX [IX_PedidoItem_PedidoId] ON [PedidoItem] ([PedidoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211011201424_EstadoRemovido')
BEGIN
    CREATE INDEX [IX_PedidoItem_ProdutoId] ON [PedidoItem] ([ProdutoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211011201424_EstadoRemovido')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211011201424_EstadoRemovido', N'5.0.10');
END;
GO

COMMIT;
GO

