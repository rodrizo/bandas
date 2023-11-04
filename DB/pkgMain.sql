
CREATE OR REPLACE PACKAGE pkgMain AS 

    PROCEDURE agregar_musico_grupo (p_IdGrupo in NUMBER, p_IdMusico in NUMBER, p_Instrumento in VARCHAR2, p_FechaInicio in DATE, 
    p_FechaFin in DATE, p_salida OUT VARCHAR2);
    
    PROCEDURE obtener_musico_genero  (p_IdGenero in NUMBER, p_cursor out sys_refcursor);
    
    PROCEDURE obtener_grupo_max  (p_cursor out sys_refcursor);
    
    PROCEDURE obtener_detalle_grupos  (p_IdGrupo in NUMBER, p_cursor out sys_refcursor);
    
END pkgMain;

    
CREATE OR REPLACE PACKAGE BODY pkgMain AS

    PROCEDURE agregar_musico_grupo (p_IdGrupo in NUMBER, p_IdMusico in NUMBER, p_Instrumento in VARCHAR2, p_FechaInicio in DATE, 
    p_FechaFin in DATE, p_salida OUT VARCHAR2) IS
    BEGIN
        DECLARE flag NUMBER; --Flag para validar inventario del pan
        BEGIN
            SELECT 1 INTO flag FROM MusicosGrupos WHERE IdGrupo = p_IdGrupo AND IdMusico = p_IdMusico;
            IF flag = 1 THEN
                p_salida:= '400'; --Código para determinar que el musico ya existe en el grupo
            END IF;
            
            EXCEPTION
                WHEN NO_DATA_FOUND THEN
                
                INSERT INTO MusicosGrupos VALUES(p_IdGrupo,p_IdMusico,p_Instrumento,p_FechaInicio, p_FechaFin);
                p_salida:='1';  --Código para determinar inserts
                COMMIT;
        END;
    END agregar_musico_grupo;
    
    
    PROCEDURE obtener_musico_genero  (p_IdGenero in NUMBER, p_cursor out sys_refcursor) IS
    BEGIN
        
        OPEN p_cursor FOR 
        SELECT gn.IdGenero, gn.Descripcion AS Genero, m.Nombre AS Musico 
        FROM MusicosGrupos mg
        INNER JOIN Musicos m ON m.IdMusico = mg.IdMusico
        INNER JOIN Grupos g ON g.IdGrupo  = mg.IdGrupo
        INNER JOIN GenerosGrupos gg ON gg.IdGrupo = g.IdGrupo
        INNER JOIN Generos gn ON gn.IdGenero = gg.IdGenero
            AND gn.IdGenero = NVL(p_IdGenero, gn.IdGenero) --Insertar ID de genero acá
        WHERE mg.IdMusico IS NOT NULL
        ORDER BY 1;
        
    END obtener_musico_genero;
    
    PROCEDURE obtener_grupo_max  (p_cursor out sys_refcursor) IS
    BEGIN
        OPEN p_cursor FOR 
        SELECT g.Nombre AS Grupo, LISTAGG(gn.Descripcion, ', ') AS Generos
        FROM Grupos g
        INNER JOIN GenerosGrupos gg ON gg.IdGrupo = g.IdGrupo
        INNER JOIN Generos gn ON gn.IdGenero = gg.IdGenero
        GROUP BY g.Nombre
        ORDER BY 2 DESC
        FETCH FIRST 1 ROW ONLY;
    END obtener_grupo_max;
    
    PROCEDURE obtener_detalle_grupos  (p_IdGrupo in NUMBER, p_cursor out sys_refcursor) IS
    BEGIN
    
        OPEN p_cursor FOR 
        SELECT g.Nombre AS Grupo, LISTAGG((m.Nombre || ' -> ' || m.Instrumento), ', ') AS Integrantes
        FROM Grupos g
        INNER JOIN MusicosGrupos mg ON mg.IdGrupo = g.IdGrupo
        INNER JOIN Musicos m ON m.IdMusico = mg.IdMusico
        WHERE g.IdGrupo = NVL(p_IdGrupo, g.IdGrupo) 
        GROUP BY g.Nombre;
    
    END obtener_detalle_grupos;
    
END pkgMain;

/*
SET SERVEROUTPUT ON;
VARIABLE p_salida VARCHAR2;

BEGIN
  pkgMain.agregar_musico_grupo(4, 4, 'guitarra', SYSDATE-5, SYSDATE-1,:p_salida);
 
END;
/


VARIABLE p_salida VARCHAR2;

BEGIN
  
  pkgMain.crud_ingrediente(11, 'Agua', 'Agua Salvavidas 2 TEST', 16, SYSDATE, 1, :p_salida);
END;
/


VARIABLE p_salida VARCHAR2;

BEGIN
  
  pkgMain.crud_sucursal(7, 'Nueva Terminal TEST', 'Main St 888', '505 12345678', 'Fidelina Perez', '8am - 7pm', 0, :p_salida);
END;
/


*/