using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Probability_Based_Model_Clustering
{
    public partial class Form1 : Form
    {
        private ProbabilityBasedModel pbModel;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Double P_C1;
            Boolean success = Double.TryParse(P_C1_textBox.Text, out P_C1);
            if (!success) return;

            Double P_C2;
            success = Double.TryParse(P_C2_textBox.Text, out P_C2);
            if (!success) return;

            Int32 pointsNumber = 30000;

            if (pbModel == null)
                pbModel = new ProbabilityBasedModel();

            pbModel.GeneratePointsAndSpreadOverClusters(pointsNumber);
            var graphics = pictureBox1.CreateGraphics();
            Int32 Oy = pictureBox1.Height;
            Double sect1 = 0;
            Double sect2 = 0;
            Double[] p1 = new double[pictureBox1.Width - 10];
            Double[] p2 = new double[pictureBox1.Width - 10];
            for (int i = 0; i < pictureBox1.Width - 10; i++)
            {
                Double[] propDensities = pbModel.CalculateProbabilityDensities(i);
                Double t1 = propDensities[0] * P_C1 * 2200;
                Double t2 = propDensities[1] * P_C2 * 2200;
                p1[i] = t1/2200;
                p2[i] = t2/2200;
                if (Math.Round(t1) == Math.Round(t2))
                {
                    sect1 = i;
                    sect2 = t1;
                }
                graphics.FillRectangle(new SolidBrush(Color.DarkGoldenrod), (int)(i), Oy - ((int)((t1))) - 20, 4, 4);
                graphics.FillRectangle(new SolidBrush(Color.Crimson), (int)(i), Oy - ((int)((t2))) - 20, 4, 4);
            }
            graphics.DrawLine(new Pen(Color.DimGray), (float)sect1, (float)(Oy - sect2 - 20), (float)sect1, (float)(Oy - 5));
            
            //False alarm area error possibility 
            double falseAlarmAreaError = 0;
            //Crossing detection zone error possibility 
            double CrossingDetectionZoneError = 0;

            falseAlarmAreaError = p1.Take((int)sect1).Sum();

            if (P_C1 > P_C2)
            {
                CrossingDetectionZoneError = p2.Skip((int)sect1).Sum();
            }
            else
            {
                CrossingDetectionZoneError = p1.Skip((int)sect1).Sum();
            }
            Double sum = falseAlarmAreaError + CrossingDetectionZoneError;
        }
    }
}
