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
    public partial class GradeViewer : Form
    {
        int currCourseIndex = -1;
        int currCatIndex = -1;
        List<Label> finalNeedsLabels;

        public GradeViewer()
        {
            InitializeComponent();

            // Disable resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void GradeViewer_Load(object sender, EventArgs e)
        {
            // Sets the default labels
            GradePercLabel.Text = "";
            LetterGradeLabel.Text = "";
            FinalWeightLabel.Text = "";

            // Resets the category labels
            CategoryPercGradeLabel.Text = "";
            CategoryLetterGradeLabel.Text = "";
            PercLostLabel.Text = "";
            NumEntriesLabel.Text = "";
            NumExpectedLabel.Text = "";
            PercCompletedLabel.Text = "";

            // Prints the course list box
            Utility.PrintListBox(CourseListBox, Courses.GetListOfNames());

            // Final needs
            Point currPoint = new Point(FinalNeedTitle.Left, FinalNeedTitle.Top + 20);
            finalNeedsLabels = new List<Label>();
            for (char i = 'A'; i <= 'D'; i++)
            {
                // Creates the letter indent
                Label currLabel = new Label();
                currLabel.AutoSize = true;
                currLabel.Location = currPoint;
                currLabel.Text = i + ": ";
                this.Controls.Add(currLabel);

                // Creates the empty label
                Label spaceLabel = new Label();
                spaceLabel.AutoSize = true;
                spaceLabel.Location = currPoint;
                spaceLabel.Left += currLabel.Width + 0; // Push it a space to the right
                spaceLabel.Text = "";
                finalNeedsLabels.Add(spaceLabel);
                this.Controls.Add(spaceLabel);

                // Pushes it down so they are by each other
                currPoint.Y += currLabel.Height;
            }

        }



        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CourseListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Finds the course
                currCourseIndex = CourseListBox.SelectedIndex;
                Course currCourse = Courses.List[currCourseIndex];

                // Resets the category labels
                CategoryPercGradeLabel.Text = "";
                CategoryLetterGradeLabel.Text = "";
                PercLostLabel.Text = "";
                NumEntriesLabel.Text = "";
                NumExpectedLabel.Text = "";
                PercCompletedLabel.Text = "";

                // Print the information
                Utility.PrintLabel(GradePercLabel, currCourse.GetPercGrade());
                GradePercLabel.Text += "%";
                LetterGradeLabel.Text = currCourse.GetLetterGrade().ToString();
                Utility.PrintLabel(FinalWeightLabel, currCourse.finalWeight, "No final");

                // Test if we need to add the no final
                if (FinalWeightLabel.Text.Equals("No final") == false)
                    FinalWeightLabel.Text += "%"; 

                // Prints all of the perc
                List<double> finalNeeds = currCourse.GetFinalNeeds();
                for (int i = 0; i < 4; i++)
                {
                    Utility.PrintLabel(finalNeedsLabels[i], finalNeeds[i], "N/A", -1000000);
                    if (finalNeedsLabels[i].Text.Equals("N/A") == false)
                        finalNeedsLabels[i].Text += "%";
                }

                // Print the category list box
                Utility.PrintListBox(CategoryListBox, currCourse.GetListOfCatNames());
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
            }
        }

        private void CategoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Finds the category
                currCatIndex = CategoryListBox.SelectedIndex;
                Category currCat = Courses.List[currCourseIndex].categories[currCatIndex];

                // Prints the labels
                Utility.PrintLabel(CategoryPercGradeLabel, currCat.GetPercGrade());
                CategoryPercGradeLabel.Text += "%";
                CategoryLetterGradeLabel.Text = Courses.List[currCourseIndex].FindLetterGrade(currCat.GetPercGrade()).ToString();
                Utility.PrintLabel(PercLostLabel, currCat.GetPercLost());
                PercLostLabel.Text += "%";
                Utility.PrintLabel(NumEntriesLabel, currCat.GradeCount());
                Utility.PrintLabel(NumExpectedLabel, currCat.expAssignments, "N\\A");
                Utility.PrintLabel(PercCompletedLabel, currCat.GetPercCompleted(), "N\\A");
                if (Math.Floor(currCat.GetPercCompleted()) != -1)
                    PercCompletedLabel.Text += "%";
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
            }
        }
    }
}
