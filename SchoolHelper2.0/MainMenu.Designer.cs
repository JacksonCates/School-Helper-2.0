namespace SchoolHelper2._0
{
    partial class MainMenu
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
            this.CourseEditor = new System.Windows.Forms.Button();
            this.ExitProg = new System.Windows.Forms.Button();
            this.ManageGradesButton = new System.Windows.Forms.Button();
            this.ViewGradeInfoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CourseEditor
            // 
            this.CourseEditor.Location = new System.Drawing.Point(12, 36);
            this.CourseEditor.Name = "CourseEditor";
            this.CourseEditor.Size = new System.Drawing.Size(109, 23);
            this.CourseEditor.TabIndex = 1;
            this.CourseEditor.Text = "Manage Courses";
            this.CourseEditor.UseVisualStyleBackColor = true;
            this.CourseEditor.Click += new System.EventHandler(this.CourseEditor_Click);
            // 
            // ExitProg
            // 
            this.ExitProg.Location = new System.Drawing.Point(12, 94);
            this.ExitProg.Name = "ExitProg";
            this.ExitProg.Size = new System.Drawing.Size(109, 23);
            this.ExitProg.TabIndex = 3;
            this.ExitProg.Text = "Exit";
            this.ExitProg.UseVisualStyleBackColor = true;
            this.ExitProg.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // ManageGradesButton
            // 
            this.ManageGradesButton.Location = new System.Drawing.Point(12, 65);
            this.ManageGradesButton.Name = "ManageGradesButton";
            this.ManageGradesButton.Size = new System.Drawing.Size(109, 23);
            this.ManageGradesButton.TabIndex = 2;
            this.ManageGradesButton.Text = "Manage Grades";
            this.ManageGradesButton.UseVisualStyleBackColor = true;
            this.ManageGradesButton.Click += new System.EventHandler(this.ManageFradesButtonClick);
            // 
            // ViewGradeInfoButton
            // 
            this.ViewGradeInfoButton.Location = new System.Drawing.Point(12, 7);
            this.ViewGradeInfoButton.Name = "ViewGradeInfoButton";
            this.ViewGradeInfoButton.Size = new System.Drawing.Size(109, 23);
            this.ViewGradeInfoButton.TabIndex = 0;
            this.ViewGradeInfoButton.Text = "View Grade Info";
            this.ViewGradeInfoButton.UseVisualStyleBackColor = true;
            this.ViewGradeInfoButton.Click += new System.EventHandler(this.ViewGradeInfoButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(133, 121);
            this.Controls.Add(this.ViewGradeInfoButton);
            this.Controls.Add(this.ManageGradesButton);
            this.Controls.Add(this.ExitProg);
            this.Controls.Add(this.CourseEditor);
            this.Name = "MainMenu";
            this.Text = "Welcome to Jackson\'s School Helper!";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CourseEditor;
        private System.Windows.Forms.Button ExitProg;
        private System.Windows.Forms.Button ManageGradesButton;
        private System.Windows.Forms.Button ViewGradeInfoButton;
    }
}

