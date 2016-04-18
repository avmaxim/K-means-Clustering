namespace Max_Min_Clustering_Algorithm
{
    partial class Form1
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
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.visualIterionsCheckbox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StartMaxMinsBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.points_TextBox = new System.Windows.Forms.TextBox();
            this.RandomizeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.Location = new System.Drawing.Point(1055, 198);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(13, 13);
            this.elapsedTimeLabel.TabIndex = 19;
            this.elapsedTimeLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(965, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Elapsed time (ms): ";
            // 
            // visualIterionsCheckbox
            // 
            this.visualIterionsCheckbox.AutoSize = true;
            this.visualIterionsCheckbox.Location = new System.Drawing.Point(968, 327);
            this.visualIterionsCheckbox.Name = "visualIterionsCheckbox";
            this.visualIterionsCheckbox.Size = new System.Drawing.Size(162, 17);
            this.visualIterionsCheckbox.TabIndex = 17;
            this.visualIterionsCheckbox.Text = "Watch each iteration visually";
            this.visualIterionsCheckbox.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 618);
            this.panel1.TabIndex = 16;
            // 
            // StartMaxMinsBtn
            // 
            this.StartMaxMinsBtn.Location = new System.Drawing.Point(1058, 259);
            this.StartMaxMinsBtn.Name = "StartMaxMinsBtn";
            this.StartMaxMinsBtn.Size = new System.Drawing.Size(109, 35);
            this.StartMaxMinsBtn.TabIndex = 15;
            this.StartMaxMinsBtn.Text = "Start Max-Mins";
            this.StartMaxMinsBtn.UseVisualStyleBackColor = true;
            this.StartMaxMinsBtn.Click += new System.EventHandler(this.StartKMeansBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(965, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Number of Points";
            // 
            // points_TextBox
            // 
            this.points_TextBox.Location = new System.Drawing.Point(1067, 220);
            this.points_TextBox.Name = "points_TextBox";
            this.points_TextBox.Size = new System.Drawing.Size(100, 20);
            this.points_TextBox.TabIndex = 12;
            // 
            // RandomizeBtn
            // 
            this.RandomizeBtn.Location = new System.Drawing.Point(968, 259);
            this.RandomizeBtn.Name = "RandomizeBtn";
            this.RandomizeBtn.Size = new System.Drawing.Size(75, 35);
            this.RandomizeBtn.TabIndex = 10;
            this.RandomizeBtn.Text = "Randomize";
            this.RandomizeBtn.UseVisualStyleBackColor = true;
            this.RandomizeBtn.Click += new System.EventHandler(this.RandomizeBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 641);
            this.Controls.Add(this.elapsedTimeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.visualIterionsCheckbox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StartMaxMinsBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.points_TextBox);
            this.Controls.Add(this.RandomizeBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label elapsedTimeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox visualIterionsCheckbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button StartMaxMinsBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox points_TextBox;
        private System.Windows.Forms.Button RandomizeBtn;
    }
}

