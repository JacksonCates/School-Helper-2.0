using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolHelper2._0
{
    public partial class AddGradeForm : Form
    {
        internal bool addedGrade;
        internal Grade newGrade;

        public AddGradeForm()
        {
            InitializeComponent();

            // Disable resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            newGrade = new Grade();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Test to see if the boxes are the correct format
                // Test to see if the boxes are in the correct format
                if (GradeNameTextBox.Text.Equals(""))
                {
                    MessageBox.Show("ERROR: Must have a grade name!");
                    Console.WriteLine("\nERROR: GRADENAMETEXTBOX IS INVALID");
                }
                else if (Convert.ToInt16(Utility.ReadTextBox(PointsEarnedTextBox)) < 0 && Convert.ToInt16(Utility.ReadTextBox(PointsEarnedTextBox)) != -1)
                {
                    MessageBox.Show("ERROR: Points earned is invalid");
                    Console.WriteLine("\nERROR: POINTSEARNEDTEXTBOX IS INVALID");
                }
                else if (Convert.ToInt16(Utility.ReadTextBox(PointsTotalTextBox)) < 0 && Convert.ToInt16(Utility.ReadTextBox(PointsTotalTextBox)) != -1)
                {
                    MessageBox.Show("ERROR: Points total Assignments are invalid");
                    Console.WriteLine("\nERROR: POINTSTOTALTEXTBOX IS INVALID");
                }
                else
                {
                    // Creates the new catagory
                    newGrade.name = GradeNameTextBox.Text;
                    newGrade.pointsEarned = Convert.ToInt16(Utility.ReadTextBox(PointsEarnedTextBox));
                    newGrade.pointsPossible = Convert.ToInt16(Utility.ReadTextBox(PointsTotalTextBox));

                    // Sets this to true and exists
                    addedGrade = true;
                    this.Hide();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("ERROR: Text boxes are not in the correct format");
                Console.WriteLine("\n" + exp.ToString());
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            addedGrade = false;
            this.Hide();
        }
    }
}
