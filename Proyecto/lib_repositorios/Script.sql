CREATE DATABASE db_Tienda_Zapatos;
GO
USE db_Tienda_Zapatos;
GO

CREATE TABLE Zapatos (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(100) NOT NULL,
	Codigo NVARCHAR(50) NOT NULL,
	Descripcion NVARCHAR(200) NOT NULL,
	Precio DECIMAL(10, 2) NOT NULL,
	Talla NVARCHAR(255) NULL,
	Marca NVARCHAR (200)
);

CREATE TABLE Clientes (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(100) NOT NULL,
	Cedula NVARCHAR(100) NOT NULL ,
	Direccion NVARCHAR(150) NOT NULL,
	Telefono NVARCHAR (100) NOT NULL
);

CREATE TABLE Empleados (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(100) NOT NULL,
	Cedula NVARCHAR(100) NOT NULL,
	Salario NVARCHAR(100) NOT NULL,
	Telefono NVARCHAR(100) NOT NULL
);

CREATE TABLE Inventarios (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Cantidad INT NOT NULL,
	Codigo NVARCHAR (100) NOT NULL,
	Zapato INT NOT NULL,
	FOREIGN KEY (Zapato) REFERENCES Zapatos(id)
);

CREATE TABLE Compras (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Fecha DATETIME NOT NULL DEFAULT GETDATE(),
	MetodoPago NVARCHAR(50) NOT NULL,
	Total DECIMAL(10, 2) NOT NULL,
	Codigo NVARCHAR(50) NOT NULL,

	Cliente INT NOT NULL,
	Empleado INT NOT NULL,
	FOREIGN KEY (cliente) REFERENCES Clientes(id),
	FOREIGN KEY (empleado) REFERENCES Empleados(id)
);

CREATE TABLE DetallesCompras (
	Id INT PRIMARY KEY IDENTITY (1,1),
	Cantidad INT,
	Subtotal DECIMAL (10,2),
	Codigo NVARCHAR (100),
	
	Zapato INT NOT NULL REFERENCES Zapatos(Id),
	Compra INT NOT NULL REFERENCES Compras(Id),
);

CREATE TABLE CuentaEmpleados (
	Id INT PRIMARY KEY IDENTITY (1,1),
	Correo NVARCHAR (100),
	Contrasena NVARCHAR (200),
	
	Empleado INT NOT NULL REFERENCES Empleados(Id)
);

CREATE TABLE CuentaClientes (
	Id INT PRIMARY KEY IDENTITY (1,1),
	Correo NVARCHAR (100),
	Contrasena NVARCHAR (200),
	
	Cliente INT NOT NULL REFERENCES Clientes(Id)
);

CREATE TABLE Auditorias (
	Id INT PRIMARY KEY IDENTITY (1,1),
	Fecha DATETIME,
	Accion NVARCHAR (50),
	Tabla NVARCHAR (50),
);


-- Zapatos
INSERT INTO Zapatos (Nombre, Codigo, Descripcion, precio, Talla, Marca) VALUES
('Tenis Blancos', 'ZAP-001', 'Tenis deportivos blancos', 199.99, '42', 'Nike'),
('Botas Negras', 'ZAP-002', 'Botas de cuero negras', 249.99, '40', 'Dr. Martens');

-- Clientes
INSERT INTO Clientes (Nombre, Cedula, Direccion, Telefono) VALUES
('Juan Pérez', '123456789', 'Calle 123 #45-67', '3101234567'),
('Ana Gómez', '987654321', 'Carrera 8 #76-20', '3159876543');

-- Empleados
INSERT INTO Empleados (Nombre, Cedula, Salario, Telefono) VALUES
('Carlos López', '1122334455', '3000000', '3121112233'),
('Lucía Ramírez', '5544332211', '2800000', '3142223344');

-- Inventario
INSERT INTO Inventarios (Cantidad, Codigo, Zapato) VALUES
(50, '1001', 1),
(30, '1002', 2);

-- Compras
INSERT INTO Compras (Fecha, MetodoPago, Total, Codigo, Cliente, Empleado) VALUES
(GETDATE(), 'Tarjeta', 449.98, 'COMP001', 1, 1),
(GETDATE(), 'Efectivo', 199.99, 'COMP002', 2, 2);

-- DetallesCompras
INSERT INTO DetallesCompras (Cantidad, Subtotal, Codigo, Zapato, Compra) VALUES
(1, 199.99, 'DET001', 1, 1),
(1, 249.99, 'DET002', 2, 1);

-- CuentaClientes
INSERT INTO CuentaClientes (Correo, Contrasena, Cliente) VALUES
('juanperez@email.com', 'clave123', 1),
('anagomez@email.com', 'clave456', 2);

-- CuentaEmpleados
INSERT INTO CuentaEmpleados (Correo, Contrasena, Empleado) VALUES
('carloslopez@empresa.com', 'admin123', 1),
('luciaramirez@empresa.com', 'admin456', 2);

-- Auditorias (no depende de ninguna otra tabla)
INSERT INTO Auditorias (Fecha, Accion, Tabla) VALUES
(GETDATE(), 'INSERT', 'Zapatos'),
(GETDATE(), 'INSERT', 'Clientes');
