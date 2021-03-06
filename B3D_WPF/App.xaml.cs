﻿using B3D_WPF.MainWindowDir;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace B3D_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Bootstrapper.Initialise(new Container());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = (MainWindow)Bootstrapper.Container.GetInstance<IMainWindowViewModel>().Window;
            MainWindow.Show();
        }

    }
}
