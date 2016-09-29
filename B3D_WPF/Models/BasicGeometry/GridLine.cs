using B3D_WPF.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3D_WPF.Models.BasicGeometry
{
    public class GridLine : LineBase, ILine
    {
        public GridLine(PointBase start, PointBase end, int thickness = 1)
        {
            Start = start;
            End = end;
            Thickness = thickness;
        }
    }
}
