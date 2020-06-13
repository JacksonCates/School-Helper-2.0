using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelper2._0
{
    public static class Courses
    {
        // Global const
        internal const string finalText = "FINAL";

        // Property functions
        internal static int Length { get => List.Count(); }

        internal static List<Course> List { get; private set; } = new List<Course>();

        internal static List<string> GetListOfNames()
        {
            List<string> names = new List<string>();

            // Gets all the names
            foreach (Course course in List)
                names.Add(course.name);

            return names;
        }

        // Filesystem management
        internal static void FileSystemLoad()
        {
            // Open the excel spreadsheet
            List = FileSystem.Setup();
        }

        // Returns true or false for success
        internal static bool DatabaseLoad()
        {
            // Tries to connect to the database
            if (SchoolHelperDatabase.Load(Courses.List))
            {
                // Success
                return true;
            }

            // Cleans for non-success
            List.Clear();
            return false;
        }
    }
}
