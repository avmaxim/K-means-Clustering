using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probability_Based_Model_Clustering
{
    public class PBM_Math
    {
        private static Double CalculateMean(Int32[] points)
        {
            Double mean = 0d;
            foreach (var point in points)
                mean += point;
            return mean / points.Length;
        }

        private static Double CalculateVariance(Int32[] points, Double jm)
        {
            Double G2 = 0d;
            foreach (var point in points)
                G2 += Math.Pow(point - jm, 2);
            return G2 / (points.Length);
        }

        private static Double CalculateStandardDeviation(Double G2)
        {
            return Math.Sqrt(G2);
        }

        public static Double CalculateDensity(Int32[] points, Int32 X)
        {
            Double jm = CalculateMean(points);
            Double G2 = CalculateVariance(points, jm);
            Double G = CalculateStandardDeviation(G2);
            Double p = (Math.Exp(-Math.Pow( (X - jm)/G, 2 )/ 2)) / (G * Math.Sqrt(2 * Math.PI));
            return p;
        }
    }
}
