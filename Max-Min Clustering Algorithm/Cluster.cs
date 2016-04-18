using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Min_Clustering_Algorithm
{
    public class Cluster : IDrawable, IEnumerable<CPoint>
    {
        private List<CPoint> points;
        private Color defaultColor;
        private CPoint centroid;

        public Color DefaultColor
        {
            get { return defaultColor; }
            set { defaultColor = value; }
        }

        public Cluster()
        {
            points = new List<CPoint>(); 
            centroid = null;
            defaultColor = Color.Black;
        }

        public Cluster(CPoint centroid, Color color)
        {
            this.centroid = centroid;
            defaultColor = color;
            points = new List<CPoint>(); 
        }

        public CPoint GetPoint(int i)
        {
            return points[i];
        }

        public void SetPoint(int i, CPoint value)
        {
            points[i] = value;
        }

        public void RemovePoints()
        {
            points = new List<CPoint>(); 
        }

        public Int32 GetPointsCount()
        {
            return points.Count;
        }

        public void SetPoints(List<CPoint> points)
        {
            this.points = points;
        }

        public void AddPoint(CPoint point)
        {
            points.Add(point);    
        }

        public void SetCentroid(CPoint centroid)
        {
            this.centroid = centroid;
        }

        public CPoint GetCentroid()
        {
            return centroid;
        }
        
        public List<CPoint> GetPointAsList()
        {
            return points;
        }

        public void Draw()
        {
            
        }

        public IEnumerator<CPoint> GetEnumerator()
        {
            return points.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
