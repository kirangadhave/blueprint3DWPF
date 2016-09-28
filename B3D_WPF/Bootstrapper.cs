using B3D_WPF.CanvasViewDir;
using B3D_WPF.MainViewDir;
using B3D_WPF.MainWindowDir;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace B3D_WPF
{
    public static class Bootstrapper
    {
        public static Container Container { get; set; }
        
        public static bool Initialise(IContainer container)
        {
            try
            {
                Container = (Container)container;

                Container.Configure(x =>
                {
                    x.For<IMainWindow>().Use<MainWindow>();
                    x.For<IMainWindowViewModel>().Use<MainWindowViewModel>();

                    x.For<IMainView>().Use<MainView>();
                    x.For<IMainViewModel>().Use<MainViewModel>();

                    x.For<ICanvasViewModel>().Use<CanvasViewModel>();
                    x.For<ICanvasView>().Use<CanvasView>();
                });


            }catch(Exception ex) { MessageBox.Show($"Error Starting Application: {ex.ToString()}"); }
            return true;
        }

    }
}
