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

CREATE TABLE [Categorias] (
    [Id] int NOT NULL IDENTITY,
    [NomeCategoria] varchar(100) NOT NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Fornecedores] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Telefone] nvarchar(max) NOT NULL,
    [Cnpj] varchar(14) NOT NULL,
    CONSTRAINT [PK_Fornecedores] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuarios] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Cpf] varchar(11) NOT NULL,
    [Genero] nvarchar(max) NOT NULL,
    [Telefone] nvarchar(max) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Imagem] varchar(100) NOT NULL,
    [TipoUsuario] int NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Enderecos] (
    [Id] uniqueidentifier NOT NULL,
    [UsuarioId] uniqueidentifier NOT NULL,
    [Cep] varchar(8) NOT NULL,
    [Logradouro] varchar(200) NOT NULL,
    [Bairro] varchar(100) NOT NULL,
    [Cidade] varchar(100) NOT NULL,
    [Uf] varchar(30) NOT NULL,
    CONSTRAINT [PK_Enderecos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Enderecos_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id])
);
GO

CREATE TABLE [Pedidos] (
    [Id] uniqueidentifier NOT NULL,
    [UsuarioId] uniqueidentifier NOT NULL,
    [DataVenda] datetime NOT NULL,
    [NomeCliente] varchar(100) NOT NULL,
    [Quantidade] int NOT NULL,
    [ValorUnitario] decimal(18,2) NOT NULL,
    [ValorTotal] decimal(18,2) NOT NULL,
    [Frete] decimal(18,2) NULL,
    [StatusPedido] int NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pedidos_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id])
);
GO

CREATE TABLE [Carrinhos] (
    [Id] uniqueidentifier NOT NULL,
    [PedidoId] uniqueidentifier NOT NULL,
    [Quantidade] int NOT NULL,
    CONSTRAINT [PK_Carrinhos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Carrinhos_Pedidos_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [Pedidos] ([Id])
);
GO

CREATE TABLE [Produtos] (
    [Id] uniqueidentifier NOT NULL,
    [CategoriaId] int NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Descricao] varchar(1000) NOT NULL,
    [Marca] varchar(100) NOT NULL,
    [Quantidade] int NOT NULL,
    [ValorUnitario] decimal(18,2) NOT NULL,
    [Imagem] varchar(100) NOT NULL,
    [Status] int NOT NULL,
    [CarrinhoId] uniqueidentifier NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Produtos_Carrinhos_CarrinhoId] FOREIGN KEY ([CarrinhoId]) REFERENCES [Carrinhos] ([Id]),
    CONSTRAINT [FK_Produtos_Categorias_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categorias] ([Id]),
    CONSTRAINT [FK_Produtos_Fornecedores_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [Fornecedores] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Carrinhos_PedidoId] ON [Carrinhos] ([PedidoId]);
GO

CREATE UNIQUE INDEX [IX_Enderecos_UsuarioId] ON [Enderecos] ([UsuarioId]);
GO

CREATE INDEX [IX_Pedidos_UsuarioId] ON [Pedidos] ([UsuarioId]);
GO

CREATE INDEX [IX_Produtos_CarrinhoId] ON [Produtos] ([CarrinhoId]);
GO

CREATE INDEX [IX_Produtos_CategoriaId] ON [Produtos] ([CategoriaId]);
GO

CREATE INDEX [IX_Produtos_FornecedorId] ON [Produtos] ([FornecedorId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221105195503_Initial', N'6.0.10');
GO

COMMIT;
GO

