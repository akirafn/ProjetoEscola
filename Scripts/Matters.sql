CREATE TABLE dbo.Matters(
	id int identity(1,1) not null,
	name nvarchar(256) not null,
	CONSTRAINT PK_Matters PRIMARY KEY(id)
);

INSERT INTO dbo.Matters (name) VALUES ('Matemática');
INSERT INTO dbo.Matters (name) VALUES ('Português');
INSERT INTO dbo.Matters (name) VALUES ('História');
INSERT INTO dbo.Matters (name) VALUES ('Geografia');