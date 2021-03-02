CREATE TABLE [dbo].[Ferias]
(
	[ferias_id] INT NOT NULL PRIMARY KEY, 
    [cpf] NVARCHAR(14) NOT NULL, 
    [ativo] BIT NOT NULL, 
    [dataInicio] DATE NOT NULL, 
    [dataFim] DATE NOT NULL, 
    CONSTRAINT [FK_Pessoa_Ferias] FOREIGN KEY ([cpf]) REFERENCES [Pessoa]([cpf])
)
