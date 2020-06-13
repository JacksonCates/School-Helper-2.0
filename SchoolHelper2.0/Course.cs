using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelper2._0
{
    [Serializable]
    public class Course : ICloneable
    {
        internal string name;
        internal int credits;
        internal List<double> cutOffs; // First elem it A, then B, then C, then etc
        internal double finalWeight;
        internal List<Category> categories;

        internal Course()
        {
            name = "NO_NAME";
            credits = -1; // Means no information
            cutOffs = new List<double>();
            categories = new List<Category>();
            finalWeight = -1; // Means no information
        }

        internal double GetPercGrade()
        {
            double totalPerc = 0;
            double totalWeight = 0;

            // Adds all the weight perc
            foreach (Category category in categories)
            {
                // Test if the category has grades in it
                if (category.GradeCount() != 0)
                {
                    totalPerc += category.GetPerc();
                    totalWeight += category.weight;
                }
                
            }

            // Test if any category has grades in it
            if (Math.Floor(totalWeight) != 0)
                return 100 * (totalPerc / totalWeight);
            else
                return -1;
        }

        internal char GetLetterGrade()
        {
            // Gets the perc grade
            double perc = GetPercGrade();

            return FindLetterGrade(perc);
        }

        internal char FindLetterGrade(double perc)
        {
            // Test if the grade is unknown
            if (Math.Floor(perc) == -1)
                return 'U';

            // Test for each grade
            if (perc > cutOffs[0])
                return 'A';
            else if (perc > cutOffs[1])
                return 'B';
            else if (perc > cutOffs[2])
                return 'C';
            else if (perc > cutOffs[3])
                return 'D';
            else
                return 'F';
        }

        // Returns a list of perc needed on final to 
        internal List<double> GetFinalNeeds()
        {
            // Check if there is a final, returns special empty case for output
            if (Math.Floor(finalWeight) == -1)
                return new List<double> { -1000000, -1000000, -1000000, -1000000 };

            // Checks if there are grades
            if(Math.Floor(GetPercGrade()) == -1)
                return new List<double> { -1000000, -1000000, -1000000, -1000000 };

            // Calculates the list
            double currPerc = GetPercGrade();
            List<double> finalNeed = new List<double>();
            foreach( double cutOff in cutOffs)
            {
                double required = (cutOff - currPerc * (1 - finalWeight / 100.0)) / (finalWeight / 100.0);
                finalNeed.Add(required);
            }

            return finalNeed;
        }

        // Gets the perc of the course completed
        internal double GetPercCompleted()
        {
            int totalGrades = 0;
            int totalExp = 0;

            // Adds all the % completed
            foreach (Category category in categories)
            {
                // Test if we know how much grades are to be exp
                if (category.expAssignments != -1)
                {
                    totalExp += category.expAssignments;
                    totalGrades += category.GradeCount();
                }
            }

            // Test if any assignments are expected
            if (totalExp != 0)
                return 100 * (double)totalGrades / totalExp;
            else
                return -1;
        }

        internal List<string> CreateListOfCutOffs()
        {
            List<string> cutOffData = new List<string>();

            char currLetter = 'A';
            foreach (double cutOff in cutOffs)
            {
                cutOffData.Add(currLetter + ": " + String.Format("{0:0.00}", cutOff));
                currLetter++;
            }

            return cutOffData;
        }

        internal List<string> GetListOfCatNames()
        {
            List<string> names = new List<string>();

            foreach (Category catagory in categories)
                names.Add(catagory.name);

            return names;
        }

        // Checks if the grading scale adds up to 100
        internal double WeightSums()
        {
            double sum = 0;

            // Adds final weight
            foreach (Category catagory in categories)
                sum += catagory.weight;

            // Adds category weight
            if (Math.Floor(finalWeight) != -1)
                sum += finalWeight;

            return sum;
        }

        // Creates a clone
        public object Clone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (this.GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }

                // If its not return nothing
                return null;
            }
        }

        // Used to print the course information for debugging info
        internal void PrintDebugInfo()
        {
            Console.WriteLine(new String('-', 50));
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Credits: " + credits);
            Console.WriteLine("Final Weight: " + String.Format("{0:0.00}", finalWeight));
            Console.WriteLine();

            // Prints grade scale information
            Console.WriteLine("Grade Scale:");
            char currLetter = 'A';
            for (int i = 0; i < 4; i++, currLetter++)
                Console.WriteLine("   " + currLetter + ": " + String.Format("{0:0.00}", cutOffs[i]));
            Console.WriteLine();

            // Prints the catagory information
            foreach (Category catagory in categories)
            {
                Console.WriteLine("Category Name: " + catagory.name);
                Console.WriteLine("Weight: " + String.Format("{0:0.00}", catagory.weight));
                Console.WriteLine("Expected Assignments: " + catagory.expAssignments);
                Console.WriteLine("Grades:");

                // Prints all the grades
                foreach(Grade grade in catagory.grades)
                {
                    Console.WriteLine("     " + grade.name + " ~ " + grade.pointsEarned.ToString() + @"/" + grade.pointsPossible.ToString());
                }
                Console.WriteLine();


            }
            Console.WriteLine(new String('-', 50));
        }
    }
}
