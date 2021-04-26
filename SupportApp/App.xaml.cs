using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SupportApp.ViewModels;

namespace SupportApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var view = new MainWindow();
            var vm = new MainWindowViewModel();
            view.DataContext = vm;
            Application.Current.MainWindow = view;
            view.Show();
        }
    }
}
