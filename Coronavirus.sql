create database Coronavirus
go
use Coronavirus
go

create table Preguntas
(
	idPregunta int identity(1,1) not null,
	pregunta varchar (35) null,

	-----------------pk------------------------
	constraint PK_Preguntas primary key (idPregunta) 
)
go

create table Respuestas 
(
	idRespuesta int identity(1,1) not null, 
	idPregunta int not null, 
	respuesta varchar (20) not null, 
	posibleCaso bit not null

	-------------pk-----------------------------	
	constraint PK_Respuestas primary key (idRespuesta),

	-------------fk--------------------------------
	constraint FK_Preguntas_Respuestas foreign key (idPregunta) references Preguntas(idPregunta)
)
go

create table Personas 
(
	dniPersona char(9) not null, 
	nombrePersona varchar(20) not null, 
	apellidosPersona varchar(30) not null, 
	telefono varchar(15) not null, 
	direccion varchar(50) not null, 
	diagnostico bit not null,

	-------------pk-----------------------------	
	constraint PK_Personas primary key (dniPersona)
)
go

insert into Preguntas(pregunta)
values ('¿Tiene usted tos?'),
		('¿Tiene usted fiebre?'),
		('¿Tiene usted dolor de garganta?'),
		('¿Dificultad para respirar?'),
		('¿Escalofríos y malestar general?'),
		('¿Secreción y goteo nasal?'),
		('¿Tiene usted dolor de cabeza?')

select * from Preguntas

--0 es false y 1 es true
insert into Respuestas(idPregunta,respuesta,posibleCaso)
values(1,'Si',1),
		(1,'No',0),
		(2,'No',0),
		(2,'Entre 37º y 38º',0),
		(2,'>38º',1),
		(3,'Si',1),
		(3,'No',0),
		(4,'Si',1),
		(4,'No',0),
		(5,'Si',1),
		(5,'No',0),
		(6,'Si',1),
		(6,'No',0),
		(7,'Si',1),
		(7,'No',0)

select * from Respuestas

