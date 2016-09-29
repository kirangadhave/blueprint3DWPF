using IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using System.Windows;
using System.ComponentModel;
using B3D_WPF.Models.BasicGeometry;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;

namespace B3D_WPF.CanvasViewDir
{
    public class CanvasViewModel : ViewModelBase, ICanvasViewModel
    {
        public CanvasView CV { get; set; }
        public Canvas Canvas { get; set; }
        public bool AddingWall { get; set; }
        public Corner LastNode { get; set; }
        public double SnapTolerance { get; set; }
        public Point LastMousePosition { get; set; }
        #region Canvas Objects
        public List<GridLine> Grids { get; set; }
        public Origin Origin { get; set; }
        public List<Corner> Corners { get; set; }
        public List<Wall> Walls { get; set; }
        #endregion

        public CanvasViewModel(ICanvasView view, StructureMap.IContainer container) : base(view, container)
        {
            CV = View as CanvasView;
            CV.Loaded += CV_Loaded;
            CV.SizeChanged += CV_SizeChanged;
            ShapeGen.Can = CV.TheCanvas;
            SnapTolerance = 10;
        }

        #region EventTriggers
        private void CV_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Generate();
        }

        private void CV_Loaded(object sender, RoutedEventArgs e)
        {
            Generate();
        }

        public void Generate()
        {
            GenerateGrid();
            AddOrigin();
            GenerateCorners();
            GenerateWalls();
        }

        public void CanvasMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Corners == null)
                Corners = new List<Corner>();

            if (Walls == null)
                Walls = new List<Wall>();

            var mousePosition = e.MouseDevice.GetPosition(ShapeGen.Can);
            LastMousePosition = mousePosition;

            var cor = new Corner(mousePosition.X, mousePosition.Y)
            {
                FillBrush = Brushes.Black,
                Height = 10,
                Width = 10,
                StrokeBrush = Brushes.White,
                StrokeThickness = 1
            };


            Corners.ForEach(x =>
            {
                if(cor.DistanceFrom(x) <= SnapTolerance)
                {
                    cor = x;
                }
            });
            Corners.Add(cor);
            cor.DrawPoint();

            if (AddingWall && LastNode!=null)
            {
                var wall = new Wall(LastNode, cor);
                Walls.Add(wall);
                wall.StrokeBrush = Brushes.Black;
                wall.DrawLine();
            }

            LastNode = cor;
            AddingWall = true;
        }
        #endregion

        private void GenerateGrid()
        {
            ShapeGen.Can.Children.Clear();
            Grids = new List<GridLine>();
            var width = CV.ActualWidth;
            var height = CV.ActualHeight;

            for (int x = 0; x<width; x += 20)
            {
                Grids.Add(new GridLine(new Corner(x, 0), new Corner(x, height)));
            }

            for (int y = 0; y<height; y += 20)
            {
                Grids.Add(new GridLine(new Corner(0, y), new Corner(width, y)));
            }

            Grids.ForEach(x =>
            {
                x.StrokeBrush = Brushes.Gray;
                x.DrawLine();
            });
        }

        private void AddOrigin()
        {
            Origin = new Origin
            {
                FillBrush = Brushes.Black,
                StrokeBrush = Brushes.White,
                Height = 25,
                Width = 25,
                StrokeThickness = 1
            };
            Origin.DrawPoint();
        }

        private void GenerateWalls()
        {
            if (Walls != null)
                Walls.ForEach(x => { x.DrawLine(); });
        }

        private void GenerateCorners()
        {
            if(Corners!=null)
                Corners.ForEach(x => {
                    x.DrawPoint();
                });
        }
    }
}
