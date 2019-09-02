/*DQL*/
USE M_InLock;

SELECT * FROM Usuarios;
SELECT * FROM Estudios;
SELECT * FROM Jogos;
SELECT J.NomeJogo AS Jogo,FORMAT( J.DataLancamento, 'dd/MM/yyyy') AS DataLancamento,E.NomeEstudio AS Estudio,P.NomePais AS Pais FROM Jogos J JOIN Estudios E ON J.EstudioId = E.EstudioId
																																			 JOIN Paises P ON P.PaisId = E.PaisId;
SELECT J.NomeJogo AS Jogo,FORMAT( J.DataLancamento, 'dd/MM/yyyy') AS DataLancamento,E.NomeEstudio AS Estudio,P.NomePais AS Pais FROM Jogos J FULL JOIN Estudios E ON J.EstudioId = E.EstudioId
																																			 JOIN Paises P ON P.PaisId = E.PaisId;
SELECT * FROM Usuarios WHERE Email LIKE '%a%' AND Senha LIKE '%a%';
SELECT * FROM Jogos WHERE JogoId = 1;
SELECT * FROM Estudios WHERE EstudioId = 1;