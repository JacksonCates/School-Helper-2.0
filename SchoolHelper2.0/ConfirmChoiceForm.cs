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
    public partial class ConfirmChoiceForm : Form
    {
        private bool choice;

        public ConfirmChoiceForm(string text = "Are you sure?")
        {
            InitializeComponent();

            // Disable resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Updates the label
            TextLabel.Text = text;
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            choice = true;
            this.Hide();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            choice = false;
            this.Hide();
        }

        internal bool GetChoice()
        {
            return choice;
        }

        private void ConfirmChoiceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
