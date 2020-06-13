using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SchoolHelper2._0
{
    public static class Utility
    {
        internal static void PrintLabel(Label label, int newText, string emptyText = "Unknown")
        {
            // Checks if it is empty or not
            if (newText == -1)
            {
                label.Text = emptyText;
            }
            else
            {
                label.Text = newText.ToString();
            }
        }
        internal static void PrintLabel(Label label, double newText, string emptyText = "Unknown", int emptyValue = -1)
        {
            // Checks if it is empty or not
            if (Math.Floor(newText) == emptyValue)
            {
                label.Text = emptyText;
            }
            else
            {
                label.Text = String.Format("{0:0.00}", newText);
            }
        }

        internal static void PrintTextBox(TextBox textBox, int newText, string emptyText = "Unknown")
        {
            // Checks if it is empty or not
            if (newText == -1)
            {
                textBox.Text = emptyText;
            }
            else
            {
                textBox.Text = newText.ToString();
            }
        }
        internal static void PrintTextBox(TextBox textBox, double newText, string emptyText = "Unknown")
        {
            // Checks if it is empty or not
            if (Math.Floor(newText) == -1)
            {
                textBox.Text = emptyText;
            }
            else
            {
                textBox.Text = String.Format("{0:0.00}", newText);
            }
        }

        internal static void PrintListBox(ListBox listBox, List<string> choices, string emptyText = "None")
        {
            // Clears
            listBox.Items.Clear();

            if (choices.Count() == 0)
                listBox.Items.Add(emptyText);
            else
            {
                foreach (string choice in choices)
                    listBox.Items.Add(choice);
            }
        }        

        internal static string ReadTextBox(TextBox textBox, string emptyReturn = "-1", string emptyText = "")
        {
            // Checks if it is empty
            if (textBox.Text.Equals(emptyText))
            {
                return emptyReturn;
            }
            else
            {
                return textBox.Text;
            }
        }

        internal static void PrintCheckedListBox(CheckedListBox listBox, List<string> choices)
        {
            // Clears
            listBox.Items.Clear();

            foreach (string choice in choices)
                listBox.Items.Add(choice);
        }
    }
}
