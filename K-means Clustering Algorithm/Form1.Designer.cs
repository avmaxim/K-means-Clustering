﻿namespace K_means_Clustering_Algorithm
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
            this.RandomizeBtn = new System.Windows.Forms.Button();
            this.clusters_TextBox = new System.Windows.Forms.TextBox();
            this.points_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartKMeansBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // RandomizeBtn
            // 
            this.RandomizeBtn.Location = new System.Drawing.Point(775, 255);
            this.RandomizeBtn.Name = "RandomizeBtn";
            this.RandomizeBtn.Size = new System.Drawing.Size(75, 35);
            this.RandomizeBtn.TabIndex = 0;
            this.RandomizeBtn.Text = "Randomize";
            this.RandomizeBtn.UseVisualStyleBackColor = true;
            this.RandomizeBtn.Click += new System.EventHandler(this.RandomizeBtn_Click);
            // 
            // clusters_TextBox
            // 
            this.clusters_TextBox.Location = new System.Drawing.Point(874, 190);
            this.clusters_TextBox.Name = "clusters_TextBox";
            this.clusters_TextBox.Size = new System.Drawing.Size(100, 20);
            this.clusters_TextBox.TabIndex = 1;
            // 
            // points_TextBox
            // 
            this.points_TextBox.Location = new System.Drawing.Point(874, 216);
            this.points_TextBox.Name = "points_TextBox";
            this.points_TextBox.Size = new System.Drawing.Size(100, 20);
            this.points_TextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(772, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of Clusters";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(772, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of Points";
            // 
            // StartKMeansBtn
            // 
            this.StartKMeansBtn.Location = new System.Drawing.Point(865, 255);
            this.StartKMeansBtn.Name = "StartKMeansBtn";
            this.StartKMeansBtn.Size = new System.Drawing.Size(109, 35);
            this.StartKMeansBtn.TabIndex = 5;
            this.StartKMeansBtn.Text = "Start K-means";
            this.StartKMeansBtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 523);
            this.panel1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 548);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StartKMeansBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.points_TextBox);
            this.Controls.Add(this.clusters_TextBox);
            this.Controls.Add(this.RandomizeBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RandomizeBtn;
        private System.Windows.Forms.TextBox clusters_TextBox;
        private System.Windows.Forms.TextBox points_TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StartKMeansBtn;
        private System.Windows.Forms.Panel panel1;
    }
}
