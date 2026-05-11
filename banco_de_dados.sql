-- Script de criação do banco de dados
-- Sistema de Gestão Acadêmica

CREATE DATABASE IF NOT EXISTS GestaoAcademicaDB CHARACTER SET utf8mb4;
USE GestaoAcademicaDB;

CREATE TABLE Alunos (
    Id INT NOT NULL AUTO_INCREMENT,
    Nome LONGTEXT NOT NULL,
    Email LONGTEXT NOT NULL,
    PRIMARY KEY (Id)
) CHARACTER SET utf8mb4;

CREATE TABLE Disciplinas (
    Id INT NOT NULL AUTO_INCREMENT,
    Nome LONGTEXT NOT NULL,
    CargaHoraria INT NOT NULL,
    PRIMARY KEY (Id)
) CHARACTER SET utf8mb4;

CREATE TABLE Professores (
    Id INT NOT NULL AUTO_INCREMENT,
    Nome LONGTEXT NOT NULL,
    Email LONGTEXT NOT NULL,
    PRIMARY KEY (Id)
) CHARACTER SET utf8mb4;

CREATE TABLE Notas (
    Id INT NOT NULL AUTO_INCREMENT,
    AlunoId INT NOT NULL,
    DisciplinaId INT NOT NULL,
    Valor DECIMAL(65,30) NOT NULL,
    PRIMARY KEY (Id),
    CONSTRAINT FK_Notas_Alunos_AlunoId
        FOREIGN KEY (AlunoId) REFERENCES Alunos(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Notas_Disciplinas_DisciplinaId
        FOREIGN KEY (DisciplinaId) REFERENCES Disciplinas(Id) ON DELETE CASCADE
) CHARACTER SET utf8mb4;

CREATE TABLE Turmas (
    Id INT NOT NULL AUTO_INCREMENT,
    Nome LONGTEXT NOT NULL,
    ProfessorId INT NOT NULL,
    DisciplinaId INT NOT NULL,
    PRIMARY KEY (Id),
    CONSTRAINT FK_Turmas_Professores_ProfessorId
        FOREIGN KEY (ProfessorId) REFERENCES Professores(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Turmas_Disciplinas_DisciplinaId
        FOREIGN KEY (DisciplinaId) REFERENCES Disciplinas(Id) ON DELETE CASCADE
) CHARACTER SET utf8mb4;

CREATE INDEX IX_Notas_AlunoId ON Notas(AlunoId);
CREATE INDEX IX_Notas_DisciplinaId ON Notas(DisciplinaId);
CREATE INDEX IX_Turmas_ProfessorId ON Turmas(ProfessorId);
CREATE INDEX IX_Turmas_DisciplinaId ON Turmas(DisciplinaId);
