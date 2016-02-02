using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_means_Clustering_Algorithm
{
    public partial class Form1 : Form
    {
        private K_Means kMeans;

        public Form1()
        {
            kMeans = new K_Means();
            InitializeComponent();
        }

        private void RandomizeBtn_Click(object sender, EventArgs e)
        {
            bool isSucceed = true;
            UInt32 clustersCount = 0;
            UInt32 pointsCount = 0;
            isSucceed = UInt32.TryParse(clusters_TextBox.Text, out clustersCount);
            if (!isSucceed)
            {
                MessageBox.Show(@"Clusters Count is invalid. \n Please, observe ur specified data");
                return;
            }
            isSucceed = UInt32.TryParse(points_TextBox.Text, out pointsCount);
            if (!isSucceed)
            {
                MessageBox.Show(@"Clusters Count is invalid. \n Please, observe ur specified data");
                return;
            }

            kMeans = new K_Means(pointsCount, clustersCount);
            kMeans.Randomize();
           // Painter.Draw(kMeans);
        }

      
    }
}
