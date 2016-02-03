using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means_Clustering_Algorithm
{
    public sealed class Painter
    {

        public static void Draw(IDrawable obj, Object surface)
        {
            obj.Draw(surface);
        }
    }
}
