using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3D_WPF.Models.BasicGeometry
{
    public static class GeomCalculator
    {
        public static double DistanceFrom(this Corner A, Corner B)
        {
            return Math.Sqrt(Math.Pow((A.X - B.X), 2) + Math.Pow((A.Y - B.Y), 2));
        }

    }
}
