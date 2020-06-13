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
    public partial class ChooseCourseForm : Form
    {
        private int currCourseIndex = -1;
        private int prevCourseIndex = -1;
        internal bool courseChoosen = false;
        internal int courseIndex = -1; // What to return

        public ChooseCourseForm(Point pos)
        {
            // Checks if we have courses
            // Checks if there are courses
            if (Courses.Length <= 0)
            {
                // Hides and close
                MessageBox.Show("ERROR: You have no courses stored!");

                this.Hide();
            }
            else
            {
                InitializeComponent();

                // Shows the form
                this.StartPosition = FormStartPosition.Manual;
                this.Location = pos;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.MinimizeBox = false;

                this.ShowDialog();
            }
        }

        private void ChooseCourseForm_Load(object sender, EventArgs e)
        {

            // Updates the list box
            Utility.PrintCheckedListBox(CourseListBox, Courses.GetListOfNames());
        }

        private void CourseListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                currCourseIndex = CourseListBox.SelectedIndex;

                if (currCourseIndex >= 0 && currCourseIndex < Courses.Length)
                {
                    prevCourseIndex = currCourseIndex;

                    // Removes all the previous checks
                    for (int i = 0; i < CourseListBox.Items.Count; i++)
                    {
                        if (i != prevCourseIndex)
                            CourseListBox.SetItemChecked(i, false);
                    }

                    // Reprints it to get rid of hightlist
                    Utility.PrintCheckedListBox(CourseListBox, Courses.GetListOfNames());
                    CourseListBox.SetItemChecked(currCourseIndex, true);
                }
                else
                {
                    Console.WriteLine("\nERROR: Invalid Index Choosen");
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            // Checks if an index has been choosen
            if (prevCourseIndex != -1)
            {
                // Sets the values needed and return
                courseIndex = prevCourseIndex;
                courseChoosen = true;
                this.Hide();
            }
            else
            {
                Console.WriteLine("\nERROR: No course choosen");
                MessageBox.Show("ERROR: You must choose a course!");
            }
        }
    }
}
