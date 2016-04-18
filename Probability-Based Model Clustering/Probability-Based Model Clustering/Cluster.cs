using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probability_Based_Model_Clustering
{
    public class Cluster
    {
        private Double jm;
        private Double G2;
        private Double G;
        private Double p;
        private List<Int32> points;
        private Int32[] pointsAsArray;

        public Cluster()
        {
            this.jm = 0d;
            this.G = 0d;
            this.G2 = 0d;
            this.p = 0d;
            this.points = new List<int>();
        }

        public void AddPoint(Int32 point)
        {
            points.Add(point);
        }

        public Double CalculateProbabilityDensity(Int32 X)
        {
            return PBM_Math.CalculateDensity(points.ToArray(), X);
        }
    }
}
