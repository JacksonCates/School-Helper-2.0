namespace SchoolHelper2._0
{
    partial class AddGradeForm
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.PointsTotalTextBox = new System.Windows.Forms.TextBox();
            this.PointsTotalLabel = new System.Windows.Forms.Label();
            this.PointsEarnedTextBox = new System.Windows.Forms.TextBox();
            this.PointsEarnedLabel = new System.Windows.Forms.Label();
            this.GradeNameTextBox = new System.Windows.Forms.TextBox();
            this.GradeNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(212, 23);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 30;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(212, 50);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 29;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PointsTotalTextBox
            // 
            this.PointsTotalTextBox.Location = new System.Drawing.Point(101, 53);
            this.PointsTotalTextBox.Name = "PointsTotalTextBox";
            this.PointsTotalTextBox.Size = new System.Drawing.Size(88, 20);
            this.PointsTotalTextBox.TabIndex = 28;
            this.PointsTotalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PointsTotalLabel
            // 
            this.PointsTotalLabel.AutoSize = true;
            this.PointsTotalLabel.Location = new System.Drawing.Point(12, 56);
            this.PointsTotalLabel.Name = "PointsTotalLabel";
            this.PointsTotalLabel.Size = new System.Drawing.Size(66, 13);
            this.PointsTotalLabel.TabIndex = 27;
            this.PointsTotalLabel.Text = "Points Total:";
            // 
            // PointsEarnedTextBox
            // 
            this.PointsEarnedTextBox.Location = new System.Drawing.Point(101, 30);
            this.PointsEarnedTextBox.Name = "PointsEarnedTextBox";
            this.PointsEarnedTextBox.Size = new System.Drawing.Size(88, 20);
            this.PointsEarnedTextBox.TabIndex = 26;
            this.PointsEarnedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PointsEarnedLabel
            // 
            this.PointsEarnedLabel.AutoSize = true;
            this.PointsEarnedLabel.Location = new System.Drawing.Point(12, 33);
            this.PointsEarnedLabel.Name = "PointsEarnedLabel";
            this.PointsEarnedLabel.Size = new System.Drawing.Size(76, 13);
            this.PointsEarnedLabel.TabIndex = 25;
            this.PointsEarnedLabel.Text = "Points Earned:";
            // 
            // GradeNameTextBox
            // 
            this.GradeNameTextBox.Location = new System.Drawing.Point(101, 7);
            this.GradeNameTextBox.Name = "GradeNameTextBox";
            this.GradeNameTextBox.Size = new System.Drawing.Size(88, 20);
            this.GradeNameTextBox.TabIndex = 24;
            this.GradeNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GradeNameLabel
            // 
            this.GradeNameLabel.AutoSize = true;
            this.GradeNameLabel.Location = new System.Drawing.Point(12, 10);
            this.GradeNameLabel.Name = "GradeNameLabel";
            this.GradeNameLabel.Size = new System.Drawing.Size(70, 13);
            this.GradeNameLabel.TabIndex = 23;
            this.GradeNameLabel.Text = "Grade Name:";
            // 
            // AddGradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 81);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.PointsTotalTextBox);
            this.Controls.Add(this.PointsTotalLabel);
            this.Controls.Add(this.PointsEarnedTextBox);
            this.Controls.Add(this.PointsEarnedLabel);
            this.Controls.Add(this.GradeNameTextBox);
            this.Controls.Add(this.GradeNameLabel);
            this.Name = "AddGradeForm";
            this.Text = "AddGrade";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox PointsTotalTextBox;
        private System.Windows.Forms.Label PointsTotalLabel;
        private System.Windows.Forms.TextBox PointsEarnedTextBox;
        private System.Windows.Forms.Label PointsEarnedLabel;
        private System.Windows.Forms.TextBox GradeNameTextBox;
        private System.Windows.Forms.Label GradeNameLabel;
    }
}