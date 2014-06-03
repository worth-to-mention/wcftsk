using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AdventureWorksClient.Mapping;
using AutoMapper;

namespace AdventureWorksClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {

        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MappingConfig.Init();
        }

        private void Application_Activated(object sender, EventArgs e)
        {

        }

        private void Application_Deactivated(object sender, EventArgs e)
        {

        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {

        }
    }
}
