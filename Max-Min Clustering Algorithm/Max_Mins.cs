using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Max_Min_Clustering_Algorithm
{
    public class CPoint
    {
        public CPoint(Int32 x, Int32 y)
        {
            this.X = x;
            this.Y = y;
            this.Color = Color.Black;
        }

        public CPoint(Int32 x, Int32 y, Color color)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
        }

        public CPoint(CPoint point, Color color)
        {
            this.X = point.X;
            this.Y = point.Y;
            this.Color = color;
        }

        public Color Color { get; set; }
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
    }


    public sealed class Max_Mins : IDrawable
    {
        private List<CPoint> points;
        private List<CPoint> centroids;
        private readonly Int32 pointsCount;
        private Graphics graphics;
        private List<Cluster> clusters;
        public Max_Mins()
        {
            pointsCount = 0;
            points = new List<CPoint>();
            centroids = new List<CPoint>();
        }

        public Max_Mins(Int32 pointsCount) : this()
        {
            this.pointsCount = pointsCount;
            clusters = new List<Cluster>(pointsCount);
        }

        public void SetGraphics(Graphics graphics)
        {
            this.graphics = graphics;
            graphics.Clear(Color.White);
        }

        public void Randomize()
        {
            Random rand = new Random();
            for (var i = 0; i < pointsCount; i++)
                points.Add(new CPoint(rand.Next(10, 947 - 10), rand.Next(10, 618 - 10)));
        }

        public void Start()
        {
            // Input: 
            //      {Point1, Point2, ... , PointN} - dataset of given points(vectors) {x1, x2, ... , xN}
            // Output: 
            //      {Centroid1, Centroid2, ... , CentroidK} - dataset of new cluster centroids {jm1, jm2, ... , jmK}
            //
            // Implementation:
            //      {Centroid1, Centroid2, ... , CentroidK} <-- SelectRandomSeeds({Point1, Point2, ... , PointN}, K)

            // Step 1 - Find 1st Centroid
            CPoint centroid = MM_Math.RandomPoint(points);      
            centroids.Add(centroid);
            clusters.Add(new Cluster(centroid, MM_Painter.GetRandomColor()));

            // Step 2 - Find 2nd Centroid
            Int32 l = MM_Math.ArgMaxFromSquaredEuclideanDistances(centroid, points);
            centroid = points[l];   
            centroids.Add(centroid);
            clusters.Add(new Cluster(centroid, MM_Painter.GetRandomColor()));
            
            Boolean isConditionOk = false;
            
            do
            {
               
                // Step 3 - Points Distribution upon Clusters by Finding Closest Centroid 
                for (Int32 n = 0; n < pointsCount; n++)
                {
                    if (!centroids.Contains(points[n]))
                    {
                        Int32 j = MM_Math.ArgMinFromSquaredEuclideanDistances(points[n], centroids);
                        clusters[j].AddPoint(points[n]); // Wj = Wj U {Xn} 
                    }
                }

                ///////////  Find Max distance(Centroid, Points) in every Cluster 
                // Step 4  - and 
                ///////////  Combine all max distances into Dictionary

                int max = -1;
                int argmax = -1;

                for (int i = 0; i < clusters.Count; i++)
                {
                    KeyValuePair<int, int> kvPair = MM_Math.MaxAndArgMaxComboFromSquaredEuclideanDistances(clusters[i].GetCentroid(), clusters[i], points);
                    if (kvPair.Key != -1)
                    {
                        if (kvPair.Value > max)
                        {
                            max = kvPair.Value;
                            argmax = kvPair.Key;
                        }
                    }
                }

                //Step 5 - Find 3rd Centroid  
                Int32 p = argmax;
                isConditionOk = Math.Sqrt(max) > (MM_Math.MeanOutOfDistancesBetweenPonts(centroids)/2);
                if (isConditionOk)
                {
                    centroid = points[p];               
                    centroids.Add(centroid);
                    clusters.Add(new Cluster(centroid, MM_Painter.GetRandomColor()));
                    
                    // Step 6 - Empty points in N clusters
                    for (int i = 0; i < clusters.Count; i++)
                        clusters[i].RemovePoints();
                }

            } while (isConditionOk);
        }

        public List<Cluster> GetClusters()
        {
            return clusters;
        }

        public void Draw()
        {
            graphics.Clear(Color.White);
            if (clusters.Count == 0)
            {
                foreach (var point in points)
                    graphics.FillRectangle(new SolidBrush(Color.Black), point.X, point.Y, 4, 4);
            }
            else
            {
                foreach (var cluster in clusters)
                {
                    SolidBrush sb = new SolidBrush(cluster.DefaultColor);
                    Pen p = new Pen(Color.Black);

                    foreach(var point in cluster)
                        graphics.FillRectangle(sb, point.X, point.Y, 4, 4);

                    CPoint centroid = cluster.GetCentroid();

                    
                    graphics.FillEllipse(sb, new Rectangle((int)centroid.X - 8, (int)centroid.Y + 8, 16, 16));
                    graphics.DrawEllipse(p, new Rectangle((int)centroid.X - 8, (int)centroid.Y + 8, 16, 16));
                    
                }
            }
        }


    }
}
