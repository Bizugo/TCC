CREATE TABLE [dbo].[Aulas] (
    [aula_id]        INT            IDENTITY (1, 1) NOT NULL,
    [nome]           NVARCHAR (100) NOT NULL,
    [nome_instrutor] NVARCHAR (100) NOT NULL,
    [horario_inicio] NVARCHAR (5)   NOT NULL,
    [horario_fim]    NVARCHAR (5)   NOT NULL,
    [dias_semana]    NVARCHAR (14)  NOT NULL,
    [sala]           NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_dbo.Aulas] PRIMARY KEY CLUSTERED ([aula_id] ASC)
);

