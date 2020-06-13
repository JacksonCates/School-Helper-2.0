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
    public partial class GradeEditor : Form
    {
        int currCatagoryIndex = -1;
        int currGradeIndex = -1;
        int prevGradeIndex = -1;
        Course currCourse;
        Category currCategory;
        internal bool changesMade = false;

        public GradeEditor(Course course)
        {
            InitializeComponent();

            // Disable resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Creates the clone
            currCourse = (Course)course.Clone();
        }

        public Course GetCourse
        {
            get => (Course)currCourse.Clone();
        }

        private void ExitEditor_Click(object sender, EventArgs e)
        {
            Console.WriteLine("\nNO CHANGES MADE");
            changesMade = false;
            this.Hide();
        }        

        private void ClearGradeBoxes()
        {
            GradeNameTextBox.Text = "";
            PointsEarnedTextBox.Text = "";
            PointsTotalTextBox.Text = "";
            GradePercLabel.Text = "N\\A";
        }

        private bool IsGradeTextBoxesValid()
        {
            try
            {
                // Test for empty/invalid boxes, print error msg as needed
                if (GradeNameTextBox.Text.Equals(""))
                {
                    MessageBox.Show("ERROR: Must have a grade name!");
                    Console.WriteLine("\nERROR: GRADENAMETEXTBOX IS INVALID");
                    return false;
                }
                if (Convert.ToInt16(Utility.ReadTextBox(PointsEarnedTextBox)) < 0 || Convert.ToInt16(Utility.ReadTextBox(PointsEarnedTextBox)) == -1)
                {
                    MessageBox.Show("ERROR: Points earned is invalid");
                    Console.WriteLine("\nERROR: POINTSEARNEDTEXTBOX IS INVALID");
                    return false;
                }
                if (Convert.ToInt16(Utility.ReadTextBox(PointsTotalTextBox)) < 0 || Convert.ToInt16(Utility.ReadTextBox(PointsTotalTextBox)) == -1)
                {
                    MessageBox.Show("ERROR: Points total Assignments are invalid");
                    Console.WriteLine("\nERROR: POINTSTOTALTEXTBOX IS INVALID");
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                // Prints to consol for debugging
                Console.WriteLine("\n" + e.ToString());
                return false;
            }
        }

        private void GradeEditor_Load(object sender, EventArgs e)
        {
            this.Text = "Grade Editor for " + currCourse.name;

            // Sets an empty course for the beginning
            currCategory = new Category();

            // Prints choices
            Utility.PrintListBox(CatagoryListBox, currCourse.GetListOfCatNames());

            // Sets up components
            GradeListBox.Items.Clear();
            GradeListBox.Items.Add("N/A");
            ClearGradeBoxes();
        }

        private void CatagoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (currCatagoryIndex != CatagoryListBox.SelectedIndex)
                {
                    currCatagoryIndex = CatagoryListBox.SelectedIndex;

                    // Test for the index
                    if (currCatagoryIndex >= 0 && currCatagoryIndex < currCourse.categories.Count)
                    {
                        // Saves the grade information
                        if (currGradeIndex != -1 && IsGradeTextBoxesValid())
                        {
                            // Saves current grade information
                            changesMade = true;

                            Grade currGrade = currCategory.grades[currGradeIndex];
                            currGrade.name = Utility.ReadTextBox(GradeNameTextBox);
                            currGrade.pointsEarned = Convert.ToInt16(Utility.ReadTextBox(PointsEarnedTextBox));
                            currGrade.pointsPossible = Convert.ToInt16(Utility.ReadTextBox(PointsTotalTextBox));
                        }

                        // Finds the category
                        currCategory = currCourse.categories[currCatagoryIndex];

                        // Update the Grades list box
                        Utility.PrintListBox(GradeListBox, currCategory.GetListOfGradeNames());
                        ClearGradeBoxes();
                        currGradeIndex = -1;

                    }
                    else
                    {
                        Console.WriteLine("\nERROR: Invalid Index Chosen");
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
            }
        }

        private void AddGradeButton_Click(object sender, EventArgs e)
        {
            // Test if a category has been choosen
            if (currCatagoryIndex >= 0 && currCatagoryIndex < currCourse.categories.Count)
            {
                // Creats new form
                AddGradeForm form = new AddGradeForm();
                form.StartPosition = FormStartPosition.Manual;
                form.Location = this.Location;
                form.ShowDialog();

                // Adds if only succesffuly
                if (form.addedGrade == true)
                {
                    changesMade = true;
                    Grade newGrade = form.newGrade;

                    // Adds it to the category
                    currCategory.grades.Add(newGrade);

                    // Update the form
                    Utility.PrintListBox(GradeListBox, currCategory.GetListOfGradeNames());
                    ClearGradeBoxes();
                }
            }
            else
            {
                Console.WriteLine("\nERROR: No Category Chooen!");
                MessageBox.Show("ERROR: No Category Chooen!");
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Check if the text boxes has been changed
            

            // Updates the files
            if (changesMade)
            {
                //Checks for errors
                if (currGradeIndex != -1 && IsGradeTextBoxesValid())
                {
                    Grade currGrade = currCategory.grades[currGradeIndex];
                    currGrade.name = Utility.ReadTextBox(GradeNameTextBox);
                    currGrade.pointsEarned = Convert.ToInt16(Utility.ReadTextBox(PointsEarnedTextBox));
                    currGrade.pointsPossible = Convert.ToInt16(Utility.ReadTextBox(PointsTotalTextBox));

                    // Updates the files
                    FileSystem.Save(currCourse);
                    MessageBox.Show("Saved!");
                    changesMade = true;

                    // Closes the form
                    this.Close();
                }
                // If no grade is selected
                else if (currGradeIndex == -1)
                {
                    // Updates the files
                    FileSystem.Save(currCourse);
                    MessageBox.Show("Saved!");
                    changesMade = true;

                    // Closes the form
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No changes made!");
                Console.WriteLine("\nNO CHANGES MADE");
            }            
        }

        private void GradeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Checks if the index is valid
                if (currCatagoryIndex >= 0 && currCatagoryIndex < currCourse.categories.Count)
                {
                    if (currGradeIndex != GradeListBox.SelectedIndex)
                    {
                        prevGradeIndex = currGradeIndex;
                        currGradeIndex = GradeListBox.SelectedIndex;

                        if (currGradeIndex >= 0 && currGradeIndex < currCategory.grades.Count)
                        {
                            Grade currGrade = currCategory.grades[currGradeIndex];

                            // Test the case for valid textboxes
                            if (prevGradeIndex != -1 && IsGradeTextBoxesValid() == true)
                            {
                                // Save the information
                                changesMade = true;

                                Grade prevGrade = currCategory.grades[prevGradeIndex];
                                prevGrade.name = Utility.ReadTextBox(GradeNameTextBox);
                                prevGrade.pointsEarned = Convert.ToInt16(Utility.ReadTextBox(PointsEarnedTextBox));
                                prevGrade.pointsPossible = Convert.ToInt16(Utility.ReadTextBox(PointsTotalTextBox));
                            }

                            // Shows the current grade information
                            GradeNameTextBox.Text = currGrade.name;
                            Utility.PrintTextBox(PointsEarnedTextBox, currGrade.pointsEarned);
                            Utility.PrintTextBox(PointsTotalTextBox, currGrade.pointsPossible);
                            Utility.PrintLabel(GradePercLabel, currGrade.GetGrade, "N/A");
                            GradePercLabel.Text += "%";
                        }
                        else
                        {
                            currGradeIndex = -1;
                            Console.WriteLine("\nERROR: Invalid Index Chosen (the none index)");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: No Category Choen!");
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
            }
        }

        private void RemoveGradeButton_Click(object sender, EventArgs e)
        {
            // Sees if a grade has been selected
            if (currCatagoryIndex != -1 && currGradeIndex != -1)
            {
                // Creates the new form
                ConfirmChoiceForm form = new ConfirmChoiceForm();
                form.StartPosition = FormStartPosition.Manual;
                form.Location = this.Location;
                form.ShowDialog();

                // Test if the user is sure they want to delete it
                if (form.GetChoice() == true)
                {
                    changesMade = true;

                    // Removes the category and item in the list
                    currCourse.categories[currCatagoryIndex].grades.RemoveAt(currGradeIndex);
                    Utility.PrintListBox(CatagoryListBox, currCourse.GetListOfCatNames());

                    prevGradeIndex = -1;
                    currGradeIndex = -1;
                    currCatagoryIndex = -1;

                    // Update the Grades list box
                    Utility.PrintListBox(GradeListBox, currCategory.GetListOfGradeNames());
                    ClearGradeBoxes();
                    currGradeIndex = -1;
                }
            }
            else
            {
                MessageBox.Show("ERROR: You must have a category selected!");
            }
        }

        private void GradeNameTextBox_TextChanged(object sender, EventArgs e)
        {
            changesMade = true;
        }

        private void PointsEarnedTextBox_TextChanged(object sender, EventArgs e)
        {
            changesMade = true;

            try
            {
                // Updates grade percentage
                double newPerc = Convert.ToDouble(Utility.ReadTextBox(PointsEarnedTextBox, "0"));
                newPerc /= Convert.ToDouble(Utility.ReadTextBox(PointsTotalTextBox, "0"));
                newPerc *= 100;
                Utility.PrintLabel(GradePercLabel, newPerc, "NA");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                Utility.PrintTextBox(PointsTotalTextBox, currCourse.categories[currCatagoryIndex].grades[currGradeIndex].pointsEarned);
            }
        }

        private void PointsTotalTextBox_TextChanged(object sender, EventArgs e)
        {
            changesMade = true;

            try
            {
                // Updates grade percentage
                double newPerc = Convert.ToDouble(Utility.ReadTextBox(PointsEarnedTextBox, "0"));
                newPerc /= Convert.ToDouble(Utility.ReadTextBox(PointsTotalTextBox, "0"));
                newPerc *= 100;
                Utility.PrintLabel(GradePercLabel, newPerc, "NA");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                Utility.PrintTextBox(PointsTotalTextBox, currCourse.categories[currCatagoryIndex].grades[currGradeIndex].pointsPossible);
            }
        }
    }
}
