CREATE TABLE dbo.Students(
	id int identity(1,1) not null,
	ra int not null,
	name nvarchar(max) not null,
	degreeId int not null,
	classId int not null,
	CONSTRAINT PK_Students PRIMARY KEY(id)
);

INSERT INTO dbo.Students (ra, name, degreeId, classId) VALUES (12346, 'Nome do aluno 1', 1, 1);
INSERT INTO dbo.Students (ra, name, degreeId, classId) VALUES (456798, 'Nome do aluno 2', 2, 1);
INSERT INTO dbo.Students (ra, name, degreeId, classId) VALUES (752156, 'Nome do aluno 3', 3, 2);
INSERT INTO dbo.Students (ra, name, degreeId, classId) VALUES (852348, 'Nome do aluno 4', 4, 2);
INSERT INTO dbo.Students (ra, name, degreeId, classId) VALUES (454643, 'Nome do aluno 5', 6, 2);
