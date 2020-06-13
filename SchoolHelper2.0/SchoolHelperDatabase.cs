using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace SchoolHelper2._0
{
    internal static class SchoolHelperDatabase
    {
        private const string connectionPathString = @"C:\SchoolHelperFileSystem\SQLConnectionString";
        private const string courseInfoTable = "SchoolHelperProg.courseInfo";
        private const string catInfoTable = "SchoolHelperProg.catInfo";
        private const string gradeInfoTable = "SchoolHelperProg.gradeInfo";
        private static Database database;

        // Returns true for success, false for not
        internal static bool Load(List<Course> courses)
        {
            // Makes sure the courses vector is clear
            if(Courses.List.Count() != 0)
            {
                Console.WriteLine("Courses vector is not clear!");
                return false;
            }

            // Connects to the database, checks for success
            if (Connect())
            {
                // Reads in all the data
                DataTable courseTable = database.Select(courseInfoTable, "completed = 0");

                // Goes for each course
                foreach(DataRow courseRow in courseTable.Rows)
                {
                    // Debuggings
                    /*
                    foreach (var item in courseRow.ItemArray)
                    {
                        Console.Write(item);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                    */

                    // Test if it is a incompleted course
                    if ((bool)courseRow.ItemArray[3] == false)
                    {
                        // Builds the course
                        Course newCourse = new Course();
                        newCourse.name = (string)courseRow.ItemArray[1];
                        newCourse.credits = (int)courseRow.ItemArray[2];

                        // Test for null for final_weight
                        if (courseRow.ItemArray[5] == DBNull.Value)
                            newCourse.finalWeight = -1;
                        else
                            newCourse.finalWeight = (double)courseRow.ItemArray[5];

                        // Creates the cutoffs list
                        List<double> cutOffs = new List<double>();
                        for (int i = 6; i < 10; i++)
                            cutOffs.Add((double)courseRow.ItemArray[i]);
                        newCourse.cutOffs = cutOffs;

                        // Get the category table
                        DataTable catTable = database.InnerJoin(courseInfoTable, catInfoTable, "courseID",
                            new List<string>() { "courseName" }, new List<string>() { "catName", "expAssignments", "cat_weight" },
                            courseInfoTable + ".courseName = \'" + newCourse.name + "\'");


                        // Goes through each cat
                        foreach(DataRow catRow in catTable.Rows)
                        {
                            // Debugging
                            /*
                            foreach (var item in catRow.ItemArray)
                            {
                                Console.Write(item);
                                Console.Write(" ");
                            }
                            Console.WriteLine();*/

                            // Builds the new cat
                            Category newCat = new Category();
                            newCat.name = (string)catRow.ItemArray[1];

                            // test for null for expAssignments
                            if (catRow.ItemArray[2] == DBNull.Value)
                                newCat.expAssignments = -1;
                            else
                                newCat.expAssignments = (int)catRow.ItemArray[2];

                            // Weight
                            newCat.weight = (double)catRow.ItemArray[3];

                            // Get the grade table
                            DataTable gradeTable = database.DoubleInnerJoin(courseInfoTable, catInfoTable, gradeInfoTable, "courseID", "catID",
                                new List<string>() { "courseName" }, new List<string>() { "catName" }, 
                                new List<string>() { "gradeName", "pointsTotal", "pointsPossible" },
                                courseInfoTable + ".courseName = \'" + newCourse.name + "\' AND " 
                                + catInfoTable + ".catName = \'" + newCat.name + "'");

                            // Goes through each grade
                            foreach (DataRow gradeRow in gradeTable.Rows)
                            {
                                // Debugging
                                /*foreach (var item in catRow.ItemArray)
                                {
                                    Console.Write(item);
                                    Console.Write(" ");
                                }
                                Console.WriteLine();*/

                                // Builds the grade
                                Grade newGrade = new Grade();
                                newGrade.name = (string)gradeRow.ItemArray[2];
                                newGrade.pointsEarned = (int)gradeRow.ItemArray[3];
                                newGrade.pointsPossible = (int)gradeRow.ItemArray[4];

                                // Adds the grade
                                newCat.grades.Add(newGrade);
                            }

                            // Adds the catagory
                            newCourse.categories.Add(newCat);
                        }

                        // Adds the course to the vector
                        Courses.List.Add(newCourse);

                        // prints debugging
                        newCourse.PrintDebugInfo();
                            
                    }
                    // Adds to the completed course list
                    else
                    {
                        Console.WriteLine("FIXME: COMPLETED COURSE VECTOR");
                    }


                    // Gets the cat info
                    database.InnerJoin(courseInfoTable, catInfoTable, "courseID", new List<string>() { "courseName" },
                        new List<string>() { "catName", "expAssignments", "cat_weight" }, courseInfoTable + ".courseName = " + @"'newCourse.name'");


                }

                database.Close();
                return true;
            }

            return false;
        }

        internal static void Sync(object sender, EventArgs e)
        {
            DataTable table;

            // Connects to the database, checks for success
            if (Connect())
            {
                // Clears the course FOR DEBUGGING
                //database.CleanTable(gradeInfoTable);
                //database.CleanTable(catInfoTable);
                //database.CleanTable(courseInfoTable);

                // Checks if we need to remove a uncompleted course
                // Need to create the where statement to return a list of ID's
                string whereStatement = "completed = 0";

                // Creates multiple AND statements to single out the non completed course
                foreach (Course currCourse in Courses.List)
                    whereStatement += " AND courseName != \'" + currCourse.name + "\'";
                whereStatement += ";";

                // Runs the statement
                table = database.Select(courseInfoTable, whereStatement, new List<string> { "courseID" });

                // Removes all of the results with the ID
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine("Removing Course ID: " + row.ItemArray[0]);
                    RemoveCourse(row.ItemArray[0].ToString());
                }

                // Goes through each course to check for update and add
                foreach (Course currCourse in Courses.List)
                {
                    // test if we need to add the course
                    table = database.Select(courseInfoTable, "courseName = '" + currCourse.name + "' AND completed = 0");
                    if (table.Rows.Count == 0)
                    {
                        // add to course info
                        addCourse(currCourse);
                        UpdateDate(currCourse);
                    }
                    else
                    {
                        // Checks for updates
                        UpdateCourse(currCourse);
                        UpdateDate(currCourse);
                    }

                    // Saves in file system
                    FileSystem.Save(currCourse);

                    // Cleans the table
                    table.Clear();
                }

                // Closes
                database.Close();
            }
        }

        private static bool UpdateCourse(Course course)
        {
            try
            {
                // Builds a table for the program to update
                List<List<string>> newTable = new List<List<string>>();

                // Checks for updates in course information
                List<string> row = new List<string> { course.name, course.credits.ToString(),
                    course.finalWeight.ToString(), course.cutOffs[0].ToString(), course.cutOffs[1].ToString(),
                    course.cutOffs[2].ToString(), course.cutOffs[3].ToString()};
                newTable.Add(row);

                database.UpdateTable(courseInfoTable, "courseName = \'" + course.name + "\'", 
                    new List<string> { "courseID", "courseName", "credits", "final_weight", "A", "B", "C", "D"}, newTable);

                // Check to delete a category
                // Need to create the where statement to return a list of ID's
                string whereStatement = "completed = 0 AND courseName = \'" + course.name + "\'";

                // Creates multiple AND statements to single out the non completed course
                foreach (Category currCat in course.categories)
                    whereStatement += " AND catName != \'" + currCat.name + "\'";
                whereStatement += ";";

                // Runs the statement
                DataTable table = database.InnerJoin(catInfoTable, courseInfoTable, "courseID",
                    new List<string> { "catID" }, new List<string> { "courseID" }, whereStatement);

                // Runs through each row, removing each row
                foreach (DataRow catRow in table.Rows)
                {
                    // Remove all of the grades in the category
                    database.Delete(gradeInfoTable, "catID = " + catRow[0]);

                    // Remove the category
                    database.Delete(catInfoTable, "catID = " + catRow[0]);
                }

                // Goes through each category to check for update and add
                table.Clear();
                foreach (Category currCat in course.categories)
                {
                    // test if we need to add the category
                    table = database.InnerJoin(catInfoTable, courseInfoTable, "courseID",
                        new List<string> { "catName", "catID" }, new List<string>() { "courseID" }, 
                        "courseName = \'" + course.name + "\' AND catName = \'" + currCat.name + "\'");
                    if (table.Rows.Count == 0)
                    {
                        // Get the course ID
                        DataTable courseIDTable = database.Select(courseInfoTable, "courseName = \'" + course.name + "\'",
                            new List<string> { "courseID" });

                        // add category info
                        addCat(currCat, courseIDTable.Rows[0][0].ToString());
                    }
                    else
                    {
                        // Checks for updates
                        // Builds a new table
                        newTable = new List<List<string>>();

                        // Adds the new row of data
                        row = new List<string>() { currCat.name, currCat.expAssignments.ToString(),
                            currCat.weight.ToString()};
                        newTable.Add(row);

                        // Updates the table
                        database.UpdateTable(catInfoTable, "courseID = " + table.Rows[0][2].ToString() +
                            " AND catID = " + table.Rows[0][1].ToString(), 
                            new List<string> { "catID", "catName", "expAssignments", "cat_weight" },
                            newTable);

                        // Check to delete a grade
                        // Need to create the where statement to return a list of ID's
                        whereStatement = "completed = 0 AND courseName = \'" + course.name + "\' AND catName = \'"
                            + currCat.name + "\'";

                        // Creates multiple AND statements to single out the non completed course
                        foreach (Grade currGrade in currCat.grades)
                            whereStatement += " AND gradeName != \'" + currGrade.name + "\'";

                        // Runs the statement
                        table.Clear();
                        table = database.DoubleInnerJoin(courseInfoTable, catInfoTable, gradeInfoTable,
                            "courseID", "catID", new List<string> { "courseID" },
                            new List<string> { "catID" }, new List<string> { "gradeID" }, whereStatement);

                        // Runs through each row, removing each grade
                        foreach (DataRow gradeRow in table.Rows)
                        {
                            // Removes the grade
                            database.Delete(gradeInfoTable, "gradeID = " + gradeRow[2]);
                        }

                        foreach (Grade currGrade in currCat.grades)
                        {
                            // Check to add a grade
                            table.Clear();
                            table = database.DoubleInnerJoin(courseInfoTable, catInfoTable, gradeInfoTable,
                                "courseID", "catID", new List<string> { "courseID" },
                                new List<string> { "catID" }, new List<string> { "gradeID" },
                                "courseName = \'" + course.name + "\' AND catName = \'" + currCat.name +
                                "\' AND gradeName = \'" +  currGrade.name + "\'");
                            if (table.Rows.Count == 0)
                            {
                                // Gets the current ID's
                                DataTable courseIDTable = database.Select(courseInfoTable, "courseName = \'" + course.name + "\'",
                                    new List<string> { "courseID" });
                                DataTable catIDTable = database.Select(catInfoTable, "catName = \'" + currCat.name + "\' AND courseID = "
                                    + courseIDTable.Rows[0][0].ToString(), new List<string> { "catID" });
                                string gradeID = database.GetNewID(gradeInfoTable, "gradeID").ToString();

                                Console.WriteLine(courseIDTable.Rows[0][0].ToString() + catIDTable.Rows[0][0].ToString() + gradeID);

                                // Adds the grade
                                database.AddRow(gradeInfoTable, new List<string> { "gradeID", "gradeName", "pointsTotal", "pointsPossible",
                                    "catID", "courseID" }, new List<string> { gradeID, currGrade.name, currGrade.pointsEarned.ToString(),
                                    currGrade.pointsPossible.ToString(), catIDTable.Rows[0][0].ToString(), courseIDTable.Rows[0][0].ToString()});
                            }
                            else
                            {
                                // Check to update a grade
                                newTable = new List<List<string>>();

                                // Adds the new row of data
                                row = new List<string>() { currGrade.name, currGrade.pointsEarned.ToString(),
                                    currGrade.pointsPossible.ToString() };
                                newTable.Add(row);

                                // Updates the table
                                database.UpdateTable(gradeInfoTable, "courseID = " + table.Rows[0][0] +
                                    " AND catID = " + table.Rows[0][1].ToString() + " AND gradeID = " + table.Rows[0][2].ToString(),
                                    new List<string> { "gradeID", "gradeName", "pointsTotal", "pointsPossible"}, newTable);
                            }
                        }
                    }

                    // Cleans the table
                    table.Clear();
                }

                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
                return false;
            }
        }

        private static bool RemoveCourse(string courseID)
        {
            try
            {
                // Removes from all tables
                database.Delete(gradeInfoTable, "courseID = " + courseID);
                database.Delete(catInfoTable, "courseID = " + courseID);
                database.Delete(courseInfoTable, "courseID = " + courseID);

                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
                return false;
            }
        }

        private static bool Connect()
        {
            try
            {
                // Checks if the connectionPathString file exist
                if (File.Exists(connectionPathString) == false)
                {
                    Console.WriteLine("\nConnection string file is missing");
                    return false;
                }

                // Reads in a file of my SQL connection string, hidden because for security reasons
                BinaryReader fin = new BinaryReader(File.Open(@"C:/SchoolHelperFileSystem/SQlConnectionString", FileMode.Open));
                string connectionString = fin.ReadString();
                fin.Close();

                database = new Database(connectionString);
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
                return false;
            }
        }

        private static void UpdateDate(Course course)
        {
            DateTime currDate = DateTime.Now;
            string sqlFormattedDate = "lastUpdate = \'";
            sqlFormattedDate += currDate.ToString("yyyy-MM-dd") + "\'";

            database.Update(courseInfoTable, new List<string>() { sqlFormattedDate },
                "courseName = \'" + course.name + "\'");
        }

        private static void addCourse(Course course)
        {
            string newCourseID = database.GetNewID(courseInfoTable, "courseID").ToString();

            // Adds to the course table
            List<string> courseVarNames = new List<string>() { "courseID", "courseName", "credits",
                "completed", "final_weight", "A", "B", "C", "D", "lastUpdate"};

            DateTime currDate = DateTime.Now;
            string sqlFormattedDate = currDate.ToString("yyyy-MM-dd");

            List<string> courseValues = new List<string>() { newCourseID, course.name, course.credits.ToString(), "0", course.finalWeight.ToString(),
                course.cutOffs[0].ToString(), course.cutOffs[1].ToString(), course.cutOffs[2].ToString(), course.cutOffs[3].ToString(), sqlFormattedDate};

            Console.WriteLine(database.AddRow(courseInfoTable, courseVarNames, courseValues));

            // Now adds to the category table
            foreach (Category category in course.categories)
            {
                // Adds the category
                string newCatID = database.GetNewID(catInfoTable, "catID").ToString();

                List<string> catVarNames = new List<string>() { "catID", "catName", "expAssignments", "cat_weight", "courseID" };
                List<string> catValues = new List<string>() { newCatID, category.name, category.expAssignments.ToString(),
                string.Format("{0:0.00}", category.weight), newCourseID };

                Console.WriteLine(database.AddRow(catInfoTable, catVarNames, catValues));

                // Adds all of the grades
                foreach (Grade grade in category.grades)
                {
                    // Adds the grade
                    string newGradeID = database.GetNewID(gradeInfoTable, "gradeID").ToString();

                    List<string> gradeVarNames = new List<string>() { "gradeID", "gradeName", "pointsTotal", "pointsPossible", 
                        "catID", "courseID"};
                    List<string> gradeValues = new List<string>() { newGradeID, grade.name, grade.pointsEarned.ToString(),
                        grade.pointsPossible.ToString(), newCatID, newCourseID };

                    Console.WriteLine(database.AddRow(gradeInfoTable, gradeVarNames, gradeValues));
                }
            }

        }

        private static void addCat(Category category, string courseID)
        {
            // Adds the category
            string newCatID = database.GetNewID(catInfoTable, "catID").ToString();

            List<string> catVarNames = new List<string>() { "catID", "catName", "expAssignments", "cat_weight", "courseID" };
            List<string> catValues = new List<string>() { newCatID, category.name, category.expAssignments.ToString(),
                string.Format("{0:0.00}", category.weight), courseID };

            Console.WriteLine(database.AddRow(catInfoTable, catVarNames, catValues));

            // Adds all of the grades
            foreach (Grade grade in category.grades)
            {
                // Adds the grade
                string newGradeID = database.GetNewID(gradeInfoTable, "gradeID").ToString();

                List<string> gradeVarNames = new List<string>() { "gradeID", "gradeName", "pointsTotal", "pointsPossible",
                        "catID", "courseID"};
                List<string> gradeValues = new List<string>() { newGradeID, grade.name, grade.pointsEarned.ToString(),
                        grade.pointsPossible.ToString(), newCatID, courseID };

                Console.WriteLine(database.AddRow(gradeInfoTable, gradeVarNames, gradeValues));
            }
        }
    }
}
