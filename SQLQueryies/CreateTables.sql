USE SchoolHelper;

-- Creates the general information table
/*CREATE TABLE SchoolHelperProg.current_generalinfo
(
id INTEGER PRIMARY KEY,
[name] NVARCHAR(50),
credits INTEGER NOT NULL,
);

-- Forgot to add the not null attribute
ALTER TABLE SchoolHelperProg.current_generalinfo
ALTER COLUMN [name] NVARCHAR(50) NOT NULL;

-- Decided to add a completed boolean for future GPA prediction uses
ALTER TABLE SchoolHelperProg.current_generalinfo
ADD completed BIT NOT NULL;

-- Also decided to put a final grade col for future GPA prediction uses
ALTER TABLE SchoolHelperProg.current_generalinfo
ADD final_grade CHAR; 

-- Decided to add a final grade weight col to reduce the amount of tables needed
ALTER TABLE SchoolHelperProg.current_generalinfo
ADD final_weight FLOAT;

-- Also need to put grade cutoff information
ALTER TABLE SchoolHelperProg.current_generalinfo
ADD 
A FLOAT NOT NULL,
B FLOAT NOT NULL,
C FLOAT NOT NULL,
D FLOAT NOT NULL;
*/

-- Now we want to make a catagories table
-- Since I want to use foreign keys, I'm going to rename a few things to make it a bit more clear
-- exec sp_rename 'SchoolHelperProg.current_generalinfo.id', 'courseID', 'COLUMN';
-- exec sp_rename 'SchoolHelperProg.current_generalinfo.name', 'courseName', 'COLUMN';

-- Makes the table
/*
CREATE TABLE SchoolHelperProg.catInfo
(
catID INT PRIMARY KEY,
catName NVARCHAR(100) NOT NULL,
expAssignments INT,
cat_weight FLOAT NOT NULL,
courseID INT FOREIGN KEY REFERENCES SchoolHelperProg.courseInfo(courseID)
);*/

-- Now makes the grade table
/*
CREATE TABLE SchoolHelperProg.gradeInfo
(
gradeID INT PRIMARY KEY,
gradeName NVARCHAR(100) NOT NULL,
pointsTotal INT NOT NULL,
pointsPossible INT NOT NULL,
catID INT FOREIGN KEY REFERENCES SchoolHelperProg.catInfo(catID),
courseID INT FOREIGN KEY REFERENCES SchoolHelperProg.courseInfo(courseID)
);*/

-- Now I wanted to add a timestamp on courses to see when they were last updated
ALTER TABLE SchoolHelperProg.courseInfo
ADD lastUpdate date NOT NULL;

SELECT * FROM SchoolHelperProg.courseInfo;
