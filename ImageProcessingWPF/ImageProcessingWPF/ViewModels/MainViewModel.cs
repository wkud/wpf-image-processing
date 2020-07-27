using ImageProcessingWPF.Models;
using ImageProcessingWPF.Views;
using System.Windows.Controls;

namespace ImageProcessingWPF.ViewModels
{
    class MainViewModel
    {
        private ImageLoader _imageLoader = new ImageLoader();
        public ImageLoader ImageLoader => _imageLoader; 
        
        private FilterHandler _filterHandler = new FilterHandler();
        public FilterHandler FilterHandler => _filterHandler;

        private ImageSaver _imageSaver;
        public ImageSaver ImageSaver => _imageSaver;


        KernelBarViewModel _kernelBarViewModel;
        ThresholdingParametersViewModel _thresholdingParametersView;

        private MainWindow _window;
        public MainViewModel(MainWindow window)
        {
            _window = window;

            _kernelBarViewModel = GetViewModel<KernelBarViewModel, KernelBarView>("KernelBarView");
            _thresholdingParametersView = GetViewModel<ThresholdingParametersViewModel, ThresholdingParametersView>("ThresholdingParametersView");

            _imageSaver = new ImageSaver(_imageLoader); //TODO swap back to _filterHandler after testing
        }

        private TViewModel GetViewModel<TViewModel, TView>(string viewControlNameInMainWindow) where TViewModel : class where TView : UserControl
        {
            var view = _window.FindName(viewControlNameInMainWindow) as TView;
            return view.DataContext as TViewModel;
        }

    }
}
