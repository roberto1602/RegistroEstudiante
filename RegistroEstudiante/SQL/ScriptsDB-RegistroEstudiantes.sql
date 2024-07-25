--create database RegistroEstudiantesDB

--use RegistroEstudiantesDB


CREATE TABLE usuario (
    usuario_id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	numero_identificacion NVARCHAR(50),
	nombre NVARCHAR(100),
    apellido NVARCHAR(100),
    nombre_usuario NVARCHAR(100),-----
    correo NVARCHAR(100) unique,
	telefono NVARCHAR(15),
    direccion NVARCHAR(255),
    genero NVARCHAR(10),
    estado NVARCHAR(20),
    contrasena NVARCHAR(255),
    fecharegistro date,
	activo BIT
);


CREATE TABLE rol KEY IDENTITY(1,1) NOT NULL, (
    rol_id INT PRIMARY KEY,
    nombre NVARCHAR(50),
);

CREATE TABLE [dbo].[usuario_rol] (
    [usuario_rol_id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [fk_id_usuario] INT NOT NULL,
    [fk_id_rol] INT NOT NULL,
    [activo] BIT NOT NULL,
    CONSTRAINT FK_usuario_rol_usuario FOREIGN KEY ([fk_id_usuario]) REFERENCES [dbo].usuario,
    CONSTRAINT FK_usuario_rol_rol FOREIGN KEY ([fk_id_rol]) REFERENCES [dbo].rol
);



-- tabla carrera
CREATE TABLE carrera(
    carrera_id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    nombre NVARCHAR(50)
);

-- tabla materia
CREATE TABLE materia(
    materia_id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    nombre NVARCHAR(50),
    credito_materia FLOAT,
    fk_carrera_id INT FOREIGN KEY REFERENCES carrera(carrera_id)
);

-- tabla intermedia carrera_materia
CREATE TABLE carrera_materia (
    carrera_materia_id INT PRIMARY KEY IDENTITY(1,1),
    fk_carrera_id INT NOT NULL,
    fk_materia_id INT NOT NULL,
    activo BIT NOT NULL,
    FOREIGN KEY (fk_carrera_id) REFERENCES carrera(carrera_id),
    FOREIGN KEY (fk_materia_id) REFERENCES materia(materia_id)
);

-- usuario_rol_carrera
CREATE TABLE usuario_rol_carrera (
    usuario_rol_carrera_id INT PRIMARY KEY IDENTITY(1,1),
    fk_usuario_rol_id INT NOT NULL,
    fk_carrera_id INT NOT NULL,
    activo BIT NOT NULL,
    FOREIGN KEY (fk_usuario_rol_id) REFERENCES usuario_rol(usuario_rol_id),
    FOREIGN KEY (fk_carrera_id) REFERENCES carrera(carrera_id)
);


CREATE TABLE alumno (
    [alumno_id] [int] IDENTITY(1,1) NOT NULL,
	[fk_id_usuario] [int] NOT NULL,
	[fk_id_rol] [int] NOT NULL,
	[fk_carrera_id] [int] NOT NULL,
	[fk_materia_id] [int] NOT NULL,
	[rol] [nvarchar](100) NULL,
	[usuario] [nvarchar](100) NULL,
	[carrera] [nvarchar](100) NULL,
	[materia] [nvarchar](100) NULL,
    CONSTRAINT FK_usuario FOREIGN KEY (fk_id_usuario) REFERENCES usuario(usuario_id),
    CONSTRAINT FK_rol FOREIGN KEY (fk_id_rol) REFERENCES rol(rol_id),
    CONSTRAINT FK_carrera FOREIGN KEY (fk_carrera_id) REFERENCES carrera(carrera_id),
    CONSTRAINT FK_materia FOREIGN KEY (fk_materia_id) REFERENCES materia(materia_id)
);

