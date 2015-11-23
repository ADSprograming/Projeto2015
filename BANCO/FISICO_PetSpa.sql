USE master
GO
DROP DATABASE PetSpa
GO
CREATE DATABASE PetSpa
GO
USE PetSpa
GO
CREATE TABLE Cliente (
CPF VARCHAR(11) PRIMARY KEY,
Nome VARCHAR(100),
Telefone VARCHAR(11),
CodigoEndereco INTEGER
)
GO
CREATE TABLE Animal (
CodigoAnimal INTEGER PRIMARY KEY,
NomeDoAnimal VARCHAR(100),
Raca VARCHAR(100),
Peso FLOAT,
Idade INTEGER,
Tipo VARCHAR(100),
CPF VARCHAR(11),
FOREIGN KEY(CPF) REFERENCES Cliente (CPF)
)
GO
CREATE TABLE Agenda (
CodigoAgenda INTEGER PRIMARY KEY,
Hora TIME,
Data DATE
)
GO
CREATE TABLE Servico (
CodigoServico INTEGER PRIMARY KEY,
Descricao VARCHAR(100)
)
GO
CREATE TABLE registra (
MatriculaDoFuncionario INTEGER,
CodigoAtendimento INTEGER
)
GO
CREATE TABLE Atendimento (
CodigoAtendimento INTEGER PRIMARY KEY,
Descricao VARCHAR(100),
Status VARCHAR(100),
CodigoAgenda INTEGER,
FOREIGN KEY(CodigoAgenda) REFERENCES Agenda (CodigoAgenda)
)
GO
CREATE TABLE Recebe (
CodigoAnimal INTEGER,
CodigoAtendimento INTEGER,
FOREIGN KEY(CodigoAnimal) REFERENCES Animal (CodigoAnimal),
FOREIGN KEY(CodigoAtendimento) REFERENCES Atendimento (CodigoAtendimento)
)
GO
CREATE TABLE Historico (
MatriculaDoFuncionario INTEGER,
CodigoAtendimento INTEGER,
CodigoServico INTEGER,
FOREIGN KEY(CodigoAtendimento) REFERENCES Atendimento (CodigoAtendimento),
FOREIGN KEY(CodigoServico) REFERENCES Servico (CodigoServico)
)
GO
CREATE TABLE Endereco (
CodigoEndereco INTEGER PRIMARY KEY,
Logradouro VARCHAR(200),
Complemento VARCHAR(100),
Bairro VARCHAR(100),
Estado VARCHAR(2),
CEP INTEGER,
Numero CHAR(10),
Cidade VARCHAR(100)
)
GO
CREATE TABLE Funcionario (
MatriculaDoFuncionario INTEGER PRIMARY KEY,
Funcao VARCHAR(100),
NomeDoFuncionario VARCHAR(100)
)
GO
CREATE TABLE Relaciona (
CodigoAgenda INTEGER,
CodigoServico INTEGER,
FOREIGN KEY(CodigoAgenda) REFERENCES Agenda (CodigoAgenda),
FOREIGN KEY(CodigoServico) REFERENCES Servico (CodigoServico)
)
GO
ALTER TABLE Cliente ADD FOREIGN KEY(CodigoEndereco) REFERENCES Endereco (CodigoEndereco)
GO
ALTER TABLE registra ADD FOREIGN KEY(MatriculaDoFuncionario) REFERENCES Funcionario (MatriculaDoFuncionario)
GO
ALTER TABLE registra ADD FOREIGN KEY(CodigoAtendimento) REFERENCES Atendimento (CodigoAtendimento)
GO
ALTER TABLE Historico ADD FOREIGN KEY(MatriculaDoFuncionario) REFERENCES Funcionario (MatriculaDoFuncionario)
