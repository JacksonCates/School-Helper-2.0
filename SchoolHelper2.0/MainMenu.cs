using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Description:
 * This is the main menu form. This is the entry point of the application for the user. 
 * 
 */ 

namespace SchoolHelper2._0
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            // Disable resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void ExitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CourseEditor_Click(object sender, EventArgs e)
        {
            // Starts the new form
            CourseEditor form = new CourseEditor();
            this.Hide();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.ShowDialog();
            this.Show();
        }

        private void ManageFradesButtonClick(object sender, EventArgs e)
        {
            // Run course selection index
            ChooseCourseForm form = new ChooseCourseForm(this.Location);

            // Branches if a course has been chosen
            if (form.courseChoosen == true)
            {
                Course currCourse = Courses.List[form.courseIndex];

                // Checks if the course has categories in it
                if (currCourse.categories.Count != 0)
                {
                    // Starts the new form
                    GradeEditor gradeForm = new GradeEditor(currCourse);
                    this.Hide();
                    gradeForm.StartPosition = FormStartPosition.Manual;
                    gradeForm.Location = form.Location;
                    gradeForm.ShowDialog();
                    this.Show();

                    // Updates the courses
                    if (gradeForm.changesMade == true)
                    {
                        Courses.List[form.courseIndex] = gradeForm.GetCourse;
                    }
                }
                else
                {
                    // Prints the error msg
                    MessageBox.Show("ERROR: Course has no categories!");
                }
            }
        }

        private void ViewGradeInfoButton_Click(object sender, EventArgs e)
        {
            // Starts the new form
            GradeViewer gradeViewForm = new GradeViewer();
            this.Hide();
            gradeViewForm.StartPosition = FormStartPosition.Manual;
            gradeViewForm.Location = this.Location;
            gradeViewForm.ShowDialog();
            this.Show();

        }
    }
}
