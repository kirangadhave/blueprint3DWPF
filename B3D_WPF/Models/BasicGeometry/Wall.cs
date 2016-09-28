using B3D_WPF.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3D_WPF.Models.BasicGeometry
{
    public class Wall : LineBase, ILine
    {
        public Wall(Corner start, Corner end, int thickness = 2)
        {
            Start = start;
            End = end;
            Thickness = thickness;
        }
    }
}
