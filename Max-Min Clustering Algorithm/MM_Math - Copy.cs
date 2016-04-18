using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Min_Clustering_Algorithm
{
    public sealed class MM_Math
    {
        public static int SquaredEuclideanDistance(CPoint pointA, CPoint pointB)
        {
            //(A.x - B.x)^2 + (A.y - B.y)^2
            return (pointB.X - pointA.X) * (pointB.X - pointA.X) +
                   (pointB.Y - pointA.Y) * (pointB.Y - pointA.Y);
        }


        public static Dictionary<int, int> SquaredEuclideanDistances(CPoint centroid, List<CPoint> points)
        {
            Dictionary<int, int> dists = new Dictionary<int, int>();
            for (int i = 0; i < points.Count; i++)
            {
                if ( !ReferenceEquals(centroid, points[i]))
                    dists.Add(i, SquaredEuclideanDistance(centroid, points[i]));
                else 
                    dists.Add(i, 0);
            }
            return dists;
        }

        //public static Dictionary<int, int> SquaredEuclideanDistances(CPoint centroid, List<CPoint> cluster, List<CPoint> allPoints)
        //{
        //    Dictionary<int, int> dists = new Dictionary<int, int>();
        //    for (int i = 0; i < cluster.Count; i++)
        //    {
        //        no need to check references cuz thera ain't any centroids in cluster. only points
        //         dists.Add(i, SquaredEuclideanDistance(centroid, allPoints[i]));
        //    }

        //    return dists;
        //}

        public static KeyValuePair<int, int> MaxAndArgMaxComboFromSquaredEuclideanDistances(CPoint centroid, List<CPoint> clusterPoints, List<CPoint> allPoints)
        {
            Dictionary<int, int> dists = new Dictionary<int, int>();
            int argmax = -1;
            int max = -1;

            for (int i = 0; i < clusterPoints.Count; i++)
            {
                var distance = SquaredEuclideanDistance(centroid, clusterPoints[i]);
                if (distance > max)
                {
                    max = distance;
                    argmax = allPoints.IndexOf(clusterPoints[i]);
                }
            }

            return new KeyValuePair<int, int>(argmax, max);
        }

        //Returns 'Key' for which 'Value' attains it's maximum
        public static int ArgMax(IDictionary<int, int> dic)
        {
            int argmax;
            int max;

            if (dic.Count == 0)
            {
                return -1; //argmax == -1
            }

            argmax = dic.Keys.First();                        // inverse(dic[argmin]) == argmin
            max = dic[argmax];

            if (dic.Count == 1)
                return argmax;

            foreach (var key in dic.Keys)
            {
                if (dic[key] > max)
                {
                    max = dic[key];
                    argmax = key;
                }
            }

            return argmax;
        }

        //Returns 'Key' for which 'Value' attains it's maximum
        public static int ArgMin(IDictionary<int, int> dic)
        {
            int argmin;
            int min;

            if (dic.Count == 0)
            {
                return -1;  //armin == -1
            }

            argmin = dic.Keys.First();                        // inverse(dic[argmin]) == argmin
            min = dic[argmin];

            if (dic.Count == 1)
                return argmin;

            foreach (var key in dic.Keys)
            {
                if (dic[key] < min)
                {
                    min = dic[key];
                    argmin = key;
                }
            }

            return argmin;
        }

        //Returns 'Key-Value' from where for argument 'Key' function's 'Value' attains it's maximum
        public static KeyValuePair<int, int> MaxAndArgmaxCombo(IDictionary<int, int> dic)
        {
            int argmax;
            int max;

            if (dic.Count == 0)
            {
                return new KeyValuePair<int, int>(-1, -1);  //argmax == -1, max = -1
            }

            argmax = dic.Keys.First();                        // inverse(dic[argmin]) == argmin
            max = dic[argmax];

            if (dic.Count == 1)
                return new KeyValuePair<int, int>(argmax, max);

            foreach (var key in dic.Keys)
            {
                if (dic[key] > max)
                {
                    max = dic[key];
                    argmax = key;
                }
            }

            return new KeyValuePair<int, int>(argmax, max);
        }

        public static double MeanOutOfDistancesBetweenPonts(List<CPoint> points)
        {
            double sum = 0d;
            int divisor = 0;

            for (int i = 0; i < points.Count - 1; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    sum += Math.Sqrt(SquaredEuclideanDistance(points[i], points[j]));
                    divisor ++;
                }
            }
            return sum/divisor;
        }

        public static CPoint RandomPoint(List<CPoint> points)
        {
            return points[new Random().Next(0, points.Count - 1)];
        }
    }
}
