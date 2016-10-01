using B3D_WPF.Models.BasicGeometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace B3D_WPF.Models.Bases
{
    public interface ILine
    {
        PointBase End { get; set; }
        PointBase Start { get; set; }
        int Thickness { get; set; }
        Brush StrokeBrush { get; set; }
        Line RepLine { get; set; }
    }

    public class LineBase:ILine
    {
        public Line RepLine  { get; set; }
        public PointBase Start { get; set; }
        public PointBase End { get; set; }
        public int Thickness { get; set; }
        public Brush StrokeBrush { get; set; }
    }
}
