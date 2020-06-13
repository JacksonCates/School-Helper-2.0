using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelper2._0
{
    [Serializable]
    public class Category
    {
        internal string name;
        internal double weight;
        internal int expAssignments; // NUmber of assignments expected
        internal List<Grade> grades;

        public Category()
        {
            name = "";
            weight = -1;
            expAssignments = -1; // Means it is unknown
            grades = new List<Grade>();
        }              
        
        internal List<string> GetListOfGradeNames()
        {
            List<string> names = new List<string>();

            foreach (Grade grade in grades)
                names.Add(grade.name);

            return names;
        }

        // Gets the perc of weight cat is going towards course
        internal double GetPerc()
        {
            // Returns the percentage
            return weight * GetPercGrade() / 100;
        }

        // Gets the category's grade
        internal double GetPercGrade()
        {
            int pointsTotal = 0, pointsEarned = 0;

            // Loops through each grade, getting total points
            foreach (Grade grade in grades)
            {
                pointsEarned += grade.pointsEarned;
                pointsTotal += grade.pointsPossible;
            }

            // Returns the percentage
            return 100 * (double)pointsEarned / pointsTotal;
        }

        // Gets perc lost due to the category
        internal double GetPercLost()
        {
            return weight - GetPerc();
        }

        internal int GradeCount()
        {
            return grades.Count();
        }

        // Gets the % of category completed
        internal double GetPercCompleted()
        {
            // Test if we have an exp assignments inputted
            if (expAssignments != -1)
                return 100 * (double)grades.Count() / expAssignments;
            else
                // Returns unknown
                return -1;
        }
    }
}
