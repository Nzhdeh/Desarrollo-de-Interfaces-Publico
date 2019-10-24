create database PersonaDepartamento
go
use PersonaDepartamento
go

create table PD_Departamentos
(
	ID int not null,
	Nombre varchar (20) null

	constraint PD_Departamentos primary key (ID)
)
go

create table PD_Personas
(
	ID int not null,
	Nombre varchar (20) null,
	Apellidos varchar (30) null,
	IDDepartamento int not null

	constraint PD_Personas primary key (ID),
	constraint FK_Persona_Departamento foreign key (IDDepartamento) references PD_Departamentos(ID)
)

--drop database PersonaDepartamento