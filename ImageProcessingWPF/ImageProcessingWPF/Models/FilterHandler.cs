using System;
using System.Windows.Media.Imaging;

namespace ImageProcessingWPF.Models
{
    class FilterHandler : IImageProcessor
    {
        private BitmapImage _resultImage;
        public event Action ResultImageUpdated;
        public BitmapImage ResultImage => _resultImage;

    }
}
