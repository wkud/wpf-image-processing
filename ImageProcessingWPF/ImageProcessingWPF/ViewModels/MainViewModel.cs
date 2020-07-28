using ImageProcessingWPF.Models;
using ImageProcessingWPF.Views;

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


        private KernelBarViewModel _kernelBarViewModel;
        public KernelBarViewModel KernelBarViewModel => _kernelBarViewModel;

        private ThresholdingParametersViewModel _thresholdingParametersViewModel;
        public ThresholdingParametersViewModel ThresholdingParametersViewModel => _thresholdingParametersViewModel;


        public MainViewModel(MainWindow mainWindow)
        {
            _kernelBarViewModel = new KernelBarViewModel(_filterHandler, mainWindow);
            _thresholdingParametersViewModel = new ThresholdingParametersViewModel(_filterHandler);

            _imageSaver = new ImageSaver(_filterHandler); 
        }
    }
}
