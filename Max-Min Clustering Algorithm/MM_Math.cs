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


        public static int ArgMinFromSquaredEuclideanDistances(CPoint point, List<CPoint> centroids)
        {
            int argmin = -1;
            int min = Int32.MaxValue;
           
            for (int i = 0; i < centroids.Count; i++)
            {
                if (!Object.ReferenceEquals(centroids[i], point))
                {
                    var distance = SquaredEuclideanDistance(point, centroids[i]);
                    if (distance < min)
                    {
                        min = distance;
                        argmin = i;
                    }
                }
                  
            }
            return argmin;
        }

        public static int ArgMaxFromSquaredEuclideanDistances(CPoint centroid, List<CPoint> points)
        {
            int argmax = -1;
            int max = -1;
            int distance;

            for (int i = 0; i < points.Count; i++)
            {
                if (!Object.ReferenceEquals(centroid, points[i]))
                {
                    distance = SquaredEuclideanDistance(centroid, points[i]);
                    if (distance > max)
                    {
                        max = distance;
                        argmax = i;
                    }
                }
            }
            return argmax;
        }

        public static KeyValuePair<int, int> MaxAndArgMaxComboFromSquaredEuclideanDistances(CPoint centroid, Cluster cluster, List<CPoint> allPoints)
        {
            int argmax = -1;
            int max = -1;
            var clusterPoints = cluster.GetPointAsList();
            for (int i = 0; i < cluster.GetPointsCount(); i++)
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
