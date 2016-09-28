using B3D_WPF.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3D_WPF.Models.BasicGeometry
{
    public class Corner : PointBase, IPoint
    {
        public Corner(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
