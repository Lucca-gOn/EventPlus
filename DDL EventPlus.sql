--DDL - Data Definition Language
--Criar o banco de dados;
CREATE DATABASE [Event+_manha];

USE [Event+_manha];
--Criar Tabelas;

CREATE TABLE TipoDeUsuario
(
	IdTipoDeUsuario INT PRIMARY KEY IDENTITY,  --IDENTITY É UM AUTO ENCREMENTO
	TituloTipoUsuario VARCHAR(20) NOT NULL UNIQUE  -- Unique (fala que o tipo de usuario é unico, adm ou user, ou seja, não posso criar outro com o mesmo nome ou a mesma categoria)
)

CREATE TABLE TipoDeEvento(
	IdTipoDeEvento INT PRIMARY KEY IDENTITY,
	TituloTipoEvento VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Instituicao (
	IdInstituicao INT PRIMARY KEY IDENTITY,
	CNPJ CHAR(14) NOT NULL UNIQUE,
	NomeFantasia VARCHAR(50) NOT NULL,
	Endereco VARCHAR(30) NOT NULL 
)

--ALTER TABLE Instituicao
--ADD NomeFantasia VARCHAR(50) NOT NULL

CREATE TABLE Usuario (
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoDeUsuario INT FOREIGN KEY REFERENCES TipoDeUsuario(IdTIpoDeUsuario) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Email VARCHAR(256) NOT NULL UNIQUE,
	Senha VARCHAR(50) NOT NULL
)

CREATE TABLE Evento (
	IdEvento INT PRIMARY KEY IDENTITY,
	IdInstituicao INT FOREIGN KEY REFERENCES Instituicao(IdInstituicao) NOT NULL,
	IdTipoDeEvento INT FOREIGN KEY REFERENCES TipoDeEvento(IdTipoDeEvento) NOT NULL,
	NomeDoEvento VARCHAR(50) NOT NULL UNIQUE,
	Descricao VARCHAR(256) NOT NULL,
	DataEvento DATE NOT NULL,
	HoraEvento TIME NOT NULL
)	

CREATE TABLE PresencasDeEvento
(
	IdPresencasDeEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
	Situacao BIT DEFAULT(0) --Se ele não especificar nada, a presenca n vai ser confirmada (0) confirmado (1)
)

CREATE TABLE Comentario 
(
	IdComentario INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
	DescricaoComentario VARCHAR(256),
	ExibirComentario BIT DEFAULT(0) --Se ele não especificar nada, a presenca n vai ser exibido (0) exibir (1)

)

