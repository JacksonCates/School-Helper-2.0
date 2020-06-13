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
    public partial class CourseEditor : Form
    {
        // Used for labels
        private const string CourseText = "Course Name: ";
        private const string CatagoryText = "Catagory Name: ";
        private const string CreditsText = "Credits: ";
        private const string FinalWeightText = "Final Weight: ";
        private const string WeightText = "Weight: ";
        private const string ExpAssText = "Expected Assignments: ";
        private const int spacePixels = 0;
        private List<Label> cutOffLabels;

        // Used for logic
        int currCourseIndex = -1;
        int currCatIndex = -1;

        public CourseEditor()
        {
            InitializeComponent();

            // Disable resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void ExitScreen_Click(object sender, EventArgs e)
        {
            // Hides the form
            this.Hide();
        }

        private void CourseEditor_Load(object sender, EventArgs e)
        {
            // Updates all the course information
            cutOffLabels = new List<Label>();

            // Prints choices
            Utility.PrintListBox(CourseListBox, Courses.GetListOfNames());
            CatagoryListBox.Items.Clear();
            CatagoryListBox.Items.Add(@"N/A");

            // Sets the default label
            CourseNameLabel.Text = CourseText;
            ActualCourseNameLabel.Text = "";
            CreditsLabel.Text = CreditsText;
            ActualCreditsLabel.Text = "";
            FinalWeightLabel.Text = FinalWeightText;
            ActualFinalWeightLabel.Text = "";
            CatagoryNameLabel.Text = CatagoryText;
            ActualCatagoryNameLabel.Text = "";
            CatagoryWeightLabel.Text = WeightText;
            ActualCatagoryWeightLabel.Text = "";
            ExpAssLabel.Text = ExpAssText;
            ActualExpAssLabel.Text = "";

            // Grade Scale
            // Writes the base letters
            Point currPoint = new Point(GradeScaleLabel.Left, GradeScaleLabel.Top + 20);
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
                spaceLabel.Left += currLabel.Width + spacePixels; // Push it a space to the right
                spaceLabel.Text = "";
                cutOffLabels.Add(spaceLabel);
                this.Controls.Add(spaceLabel);

                // Pushes it down so they are by each other
                currPoint.Y += currLabel.Height;                
            }
        }

        private void CourseListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Finds the course
                currCourseIndex = CourseListBox.SelectedIndex;
                Course currCourse = Courses.List[currCourseIndex];

                // Resets the category labels
                currCatIndex = -1;
                ActualCatagoryNameLabel.Text = "";
                ActualCatagoryWeightLabel.Text = "";
                ActualExpAssLabel.Text = "";

                // Prints
                ActualCourseNameLabel.Text = currCourse.name;
                Utility.PrintLabel(ActualCreditsLabel, currCourse.credits);
                Utility.PrintLabel(ActualFinalWeightLabel, currCourse.finalWeight);
                if (currCourse.finalWeight != -1)
                    ActualFinalWeightLabel.Text += "%";
                for (int i = 0; i < 4; i++)
                    Utility.PrintLabel(cutOffLabels[i], currCourse.cutOffs[i]);
                Utility.PrintListBox(CatagoryListBox, currCourse.GetListOfCatNames());
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
            }
        }

        private void CatagoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Test to see if a course has been selected
            if (currCourseIndex != -1)
            {
                try
                {
                    // Finds the category
                    currCatIndex = CatagoryListBox.SelectedIndex;
                    Category currCat = Courses.List[currCourseIndex].categories[currCatIndex];

                    // Prints
                    ActualCatagoryNameLabel.Text = currCat.name;
                    Utility.PrintLabel(ActualCatagoryWeightLabel, currCat.weight);
                    ActualCatagoryWeightLabel.Text += "%";
                    Utility.PrintLabel(ActualExpAssLabel, currCat.expAssignments);
                }
                catch (Exception exp)
                {
                    Console.WriteLine("\n" + exp.ToString());
                }
            }
            else
            {
                MessageBox.Show("ERROR: You have no course selected!");
            }
        }

        private void AddCourseButton_Click(object sender, EventArgs e)
        {
            // Creates the new form
            EditCourseFormcs form = new EditCourseFormcs();
            this.Hide();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.ShowDialog();
            this.Show();

            // Adds the course to the list
            if (form.CourseMade)
            {
                // Adds the course to the list
                Courses.List.Add(form.GetCourse);

                ResetLabelsAndCourseList();
            }
        }

        private void EditCourseButton_Click(object sender, EventArgs e)
        {
            // Checks if its a valid option
            if (currCourseIndex == -1)
            {
                MessageBox.Show("Error: No Course Selected!");
            }
            // Creates the new form
            else
            {
                EditCourseFormcs form = new EditCourseFormcs(Courses.List[currCourseIndex]);
                this.Hide();
                // Shows the form
                form.StartPosition = FormStartPosition.Manual;
                form.Location = this.Location;
                form.ShowDialog();
                this.Show();

                // Updates the form
                if (form.CourseMade)
                {
                    // Replace the course in the list
                    Courses.List[currCourseIndex] = form.GetCourse;

                    ResetLabelsAndCourseList();
                }
            }            
        }

        private void ResetLabelsAndCourseList()
        {
            // Updates the form
            CourseListBox.Items.Clear();
            Utility.PrintListBox(CourseListBox, Courses.GetListOfNames());
            CatagoryListBox.Items.Clear();
            CatagoryListBox.Items.Add(@"N/A");

            // Sets the default label
            CourseNameLabel.Text = CourseText;
            ActualCourseNameLabel.Text = "";
            CreditsLabel.Text = CreditsText;
            ActualCreditsLabel.Text = "";
            FinalWeightLabel.Text = FinalWeightText;
            ActualFinalWeightLabel.Text = "";
            CatagoryNameLabel.Text = CatagoryText;
            ActualCatagoryNameLabel.Text = "";
            CatagoryWeightLabel.Text = WeightText;
            ActualCatagoryWeightLabel.Text = "";
            ExpAssLabel.Text = ExpAssText;
            ActualExpAssLabel.Text = "";

            // Resets cutoffs
            foreach (Label cutoff in cutOffLabels)
                cutoff.Text = "";
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void RemoveCourseButton_Click(object sender, EventArgs e)
        {
            // Checks if its a valid option
            if (currCourseIndex == -1)
            {
                MessageBox.Show("Error: No Course Selected!");
            }
            // Creates the new form
            else
            {
                // Asks if they are sure
                ConfirmChoiceForm form = new ConfirmChoiceForm("Are you sure? Deleted courses cannot be recovered");
                form.StartPosition = FormStartPosition.Manual;
                form.Location = this.Location;
                form.ShowDialog();

                if (form.GetChoice())
                {
                    // Deletes it in the file system
                    FileSystem.Delete(Courses.List[currCourseIndex].name);

                    // Deletes the course
                    Courses.List.RemoveAt(currCourseIndex);

                    // Updates the form
                    ResetLabelsAndCourseList();
                }
            }
        }
    }
}
