
--Generos
INSERT INTO Generos VALUES(1, 'Indie')
INSERT INTO Generos VALUES((SELECT MAX(IdGenero)+1 FROM Generos), 'Rock')
INSERT INTO Generos VALUES((SELECT MAX(IdGenero)+1 FROM Generos), 'Pop')
INSERT INTO Generos VALUES((SELECT MAX(IdGenero)+1 FROM Generos), 'Reggae')
INSERT INTO Generos VALUES((SELECT MAX(IdGenero)+1 FROM Generos), 'Folk')
INSERT INTO Generos VALUES((SELECT MAX(IdGenero)+1 FROM Generos), 'Jazz')
INSERT INTO Generos VALUES((SELECT MAX(IdGenero)+1 FROM Generos), 'Gospel')



--Grupos
INSERT INTO Grupos VALUES(1, 'Nirvana', SYSDATE-10000, SYSDATE-5000)
INSERT INTO Grupos VALUES((SELECT MAX(IdGrupo)+1 FROM Grupos), 'Foo Fighters', SYSDATE-10000, SYSDATE-5000)
INSERT INTO Grupos VALUES((SELECT MAX(IdGrupo)+1 FROM Grupos), 'Queen', SYSDATE-10000, SYSDATE-5000)
INSERT INTO Grupos VALUES((SELECT MAX(IdGrupo)+1 FROM Grupos), 'Jackson 5', SYSDATE-10000, SYSDATE-5000)


--Generos Grupos

INSERT INTO GenerosGrupos VALUES(1, 2)
INSERT INTO GenerosGrupos VALUES(4, 2)
INSERT INTO GenerosGrupos VALUES(2, 2)
INSERT INTO GenerosGrupos VALUES(3, 3)

--Musicos

INSERT INTO Musicos VALUES(1, 'Dave Grohl', 'Bateria', 'USA', SYSDATE-10000, NULL)
INSERT INTO Musicos VALUES((SELECT MAX(IdMusico)+1 FROM Musicos), 'Kurt Cobain', 'Guitarra', 'USA', SYSDATE-10000, SYSDATE-5000)
INSERT INTO Musicos VALUES((SELECT MAX(IdMusico)+1 FROM Musicos), 'Freddie Mercury', 'Todos', 'ENG', SYSDATE-10000, SYSDATE-5000)
INSERT INTO Musicos VALUES((SELECT MAX(IdMusico)+1 FROM Musicos), 'Michael Jackson', 'Todos', 'USA', SYSDATE-10000, SYSDATE-5000)


--Musicos Grupos
INSERT INTO MusicosGrupos VALUES(1,1,'Bateria',SYSDATE-10000, SYSDATE-2500)
INSERT INTO MusicosGrupos VALUES(2,1,'Solista',SYSDATE-10000, NULL)
INSERT INTO MusicosGrupos VALUES(1,2,'Solista y Guitarra',SYSDATE-10000, SYSDATE-5000)
INSERT INTO MusicosGrupos VALUES(4,4,'Solista y piano',SYSDATE-10000, SYSDATE-5000)
INSERT INTO MusicosGrupos VALUES(3,3,'Solista y piano',SYSDATE-10000, SYSDATE-5000)

