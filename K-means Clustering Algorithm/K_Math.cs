using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace K_means_Clustering_Algorithm
{
    public sealed class K_Math
    {

        public static int SquaredEuclideanDistance(Point point, Centroid centroid)
        {
            //(A.x - B.x)^2 + (A.y - B.y)^2
            return (point.X - centroid.X) * (point.X - centroid.X) +
                   (point.Y - centroid.Y) * (point.Y - centroid.Y) ;
        }
        

        public static Dictionary<int, int> SquaredEuclideanDistances(Point point, List<Centroid> centroids)
        {
            Dictionary<int, int> distances = new Dictionary<int, int>();
            for(int i = 0; i < centroids.Count; i++)
            {
                distances.Add(i, SquaredEuclideanDistance(point, centroids[i]));
            }
            return distances;
        }

        //Returns 'Key' for which 'Value' attains it's minimum
        public static int ArgMin(IDictionary<int, int> dic)
        {
            int min = dic[0];
            int argmin = 0; // inverse(dic[0]) == 0
            object obj = new object();

            for (int i = 1; i < dic.Count; i++)
                if (dic[i] < min)
                {
                    min = dic[i];
                    argmin = i;
                }
            //for (int i = 1; i < dic.Count; i++)
            //    ThreadPool.QueueUserWorkItem(delegate
            //    {
            //        lock (obj)
            //        {
            //            if (dic[i] < min)
            //            {
            //                min = dic[i];
            //                argmin = i;
            //            }
            //        }
            //    }, 4);
                
            return argmin;
        }
    }
}
