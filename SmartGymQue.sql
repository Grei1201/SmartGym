-- Script para crear la base de datos SmartGym
CREATE DATABASE SmartGym;
GO

USE SmartGym;
GO


-- Tabla: Trainner
CREATE TABLE Trainner (
    IdTrainner INT PRIMARY KEY,
    Name VARCHAR(20),
    LastName1 VARCHAR(20),
    LastName2 VARCHAR(20),
	Password VARCHAR(100) NOT NULL,
    Phone NUMERIC(10, 0),
    City VARCHAR(20),
    Direcition VARCHAR(200),
    IdLocal INT FOREIGN KEY REFERENCES Local(IdLocal)    
);

-- Tabla: Client
CREATE TABLE Client (
    IdClient INT PRIMARY KEY,
    Password VARCHAR(100) NOT NULL,
    Name VARCHAR(20),
    LastName1 VARCHAR(20),
    LastName2 VARCHAR(20),
    Phone NUMERIC(10, 0),
    City VARCHAR(20),
    Direcition VARCHAR(200),
    Age INT

);

-- Tabla: GymMachine
CREATE TABLE GymMachine (
    IdMachine INT PRIMARY KEY,
    NameMachine VARCHAR(20),
    DateBuy DATE,
    DateMantence DATE,
    Brand NUMERIC(10, 0),
    City VARCHAR(20)
);

-- Tabla: Membership
CREATE TABLE Membership (
    IdMembership INT PRIMARY KEY,
    Membership VARCHAR(20),
    MambDays INT,
    Active BIT,
    PrimDate DATE,
    Renewal DATE
);

-- Tabla: Class
CREATE TABLE Class (
    IdClass INT PRIMARY KEY,
    NameClass VARCHAR(20),
    Day DATE,
    Hour TIME,
    IdTrainner INT FOREIGN KEY REFERENCES Trainner(IdTrainner),
    Space NUMERIC(2, 0)
);

-- Tabla: Local
CREATE TABLE Local (
    IdLocal INT PRIMARY KEY,
    City VARCHAR(20),
    Direcition VARCHAR(200)
);

INSERT INTO Client (IdClient, Name, LastName1, LastName2, Phone, City, Direcition, Age)
VALUES 
(10000001, 'Juan', 'Pérez', 'García', 1234567890, 'Ciudad de México', 'Calle 10, No. 15', 25),
(10000002, 'María', 'López', 'Martínez', 2345678901, 'Bogotá', 'Calle 20, No. 30', 30),
(10000003, 'Carlos', 'Rodríguez', 'Hernández', 3456789012, 'Buenos Aires', 'Calle 5, No. 8', 22),
(10000004, 'Ana', 'Torres', 'Flores', 4567890123, 'Santiago', 'Calle 18, No. 25', 28),
(10000005, 'Luis', 'Ramírez', 'González', 5678901234, 'Lima', 'Calle 12, No. 40', 35),
(10000006, 'Lucía', 'Pérez', 'García', 6789012345, 'Madrid', 'Calle 3, No. 7', 27),
(10000007, 'Pedro', 'López', 'Martínez', 7890123456, 'Barcelona', 'Calle 7, No. 12', 32),
(10000008, 'Sofía', 'Rodríguez', 'Hernández', 8901234567, 'Quito', 'Calle 15, No. 20', 29),
(10000009, 'Jorge', 'Torres', 'Flores', 9012345678, 'Montevideo', 'Calle 4, No. 11', 24),
(10000010, 'Camila', 'Ramírez', 'González', 1023456789, 'San José', 'Calle 25, No. 5', 21)

SELECT * from Client

INSERT INTO Client (IdClient, Name, LastName1, LastName2, Phone, City, Direcition, Age)
VALUES 
(10000011, 'Fernando', 'Martínez', 'Pérez', 1239876543, 'Ciudad de México', 'Calle 50, No. 20', 29),
(10000012, 'Isabel', 'Gómez', 'Torres', 9876543210, 'Bogotá', 'Calle 32, No. 12', 34),
(10000013, 'Miguel', 'Hernández', 'Ramírez', 5671239087, 'Buenos Aires', 'Calle 15, No. 25', 40),
(10000014, 'Elena', 'Vargas', 'López', 8765432190, 'Santiago', 'Calle 21, No. 30', 26),
(10000015, 'Diego', 'Castro', 'González', 3456781234, 'Lima', 'Calle 19, No. 7', 23),
(10000016, 'Valeria', 'Rojas', 'Martínez', 4567890123, 'Madrid', 'Calle 2, No. 18', 31),
(10000017, 'Ricardo', 'Jiménez', 'Flores', 9087654321, 'Barcelona', 'Calle 10, No. 45', 27),
(10000018, 'Patricia', 'Navarro', 'Rodríguez', 5678901234, 'Quito', 'Calle 6, No. 28', 33),
(10000019, 'Andrés', 'Mendoza', 'Luna', 3456791234, 'Montevideo', 'Calle 12, No. 11', 21),
(10000020, 'Laura', 'Sánchez', 'Fernández', 1234567098, 'San José', 'Calle 8, No. 35', 28);

ALTER TABLE Trainner
ADD Password VARCHAR(100) NOT NULL;

INSERT INTO Trainner (IdTrainner, Name, LastName1, LastName2, Phone, City, Direcition, Password)
VALUES 
(1, 'Carlos', 'Mendez', 'GenericLastName', 1234567890, 'Ciudad de México', 'Calle 10, No. 15', 'password1'),
(2, 'Ana', 'Ramirez', 'GenericLastName', 2345678901, 'Bogotá', 'Calle 20, No. 30', 'password2'),
(3, 'Luis', 'Fernandez', 'GenericLastName', 3456789012, 'Buenos Aires', 'Calle 5, No. 8', 'password3'),
(4, 'Marta', 'Suarez', 'GenericLastName', 4567890123, 'Santiago', 'Calle 18, No. 25', 'password4'),
(5, 'Juan', 'Lopez', 'GenericLastName', 5678901234, 'Lima', 'Calle 12, No. 40', 'password5'),
(6, 'Sofia', 'Morales', 'GenericLastName', 6789012345, 'Madrid', 'Calle 3, No. 7', 'password6'),
(7, 'Daniel', 'Gonzalez', 'GenericLastName', 7890123456, 'Barcelona', 'Calle 7, No. 12', 'password7'),
(8, 'Laura', 'Vargas', 'GenericLastName', 8901234567, 'Quito', 'Calle 15, No. 20', 'password8'),
(9, 'Fernando', 'Martinez', 'GenericLastName', 9012345678, 'Montevideo', 'Calle 4, No. 11', 'password9'),
(10, 'Elena', 'Cruz', 'GenericLastName', 1023456789, 'San José', 'Calle 25, No. 5', 'password10');


select * from Class

INSERT INTO Class (IdClass, NameClass, Day, Hour, IdTrainner, Space)
VALUES
(1, 'Zumba', '2024-12-16', '10:00 AM', 1, 20),
(2, 'CardioDance', '2024-12-17', '9:00 AM', 2, 25),
(3, 'Funcional', '2024-12-18', '8:00 AM', 1, 15);


select * from GymMachine

INSERT INTO GymMachine (IdMachine, NameMachine, DateBuy, DateMantence, Brand, City)
VALUES
(1, 'Cinta de Correr', '2022-01-15', '2025-01-15', 0001, 'Operativa'),
(2, 'Bicicleta Estática', '2021-03-10', '2024-03-10', 0002, 'Operativa'),
(3, 'Máquina de Remo', '2021-06-20', '2024-06-20', 0003, 'En Mantenimiento'),
(4, 'Máquina de Pesas', '2022-09-05', '2025-09-05', 0004, 'Operativa'),
(5, 'Elíptica', '2020-12-01', '2023-12-01', 0005, 'No Operativa'),
(6, 'Stepper', '2022-02-15', '2025-02-15', 0006, 'Operativa'),
(7, 'Banco de Pesas', '2021-07-10', '2024-07-10', 0007, 'Operativa'),
(8, 'Máquina de Piernas', '2021-11-05', '2024-11-05', 0008, 'Operativa'),
(9, 'Máquina de Pecho', '2020-08-20', '2023-08-20', 0009, 'No Operativa'),
(10, 'Press de Hombros', '2021-05-10', '2024-05-10', 0010, 'Operativa'),
(11, 'Máquina de Espalda', '2022-03-25', '2025-03-25', 0011, 'Operativa'),
(12, 'Máquina Abdominal', '2021-01-15', '2024-01-15', 0012, 'Operativa'),
(13, 'Smith Machine', '2021-04-20', '2024-04-20', 0013, 'Operativa'),
(14, 'Rack de Sentadillas', '2022-05-15', '2025-05-15', 0014, 'Operativa'),
(15, 'Máquina Gemelos', '2020-09-10', '2023-09-10', 0015, 'No Operativa'),
(16, 'Máquina Glúteos', '2021-08-15', '2024-08-15', 0016, 'Operativa'),
(17, 'Máquina Isqui', '2022-07-01', '2025-07-01', 0017, 'Operativa'),
(18, 'Máquina Cuádriceps', '2021-02-20', '2024-02-20', 0018, 'Operativa'),
(19, 'Cuerda Batalla', '2020-11-05', '2023-11-05', 0019, 'No Operativa'),
(20, 'Kettlebells', '2021-09-10', '2024-09-10', 0020, 'Operativa'),
(123, 'Maquina', '2023-11-27', '2024-11-26', 0021, 'Operativa');

EXEC sp_rename '@GymMachine.City', 'Status', 'COLUMN';

SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'GymMachine';

EXEC sp_rename 'GymMachine.City', 'Status', 'COLUMN';

select * from Membership

ALTER TABLE Membership
DROP COLUMN Renewal;


INSERT INTO Membership (IdMembership, Membership, MambDays, Price)
VALUES 
(01, 'Mensual', 30, 50),
(02,'Trimestral', 90, 140),
(03,'Anual', 365, 500);


ALTER TABLE Membership
ADD Price numeric NOT NULL;



ALTER TABLE Client
ADD IdMembership numeric NOT NULL Foreign Key,