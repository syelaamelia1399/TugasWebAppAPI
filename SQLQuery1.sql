CREATE DATABASE db_TugasBaruMVC;

CREATE TABLE Division
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100)
);

CREATE TABLE Department
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100),
	DivisionId INT,
	FOREIGN KEY(DivisionId) REFERENCES Division(Id)
);

INSERT INTO Division(Name) VALUES
('Aplikasi Development Devisi'),
('Manager Service Business');

INSERT INTO Department(Name, DivisionId) VALUES
('Aplikasi development 1', 1),
('Aplikasi development 2', 1),
('Training Center', 1),
('Manage Service Bid', 2),
('Manage Service Operator', 2),
('Manage Service Finance', 2);

SELECT * FROM Department;