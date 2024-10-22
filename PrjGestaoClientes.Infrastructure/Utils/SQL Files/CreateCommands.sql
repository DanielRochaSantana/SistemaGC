CREATE TABLE Cliente (
    Id  UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    CPF  varchar(20),
    Nome  varchar(255),
    RG  varchar(15),
    DataExpedicao  datetime,
    OrgaoExpedicao  varchar(10),
    DataNascimento  datetime,
    Sexo  varchar(20),
    EstadoCivil  varchar(20),
    IdEnderecoCliente UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    DataCadastro datetime,
    DataModificacao datetime,
    IsAtivo bit NOT NULL DEFAULT 1
);

--drop table Cliente;

CREATE TABLE EnderecoCliente (
    Id  UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    CEP  varchar(15), 
    Logradouro  varchar(255),
    Número  varchar(10),
    Complemento  varchar(100),
    Bairro  varchar(200),
    Cidade  varchar(200),
    UF  varchar(2),
    DataCadastro datetime,
    DataModificacao datetime,
    IsAtivo bit NOT NULL DEFAULT 1
);

--drop table EnderecoCliente;