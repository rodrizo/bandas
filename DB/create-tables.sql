

DROP TABLE Generos CASCADE CONSTRAINTS;

DROP TABLE GenerosGrupos CASCADE CONSTRAINTS;

DROP TABLE Grupos CASCADE CONSTRAINTS;

DROP TABLE MusicosGrupos CASCADE CONSTRAINTS;

DROP TABLE Musicos CASCADE CONSTRAINTS;


CREATE TABLE Generos (
    IdGenero NUMBER(4) NOT NULL,
    Descripcion        VARCHAR2(45 CHAR)
);


ALTER TABLE Generos ADD CONSTRAINT Generos_pk PRIMARY KEY ( IdGenero );

CREATE TABLE Grupos (
    IdGrupo NUMBER(4) NOT NULL,
    Nombre        VARCHAR2(45 CHAR),
    Formacion        DATE,
    Desintegracion        DATE
);


ALTER TABLE Grupos ADD CONSTRAINT Grupos_pk PRIMARY KEY ( IdGrupo );

CREATE TABLE GenerosGrupos (
    IdGrupo NUMBER(4) NOT NULL,
    IdGenero NUMBER(4) NOT NULL
);


CREATE TABLE Musicos (
    IdMusico NUMBER(4) NOT NULL,
    Nombre        VARCHAR2(45 CHAR),
    Instrumento        VARCHAR2(45 CHAR),
    LugarNacimiento        VARCHAR2(45 CHAR),
    FechaNacimiento        DATE,
    FechaMuerte        DATE
);


ALTER TABLE Musicos ADD CONSTRAINT Musicos_pk PRIMARY KEY ( IdMusico );

CREATE TABLE MusicosGrupos (
    IdGrupo NUMBER(4) NOT NULL,
    IdMusico NUMBER(4) NOT NULL,
    Instrumento        VARCHAR2(45 CHAR),
    FechaInicio DATE,
    FechaFin        DATE
);


/*FKS*/
ALTER TABLE MusicosGrupos
    ADD CONSTRAINT MusicosGrupos_Grupos_fk FOREIGN KEY ( IdGrupo )
        REFERENCES Grupos ( IdGrupo );



ALTER TABLE MusicosGrupos
    ADD CONSTRAINT MusicosGrupos_Musicos_fk FOREIGN KEY ( IdMusico )
        REFERENCES Musicos ( IdMusico );
        
        
ALTER TABLE GenerosGrupos
    ADD CONSTRAINT GenerosGrupos_Grupos_fk FOREIGN KEY ( IdGrupo )
        REFERENCES Grupos ( IdGrupo );


ALTER TABLE GenerosGrupos
    ADD CONSTRAINT GenerosGrupos_Generos_fk FOREIGN KEY ( IdGenero )
        REFERENCES Generos ( IdGenero );

