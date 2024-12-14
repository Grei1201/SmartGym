-- Script para crear la base de datos SmartGym
CREATE DATABASE SmartGym;
GO

USE SmartGym;
GO

-- Tabla: Client
CREATE TABLE Client (
    IdClient INT PRIMARY KEY,
    Name VARCHAR(20),
    LastName1 VARCHAR(20),
    LastName2 VARCHAR(20),
    Phone NUMERIC(10, 0),
    City VARCHAR(20),
    Direcition VARCHAR(200),
    Age INT
);

-- Tabla: Trainner
CREATE TABLE Trainner (
    IdTrainner INT PRIMARY KEY,
    Name VARCHAR(20),
    LastName1 VARCHAR(20),
    LastName2 VARCHAR(20),
    Phone NUMERIC(10, 0),
    City VARCHAR(20),
    Direcition VARCHAR(200),
    IdLocal INT FOREIGN KEY REFERENCES Local(IdLocal)
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
(10000001, 'Juan', 'P�rez', 'Garc�a', 1234567890, 'Ciudad de M�xico', 'Calle 10, No. 15', 25),
(10000002, 'Mar�a', 'L�pez', 'Mart�nez', 2345678901, 'Bogot�', 'Calle 20, No. 30', 30),
(10000003, 'Carlos', 'Rodr�guez', 'Hern�ndez', 3456789012, 'Buenos Aires', 'Calle 5, No. 8', 22),
(10000004, 'Ana', 'Torres', 'Flores', 4567890123, 'Santiago', 'Calle 18, No. 25', 28),
(10000005, 'Luis', 'Ram�rez', 'Gonz�lez', 5678901234, 'Lima', 'Calle 12, No. 40', 35),
(10000006, 'Luc�a', 'P�rez', 'Garc�a', 6789012345, 'Madrid', 'Calle 3, No. 7', 27),
(10000007, 'Pedro', 'L�pez', 'Mart�nez', 7890123456, 'Barcelona', 'Calle 7, No. 12', 32),
(10000008, 'Sof�a', 'Rodr�guez', 'Hern�ndez', 8901234567, 'Quito', 'Calle 15, No. 20', 29),
(10000009, 'Jorge', 'Torres', 'Flores', 9012345678, 'Montevideo', 'Calle 4, No. 11', 24),
(10000010, 'Camila', 'Ram�rez', 'Gonz�lez', 1023456789, 'San Jos�', 'Calle 25, No. 5', 21)

SELECT * from Client

INSERT INTO Client (IdClient, Name, LastName1, LastName2, Phone, City, Direcition, Age)
VALUES 
(10000011, 'Fernando', 'Mart�nez', 'P�rez', 1239876543, 'Ciudad de M�xico', 'Calle 50, No. 20', 29),
(10000012, 'Isabel', 'G�mez', 'Torres', 9876543210, 'Bogot�', 'Calle 32, No. 12', 34),
(10000013, 'Miguel', 'Hern�ndez', 'Ram�rez', 5671239087, 'Buenos Aires', 'Calle 15, No. 25', 40),
(10000014, 'Elena', 'Vargas', 'L�pez', 8765432190, 'Santiago', 'Calle 21, No. 30', 26),
(10000015, 'Diego', 'Castro', 'Gonz�lez', 3456781234, 'Lima', 'Calle 19, No. 7', 23),
(10000016, 'Valeria', 'Rojas', 'Mart�nez', 4567890123, 'Madrid', 'Calle 2, No. 18', 31),
(10000017, 'Ricardo', 'Jim�nez', 'Flores', 9087654321, 'Barcelona', 'Calle 10, No. 45', 27),
(10000018, 'Patricia', 'Navarro', 'Rodr�guez', 5678901234, 'Quito', 'Calle 6, No. 28', 33),
(10000019, 'Andr�s', 'Mendoza', 'Luna', 3456791234, 'Montevideo', 'Calle 12, No. 11', 21),
(10000020, 'Laura', 'S�nchez', 'Fern�ndez', 1234567098, 'San Jos�', 'Calle 8, No. 35', 28);

INSERT INTO Client (IdClient, Name, LastName1, LastName2, Phone, City, Direcition, Age)
VALUES 