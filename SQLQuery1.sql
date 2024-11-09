create database nimusmatica;
go
use nimusmatica;
go
create table usuarios(
cod int identity(1,1),
nombre varchar(100) not null,
usuario varchar(50) not null,
pass varchar(50) not null,
tipo int not null default (1),
constraint pk_usuarios_cod primary key (cod),
);
go
create table tipos_monedas(
cod int identity(1,1),
nombre varchar(50),
constraint pk_tipos_monedas_int_cod primary key (cod),
);
go
create table tipos_usuarios(
cod int not null,
tipo varchar(50),
constraint pk_tipos_usuarios_cod primary key (cod)
);
go
create table paises(
cod int identity(1,1),
nombre varchar(50),
constraint pk_paises_cod primary key (cod),
);
go
create table tipos(
cod int not null,
tipo varchar(50),
constraint pk_tipos_cod primary key (cod),
);
go

create table monedas(
cod int identity(1,1),
valor money not null,
cantidad int default (1),
tipo int not null,
imagen varbinary(max),
fecha varchar(50),
tipo_moneda int,
pais int,
constraint pk_monedas_int_cod primary key (cod),
constraint fk_monedas_tipos_tipo foreign key (tipo) references tipos,
constraint fk_monedas_paises_pais foreign key (pais) references paises,
constraint fk_monedas_tipos_monedas_tipo_moneda foreign key (tipo_moneda) references tipos_monedas
);
go

create table billetes(
cod int identity(1,1),
valor money not null,
cantidad int default (1),
tipo int not null,
imagen varbinary(max),
fecha varchar(50),
tipo_moneda int,
pais int,
constraint pk_billetes_int_cod primary key (cod),
constraint fk_biletes_tipos_tipo foreign key (tipo) references tipos,
constraint fk_billetes_paises_pais foreign key (pais) references paises,
constraint fk_billetes_tipos_monedas_tipo_moneda foreign key (tipo_moneda) references tipos_monedas
);
go

create table monedas_especiales(
cod int identity(1,1),
nombre varchar(max) not null,
valor money not null,
cantidad int default (1),
tipo int not null,
imagen varbinary(max),
fecha varchar(50),
tipo_moneda int,
pais int,
constraint pk_monedas_especiales_cod primary key(cod),
constraint fk_monedas_especiales_tipo foreign key (tipo) references tipos,
constraint fk_monedas_especiales_paises_pais foreign key (pais) references paises,
constraint fk_monedas_especiales_tipos_monedas_tipo_moneda foreign key (tipo_moneda) references tipos_monedas
);

create table billetes_especiales(
cod int identity(1,1),
nombre varchar(max) not null,
valor money not null,
cantidad int default (1),
tipo int not null,
imagen varbinary(max),
fecha varchar(50),
tipo_moneda int,
pais int,
constraint pk_billetes_especiales_cod primary key(cod),
constraint fk_billetes_especiales_tipo foreign key (tipo) references tipos,
constraint fk_billetes_especiales_paises_pais foreign key (pais) references paises,
constraint fk_billetes_especiales_tipos_monedas_tipo_moneda foreign key (tipo_moneda) references tipos_monedas
);

insert into tipos values (1, 'nacionales'),
						(2, 'internacionales');
go
insert into tipos_usuarios values (1, 'común'),
						(2, 'administrador');
go
insert into usuarios values('Jeronimo', '1000662146','qwerty','2');
go
insert into paises values ('colombia'),
						 ('brasil');
go
insert into tipos_monedas values ('Pesos'),
								 ('Bolivares');
go

-------------------------------------
