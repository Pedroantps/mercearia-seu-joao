CREATE DATABASE bd_mercearia;

USE bd_mercearia;

CREATE TABLE Usuario(
id int AUTO_INCREMENT PRIMARY KEY,
nome varchar(100),
email varchar(100),
senha varchar(100),
tipoUsuario varchar(100),
dataHoraInsercao datetime,
dataHoraExclusao datetime
);

CREATE TABLE Produto(
id int AUTO_INCREMENT PRIMARY KEY,
nome varchar(100),
quantidade int,
precoUnitario float,
fornecedor varchar(100),
dataHoraInsercao datetime,
dataHoraExclusao datetime
);

CREATE TABLE Vende(
id int AUTO_INCREMENT PRIMARY KEY,
idUsuario int,
idProduto int,
qtdProduto int,
precoTotal float,
dataHoraVenda datetime,
FOREIGN KEY(idUsuario) references Usuario(id),
FOREIGN KEY(idProduto) references Produto(id)
);

INSERT INTO Usuario(nome, email, senha, tipoUsuario, dataHoraInsercao) 
VALUES ('Rodolfo', 'rodolfo@gmail.com', 'R0dolfo@', 'gerente', '2022-11-09 13:00:00'),
('Victor Hugo', 'victorhugo@gmail.com', 'VictorHug0@', 'caixa', '2022-11-09 13:00:00');
