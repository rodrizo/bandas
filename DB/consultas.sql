
SELECT * FROM MusicosGrupos

--delete from MusicosGrupos where idgrupo = 3 and idmusico = 4

SELECT * FROM Grupos

SELECT * FROM Musicos


SELECT  1 FROM MusicosGrupos WHERE IdGrupo = 3 AND IdMusico = 10

--WS 2
SELECT gn.IdGenero, gn.Descripcion AS Genero, m.Nombre AS Musico 
FROM MusicosGrupos mg
INNER JOIN Musicos m ON m.IdMusico = mg.IdMusico
INNER JOIN Grupos g ON g.IdGrupo  = mg.IdGrupo
INNER JOIN GenerosGrupos gg ON gg.IdGrupo = g.IdGrupo
INNER JOIN Generos gn ON gn.IdGenero = gg.IdGenero
    AND gn.IdGenero = NVL(gn.IdGenero, gn.IdGenero) --Insertar ID de genero acá
WHERE mg.IdMusico IS NOT NULL

--WS 3





--WS 4

