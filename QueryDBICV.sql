CREATE TABLE [dbo].[TableTurma] (
    [IdTurma]           INT           IDENTITY (1, 1) NOT NULL,
    [NomeTurma]         VARCHAR (100) NOT NULL,
    [DescricaoTurma]    VARCHAR (250) NOT NULL,
    [PeriodoTurma]      SMALLINT      NOT NULL,
    [StatusTurma]       SMALLINT      NOT NULL,
    [DataCadastroTurma] DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([IdTurma] ASC)
);

CREATE TABLE [dbo].[TableCurso] (
    [IdCurso]           INT           IDENTITY (1, 1) NOT NULL,
    [NomeCurso]         VARCHAR (100) NOT NULL,
    [DescricaoCurso]    VARCHAR (250) NOT NULL,
    [StatusCurso]       SMALLINT      NOT NULL,
    [DataCadastroCurso] DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([IdCurso] ASC)
);

CREATE TABLE [dbo].[TableColaborador] (
    [IdColaborador]             INT           IDENTITY (1, 1) NOT NULL,
    [NomeColaborador]           VARCHAR (150) NOT NULL,
    [DocumentoColaborador]      VARCHAR (20)  NOT NULL,
    [DataNascimentoColaborador] DATE          NOT NULL,
    [EmailColaborador]          VARCHAR (150) NOT NULL,
    [SenhaColaborador]          VARCHAR (15)  NULL,
    [TelefoneColaborador]       VARCHAR (11)  NULL,
    [StatusColaborador]         SMALLINT      NOT NULL,
    [TipoColaborador]           SMALLINT      NOT NULL,
    [DataCadastroColaborador]   DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([IdColaborador] ASC)
);

CREATE TABLE [dbo].[TableAluno] (
    [IdAluno]             INT           IDENTITY (1, 1) NOT NULL,
    [NomeAluno]           VARCHAR (150) NOT NULL,
    [CpfAluno]            VARCHAR (11)  NOT NULL,
    [DataNascimentoAluno] DATETIME      NOT NULL,
    [EmailAluno]          VARCHAR (150) NOT NULL,
    [TelefoneAluno]       VARCHAR (11)  NULL,
    [StatusAluno]         SMALLINT      NOT NULL,
    [DataCadastroAluno]   DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([IdAluno] ASC)
);

