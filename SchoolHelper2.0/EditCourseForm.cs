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
    public partial class EditCourseFormcs : Form
    {
        Course newCourse; // The new, edited course
        Course courseToEdit;
        List<TextBox> cutOffBoxes;
        private const int SpaceBetweenBoxes = 3;
        private const int BoxHeight = 20;
        private const int BoxWidth = 60;

        // Logic
        private int currCatagoryIndex = -1;
        private int prevCatagoryIndex = -1;
        private int savedCatagoryIndex = -1; // Saved in case of errors
        private bool progIsChangingListBoxIndex = false; // Used to prevent the change listbox function from runing when the program changes it
        private bool progIsDeletingCatagory = false;
        private bool isNewCourse;
        private bool progIsClearingBoxes = false;

        // Used when to edit a course
        public EditCourseFormcs(Course courseToEdit)
        {
            InitializeComponent();

            // Disable resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.Text = "Edit " + courseToEdit.name + " Form";
            isNewCourse = false;
            this.courseToEdit = courseToEdit;
            newCourse = (Course)courseToEdit.Clone();
            SetUpTextBoxes();
        }

        // Used when to make a new course
        public EditCourseFormcs()
        {
            InitializeComponent();

            // Disable resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.Text = "New Course Form";
            isNewCourse = true;
            newCourse = new Course();
            newCourse.name = "";
            SetUpTextBoxes();
        }

        public Course GetCourse
        {
            get => newCourse;
        }

        public bool CourseMade { get; private set; } = false;

        public bool FormDone { get; private set; } = false;

        private void SetUpTextBoxes()
        {
            // Sets the names of the text boxes
            CourseNameTextBox.Text = newCourse.name;
            Utility.PrintTextBox(CreditsTextBox, newCourse.credits, "");
            Utility.PrintTextBox(FinalWeightTextBox, newCourse.finalWeight, "");
            UpdateWeightSumLabel();

            ClearCatagoryTextBoxes();

            // Creates the grading scale text box
            cutOffBoxes = new List<TextBox>();
            Point currBoxLoc = new Point(GradeScaleLabel.Location.X, CourseNameTextBox.Location.Y);
            Point currLabelLoc = new Point(GradeScaleLabel.Location.X, GradeScaleLabel.Location.Y);
            char currLetter = 'A';
            for (int i = 0; i < 4; i++, currLetter++)
            {
                // Updates the location
                currBoxLoc.Y += BoxHeight + SpaceBetweenBoxes;
                currLabelLoc.Y += BoxHeight + SpaceBetweenBoxes;

                // Creates the new label and box
                TextBox currBox = new TextBox();
                Label currLabel = new Label();

                // Updates the text, makes last box the final
                currLabel.Text = currLetter + ":";

                // Only prints if it is a old course
                if (isNewCourse == false)
                    Utility.PrintTextBox(currBox, newCourse.cutOffs[i], "");
                else
                    currBox.Text = "";

                // Create the label next to the box
                currLabel.AutoSize = true;
                currLabel.Location = new Point(GradeScaleLabel.Location.X, currLabelLoc.Y);

                // Adds the label to the list
                this.Controls.Add(currLabel);

                // Updates a new box
                currBox.Width = BoxWidth;
                currBox.Height = BoxHeight;
                currBox.Location = new Point(currBoxLoc.X + SpaceBetweenBoxes + currLabel.Width, currBoxLoc.Y);
                currBox.TextAlign = HorizontalAlignment.Right;

                // Adds the box to the list
                this.Controls.Add(currBox);
                cutOffBoxes.Add(currBox);
            }

            // Sets up the catagory list box
            Utility.PrintListBox(CatagoryListBox, newCourse.GetListOfCatNames());
        }

        // CHANGE THIS SO IT RETURN IF ANYTHING IS EMPTY
        private bool IsCourseTextBoxValid()
        {
            // If there is an execption, force it to be wrong
            try
            {
                // Checks all the labels, if there is a difference return true, else return false
                if (CourseNameTextBox.Text.Equals(""))
                {
                    Console.WriteLine("\nCOURSENAMETEXTBOX IS INVALID");
                    return false;
                }
                else if (CreditsTextBox.Text.Equals("") || Convert.ToInt16(CreditsTextBox.Text) <= 0 || Convert.ToInt16(CreditsTextBox.Text) >= 100)
                {
                    Console.WriteLine("\nCREDITSTEXTBOX IS INVALID");
                    return false;
                }
                else if ((Convert.ToDouble(Utility.ReadTextBox(FinalWeightTextBox)) <= 0.001 || Convert.ToDouble(Utility.ReadTextBox(FinalWeightTextBox)) >= 100.001)
                    && Convert.ToInt16(Utility.ReadTextBox(FinalWeightTextBox)) != -1)
                {
                    Console.WriteLine("\nFINALWEIGHTTEXTBOX IS INVALID");
                    return false;
                }

                // Check cutoffs and final
                for (int i = 0; i < 4; i++)
                {
                    if (cutOffBoxes[i].Text.Equals("") || Convert.ToDouble(Utility.ReadTextBox(cutOffBoxes[i])) <= 0.001 || Convert.ToDouble(Utility.ReadTextBox(cutOffBoxes[i])) >= 100.001)
                    {
                        Console.WriteLine("\nCUTOFFBOX " + i + " IS INVALID");
                        return false;
                    }
                }

                // Check for correct grading scale
                for (int i = 0; i < 3; i++)
                {
                    if (Convert.ToDouble(Utility.ReadTextBox(cutOffBoxes[i])) <= Convert.ToDouble(Utility.ReadTextBox(cutOffBoxes[i + 1])))
                    {
                        Console.WriteLine("\nCUTOFFBOX SCALES " + i + 1 + " IS INVALID");
                        return false;
                    }
                }

                return true;
            }
            catch(Exception e)
            {
                // Prints to consol for debugging
                Console.WriteLine("\n" + e.ToString());
                return false;
            }
        }

        private bool IsCatagoryTexBoxesValid(bool finalCheck = false)
        {
            // If there is an execption, force it to be wrong
            try
            {
                // Test to see if the boxes are in the correct format
                if (CatagoryNameTextBox.Text.Equals(""))
                {
                    Console.WriteLine("\nERROR: CATAGORYNAMETEXTBOX IS INVALID");
                    return false;
                }
                else if (WeightTextBox.Text.Equals("") || Convert.ToDouble(WeightTextBox.Text) <= -0.001 || Convert.ToDouble(WeightTextBox.Text) >= 100.001)
                {
                    Console.WriteLine("\nERROR: WEIGHTTEXTBOX IS INVALID");
                    return false;
                }
                else if (Convert.ToInt16(Utility.ReadTextBox(ExpAssignmentsTextBox)) <= 0 && Convert.ToInt16(Utility.ReadTextBox(ExpAssignmentsTextBox)) != -1)
                {
                    Console.WriteLine("\nERROR: EXPASSIGNMENTSTEXTBOX IS INVALID");
                    return false;
                }

                // Checks if the textbox is unique or not
                // Only want this to run if we have a previous course (it has been potientally edited)
                if (finalCheck == false && prevCatagoryIndex != -1)
                {
                    for (int i = 0; i < newCourse.categories.Count(); i++)
                    {
                        if (i != prevCatagoryIndex && CatagoryNameTextBox.Text.Equals(newCourse.categories[i].name))
                        {
                            Console.WriteLine("\nERROR: CATAGORY NAME IS A DUPLICATE");
                            return false;
                        }
                    }
                }
                else if (finalCheck == true)
                {
                    for (int i = 0; i < newCourse.categories.Count(); i++)
                    {
                        if (i != currCatagoryIndex && CatagoryNameTextBox.Text.Equals(newCourse.categories[i].name))
                        {
                            Console.WriteLine("\nERROR: CATAGORY NAME IS A DUPLICATE");
                            return false;
                        }
                    }
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

        private void UpdateWeightSumLabel()
        {
            ActualWeightSumLabel.Text = String.Format("{0:0.00}%", newCourse.WeightSums());
        }

        private void ClearCatagoryTextBoxes()
        {
            // Makes the text boxes blank
            CatagoryNameTextBox.Text = "";
            WeightTextBox.Text = "";
            ExpAssignmentsTextBox.Text = "";
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            CourseMade = false;
            FormDone = true;
            Hide();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            // Shows a message
            MessageBox.Show(
                "To change the course information, simply replace the text inside of the text box\n\n" +
                "You CANNOT leave anything empty or negative, besides the expected assignments and final. If the expected assignments and/or finals are unknown/none, leaves as blank\n\n" +
                "Double's precision will be taken to the 2nd decimal place\n\n" +
                "To change the catagory, you select the catagory and make the changes, there is no need to save between catagories\n\n" +
                "Catagories must have distinct names and weights that add up to 100!\n\n" +
                "To add/remove catagories. Selected the corresponding buttons and go to the sub-form"
                );
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Checks possible errors
            if (IsCourseTextBoxValid() == false)
            {
                MessageBox.Show("ERROR: There is an non-valid element!");
            }
            // Doesnt check if a catagory hasnt been selected
            else if (currCatagoryIndex != -1 && IsCatagoryTexBoxesValid(true) == false)
            {
                MessageBox.Show("ERROR: Current Catagory Textboxes are invalid!");
            }
            else if (Math.Abs(newCourse.WeightSums() - 100) >= 0.001)
            {
                MessageBox.Show("ERROR: Weights dont add up to 100!");
            }
            // Success, make changes
            else
            {
                // Sees if we need to save catagory info
                if (currCatagoryIndex != -1)
                {
                    Category currCatagory = newCourse.categories[currCatagoryIndex];

                    // Stores the other data
                    currCatagory.name = CatagoryNameTextBox.Text;
                    currCatagory.weight = Convert.ToDouble(Utility.ReadTextBox(WeightTextBox));
                    currCatagory.expAssignments = Convert.ToInt16(Utility.ReadTextBox(ExpAssignmentsTextBox));
                }

                // Read the current info
                newCourse.name = CourseNameTextBox.Text;
                newCourse.credits = Convert.ToInt16(Utility.ReadTextBox(CreditsTextBox));
                newCourse.finalWeight = Convert.ToDouble(Utility.ReadTextBox(FinalWeightTextBox));

                // Reads the grade scale
                newCourse.cutOffs.Clear();
                for (int i = 0; i < 4; i++)
                    newCourse.cutOffs.Add(Convert.ToDouble(Utility.ReadTextBox(cutOffBoxes[i])));

                if (isNewCourse)
                {
                    // Creates a new file
                    FileSystem.Save(newCourse);

                    CourseMade = true;
                    FormDone = true;

                    // Closes this form
                    this.Hide();
                }
                else
                {
                    // Updates an old file
                    FileSystem.Delete(courseToEdit.name);
                    FileSystem.Save(newCourse);

                    CourseMade = true;
                    FormDone = true;

                    // Closes the form
                    this.Hide();
                }
            }            
        }

        private void CatagoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Used to stop duplicates and avoid repeated indexs
            if (progIsChangingListBoxIndex == false && CatagoryListBox.SelectedIndex != currCatagoryIndex)
            {
                // Changes the selected index
                savedCatagoryIndex = prevCatagoryIndex;
                prevCatagoryIndex = currCatagoryIndex;
                currCatagoryIndex = CatagoryListBox.SelectedIndex;

                // For debugging
                //Console.WriteLine("\n" + savedCatagoryIndex + " " + prevCatagoryIndex + " " + currCatagoryIndex);

                // Test to avoid crashes
                if (currCatagoryIndex >= 0 && currCatagoryIndex < newCourse.categories.Count())
                {
                    // Test to see if the current boxes are valid, if so allow changes
                    if (prevCatagoryIndex == -1 || IsCatagoryTexBoxesValid() == true)
                    {

                        // Checks to see if a previous catagory course index exist
                        if (savedCatagoryIndex != -1)
                        {
                            // Saves the previous catagory information
                            Category prevCatagory = newCourse.categories[prevCatagoryIndex];

                            // Checks to see if we need to update the list box
                            if (prevCatagory.name.Equals(CatagoryNameTextBox.Text) == false)
                            {
                                prevCatagory.name = CatagoryNameTextBox.Text;
                                progIsChangingListBoxIndex = true;
                            }

                            // Stores the other data
                            prevCatagory.weight = Convert.ToDouble(Utility.ReadTextBox(WeightTextBox));
                            prevCatagory.expAssignments = Convert.ToInt16(Utility.ReadTextBox(ExpAssignmentsTextBox));
                        }

                        Category currCatagory = newCourse.categories[currCatagoryIndex];

                        // Changes the text boxes
                        CatagoryNameTextBox.Text = currCatagory.name;
                        Utility.PrintTextBox(WeightTextBox, currCatagory.weight, "");
                        Utility.PrintTextBox(ExpAssignmentsTextBox, currCatagory.expAssignments, "");

                        // Changes the index and list box
                        if (progIsChangingListBoxIndex)
                        {
                            // Update the list box
                            Utility.PrintListBox(CatagoryListBox, newCourse.GetListOfCatNames());
                            CatagoryListBox.SelectedIndex = currCatagoryIndex;
                        }
                    }
                    else
                    {
                        // Forces the user to stay on the current catagory
                        MessageBox.Show("ERROR: Catagory textboxes are invalid!");

                        // Reprints the boxes to clear the issue box
                        Category prevCatagory = newCourse.categories[prevCatagoryIndex];

                        // Changes the text boxes
                        CatagoryNameTextBox.Text = prevCatagory.name;
                        Utility.PrintTextBox(WeightTextBox, prevCatagory.weight, "");
                        Utility.PrintTextBox(ExpAssignmentsTextBox, prevCatagory.expAssignments, "");

                        // Changes the indexs
                        currCatagoryIndex = prevCatagoryIndex;
                        prevCatagoryIndex = savedCatagoryIndex;
                        CatagoryListBox.SelectedIndex = currCatagoryIndex;
                    }
                }
                else
                {
                    currCatagoryIndex = prevCatagoryIndex;
                    prevCatagoryIndex = savedCatagoryIndex;
                    Console.WriteLine("\nERROR: INVALID CATAGORY CHOOSEN");
                }
            }
            // Flips
            else
                progIsChangingListBoxIndex = false;
        }

        private void RemoveCatagoryButton_Click(object sender, EventArgs e)
        {
            // Sees if a catagory has been selected
            if (currCatagoryIndex != -1)
            {
                // Creates the new form
                ConfirmChoiceForm form = new ConfirmChoiceForm();
                form.StartPosition = FormStartPosition.Manual;
                form.Location = this.Location;
                form.ShowDialog();

                // Test if the user is sure they want to delete it
                if (form.GetChoice() == true)
                {
                    // Removes the catagory and item in the list
                    newCourse.categories.RemoveAt(currCatagoryIndex);
                    Utility.PrintListBox(CatagoryListBox, newCourse.GetListOfCatNames());

                    // Resets the logic
                    currCatagoryIndex = -1;
                    prevCatagoryIndex = -1;
                    savedCatagoryIndex = -1;
                    progIsDeletingCatagory = true;

                    // Clears the text boxes
                    ClearCatagoryTextBoxes();

                    // Updates the weight sum label
                    UpdateWeightSumLabel();
                }
            }
            else
            {
                MessageBox.Show("ERROR: You must have a catagory selected!");
            }        
        }

        private void AddCatagoryButton_Click(object sender, EventArgs e)
        {
            // Creates a new catagory
            AddCatagoryForm form = new AddCatagoryForm();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.ShowDialog();

            // Only adds if the it is successful
            if (form.addedCatagory == true)
            {
                Category newCatagory = form.newCatagory;

                // Adds it to the course
                newCourse.categories.Add(newCatagory);

                // Update the form logic
                Utility.PrintListBox(CatagoryListBox, newCourse.GetListOfCatNames());
                UpdateWeightSumLabel();
                progIsClearingBoxes = true;
                ClearCatagoryTextBoxes();

                // Resets the logic
                currCatagoryIndex = -1;
                prevCatagoryIndex = -1;
                savedCatagoryIndex = -1;
                progIsDeletingCatagory = false;
            }
        }

        private void FinalWeightTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Updates the final grade in the course information
                newCourse.finalWeight = Convert.ToDouble(Utility.ReadTextBox(FinalWeightTextBox));

                // Updates the weight sum label
                UpdateWeightSumLabel();
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
            }
        }

        private void WeightTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Avoids this step if the program is deleting the catagory
                if (progIsDeletingCatagory == false && progIsClearingBoxes == false)
                    newCourse.categories[currCatagoryIndex].weight = Convert.ToDouble(Utility.ReadTextBox(WeightTextBox));
                else
                {
                    progIsDeletingCatagory = false;
                    progIsClearingBoxes = false;
                }

                // Updates the weight sum label
                UpdateWeightSumLabel();
            }
            catch (Exception exp)
            {
                Console.WriteLine("\n" + exp.ToString());
            }
        }
    }
}
