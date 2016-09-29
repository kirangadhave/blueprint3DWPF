using B3D_WPF.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace B3D_WPF.Models.BasicGeometry
{
    public static class ShapeGen
    {
        public static Canvas Can { get; set; }

        public static bool DrawPoint(this IPoint p)
        {
            var point = new Point(p.X, p.Y);
            try
            {
                var ell = new Ellipse
                {
                    Fill = p.FillBrush,
                    Stroke = p.StrokeBrush,
                    StrokeThickness = p.StrokeThickness,
                    Width = p.Width,
                    Height = p.Height
                };

                if(p.GetType() == typeof(Corner))
                {
                    ell.MouseEnter += Ell_MouseEnter;
                    ell.MouseLeave += Ell_MouseLeave;
                }

                Canvas.SetLeft(ell, point.X - ell.Width / 2);
                Canvas.SetTop(ell, point.Y - ell.Height / 2);
                Can.Children.Add(ell);
            }
            catch(Exception) { return false; }
            return true;
        }

        public static bool DrawLine(this ILine l)
        {
            try
            {
                var line = new Line
                {
                    X1 = l.Start.X,
                    Y1 = l.Start.Y,
                    X2 = l.End.X,
                    Y2 = l.End.Y,
                    StrokeThickness = l.Thickness,
                    Stroke = l.StrokeBrush
                };
                Can.Children.Add(line);
            }
            catch (Exception) { return false; }
            return true;
        }

        #region Event Handlers
        private static void Ell_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var ell = sender as Ellipse;
            ell.Stroke = Brushes.White;
        }
        private static void Ell_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var ell = sender as Ellipse;
            ell.Stroke = Brushes.Red;
        }
        #endregion
    }
}
