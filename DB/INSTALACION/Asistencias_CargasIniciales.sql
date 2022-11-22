CREATE TABLE [Empleado] (
	[Id]	INTEGER NOT NULL CHECK(Id > 0) UNIQUE,
	[ClvEmpleado]	INTEGER NOT NULL CHECK(ClvEmpleado > 0) UNIQUE,
	[Nombre]	TEXT NOT NULL DEFAULT "Sin nombre",
	[ApellidoPaterno]	TEXT NOT NULL DEFAULT "Sin apellido",
	[ApellidoMaterno]	TEXT NOT NULL DEFAULT "Sin apellido",
	[Direccion]	TEXT NOT NULL DEFAULT "Sin direccion",
	[Cargo]	TEXT NOT NULL DEFAULT "Sin cargo",
	[Rfc]	TEXT NOT NULL DEFAULT "Sin RFC",
	[Curp]	TEXT NOT NULL DEFAULT "Sin CURP",
	[Telefono]	TEXT NOT NULL DEFAULT "Sin telefono",
	[HorasSemana]	INTEGER NOT NULL DEFAULT "Sin horas" CHECK(HorasSemana > 0),
	PRIMARY KEY([Id] AUTOINCREMENT)
);


CREATE UNIQUE INDEX [IX_Empleado_ClvEmpleado] ON [Empleado](ClvEmpleado);


CREATE TABLE [Asistencia] (
	[Id]	INTEGER NOT NULL UNIQUE,
	[Fecha]	TEXT NOT NULL,
	[Llegada]	TEXT NOT NULL,
	[Salida]	TEXT NOT NULL DEFAULT '',
	PRIMARY KEY([Id] AUTOINCREMENT)
);

CREATE INDEX [IX_Asistencia_Fecha] ON [Asistencia]([Fecha]);

ALTER TABLE [Asistencia] ADD COLUMN [ClvEmpleado] INTEGER NOT NULL REFERENCES [Empleado]([ClvEmpleado]);

CREATE TABLE "Admin" (
	"Id"	INTEGER NOT NULL UNIQUE,
	"Password"	TEXT NOT NULL CHECK(length(Password) > 8),
	PRIMARY KEY("Id" AUTOINCREMENT)
);

ALTER TABLE [Admin] ADD COLUMN [ClvEmpleado] INTEGER NOT NULL REFERENCES [Empleado]([ClvEmpleado]);



insert into Empleado (
            ClvEmpleado, 
            Nombre, 
            ApellidoPaterno,
            ApellidoMaterno, 
            Direccion, Cargo, Rfc, Curp, Telefono, HorasSemana) VALUES (1,'Nelson Alfonso','Beas','Ham','Direccion x','Ingeniero de software','123','123','8117201353','40');

insert into Empleado (
            ClvEmpleado, 
            Nombre, 
            ApellidoPaterno,
            ApellidoMaterno, 
            Direccion, Cargo, Rfc, Curp, Telefono, HorasSemana) VALUES (1942777,'Nombre2','apellido2','Apellido1.2','direccion 2','123','123','123','8117201353','40');

insert into Empleado (
            ClvEmpleado, 
            Nombre, 
            ApellidoPaterno,
            ApellidoMaterno, 
            Direccion, Cargo, Rfc, Curp, Telefono, HorasSemana) VALUES (2042777,'Nombre3','apellido3','Apellido1.3','direccion 3','123','123','123','8117201353','40');
					



INSERT INTO Asistencia (Fecha, Llegada, Salida, ClvEmpleado) VALUES ('12/17/2022','05:44:06','05:44:06' ,2042777);
INSERT INTO Asistencia (Fecha, Llegada, Salida, ClvEmpleado) VALUES ('12/18/2022','05:44:06','05:44:06' ,2042777);
INSERT INTO Asistencia (Fecha, Llegada, Salida, ClvEmpleado) VALUES ('12/19/2022','05:44:06','05:44:06' ,2042777);
INSERT INTO Asistencia (Fecha, Llegada, Salida, ClvEmpleado) VALUES ('12/20/2022','05:44:06','05:44:06' ,2042777);
INSERT INTO Asistencia (Fecha, Llegada, Salida, ClvEmpleado) VALUES ('11/01/2022','05:44:06','05:44:06' ,2042777);
INSERT INTO Asistencia (Fecha, Llegada, Salida, ClvEmpleado) VALUES ('11/02/2022','05:44:06','05:44:06' ,2042777);
INSERT INTO Asistencia (Fecha, Llegada, Salida, ClvEmpleado) VALUES ('11/03/2022','05:44:06','05:44:06' ,2042777);
INSERT INTO Asistencia (Fecha, Llegada, Salida, ClvEmpleado) VALUES ('11/04/2022','05:44:06','05:44:06' ,2042777);

