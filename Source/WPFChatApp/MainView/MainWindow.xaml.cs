using System.Windows;
using WPFChatApp.Core;

namespace WPFChatApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ApplicationViewModel ApplicationViewModel => new ApplicationViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new WindowViewModel(this);
        }
    }
}
