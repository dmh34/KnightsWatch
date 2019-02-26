using KnightsWatch.Presentation.ViewModels;
using MahApps.Metro.Controls;

namespace KnightsWatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            //Test Purposes
            this.DataContext = new MainWindowViewModel();
            InitializeComponent();
        }

        
    }
}
