using ImageProcessingWPF.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace ImageProcessingWPF.Models
{
    public enum FilterType
    {
        GaussianBlur,
        AdaptiveThresholding
    }

    class FilterHandler : IImageProcessor
    {
        private BitmapImage _resultImage;
        public BitmapImage ResultImage => _resultImage;
        public event Action ResultImageUpdated;

        public IEnumerable<FilterType> FilterTypes => Enum.GetValues(typeof(FilterType)).Cast<FilterType>();


        private FilterType _selectedFilterType;
        public FilterType SelectedFilterType
        {
            get { return _selectedFilterType; }
            set { _selectedFilterType = value; }
        }
    }
}
