CREATE TABLE dbo.Degrees(
	id int identity(1,1) not null,
	name nvarchar(256) not null,
	CONSTRAINT PK_Degrees PRIMARY KEY(id)
);

INSERT INTO dbo.Degrees (name) VALUES ('Ensino Fundamental');
INSERT INTO dbo.Degrees (name) VALUES ('1° ano do ensino médio');
INSERT INTO dbo.Degrees (name) VALUES ('2° ano do ensino médio');
INSERT INTO dbo.Degrees (name) VALUES ('3° ano do ensino médio');
INSERT INTO dbo.Degrees (name) VALUES ('Cursinho');
INSERT INTO dbo.Degrees (name) VALUES ('Estudo em casa');
INSERT INTO dbo.Degrees (name) VALUES ('Outros');
INSERT INTO dbo.Degrees (name) VALUES ('4º ano do ensino fundamental');
INSERT INTO dbo.Degrees (name) VALUES ('5º ano do ensino fundamental');
INSERT INTO dbo.Degrees (name) VALUES ('6º ano do ensino fundamental');
INSERT INTO dbo.Degrees (name) VALUES ('7º ano do ensino fundamental');
INSERT INTO dbo.Degrees (name) VALUES ('8º ano do ensino fundamental');
INSERT INTO dbo.Degrees (name) VALUES ('9º ano do ensino fundamental');
