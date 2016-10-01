using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace B3D_WPF.Models.Bases
{
    public interface IPoint
    {
        double X { get; set; }
        double Y { get; set; }
        Brush FillBrush { get; set; }
        Brush StrokeBrush { get; set; }
        double StrokeThickness { get; set; }
        double Height { get; set; }
        double Width { get; set; }
        Ellipse RepEllipse { get; set; }
    }

    public class PointBase : IPoint
    {
        public Ellipse RepEllipse { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public Brush FillBrush { get; set; }
        public Brush StrokeBrush { get; set; }
        public double StrokeThickness { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
