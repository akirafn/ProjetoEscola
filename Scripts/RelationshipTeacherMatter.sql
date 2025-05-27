CREATE TABLE dbo.RelationshipTeacherMatter (
	id int identity(1,1) not null,
	teacherId int not null,
	matterId int not null,
	CONSTRAINT PK_TeacherMatter PRIMARY KEY (id)
);

INSERT INTO dbo.RelationshipTeacherMatter (teacherId, matterId) VALUES (1, 1);
INSERT INTO dbo.RelationshipTeacherMatter (teacherId, matterId) VALUES (2, 2);
INSERT INTO dbo.RelationshipTeacherMatter (teacherId, matterId) VALUES (3, 3);
INSERT INTO dbo.RelationshipTeacherMatter (teacherId, matterId) VALUES (4, 4);
