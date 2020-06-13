namespace SchoolHelper2._0
{
    partial class GradeEditor
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
            this.ExitEditor = new System.Windows.Forms.Button();
            this.CatagoryListBox = new System.Windows.Forms.ListBox();
            this.GradeListBox = new System.Windows.Forms.ListBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.AddGradeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GradePercLabel = new System.Windows.Forms.Label();
            this.RemoveGradeButton = new System.Windows.Forms.Button();
            this.PointsTotalTextBox = new System.Windows.Forms.TextBox();
            this.PointsEarnedTextBox = new System.Windows.Forms.TextBox();
            this.GradeNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ExitEditor
            // 
            this.ExitEditor.Location = new System.Drawing.Point(276, 162);
            this.ExitEditor.Name = "ExitEditor";
            this.ExitEditor.Size = new System.Drawing.Size(75, 23);
            this.ExitEditor.TabIndex = 0;
            this.ExitEditor.Text = "Exit";
            this.ExitEditor.UseVisualStyleBackColor = true;
            this.ExitEditor.Click += new System.EventHandler(this.ExitEditor_Click);
            // 
            // CatagoryListBox
            // 
            this.CatagoryListBox.FormattingEnabled = true;
            this.CatagoryListBox.Location = new System.Drawing.Point(12, 12);
            this.CatagoryListBox.Name = "CatagoryListBox";
            this.CatagoryListBox.Size = new System.Drawing.Size(75, 173);
            this.CatagoryListBox.TabIndex = 2;
            this.CatagoryListBox.SelectedIndexChanged += new System.EventHandler(this.CatagoryListBox_SelectedIndexChanged);
            // 
            // GradeListBox
            // 
            this.GradeListBox.FormattingEnabled = true;
            this.GradeListBox.Location = new System.Drawing.Point(93, 11);
            this.GradeListBox.Name = "GradeListBox";
            this.GradeListBox.Size = new System.Drawing.Size(75, 173);
            this.GradeListBox.TabIndex = 3;
            this.GradeListBox.SelectedIndexChanged += new System.EventHandler(this.GradeListBox_SelectedIndexChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(276, 133);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AddGradeButton
            // 
            this.AddGradeButton.Location = new System.Drawing.Point(195, 133);
            this.AddGradeButton.Name = "AddGradeButton";
            this.AddGradeButton.Size = new System.Drawing.Size(75, 23);
            this.AddGradeButton.TabIndex = 5;
            this.AddGradeButton.Text = "Add Grade";
            this.AddGradeButton.UseVisualStyleBackColor = true;
            this.AddGradeButton.Click += new System.EventHandler(this.AddGradeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Grade Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Points Earned:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Points Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "% Grade:";
            // 
            // GradePercLabel
            // 
            this.GradePercLabel.AutoSize = true;
            this.GradePercLabel.Location = new System.Drawing.Point(220, 78);
            this.GradePercLabel.Name = "GradePercLabel";
            this.GradePercLabel.Size = new System.Drawing.Size(38, 13);
            this.GradePercLabel.TabIndex = 28;
            this.GradePercLabel.Text = "XX.XX";
            // 
            // RemoveGradeButton
            // 
            this.RemoveGradeButton.Location = new System.Drawing.Point(195, 162);
            this.RemoveGradeButton.Name = "RemoveGradeButton";
            this.RemoveGradeButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveGradeButton.TabIndex = 29;
            this.RemoveGradeButton.Text = "Remove Grade";
            this.RemoveGradeButton.UseVisualStyleBackColor = true;
            this.RemoveGradeButton.Click += new System.EventHandler(this.RemoveGradeButton_Click);
            // 
            // PointsTotalTextBox
            // 
            this.PointsTotalTextBox.Location = new System.Drawing.Point(263, 55);
            this.PointsTotalTextBox.Name = "PointsTotalTextBox";
            this.PointsTotalTextBox.Size = new System.Drawing.Size(88, 20);
            this.PointsTotalTextBox.TabIndex = 26;
            this.PointsTotalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PointsTotalTextBox.TextChanged += new System.EventHandler(this.PointsTotalTextBox_TextChanged);
            // 
            // PointsEarnedTextBox
            // 
            this.PointsEarnedTextBox.Location = new System.Drawing.Point(263, 32);
            this.PointsEarnedTextBox.Name = "PointsEarnedTextBox";
            this.PointsEarnedTextBox.Size = new System.Drawing.Size(88, 20);
            this.PointsEarnedTextBox.TabIndex = 24;
            this.PointsEarnedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PointsEarnedTextBox.TextChanged += new System.EventHandler(this.PointsEarnedTextBox_TextChanged);
            // 
            // GradeNameTextBox
            // 
            this.GradeNameTextBox.Location = new System.Drawing.Point(263, 9);
            this.GradeNameTextBox.Name = "GradeNameTextBox";
            this.GradeNameTextBox.Size = new System.Drawing.Size(88, 20);
            this.GradeNameTextBox.TabIndex = 22;
            this.GradeNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.GradeNameTextBox.TextChanged += new System.EventHandler(this.GradeNameTextBox_TextChanged);
            // 
            // GradeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 193);
            this.Controls.Add(this.RemoveGradeButton);
            this.Controls.Add(this.GradePercLabel);
            this.Controls.Add(this.AddGradeButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.PointsTotalTextBox);
            this.Controls.Add(this.GradeListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CatagoryListBox);
            this.Controls.Add(this.PointsEarnedTextBox);
            this.Controls.Add(this.ExitEditor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GradeNameTextBox);
            this.Name = "GradeEditor";
            this.Text = "GradeEditor";
            this.Load += new System.EventHandler(this.GradeEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitEditor;
        private System.Windows.Forms.ListBox CatagoryListBox;
        private System.Windows.Forms.ListBox GradeListBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button AddGradeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label GradePercLabel;
        private System.Windows.Forms.Button RemoveGradeButton;
        private System.Windows.Forms.TextBox PointsTotalTextBox;
        private System.Windows.Forms.TextBox PointsEarnedTextBox;
        private System.Windows.Forms.TextBox GradeNameTextBox;
    }
}