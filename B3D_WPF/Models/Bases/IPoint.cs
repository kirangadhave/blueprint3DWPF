using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3D_WPF.Models.Bases
{
    public interface IPoint
    {
        double X { get; set; }
        double Y { get; set; }
    }

    public class PointBase : IPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
