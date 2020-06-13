namespace SchoolHelper2._0
{
    partial class ChooseCourseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CourseListBox = new System.Windows.Forms.CheckedListBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CourseListBox
            // 
            this.CourseListBox.CheckOnClick = true;
            this.CourseListBox.FormattingEnabled = true;
            this.CourseListBox.Location = new System.Drawing.Point(13, 28);
            this.CourseListBox.Name = "CourseListBox";
            this.CourseListBox.Size = new System.Drawing.Size(75, 214);
            this.CourseListBox.TabIndex = 0;
            this.CourseListBox.SelectedIndexChanged += new System.EventHandler(this.CourseListBox_SelectedIndexChanged);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(94, 57);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ContinueButton
            // 
            this.ContinueButton.Location = new System.Drawing.Point(94, 28);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(75, 23);
            this.ContinueButton.TabIndex = 2;
            this.ContinueButton.Text = "Continue";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose a course!";
            // 
            // ChooseCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 253);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.CourseListBox);
            this.Name = "ChooseCourseForm";
            this.Text = "ChooseCourseForm";
            this.Load += new System.EventHandler(this.ChooseCourseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CourseListBox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ContinueButton;
        private System.Windows.Forms.Label label1;
    }
}