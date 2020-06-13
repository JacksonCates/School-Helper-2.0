namespace SchoolHelper2._0
{
    partial class AddCatagoryForm
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
            this.ExpAssignmentsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.WeightTextBox = new System.Windows.Forms.TextBox();
            this.WeightLabel = new System.Windows.Forms.Label();
            this.CatagoryNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExpAssignmentsTextBox
            // 
            this.ExpAssignmentsTextBox.Location = new System.Drawing.Point(101, 52);
            this.ExpAssignmentsTextBox.Name = "ExpAssignmentsTextBox";
            this.ExpAssignmentsTextBox.Size = new System.Drawing.Size(88, 20);
            this.ExpAssignmentsTextBox.TabIndex = 20;
            this.ExpAssignmentsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Exp Assignments:";
            // 
            // WeightTextBox
            // 
            this.WeightTextBox.Location = new System.Drawing.Point(101, 29);
            this.WeightTextBox.Name = "WeightTextBox";
            this.WeightTextBox.Size = new System.Drawing.Size(88, 20);
            this.WeightTextBox.TabIndex = 18;
            this.WeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Location = new System.Drawing.Point(12, 32);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(44, 13);
            this.WeightLabel.TabIndex = 17;
            this.WeightLabel.Text = "Weight:";
            // 
            // CatagoryNameTextBox
            // 
            this.CatagoryNameTextBox.Location = new System.Drawing.Point(101, 6);
            this.CatagoryNameTextBox.Name = "CatagoryNameTextBox";
            this.CatagoryNameTextBox.Size = new System.Drawing.Size(88, 20);
            this.CatagoryNameTextBox.TabIndex = 16;
            this.CatagoryNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Catagory Name:";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(212, 49);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 21;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(212, 22);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 22;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AddCatagory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 81);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ExpAssignmentsTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WeightTextBox);
            this.Controls.Add(this.WeightLabel);
            this.Controls.Add(this.CatagoryNameTextBox);
            this.Controls.Add(this.label2);
            this.Name = "AddCatagory";
            this.Text = "AddCatagory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ExpAssignmentsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox WeightTextBox;
        private System.Windows.Forms.Label WeightLabel;
        private System.Windows.Forms.TextBox CatagoryNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
    }
}