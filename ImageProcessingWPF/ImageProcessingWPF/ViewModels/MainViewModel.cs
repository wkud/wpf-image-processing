using ImageProcessingWPF.Models;

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


        public MainViewModel()
        {
            _kernelBarViewModel = new KernelBarViewModel(_filterHandler);
            _thresholdingParametersViewModel = new ThresholdingParametersViewModel(_filterHandler);

            _imageSaver = new ImageSaver(_filterHandler); 
        }
    }
}
