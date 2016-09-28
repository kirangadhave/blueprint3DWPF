using IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using B3D_WPF.CanvasViewDir;

namespace B3D_WPF.MainViewDir
{
    class MainViewModel : ViewModelBase, IMainViewModel
    {
        public IView Canvas { get; set; }

        public MainViewModel(IMainView view, IContainer container) : base(view, container)
        {
            Canvas = container.GetInstance<ICanvasViewModel>().View;
        }
    }
}
