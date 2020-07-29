using ImageProcessingWPF.Models.Interfaces;
using ImageProcessingWPF.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ImageProcessingWPF.Models
{
    public enum FilterType
    {
        GaussianBlur,
        AdaptiveThresholding
    }

    class FilterHandler : Observable<FilterType>, IImageProcessor, IFilterParametersContainer
    {
        private BitmapImage _resultImage;
        public BitmapImage ResultImage => _resultImage;
        public event Action ResultImageUpdated;

        public IEnumerable<FilterType> FilterTypes => Enum.GetValues(typeof(FilterType)).Cast<FilterType>();


        private FilterType _selectedFilterType;
        public FilterType SelectedFilterType
        {
            get
            {
                return _selectedFilterType;
            }
            set
            {
                _selectedFilterType = value;
                NotifyAllObservers(value);
            }
        }

        private IFilterParameters _parameters;

        public void SetFilterParameters(IFilterParameters parameters)
        {
            _parameters = parameters;
        }
    }
}
