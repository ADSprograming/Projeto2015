CREATE TABLE Endereco (IdEndereco int identity(1,1) PRIMARY KEY,
						Logradouro varchar(100),
						Numero int,
						Complemento varchar(100),
						Bairro varchar(50),
						Cidade varchar(50),
						Estado varchar(50),
						cep int);

CREATE TABLE Dono ( cpfdono varchar(11) PRIMARY KEY,
                    Nome varchar(100),
                    Telefone varchar(11),
					idEndereco int,
					FOREIGN KEY(idEndereco) REFERENCES Endereco (idEndereco));

CREATE TABLE Animal (IdDoAnimal int identity(1,1) PRIMARY KEY,
						NomeDoAnimal varchar(100),
						Peso float,
						Raca varchar(100),
						Pet varchar(50),
						Idade int,
						cpfdono varchar(11),
						FOREIGN KEY(cpfdono) REFERENCES Dono(cpfdono));

CREATE TABLE Servico (CodigoServico int identity(1,1) PRIMARY KEY,
						Descricao varchar(100),
						Preco float);

CREATE TABLE Recebe (IdDoAnimal int identity(1,1) primary key,
					CodigoServico int,
					FOREIGN KEY(IdDoAnimal) REFERENCES Animal (IdDoAnimal),
					FOREIGN KEY(CodigoServico) REFERENCES Servico (CodigoServico));

CREATE TABLE Funcionario (MatriculaDoFuncionario int identity(1,1) PRIMARY KEY,
						NomeDoFuncionario varchar(100),
						Funcao varchar(50));

CREATE TABLE Executa (CodigoServico int identity(1,1) primary key,
						MatriculaDoFuncionario int ,
						FOREIGN KEY(CodigoServico) REFERENCES Servico (CodigoServico),
						FOREIGN KEY(MatriculaDoFuncionario) REFERENCES Funcionario (MatriculaDoFuncionario)
)


select * from dono 