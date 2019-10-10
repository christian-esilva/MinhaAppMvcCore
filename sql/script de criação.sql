IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Fornecedor] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(150) NOT NULL,
    [Documento] varchar(14) NOT NULL,
    [TipoFornecedor] int NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Fornecedor] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Endereco] (
    [Id] uniqueidentifier NOT NULL,
    [IdFornecedor] uniqueidentifier NOT NULL,
    [Logradouro] varchar(150) NOT NULL,
    [Numero] varchar(30) NOT NULL,
    [Complemento] varchar(50) NOT NULL,
    [Cep] varchar(8) NOT NULL,
    [Bairro] varchar(150) NOT NULL,
    [Cidade] varchar(150) NOT NULL,
    [Estado] varchar(50) NOT NULL,
    CONSTRAINT [PK_Endereco] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Endereco_Fornecedor_IdFornecedor] FOREIGN KEY ([IdFornecedor]) REFERENCES [Fornecedor] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Produto] (
    [Id] uniqueidentifier NOT NULL,
    [IdFornecedor] uniqueidentifier NOT NULL,
    [Nome] varchar(150) NOT NULL,
    [Descricao] varchar(300) NOT NULL,
    [Imagem] varchar(100) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Produto_Fornecedor_IdFornecedor] FOREIGN KEY ([IdFornecedor]) REFERENCES [Fornecedor] ([Id]) ON DELETE NO ACTION
);

GO

CREATE UNIQUE INDEX [IX_Endereco_IdFornecedor] ON [Endereco] ([IdFornecedor]);

GO

CREATE INDEX [IX_Produto_IdFornecedor] ON [Produto] ([IdFornecedor]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191010154124_Initial', N'2.2.6-servicing-10079');

GO

