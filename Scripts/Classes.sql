CREATE TABLE dbo.Classes(
	id int identity(1,1) not null,
	name nvarchar(8) not null,
	CONSTRAINT PK_Classes PRIMARY KEY(id)
);

INSERT INTO dbo.Classes (name) VALUES ('A');
INSERT INTO dbo.Classes (name) VALUES ('B');
INSERT INTO dbo.Classes (name) VALUES ('C');
INSERT INTO dbo.Classes (name) VALUES ('D');
INSERT INTO dbo.Classes (name) VALUES ('E');
INSERT INTO dbo.Classes (name) VALUES ('F');
