CREATE TABLE [dbo].[Aula]
(
	[aula_id] INT NOT NULL PRIMARY KEY, 
    [nome] NVARCHAR(100) NOT NULL, 
    [horario_inicio] NVARCHAR(5) NOT NULL, 
    [horario_fim] NVARCHAR(5) NOT NULL, 
    [dias_semana] NVARCHAR(15) NOT NULL, 
    [sala] NVARCHAR(50) NOT NULL, 
    [ativo] BIT NOT NULL
)
