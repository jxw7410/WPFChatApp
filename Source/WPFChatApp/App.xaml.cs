using System.Windows;
using WPFChatApp.Core;

namespace WPFChatApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// Custom start up; normally empty and relies on start up URI
    /// Load the IOC
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IoC.SetUp();

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}
