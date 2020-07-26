using ImageProcessingWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageProcessingWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy FilterView.xaml
    /// </summary>
    public partial class KernelBarView : UserControl
    {
        public KernelBarView()
        {
            InitializeComponent();
            DataContext = new KernelBarViewModel(this);
        }
    }
}
