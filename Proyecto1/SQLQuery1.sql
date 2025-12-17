USE master;
GO

DROP DATABASE CalculadoraBD;
GO

CREATE DATABASE CalculadoraBD;
GO

-- Usar la base de datos
USE CalculadoraBD;
GO

-- Crear la tabla para guardar los cálculos
CREATE TABLE Calculos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Operacion VARCHAR(100) NOT NULL,
    Resultado DECIMAL(18, 6) NOT NULL
);
GO