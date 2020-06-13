using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace SchoolHelper2._0
{

    public static class FileSystem
    {
        private const string connectionPathString = @"C:\SchoolHelperFileSystem\SQLConnectionString";
        private const string filePath = @"C:\SchoolHelperFileSystem";
        private static string[] files;

        public static List<Course> Setup()
        {
            List<Course> courseData = new List<Course>();
            // Checks if the file system directory exist
            if (Directory.Exists(filePath))
            {
                // Gets all the files in the filesystem directory
                files = Directory.GetFiles(filePath);

                // Opens and reads all the files
                foreach (string file in files)
                {
                    // Checks if its not an admin file
                    if (file.Equals(connectionPathString) == false && file.Contains(".txt") == false)
                    {
                        // Prints for debugging
                        Console.WriteLine(file);

                        // Loads in the new course
                        Course currCourse = Load(file);

                        // Adds the course to the data
                        courseData.Add(currCourse);
                    }
                }
            }
            // If the directory is empty
            else
            {
                // Debugs
                Console.WriteLine(filePath + " not found. Creating directory");

                // Creates the directory
                Directory.CreateDirectory(filePath);
            }

            return courseData;
        }

        // Loads an old file
        public static Course Load(string path)
        {
            // Opens the file
            FileStream fileIn = new FileStream(path, FileMode.Open, FileAccess.Read);
            IFormatter formatter = new BinaryFormatter();

            // Reads in the new course information
            Course newCourse = (Course)formatter.Deserialize(fileIn);
            fileIn.Close();

            return newCourse;
        }

        // Creates a new file
        public static void Save(Course course)
        {
            // Creates the file stream
            FileStream fileOut = new FileStream(filePath + "\\" + course.name, FileMode.Create);
            IFormatter formatter = new BinaryFormatter();

            // Serialize the object
            formatter.Serialize(fileOut, course);
            fileOut.Close();
        }

        // Deletes a file
        public static void Delete(string fileName)
        {
            // Deletes the file
            File.Delete(filePath + "\\" + fileName);
        }

        // Used to convert a list of string to double
        private static List<double> ConvertToListDouble(List<string> oldData)
        {
            List<double> conData = new List<double>(); // converted data

            try
            {
                foreach (string currData in oldData)
                {
                    conData.Add(Convert.ToDouble(currData));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return conData;
        }
    }
}