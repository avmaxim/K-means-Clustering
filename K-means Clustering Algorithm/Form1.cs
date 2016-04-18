using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_means_Clustering_Algorithm
{
    public partial class Form1 : Form
    {
        private K_Means kMeans;
       
        public Form1()
        {
            InitializeComponent();
            kMeans = new K_Means();
           // InitBitmap();
        }

        private void RandomizeBtn_Click(object sender, EventArgs e)
        {
            bool isSucceed = true;
            Int32 clustersCount = 0;
            Int32 pointsCount = 0;
            isSucceed = Int32.TryParse(clusters_TextBox.Text, out clustersCount);
            if (!isSucceed)
            {
                MessageBox.Show(@"Clusters Count is invalid. \n Please, observe ur specified data");
                return;
            }
            isSucceed = Int32.TryParse(points_TextBox.Text, out pointsCount);
            if (!isSucceed)
            {
                MessageBox.Show(@"Clusters Count is invalid. \n Please, observe ur specified data");
                return;
            }
            
            kMeans = new K_Means(pointsCount, clustersCount);
            kMeans.Randomize();
            
            kMeans.SetGraphics(panel1.CreateGraphics());
            K_Painter.Draw(kMeans, panel1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Start(object o)
        {
            Int32 numberofIterations = 0;
            Boolean needVisualIterations = visualIterionsCheckbox.Checked;
       
            kMeans.Start(needVisualIterations, ref numberofIterations);
            string output = "********************************************************" + Environment.NewLine +
                           "Number of Clusters: " + clusters_TextBox.Text + Environment.NewLine +
                           "Number of Points:   " + points_TextBox.Text + Environment.NewLine +
                           "Result: => *** Total number of iterations: " + numberofIterations +
                           "********************************************************" + Environment.NewLine;

             System.IO.File.AppendAllText(@"./log.txt", output);
        }

        private void StartKMeansBtn_Click(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            Cursor.Current = Cursors.WaitCursor;
            Thread thread = new Thread(Start);
            thread.IsBackground = false;
            thread.Start();
            thread.Join();
            elapsedTimeLabel.Text = (DateTime.Now - now).ToString();
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Clustering points job is finished. Algorthym succeed =) ");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

      
    }
}
