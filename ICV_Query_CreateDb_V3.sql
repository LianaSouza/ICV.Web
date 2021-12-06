/*      QUERY_CREATE_DATABASE_ICV_V3

PARA RODAR A QUERY, 1° CRIAR DB COM O NOME ICV */

USE ICV

CREATE TABLE TblColaborador
(
	IdColaborador INT PRIMARY KEY IDENTITY(1,1), 
    NomeColaborador VARCHAR(150) NOT NULL, 
    DocumentoColaborador VARCHAR(11) NOT NULL, 
    DataNascimentoColaborador DATE NOT NULL, 
    EmailColaborador VARCHAR(150) UNIQUE NOT NULL, 
    SenhaColaborador VARCHAR(100) NOT NULL, 
    TelefoneColaborador VARCHAR(13) NOT NULL, 
    TipoColaborador INT NOT NULL, 
    StatusColaborador INT NOT NULL,
    DataCadastroColaborador DATE NOT NULL
)

CREATE TABLE TblCurso
(
	IdCurso INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    NomeCurso VARCHAR(50) NOT NULL, 
    DescricaoCurso VARCHAR(200) NOT NULL, 
    StatusCurso INT NOT NULL, 
    DataCadastroCurso DATE NOT NULL
)

CREATE TABLE TblTurma
(
	IdTurma INT PRIMARY KEY IDENTITY(1,1), 
    NomeTurma VARCHAR(50) NOT NULL, 
    DescricaoTurma VARCHAR(150) NOT NULL, 
    PeriodoTurma INT NOT NULL, 
    StatusTurma INT NOT NULL, 
    DataCadastroTurma DATE NOT NULL,
    FKIdCurso INT NOT NULL,
    FKIdColaborador INT NOT NULL,
    FOREIGN KEY (FKIdCurso) REFERENCES TblCurso(IdCurso),
    FOREIGN KEY (FKIdColaborador) REFERENCES TblColaborador(IdColaborador)
)

CREATE TABLE TblAluno
(
    IdAluno INT PRIMARY KEY IDENTITY(1,1),
    NomeAluno VARCHAR(120) NOT NULL,
    CpfAluno VARCHAR(11) UNIQUE NOT NULL,
    DataNascimentoAluno DATE NOT NULL,
    EmailAluno  VARCHAR(125) NOT NULL,
    TelefoneAluno VARCHAR(13) NOT NULL,
    StatusAluno INT NOT NULL,
    DataCadastroAluno DATE NOT NULL,
    FKIdTurma INT NOT NULL,
    FKIdColaborador INT NOT NULL,
    FOREIGN KEY (FKIdTurma) REFERENCES TblTurma(IdTurma),
    FOREIGN KEY (FKIdColaborador) REFERENCES TblColaborador(IdColaborador)
)

CREATE TABLE TblDoador
(
    IdDoador INT PRIMARY KEY IDENTITY(1,1),
    NomeDoador VARCHAR(120) NOT NULL,
    DocumentoDoador VARCHAR(25) UNIQUE NOT NULL,
    TelefoneDoador VARCHAR(13) NOT NULL,
    EmailDoador VARCHAR(125) UNIQUE NULL,
    StatusDoador INT NOT NULL,
    AnonimoDoador INT NOT NULL,
    ObservacaoDoador TEXT NOT NULL,
    DataCadastroDoador DATE NOT NULL,
    FKIdColaborador INT NOT NULL
    FOREIGN KEY (FKIdColaborador) REFERENCES TblColaborador(IdColaborador)
)

CREATE TABLE TblBeneficiado
(
    IdBeneficiado INT PRIMARY KEY IDENTITY(1,1),
    NomeBeneficiado VARCHAR(120) NOT NULL,
    CpfBeneficiado VARCHAR(11) UNIQUE NOT NULL,
    DataNascimentoBeneficiado DATE,
    TelefoneBeneficiado VARCHAR(13) NOT NULL,
    EmailBeneficiado VARCHAR(120) UNIQUE NULL,
    StatusBeneficiado INT NOT NULL,
    QuantidadesDependentesBeneficiado INT NOT NULL,
    RendaMensalBeneficiado DECIMAL(10,2) NOT NULL,
    DataCadastroBeneficiado DATE,
    FKIdColaborador INT NOT NULL,
    FOREIGN KEY (FKIdColaborador) REFERENCES TblColaborador(IdColaborador)
)

CREATE TABLE TblEntradaDoacao
(
    IdEntradaDoacao INT PRIMARY KEY IDENTITY(1,1),
    TipoEntradoDoacao INT NOT NULL,
    DataCadastroEntradoDoacao DATE NOT NULL,
    FKIdDoador INT NOT NULL,
    FkIdColaborador INT NOT NULL,
    FOREIGN KEY (FKIdDoador) REFERENCES TblDoador(IdDoador),
    FOREIGN KEY (FKIdColaborador) REFERENCES TblColaborador(IdColaborador)
)

CREATE TABLE TblProduto
(
    IdProduto INT PRIMARY KEY IDENTITY(1,1),
    NomeProduto VARCHAR(120) NOT NULL,
    CategoriaProduto INT NOT NULL,
    QuantidadeProduto INT NOT NULL,
    DataCadastroProduto DATE NOT NULL,
)

CREATE TABLE TblEntradaItem
(
    IdEntradaItem INT PRIMARY KEY IDENTITY(1,1),
    QuantidadeItem INT NOT NULL,
    TipoEntradaItem INT NOT NULL,
    DataCadastroEntradoItem DATE NOT NULL,
    FKIdEntradaDoacao INT NOT NULL,
    FKIdProduto INT NOT NULL,
    FOREIGN KEY (FKIdProduto) REFERENCES TblProduto(IdProduto),
    FOREIGN KEY (FKIdEntradaDoacao) REFERENCES TblEntradaDoacao(IdEntradaDoacao)
)

CREATE TABLE TblSaidaDoacao
(
    IdSaidaDoacao INT PRIMARY KEY IDENTITY(1,1),
    TipoSaidaDoacao INT NOT NULL,
    DataCadastroSaidaDoacao Date NOT NULL,
    FKIdBeneficiado INT NOT NULL,
    FkIdColaborador INT NOT NULL,
    FOREIGN KEY (FKIdBeneficiado) REFERENCES TblBeneficiado(IdBeneficiado),
    FOREIGN KEY (FKIdColaborador) REFERENCES TblColaborador(IdColaborador)
)

CREATE TABLE TblSaidaItem
(
    IdSaidaItem INT PRIMARY KEY IDENTITY(1,1),
    QuantidadeSaidaItem INT NOT NULL,
    DataCadastroSaidaItem DATE NOT NULL,
    FKIdProduto INT NOT NULL,
    FKIdSaidoDoacao INT NOT NULL,
    FOREIGN KEY (FKIdProduto) REFERENCES TblProduto(IdProduto),
    FOREIGN KEY (FKIdSaidoDoacao) REFERENCES TblSaidaDoacao(idSaidaDoacao)
)
