CREATE TABLE [dbo].[Pessoa]
(
	[cpf] NVARCHAR(14) NOT NULL PRIMARY KEY, 
    [nome] NVARCHAR(100) NOT NULL, 
    [identidade] NVARCHAR(14) NOT NULL, 
    [ativo] BIT NOT NULL, 
    [endereco] NVARCHAR(200) NOT NULL, 
    [data_pagamento] DATE NOT NULL, 
    [inadimplente] BIT NULL, 
    [tipo_atividade] NVARCHAR(20) NULL, 
    [funcionario] BIT NULL, 
    [senha] NVARCHAR(8) NULL, 
    [tipo_pessoa] NVARCHAR(20) NULL
)
