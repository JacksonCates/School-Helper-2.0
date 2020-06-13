namespace SchoolHelper2._0
{
    partial class CourseEditor
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
            this.ExitScreen = new System.Windows.Forms.Button();
            this.CourseListBox = new System.Windows.Forms.ListBox();
            this.CourseNameLabel = new System.Windows.Forms.Label();
            this.CreditsLabel = new System.Windows.Forms.Label();
            this.GeneralInfoLabel = new System.Windows.Forms.Label();
            this.ActualCourseNameLabel = new System.Windows.Forms.Label();
            this.ActualCreditsLabel = new System.Windows.Forms.Label();
            this.GradeScaleLabel = new System.Windows.Forms.Label();
            this.CatagoryListBox = new System.Windows.Forms.ListBox();
            this.CatagoryGenInfoLabel = new System.Windows.Forms.Label();
            this.CatagoryNameLabel = new System.Windows.Forms.Label();
            this.ActualCatagoryNameLabel = new System.Windows.Forms.Label();
            this.CatagoryWeightLabel = new System.Windows.Forms.Label();
            this.ActualCatagoryWeightLabel = new System.Windows.Forms.Label();
            this.FinalWeightLabel = new System.Windows.Forms.Label();
            this.ActualFinalWeightLabel = new System.Windows.Forms.Label();
            this.AddCourseButton = new System.Windows.Forms.Button();
            this.EditCourseButton = new System.Windows.Forms.Button();
            this.ExpAssLabel = new System.Windows.Forms.Label();
            this.ActualExpAssLabel = new System.Windows.Forms.Label();
            this.RemoveCourseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExitScreen
            // 
            this.ExitScreen.Location = new System.Drawing.Point(486, 163);
            this.ExitScreen.Name = "ExitScreen";
            this.ExitScreen.Size = new System.Drawing.Size(75, 23);
            this.ExitScreen.TabIndex = 0;
            this.ExitScreen.Text = "Exit";
            this.ExitScreen.UseVisualStyleBackColor = true;
            this.ExitScreen.Click += new System.EventHandler(this.ExitScreen_Click);
            // 
            // CourseListBox
            // 
            this.CourseListBox.FormattingEnabled = true;
            this.CourseListBox.Location = new System.Drawing.Point(5, 12);
            this.CourseListBox.Name = "CourseListBox";
            this.CourseListBox.Size = new System.Drawing.Size(75, 173);
            this.CourseListBox.TabIndex = 1;
            this.CourseListBox.SelectedIndexChanged += new System.EventHandler(this.CourseListBox_SelectedIndexChanged);
            // 
            // CourseNameLabel
            // 
            this.CourseNameLabel.AutoSize = true;
            this.CourseNameLabel.Location = new System.Drawing.Point(86, 36);
            this.CourseNameLabel.Name = "CourseNameLabel";
            this.CourseNameLabel.Size = new System.Drawing.Size(74, 13);
            this.CourseNameLabel.TabIndex = 2;
            this.CourseNameLabel.Text = "Course Name:";
            // 
            // CreditsLabel
            // 
            this.CreditsLabel.AutoSize = true;
            this.CreditsLabel.Location = new System.Drawing.Point(87, 60);
            this.CreditsLabel.Name = "CreditsLabel";
            this.CreditsLabel.Size = new System.Drawing.Size(42, 13);
            this.CreditsLabel.TabIndex = 3;
            this.CreditsLabel.Text = "Credits:";
            // 
            // GeneralInfoLabel
            // 
            this.GeneralInfoLabel.AutoSize = true;
            this.GeneralInfoLabel.Location = new System.Drawing.Point(86, 12);
            this.GeneralInfoLabel.Name = "GeneralInfoLabel";
            this.GeneralInfoLabel.Size = new System.Drawing.Size(68, 13);
            this.GeneralInfoLabel.TabIndex = 4;
            this.GeneralInfoLabel.Text = "General Info:";
            // 
            // ActualCourseNameLabel
            // 
            this.ActualCourseNameLabel.AutoSize = true;
            this.ActualCourseNameLabel.Location = new System.Drawing.Point(157, 36);
            this.ActualCourseNameLabel.Name = "ActualCourseNameLabel";
            this.ActualCourseNameLabel.Size = new System.Drawing.Size(56, 13);
            this.ActualCourseNameLabel.TabIndex = 5;
            this.ActualCourseNameLabel.Text = "XXXXXXX";
            // 
            // ActualCreditsLabel
            // 
            this.ActualCreditsLabel.AutoSize = true;
            this.ActualCreditsLabel.Location = new System.Drawing.Point(126, 60);
            this.ActualCreditsLabel.Name = "ActualCreditsLabel";
            this.ActualCreditsLabel.Size = new System.Drawing.Size(14, 13);
            this.ActualCreditsLabel.TabIndex = 6;
            this.ActualCreditsLabel.Text = "X";
            // 
            // GradeScaleLabel
            // 
            this.GradeScaleLabel.AutoSize = true;
            this.GradeScaleLabel.Location = new System.Drawing.Point(86, 111);
            this.GradeScaleLabel.Name = "GradeScaleLabel";
            this.GradeScaleLabel.Size = new System.Drawing.Size(69, 13);
            this.GradeScaleLabel.TabIndex = 7;
            this.GradeScaleLabel.Text = "Grade Scale:";
            // 
            // CatagoryListBox
            // 
            this.CatagoryListBox.FormattingEnabled = true;
            this.CatagoryListBox.Items.AddRange(new object[] {
            "CatagoryListBox"});
            this.CatagoryListBox.Location = new System.Drawing.Point(219, 12);
            this.CatagoryListBox.Name = "CatagoryListBox";
            this.CatagoryListBox.Size = new System.Drawing.Size(84, 173);
            this.CatagoryListBox.TabIndex = 8;
            this.CatagoryListBox.SelectedIndexChanged += new System.EventHandler(this.CatagoryListBox_SelectedIndexChanged);
            // 
            // CatagoryGenInfoLabel
            // 
            this.CatagoryGenInfoLabel.AutoSize = true;
            this.CatagoryGenInfoLabel.Location = new System.Drawing.Point(309, 12);
            this.CatagoryGenInfoLabel.Name = "CatagoryGenInfoLabel";
            this.CatagoryGenInfoLabel.Size = new System.Drawing.Size(73, 13);
            this.CatagoryGenInfoLabel.TabIndex = 9;
            this.CatagoryGenInfoLabel.Text = "Catagory Info:";
            // 
            // CatagoryNameLabel
            // 
            this.CatagoryNameLabel.AutoSize = true;
            this.CatagoryNameLabel.Location = new System.Drawing.Point(309, 36);
            this.CatagoryNameLabel.Name = "CatagoryNameLabel";
            this.CatagoryNameLabel.Size = new System.Drawing.Size(83, 13);
            this.CatagoryNameLabel.TabIndex = 10;
            this.CatagoryNameLabel.Text = "Catagory Name:";
            // 
            // ActualCatagoryNameLabel
            // 
            this.ActualCatagoryNameLabel.AutoSize = true;
            this.ActualCatagoryNameLabel.Location = new System.Drawing.Point(389, 36);
            this.ActualCatagoryNameLabel.Name = "ActualCatagoryNameLabel";
            this.ActualCatagoryNameLabel.Size = new System.Drawing.Size(63, 13);
            this.ActualCatagoryNameLabel.TabIndex = 11;
            this.ActualCatagoryNameLabel.Text = "XXXXXXXX";
            // 
            // CatagoryWeightLabel
            // 
            this.CatagoryWeightLabel.AutoSize = true;
            this.CatagoryWeightLabel.Location = new System.Drawing.Point(309, 60);
            this.CatagoryWeightLabel.Name = "CatagoryWeightLabel";
            this.CatagoryWeightLabel.Size = new System.Drawing.Size(44, 13);
            this.CatagoryWeightLabel.TabIndex = 12;
            this.CatagoryWeightLabel.Text = "Weight:";
            // 
            // ActualCatagoryWeightLabel
            // 
            this.ActualCatagoryWeightLabel.AutoSize = true;
            this.ActualCatagoryWeightLabel.Location = new System.Drawing.Point(349, 60);
            this.ActualCatagoryWeightLabel.Name = "ActualCatagoryWeightLabel";
            this.ActualCatagoryWeightLabel.Size = new System.Drawing.Size(38, 13);
            this.ActualCatagoryWeightLabel.TabIndex = 13;
            this.ActualCatagoryWeightLabel.Text = "XX.XX";
            // 
            // FinalWeightLabel
            // 
            this.FinalWeightLabel.AutoSize = true;
            this.FinalWeightLabel.Location = new System.Drawing.Point(87, 84);
            this.FinalWeightLabel.Name = "FinalWeightLabel";
            this.FinalWeightLabel.Size = new System.Drawing.Size(69, 13);
            this.FinalWeightLabel.TabIndex = 14;
            this.FinalWeightLabel.Text = "Final Weight:";
            // 
            // ActualFinalWeightLabel
            // 
            this.ActualFinalWeightLabel.AutoSize = true;
            this.ActualFinalWeightLabel.Location = new System.Drawing.Point(153, 84);
            this.ActualFinalWeightLabel.Name = "ActualFinalWeightLabel";
            this.ActualFinalWeightLabel.Size = new System.Drawing.Size(38, 13);
            this.ActualFinalWeightLabel.TabIndex = 15;
            this.ActualFinalWeightLabel.Text = "XX.XX";
            // 
            // AddCourseButton
            // 
            this.AddCourseButton.Location = new System.Drawing.Point(486, 107);
            this.AddCourseButton.Name = "AddCourseButton";
            this.AddCourseButton.Size = new System.Drawing.Size(75, 23);
            this.AddCourseButton.TabIndex = 16;
            this.AddCourseButton.Text = "Add Course";
            this.AddCourseButton.UseVisualStyleBackColor = true;
            this.AddCourseButton.Click += new System.EventHandler(this.AddCourseButton_Click);
            // 
            // EditCourseButton
            // 
            this.EditCourseButton.Location = new System.Drawing.Point(486, 78);
            this.EditCourseButton.Name = "EditCourseButton";
            this.EditCourseButton.Size = new System.Drawing.Size(75, 23);
            this.EditCourseButton.TabIndex = 17;
            this.EditCourseButton.Text = "Edit Course";
            this.EditCourseButton.UseVisualStyleBackColor = true;
            this.EditCourseButton.Click += new System.EventHandler(this.EditCourseButton_Click);
            // 
            // ExpAssLabel
            // 
            this.ExpAssLabel.AutoSize = true;
            this.ExpAssLabel.Location = new System.Drawing.Point(309, 84);
            this.ExpAssLabel.Name = "ExpAssLabel";
            this.ExpAssLabel.Size = new System.Drawing.Size(117, 13);
            this.ExpAssLabel.TabIndex = 18;
            this.ExpAssLabel.Text = "Expected Assignments:";
            // 
            // ActualExpAssLabel
            // 
            this.ActualExpAssLabel.AutoSize = true;
            this.ActualExpAssLabel.Location = new System.Drawing.Point(423, 84);
            this.ActualExpAssLabel.Name = "ActualExpAssLabel";
            this.ActualExpAssLabel.Size = new System.Drawing.Size(14, 13);
            this.ActualExpAssLabel.TabIndex = 19;
            this.ActualExpAssLabel.Text = "X";
            // 
            // RemoveCourseButton
            // 
            this.RemoveCourseButton.Location = new System.Drawing.Point(486, 136);
            this.RemoveCourseButton.Name = "RemoveCourseButton";
            this.RemoveCourseButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveCourseButton.TabIndex = 20;
            this.RemoveCourseButton.Text = "Remove Course";
            this.RemoveCourseButton.UseVisualStyleBackColor = true;
            this.RemoveCourseButton.Click += new System.EventHandler(this.RemoveCourseButton_Click);
            // 
            // CourseEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 191);
            this.Controls.Add(this.RemoveCourseButton);
            this.Controls.Add(this.ActualExpAssLabel);
            this.Controls.Add(this.ExpAssLabel);
            this.Controls.Add(this.EditCourseButton);
            this.Controls.Add(this.AddCourseButton);
            this.Controls.Add(this.ActualFinalWeightLabel);
            this.Controls.Add(this.FinalWeightLabel);
            this.Controls.Add(this.ActualCatagoryWeightLabel);
            this.Controls.Add(this.CatagoryWeightLabel);
            this.Controls.Add(this.ActualCatagoryNameLabel);
            this.Controls.Add(this.CatagoryNameLabel);
            this.Controls.Add(this.CatagoryGenInfoLabel);
            this.Controls.Add(this.CatagoryListBox);
            this.Controls.Add(this.GradeScaleLabel);
            this.Controls.Add(this.ActualCreditsLabel);
            this.Controls.Add(this.ActualCourseNameLabel);
            this.Controls.Add(this.GeneralInfoLabel);
            this.Controls.Add(this.CreditsLabel);
            this.Controls.Add(this.CourseNameLabel);
            this.Controls.Add(this.CourseListBox);
            this.Controls.Add(this.ExitScreen);
            this.Name = "CourseEditor";
            this.Text = "CourseEditor";
            this.Load += new System.EventHandler(this.CourseEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitScreen;
        private System.Windows.Forms.ListBox CourseListBox;
        private System.Windows.Forms.Label CourseNameLabel;
        private System.Windows.Forms.Label CreditsLabel;
        private System.Windows.Forms.Label GeneralInfoLabel;
        private System.Windows.Forms.Label ActualCourseNameLabel;
        private System.Windows.Forms.Label ActualCreditsLabel;
        private System.Windows.Forms.Label GradeScaleLabel;
        private System.Windows.Forms.ListBox CatagoryListBox;
        private System.Windows.Forms.Label CatagoryGenInfoLabel;
        private System.Windows.Forms.Label CatagoryNameLabel;
        private System.Windows.Forms.Label ActualCatagoryNameLabel;
        private System.Windows.Forms.Label CatagoryWeightLabel;
        private System.Windows.Forms.Label ActualCatagoryWeightLabel;
        private System.Windows.Forms.Label FinalWeightLabel;
        private System.Windows.Forms.Label ActualFinalWeightLabel;
        private System.Windows.Forms.Button AddCourseButton;
        private System.Windows.Forms.Button EditCourseButton;
        private System.Windows.Forms.Label ExpAssLabel;
        private System.Windows.Forms.Label ActualExpAssLabel;
        private System.Windows.Forms.Button RemoveCourseButton;
    }
}