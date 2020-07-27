using ImageProcessingWPF.Models.Interfaces;
using System;
using System.Windows.Media.Imaging;

namespace ImageProcessingWPF.Models
{
    public enum FilterType
    {
        None,
        GaussianBlur,
        AdaptiveThresholding
    }

    class FilterHandler : IImageProcessor
    {
        private BitmapImage _resultImage;
        public BitmapImage ResultImage => _resultImage;
        public event Action ResultImageUpdated;

        private FilterType _filterType;
        public FilterType FilterType
        {
            get { return _filterType; }
            set { _filterType = value; }
        }
    }
}
