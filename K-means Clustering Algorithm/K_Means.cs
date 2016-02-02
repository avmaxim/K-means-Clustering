using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means_Clustering_Algorithm
{
    public sealed class K_Means: IDrawable
    {
        private readonly List<Point> points;
        private readonly UInt32 pointsCount;
        private readonly UInt32 clustersCount;

        public K_Means()
        {
            pointsCount = 0;
            clustersCount = 0;
        }

        public K_Means(UInt32 pointsCount, UInt32 clustersCount) 
        {
            this.clustersCount = clustersCount;
            this.pointsCount = pointsCount;
        }

        public void Randomize()
        {
            for (var i = 0; i < pointsCount; i++)
            {
                Random rand = new Random();
                points.Add(new Point(rand.Next(0, 753), rand.Next(0, 523)));
            }
        }

        public void Draw()
        {
            //throw new NotImplementedException();
        }
    }
}
