/*DML*/
USE M_InLock;

INSERT INTO Usuarios(Email,Senha,Permissao) VALUES ('admin@admin.com','admin','A');
INSERT INTO Usuarios(Email,Senha) VALUES ('cliente@cliente.com','cliente');

INSERT INTO Paises(NomePais) VALUES ('EUA'),('JPN'),('BRA'),('UK'),('FRA');

INSERT INTO Estudios(NomeEstudio,PaisId,DataCriacao,UsuarioId) VALUES ('Blizzard',1,'08/02/1991',1)
																	, ('Rockstar Studios',1,'01/12/1998',1)
																	, ('Square Enix',2,'01/04/2003',1)
																	, ('Ubisoft',5,'12/3/1986',1);

INSERT INTO Jogos(NomeJogo,Descricao,DataLancamento,Valor,EstudioId) VALUES  ('Diablo 3','é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã','15/05/2012',99,1)
																			,('Red Dead Redemption II','jogo eletrônico de ação-aventura western','26/10/2018',120,2)
																			,('Kingdom Hearts III','Disney + Final Fantasy','25/01/2019',120,3)
																			,('Assassins Creed II','Jogo historico de assassinos','17/11/2009',100,4);


