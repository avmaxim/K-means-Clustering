using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_means_Clustering_Algorithm
{
 
    public class Centroid
    {
        public Centroid(Int32 x, Int32 y, Color color)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
        }

        public Color Color { get; set; }

        public Int32 X { get; set; }
        public Int32 Y { get; set; }

        public static bool AreEqualCentroids(List<Centroid> centroids1, List<Centroid> centroids2)
        {
            if (centroids1.Count != centroids2.Count) return false;

            Boolean isFoundTheSame;

            foreach (var newCentroid in centroids2)
            {
                isFoundTheSame = false;
                foreach(var centroid in centroids1)
                    if ((centroid.X >= newCentroid.X - 1 && centroid.X <= newCentroid.X + 1) &&
                        (centroid.Y >= newCentroid.Y - 1 && centroid.Y <= newCentroid.Y + 1))
                        isFoundTheSame = true;
                if (!isFoundTheSame)
                    return false;
            }

            return true;
        }
    }
    
    public sealed class K_Means: IDrawable
    {
        private List<Point> points;
        private List<Centroid> centroids;
        private readonly Int32 pointsCount;
        private readonly Int32 clustersCount;
        private List<Point>[] clusters;
        private Graphics graphics;
        private Int32 threadsCount;

        public K_Means()
        {
            pointsCount = 0;
            clustersCount = 0;
            threadsCount = 0;
            points = new List<Point>();
            centroids = new List<Centroid>();
            clusters = new List<Point>[clustersCount];
        }

        public K_Means(Int32 pointsCount, Int32 clustersCount) : this()
        {
            this.clustersCount = clustersCount;
            this.pointsCount = pointsCount;
            clusters = new List<Point>[clustersCount];
            for(int k = 0; k < clustersCount; k++)
                clusters[k] = new List<Point>();
        }

        public void SetGraphics(Graphics graphics)
        {
            this.graphics = graphics;
            graphics.Clear(Color.White);
        }

        public void Randomize()
        {
            if (clustersCount >= pointsCount) throw new Exception("The number of points must be bigger then the number of clusters!");

            Random rand = new Random();
            for (var i = 0; i < pointsCount; i++)
                points.Add(new Point(rand.Next(10, 947-10), rand.Next(10, 618-10)));

            
            //let the centoids be the 1st clustersCount points as they are random all the same
            for (var i = 0; i < clustersCount; i++)
                centroids.Add(new Centroid(points[i].X + 1, points[i].Y + 1, Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255))));
        }

        public void Start(Boolean needVisualEterations, ref Int32 numberofIterations)
        {
            // Input: 
            //      K = clustersCount - number of clusters
            //      {Point1, Point2, ... , PointN} - dataset of given points(vectors) {x1, x2, ... , xN}
            // Output: 
            //      {Centroid1, Centroid2, ... , CentroidK} - dataset of new cluster centroids {jm1, jm2, ... , jmK}
            //
            // Implementation:
            //      {Centroid1, Centroid2, ... , CentroidK} <-- SelectRandomSeeds({Point1, Point2, ... , PointN}, K)

            List<Centroid> prevCentroids;
            
            do
            {
                numberofIterations++;
                prevCentroids = new List<Centroid>(centroids);

                // Step 1 - Clear Clusters
                for (Int32 k = 0; k < clustersCount; k++)
                    clusters[k].Clear();

                // Step 2 - Find Closest Centroid
                for (Int32 n = 0; n < pointsCount; n++)
                {
                    var point = points[n];
                    Int32 j = K_Math.ArgMin(K_Math.SquaredEuclideanDistances(point, centroids));
                    clusters[j].Add(points[n]); // Wj = Wj U {Xn} 
                }

                if (needVisualEterations)
                {
                    graphics.Clear(Color.White);
                    DrawClusters();
                }
                

                //Step 3 - Update Centroids
                for (Int32 k = 0; k < clustersCount; k++)
                {
                    //            1       
                    // jm[k] = -------- * ESum(X), where X C W[k];
                    //         | W[k] |   

                    Point sum = new Point(0, 0);
                    foreach (var point in clusters[k])
                    {
                        sum.X += point.X;
                        sum.Y += point.Y;
                    }
                    Int32 newX = sum.X /= clusters[k].Count;
                    Int32 newY = sum.Y /= clusters[k].Count;

                    centroids[k] = new Centroid(newX, newY, centroids[k].Color);
                }
                if (needVisualEterations)
                {
                    DrawCentroids();
                    Thread.Sleep(100);
                }
            } while (!Centroid.AreEqualCentroids(prevCentroids, centroids));

            if (!needVisualEterations)
            {
                graphics.Clear(Color.White);
                DrawClusters();
            }
            Thread.Sleep(1000);
        }

        public void DrawCentroids()
        {
            var drawingPen = new Pen(Brushes.Black, 3);
            foreach (var centroid in centroids)
            {
                graphics.DrawEllipse(drawingPen, new Rectangle((int)centroid.X - 8, (int)centroid.Y + 8, 16, 16));
                graphics.FillEllipse(new SolidBrush(centroid.Color), new Rectangle((int)centroid.X - 8, (int)centroid.Y + 8, 16, 16));
            }
        }

        public void DrawClusters()
        {
            List<Point>[] local_clusters = clusters;

            for(int k = 0; k < clustersCount; k++)
                foreach (var point in local_clusters[k])
                {
                    graphics.FillRectangle(new SolidBrush(centroids[k].Color), point.X, point.Y, 4, 4);
                }

            DrawCentroids();
        }

        public void Draw(Object obj)
        {
            foreach (var point in points)
                graphics.FillRectangle(new SolidBrush(Color.Black), point.X, point.Y, 4, 4);
            
            DrawCentroids();
        }

        private Centroid GetMeanCentroid(List<Point> points)
        {
            Int32 X_mean = 0;
            Int32 Y_mean = 0;

            foreach (Point point in points)
            {
                X_mean += point.X;
                Y_mean += point.Y;
            }

            X_mean /= points.Count;
            Y_mean /= points.Count;
            return new Centroid(X_mean, Y_mean, Color.Green);
        }

    }
}
