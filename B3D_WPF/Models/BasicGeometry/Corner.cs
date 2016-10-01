using B3D_WPF.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace B3D_WPF.Models.BasicGeometry
{
    public class Corner : PointBase, IPoint
    {
        public List<Wall> StartWalls { get; set; }
        public List<Wall> EndWalls { get; set; }
        public Ellipse RepEllipse { get; set; }

        public Corner(double x, double y)
        {
            X = x;
            Y = y;
            StartWalls = new List<Wall>();
            EndWalls = new List<Wall>();
        }
    }
}
