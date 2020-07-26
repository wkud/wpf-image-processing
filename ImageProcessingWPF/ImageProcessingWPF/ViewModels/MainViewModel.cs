using ImageProcessingWPF.Models;
using ImageProcessingWPF.Views;
using System.Windows.Controls;

namespace ImageProcessingWPF.ViewModels
{
    class MainViewModel
    {
        private ImageLoader _imageLoader = new ImageLoader();
        public ImageLoader ImageLoader => _imageLoader;


        KernelBarViewModel _kernelBarViewModel;
        ThresholdingParametersViewModel _thresholdingParametersView;

        private MainWindow _window;
        public MainViewModel(MainWindow window)
        {
            _window = window;

            _kernelBarViewModel = GetViewModel<KernelBarViewModel, KernelBarView>("KernelBarView");
            _thresholdingParametersView = GetViewModel<ThresholdingParametersViewModel, ThresholdingParametersView>("ThresholdingParametersView");
        }

        private TViewModel GetViewModel<TViewModel, TView>(string viewControlNameInMainWindow) where TViewModel : class where TView : UserControl
        {
            var view = _window.FindName(viewControlNameInMainWindow) as TView;
            return view.DataContext as TViewModel;
        }

    }
}
