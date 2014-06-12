using System.Windows;

namespace ConsoleHost.View
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();

            DataContext = new ShellViewModel();
        }
    }
}
