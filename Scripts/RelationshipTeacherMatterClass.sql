CREATE TABLE dbo.RelationshipTeacherClass (
	id int identity(1,1) not null,
	teacherId int not null,
	degreeId int not null,
	classId int not null,
	CONSTRAINT PK_TeacherClass PRIMARY KEY (id)
);

INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (1, 1, 1);
INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (1, 1, 2);
INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (1, 1, 3);
INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (1, 2, 1);
INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (2, 8, 1);
INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (2, 8, 2);
INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (2, 9, 1);
INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (3, 12, 1);
INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (3, 13, 1);
INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (3, 5, 1);
INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (3, 6, 1);
INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (4, 1, 1);
INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (4, 2, 1);
INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (4, 3, 1);
INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (4, 4, 1);
INSERT INTO dbo.RelationshipTeacherClass (teacherId, degreeId, classId) VALUES (4, 5, 1);
