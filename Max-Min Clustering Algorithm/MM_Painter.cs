using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Min_Clustering_Algorithm
{
    public sealed class MM_Painter
    {
        public static void Draw(IDrawable obj)
        {
            obj.Draw();
        }

        public static Color GetRandomColor()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            return Color.FromArgb((byte)rand.Next(0, 255), 
                                  (byte)rand.Next(0, 255), 
                                  (byte)rand.Next(0, 255));
        }
    }
}
