using ImageProcessingWPF.Models;
using ImageProcessingWPF.Views;

namespace ImageProcessingWPF.ViewModels
{
    class MainViewModel
    {
        public ImageLoader ImageLoader { get; private set; }
        public FilterHandler FilterHandler { get; private set; }
        public ImageSaver ImageSaver { get; private set; }

        public KernelBarViewModel KernelBarViewModel { get; private set; }
        public ThresholdingParametersViewModel ThresholdingParametersViewModel { get; private set; }

        public MainViewModel(MainWindow mainWindow)
        {
            ImageLoader = new ImageLoader();
            FilterHandler = new FilterHandler(ImageLoader);
            ImageSaver = new ImageSaver(FilterHandler);

            KernelBarViewModel = new KernelBarViewModel(FilterHandler, mainWindow);
            ThresholdingParametersViewModel = new ThresholdingParametersViewModel(FilterHandler);
        }
    }
}
