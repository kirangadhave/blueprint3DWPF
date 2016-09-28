using B3D_WPF.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3D_WPF.Models.BasicGeometry
{
    public class Origin : PointBase, IPoint
    {
        public Origin()
        {
            X = 0;
            Y = 0;
        }
    }
}
