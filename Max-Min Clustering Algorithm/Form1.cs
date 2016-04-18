using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Max_Min_Clustering_Algorithm
{
    public partial class Form1 : Form
    {
        private Max_Mins maxMins;

        public Form1()
        {
            InitializeComponent();
            maxMins = new Max_Mins();
        }

        private void RandomizeBtn_Click(object sender, EventArgs e)
        {
            bool isSucceed = true;
            Int32 clustersCount = 0;
            Int32 pointsCount = 0;
            
            isSucceed = Int32.TryParse(points_TextBox.Text, out pointsCount);
            if (!isSucceed)
            {
                MessageBox.Show(@"Clusters Count is invalid. \n Please, observe ur specified data");
                return;
            }

            maxMins = new Max_Mins(pointsCount);
            maxMins.Randomize();

            maxMins.SetGraphics(panel1.CreateGraphics());
            MM_Painter.Draw(maxMins);
        }

        private void StartKMeansBtn_Click(object sender, EventArgs e)
        {
            maxMins.Start();
            MM_Painter.Draw(maxMins);
        }
    }
}
