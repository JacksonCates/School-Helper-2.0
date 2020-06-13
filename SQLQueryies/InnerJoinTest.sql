-- This is used to test for SQL code while coding the c# code

USE SchoolHelper;

--SELECT * FROM SchoolHelperProg.courseInfo;
SELECT * FROM SchoolHelperProg.catInfo;
SELECT * FROM SchoolHelperProg.gradeInfo;

-- InnerJoining the course and category tables
/*
SELECT co.courseName, ca.catName, ca.expAssignments, ca.cat_weight FROM SchoolHelperProg.courseInfo co
INNER JOIN SchoolHelperProg.catInfo ca
ON co.courseID = ca.courseID
WHERE co.courseName = 'CSC215';
*/

-- InnerJoining the course, category, and grade tables
SELECT co.courseName, ca.catName, g.gradeName, g.pointsTotal, g.pointsPossible
FROM SchoolHelperProg.courseInfo co
INNER JOIN SchoolHelperProg.gradeInfo g
ON co.courseID = g.courseID
INNER JOIN SchoolHelperProg.catInfo ca
ON g.catID = ca.catID
WHERE co.courseName = 'CSC215' AND ca.catName = 'Exams'
ORDER BY ca.catName;

SELECT SchoolHelperProg.courseInfo.courseName, SchoolHelperProg.catInfo.catName, SchoolHelperProg.gradeInfo.gradeName, SchoolHelperProg.gradeInfo.pointsTotal, SchoolHelperProg.gradeInfo.pointsPossible FROM SchoolHelperProg.courseInfo INNER JOIN SchoolHelperProg.catInfo ON SchoolHelperProg.courseInfo.courseID = SchoolHelperProg.catInfo.courseID INNER JOIN SchoolHelperProg.gradeInfo ON SchoolHelperProg.catInfo.catID = SchoolHelperProg.gradeInfo.catID WHERE SchoolHelperProg.courseInfo.courseName = 'CSC215' AND SchoolHelperProg.catInfo.catName = 'Exams';