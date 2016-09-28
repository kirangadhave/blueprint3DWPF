using IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using B3D_WPF.MainViewDir;

namespace B3D_WPF.MainWindowDir
{
    class MainWindowViewModel : WindowViewModelBase, IMainWindowViewModel
    {
        public MainWindowViewModel(IMainWindow window, IContainer container) : base(window, container)
        {
            ShowView<IMainViewModel>();
        }
    }
}
