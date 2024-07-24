USE [RegistroEstudiantesDB]
GO

--INSERT INTO usuario (numero_identificacion, nombre, apellido, nombre_usuario, correo, telefono, direccion, genero, estado, contrasena, fecharegistro, activo)
--VALUES 
--('1234567890', 'Juan', 'Perez', 'juan.perez', 'juan.perez1@uni.com', '1234567890', 'Direccion 1', 'M', 'Activo', 'contrasena1', GETDATE(), 1),
--('1234567891', 'Maria', 'Gomez', 'maria.gomez', 'maria.gomez1@uni.com', '1234567891', 'Direccion 2', 'F', 'Activo', 'contrasena2', GETDATE(), 1),
--('1234567892', 'Carlos', 'Lopez', 'carlos.lopez', 'carlos.lopez1@uni.com', '1234567892', 'Direccion 3', 'M', 'Activo', 'contrasena3', GETDATE(), 1),
--('1234567893', 'Ana', 'Martinez', 'ana.martinez', 'ana.martinez1@uni.com', '1234567893', 'Direccion 4', 'F', 'Activo', 'contrasena4', GETDATE(), 1),
--('1234567894', 'Luis', 'Rodriguez', 'luis.rodriguez', 'luis.rodriguez1@uni.com', '1234567894', 'Direccion 5', 'M', 'Activo', 'contrasena5', GETDATE(), 1),
--('1234567895', 'Laura', 'Hernandez', 'laura.hernandez', 'laura.hernandez1@uni.com', '1234567895', 'Direccion 6', 'F', 'Activo', 'contrasena6', GETDATE(), 1),
--('1234567896', 'Miguel', 'Garcia', 'miguel.garcia', 'miguel.garcia1@uni.com', '1234567896', 'Direccion 7', 'M', 'Activo', 'contrasena7', GETDATE(), 1),
--('1234567897', 'Sofia', 'Martinez', 'sofia.martinez', 'sofia.martinez1@uni.com', '1234567897', 'Direccion 8', 'F', 'Activo', 'contrasena8', GETDATE(), 1),
--('1234567898', 'David', 'Gonzalez', 'david.gonzalez', 'david.gonzalez1@uni.com', '1234567898', 'Direccion 9', 'M', 'Activo', 'contrasena9', GETDATE(), 1),
--('1234567899', 'Elena', 'Perez', 'elena.perez', 'elena.perez1@uni.com', '1234567899', 'Direccion 10', 'F', 'Activo', 'contrasena10', GETDATE(), 1),
--('1234567800', 'Jorge', 'Ramirez', 'jorge.ramirez', 'jorge.ramirez1@uni.com', '1234567800', 'Direccion 11', 'M', 'Activo', 'contrasena11', GETDATE(), 1),
--('1234567801', 'Isabel', 'Torres', 'isabel.torres', 'isabel.torres1@uni.com', '1234567801', 'Direccion 12', 'F', 'Activo', 'contrasena12', GETDATE(), 1),
--('1234567802', 'Pedro', 'Flores', 'pedro.flores', 'pedro.flores1@uni.com', '1234567802', 'Direccion 13', 'M', 'Activo', 'contrasena13', GETDATE(), 1),
--('1234567803', 'Lucia', 'Diaz', 'lucia.diaz', 'lucia.diaz1@uni.com', '1234567803', 'Direccion 14', 'F', 'Activo', 'contrasena14', GETDATE(), 1),
--('1234567804', 'Andres', 'Morales', 'andres.morales', 'andres.morales1@uni.com', '1234567804', 'Direccion 15', 'M', 'Activo', 'contrasena15', GETDATE(), 1),


--INSERT INTO [dbo].[usuario_rol]
--           ([fk_id_usuario]
--           ,[fk_id_rol]
--           ,[activo])
--     VALUES
--            ( 1,3,1),
--		    ( 2,3,1),
--			( 3,3,1),
--			( 4,3,1),
--			( 5,3,1),
--			--alumnos
--			( 6,2,1),
--			( 7,2,1),
--			( 8,2,1),
--			( 11,2,1),
--			( 10,2,1),
--			( 12,2,1),
--			( 13,2,1),
--			( 15,2,1),
--			( 16,2,1)
--GO



 -- INSERT INTO usuario_rol_carrera (fk_usuario_rol_id, fk_carrera_id, activo)
	--VALUES
	--		( 1,1,1),
	--	    ( 2,1,1),
	--		( 3,2,1),
	--		( 4,2,1),
	--		( 5,3,1),
	--		--alumnos
	--		( 6,1,1),
	--		( 7,1,1),
	--		( 8,1,1),
	--		( 9,2,1),
	--		( 10,2,1),
	--		( 11,2,1),
	--		( 12,3,1),
	--		( 13,3,1),
	--		( 14,3,1)


--	INSERT INTO [dbo].[carrera_materia]
--           ([fk_carrera_id]
--           ,[fk_materia_id]
--           ,[activo])
--     VALUES
--           (1,21,1),
--		   (1,22,1),
--		   (1,23,1),
--		   (3,25,1),
--		   (3,26,1),
--		   (2,27,1),
--		   (2,28,1),
--		   (2,29,1),
--		   (2,30,1),
--		   (1,31,1)
--GO

--INSERT INTO [dbo].[rol]
--           ([nombre])
--     VALUES
--           ('Administrador'),
--			 ('Alumno'),
--			 ('Profesor')
--GO




--INSERT INTO [dbo].[carrera]([nombre])
--     VALUES ('Ingeniería de Software'), ('Psicología'),  ('Filosofia')
--GO


-- Insertar materias en la tabla materia
--1  juan.perez@uni.com
--INSERT INTO materia (nombre, credito_materia, fk_carrera_id) 
--VALUES ('Programación Avanzada', 3, (SELECT carrera_id FROM carrera WHERE nombre = 'Ingeniería de Software'));

--INSERT INTO materia (nombre, credito_materia, fk_carrera_id) 
--VALUES ('Bases de Datos', 3, (SELECT carrera_id FROM carrera WHERE nombre = 'Ingeniería de Software'));

----2 maria.garcia@uni.com
--INSERT INTO materia (nombre, credito_materia, fk_carrera_id) 
--VALUES ('Ingeniería de Software', 3, (SELECT carrera_id FROM carrera WHERE nombre = 'Ingeniería de Software'));

--INSERT INTO materia (nombre, credito_materia, fk_carrera_id) 
--VALUES ('Algoritmos y Estructuras de Datos', 3, (SELECT carrera_id FROM carrera WHERE nombre = 'Ingeniería de Software'));


----3 carlos.lopez@uni.com
--INSERT INTO materia (nombre, credito_materia, fk_carrera_id) 
--VALUES ('Ética', 3, (SELECT carrera_id FROM carrera WHERE nombre = 'Filosofia'));

--INSERT INTO materia (nombre, credito_materia, fk_carrera_id) 
--VALUES ('Epistemología', 3, (SELECT carrera_id FROM carrera WHERE nombre = 'Filosofia'));


----4  ana.martinez@uni.com
--INSERT INTO materia (nombre, credito_materia, fk_carrera_id) 
--VALUES ('Psicología General', 3, (SELECT carrera_id FROM carrera WHERE nombre = 'Psicología'));

--INSERT INTO materia (nombre, credito_materia, fk_carrera_id) 
--VALUES ('Desarrollo Humano', 3, (SELECT carrera_id FROM carrera WHERE nombre = 'Psicología'));

----5   luis.rodriguez@uni.com
--INSERT INTO materia (nombre, credito_materia, fk_carrera_id) 
--VALUES ('Psicología del Desarrollo', 3, (SELECT carrera_id FROM carrera WHERE nombre = 'Psicología'));

--INSERT INTO materia (nombre, credito_materia, fk_carrera_id) 
--VALUES ('Psicología Clínica', 3, (SELECT carrera_id FROM carrera WHERE nombre = 'Psicología'));



--alumno
--INSERT INTO alumno ([fk_usuario_rol_id]
--           ,[fk_id_usuario]
--           ,[fk_id_rol]
--           ,[fk_carrera_id]
--           ,[fk_materia_id])
--SELECT ur.usuario_rol_id AS UsuarioRol, ur.fk_id_usuario AS IdUsuario, ur.fk_id_rol AS IdRol, c.carrera_id AS Carrera,  m.materia_id  AS Materia
--FROM usuario_rol ur
--INNER JOIN usuario_rol_carrera urc ON ur.usuario_rol_id = urc.fk_usuario_rol_id
--INNER JOIN carrera c ON c.carrera_id = urc.fk_carrera_id
--INNER JOIN carrera_materia cm ON cm.fk_carrera_id = c.carrera_id
--INNER JOIN materia m ON m.materia_id = cm.fk_materia_id
--INNER JOIN usuario u ON u.usuario_id = ur.fk_id_usuario
--INNER JOIN rol r ON r.rol_id = ur.fk_id_rol
--WHERE r.rol_id = 2;