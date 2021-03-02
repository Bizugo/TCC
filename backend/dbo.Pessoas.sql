CREATE TABLE [dbo].[Pessoas] (
    [cpf]            NVARCHAR (14)  NOT NULL,
    [nome]           NVARCHAR (100) NOT NULL,
    [identidade]     NVARCHAR (13)  NOT NULL,
    [endereco]       NVARCHAR (200) NOT NULL,
    [data_pagamento] DATETIME       NOT NULL,
    [inadimplente]   BIT            NOT NULL,
    [tipo_pagamento] NVARCHAR (MAX) NULL,
    [tipo_atividade] NVARCHAR (MAX) NULL,
    [funcionario]    BIT            NOT NULL,
    [senha]          NVARCHAR (8)   NULL,
    [tipo_pessoa]    NVARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_dbo.Pessoas] PRIMARY KEY CLUSTERED ([cpf] ASC)
);

