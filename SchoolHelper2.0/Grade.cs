using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelper2._0
{
    [Serializable]
    class Grade
    {
        internal string name;
        internal int pointsEarned;
        internal int pointsPossible;

        public Grade()
        {
            name = "";
            pointsEarned = -1;
            pointsPossible = -1;
        }

        public double GetGrade
        {
            get => 100 * (double)pointsEarned / pointsPossible;
        }
    }
}
