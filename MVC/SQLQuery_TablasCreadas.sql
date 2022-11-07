CREATE DATABASE Facturacion

use Facturacion

CREATE TABLE Cliente(
	id int identity(1,1) primary key not null,
	nombre varchar(90),
	empresa varchar(90),
	dir_empresa varchar(90),
	tel_empresa varchar(90),
	-- fecha_nac Date,
);


CREATE TABLE Factura_cabecera(
	id int identity(1,1) primary key not null,
	idCliente int not null,
	fecha Date,
	fecha_vence Date,



	CONSTRAINT fk_Cliente FOREIGN KEY (idCliente) REFERENCES Cliente (id),

);

CREATE TABLE Producto(
	id int identity(1,1) primary key not null,
	nombre varchar(90),
	precio float,
);

CREATE TABLE Factura_detalle(
	id int identity(1,1) primary key not null,
	idFactCab int not null,
	idProducto int not null,
	cantidad int,

	CONSTRAINT fk_Factura_cabecera FOREIGN KEY (idFactCab) REFERENCES Factura_cabecera (id),
	CONSTRAINT fk_Producto FOREIGN KEY (idProducto) REFERENCES Producto (id),
);




