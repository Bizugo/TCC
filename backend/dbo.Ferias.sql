CREATE TABLE [dbo].[Ferias] (
    [ferias_id]  INT           IDENTITY (1, 1) NOT NULL,
    [cpf]        NVARCHAR (14) NOT NULL,
    [dataInicio] DATETIME      NOT NULL,
    [dataFim]    DATETIME      NOT NULL,
    CONSTRAINT [PK_dbo.Ferias] PRIMARY KEY CLUSTERED ([ferias_id] ASC), 
    CONSTRAINT [FK_Ferias_Pessoas] FOREIGN KEY ([cpf]) REFERENCES [Pessoas]([cpf])
);

