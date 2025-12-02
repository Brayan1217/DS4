

-- Crear Base de Datos
CREATE DATABASE BrayanMartinez;
GO

USE BrayanMartinez;
GO

-- Tabla 1: Casos
CREATE TABLE BM_Casos (
    CasoId INT PRIMARY KEY IDENTITY(1,1),
    NumeroCaso VARCHAR(50) UNIQUE NOT NULL,
    Titulo VARCHAR(200) NOT NULL,
    NombreCliente VARCHAR(100) NOT NULL,
    AbogadoAsignado VARCHAR(100) NOT NULL,
    TipoCaso VARCHAR(50),
    FechaInicio DATE NOT NULL,
    FechaFinal DATE,
    Descripcion TEXT
);

-- Tabla 2: Documentos
CREATE TABLE BM_Documentos (
    DocumentoId INT PRIMARY KEY IDENTITY(1,1),
    CasoId INT FOREIGN KEY REFERENCES BM_Casos(CasoId),
    NombreArchivo VARCHAR(200),
    Descripcion VARCHAR(300)
);

-- Tabla 3: Usuarios
CREATE TABLE BM_Usuarios (
    UsuarioId INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario VARCHAR(50) UNIQUE NOT NULL,
    NombreCompleto VARCHAR(100),
    Rol VARCHAR(20)
);
