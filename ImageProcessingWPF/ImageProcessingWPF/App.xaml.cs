using ImageProcessingWPF.Views;
using System.Windows;

namespace ImageProcessingWPF
{
    /// <summary>
    /// Interaction logic for class App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = new MainWindow();
            window.Show();

            base.OnStartup(e);
        }
    }
}
