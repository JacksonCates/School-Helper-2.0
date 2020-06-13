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
    public partial class AddCatagoryForm : Form
    {
        internal bool addedCatagory;
        internal Category newCatagory;

        public AddCatagoryForm()
        {
            InitializeComponent();

            // Disable resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            newCatagory = new Category();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Test the test boxes
            try
            {
                // Test to see if the boxes are in the correct format
                if (CatagoryNameTextBox.Text.Equals(""))
                {
                    MessageBox.Show("ERROR: Must have a catagory name!");
                    Console.WriteLine("\nERROR: CATAGORYNAMETEXTBOX IS INVALID");
                }
                else if (WeightTextBox.Text.Equals("") || Convert.ToDouble(WeightTextBox.Text) <= -0.001 || Convert.ToDouble(WeightTextBox.Text) >= 100.001)
                {
                    MessageBox.Show("ERROR: Weight is invalid");
                    Console.WriteLine("\nERROR: WEIGHTTEXTBOX IS INVALID");
                }
                else if (Convert.ToInt16(Utility.ReadTextBox(ExpAssignmentsTextBox)) <= 0 && Convert.ToInt16(Utility.ReadTextBox(ExpAssignmentsTextBox)) != -1)
                {
                    MessageBox.Show("ERROR: Expected Assignments are invalid");
                    Console.WriteLine("\nERROR: EXPASSIGNMENTSTEXTBOX IS INVALID");
                }
                else
                {
                    // Creates the new catagory
                    newCatagory.name = CatagoryNameTextBox.Text;
                    newCatagory.weight = Convert.ToDouble(Utility.ReadTextBox(WeightTextBox));
                    newCatagory.expAssignments = Convert.ToInt16(Utility.ReadTextBox(ExpAssignmentsTextBox));

                    // Sets this to true and exists
                    addedCatagory = true;
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
            // Sets this to false and exits
            addedCatagory = false;
            this.Hide();
        }
    }
}
