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

namespace B3D_WPF.CanvasViewDir
{
    public class CanvasViewModel : ViewModelBase, ICanvasViewModel
    {
        public CompositeCollection CanvasObjects { get; set; }

        public CanvasView CV { get; set; }

        public CanvasViewModel(ICanvasView view, StructureMap.IContainer container) : base(view, container)
        {
            CV = View as CanvasView;
            CV.Loaded += CV_Loaded;
            CV.SizeChanged += CV_SizeChanged;
        }

        private void RefreshCompositeCollection()
        {
            CanvasObjects = new CompositeCollection();
        }

        private void CV_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GenerateGrid();
        }

        private void CV_Loaded(object sender, RoutedEventArgs e)
        {
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            RefreshCompositeCollection();

            var GridLines = new BindingList<Wall>();

            var width = CV.ActualWidth;
            var height = CV.ActualHeight;
            for(int x = 0; x<width; x += 20)
            {
                GridLines.Add(new Wall(new Corner(x, -height), new Corner(x, height)));
            }
            for (int y = -((int)height); y<height; y += 20)
            {
                GridLines.Add(new Wall(new Corner(-width, y), new Corner(width, y)));
            }

            CanvasObjects.Add(new CollectionContainer { Collection = GridLines });

            AddOrigin();            
        }

        private void AddOrigin()
        {
            CanvasObjects.Add(new CollectionContainer { Collection = new List<Origin> { new Origin() } });
        }
    }
}
