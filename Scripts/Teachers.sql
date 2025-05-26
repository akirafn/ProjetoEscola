CREATE TABLE dbo.Teachers(
	id int identity(1,1) not null,
	name nvarchar(max) not null,
	CONSTRAINT PK_Teachers PRIMARY KEY(id)
);

INSERT INTO dbo.Teachers (name) VALUES ('Professor 1');
INSERT INTO dbo.Teachers (name) VALUES ('Professor 2');
INSERT INTO dbo.Teachers (name) VALUES ('Professor 3');
INSERT INTO dbo.Teachers (name) VALUES ('Professor 4');
INSERT INTO dbo.Teachers (name) VALUES ('Professor 5');
INSERT INTO dbo.Teachers (name) VALUES ('Professor 6');
