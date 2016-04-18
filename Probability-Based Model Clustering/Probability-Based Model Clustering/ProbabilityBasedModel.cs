using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probability_Based_Model_Clustering
{
    public class ProbabilityBasedModel
    {
        private Int32[] points; 
        public Cluster C1;
        public Cluster C2;

        public ProbabilityBasedModel()
        {
            C1 = new Cluster();
            C2 = new Cluster();
        }

        public Double[] CalculateProbabilityDensities(Int32 X)
        {
            return new Double[]
            {
                C1.CalculateProbabilityDensity(X),
                C2.CalculateProbabilityDensity(X)
            };
        }

        public void GeneratePointsAndSpreadOverClusters(Int32 pointsCount)
        {
            if(points == null)
                points = new Int32[pointsCount];

            Random rand = new Random(DateTime.Now.Millisecond);
            Int32 half = pointsCount / 2;
            Int32 modulo = pointsCount % 2;
            //Int32 avrg = half + modulo;
            for (int i = 0, j = 0; i < pointsCount; i++, j++)
            {
                if (i < half)
                {
                    points[i] = rand.Next(0, 500);
                    C1.AddPoint(points[i]);
                }
                else
                {
                    points[i] = rand.Next(501, 1000);
                    C2.AddPoint(points[i]);
                }
            }
        }

    }
}
