﻿using ImageProcessingWPF.Models.FilterParameters;
using ImageProcessingWPF.Models.Filters;
using ImageProcessingWPF.Models.Interfaces;
using ImageProcessingWPF.Utility;
using ImageProcessingWPF.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ImageProcessingWPF.Models
{
    public enum FilterType
    {
        GaussianBlur,
        AdaptiveThresholding
    }

    class FilterHandler : Observable<FilterType>, INotifyPropertyChanged, IImageProcessor, IFilterParametersContainer
    {
        private BitmapImage _resultImage;
        public BitmapImage ResultImage
        {
            get { return _resultImage; }
            set
            {
                _resultImage = value;
                ResultImageUpdated.Invoke();
                PropertyChanged.Notify(this, "ResultImage");
            }
        }
        public event Action ResultImageUpdated;
        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable<FilterType> FilterTypes => Enum.GetValues(typeof(FilterType)).Cast<FilterType>();
        public ICommand ExecuteFilterCommand => new ExecuteFilterCommand(ExecuteFilter, _imageloader);

        public string TotalSampleCount => $"{_sampleCountPerDimension * _sampleCountPerDimension} samples";
        private int _sampleCountPerDimension = 100;
        public int SampleCountPerDimension
        {
            get { return _sampleCountPerDimension; }
            set
            {
                _sampleCountPerDimension = value;
                PropertyChanged.Notify(this, "TotalSampleCount");
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                PropertyChanged.Notify(this, "IsLoading");
            }
        }



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

        private Kernel _kernel;
        private ThresholdingParameters _thresholdingParameters;
        public IFilterParameters Parameters
        {
            get
            {
                if (SelectedFilterType == FilterType.GaussianBlur)
                    return _kernel;
                else
                    return _thresholdingParameters;
            }
            set
            {
                if (value is Kernel)
                    _kernel = value as Kernel;
                else if (value is ThresholdingParameters)
                    _thresholdingParameters = value as ThresholdingParameters;
            }
        }

        private IImageLoader _imageloader;
        public FilterHandler(IImageLoader imageLoader)
        {
            _imageloader = imageLoader;
            _imageloader.ImageLoaded += () =>
            {
                PropertyChanged.Notify(this, "ExecuteFilterCommand");
                ResultImage = null;
            };
        }

        public void ExecuteFilter()
        {
            IFilter filter = CreateFilter();
            if (Parameters is null)
                Parameters = CreateDefaultParameters();

            ResultImage = null;

            IsLoading = true;
            var inputImage = _imageloader.LoadedImage.ToBitmap();
            var samplingScale = (int)Math.Ceiling(Math.Max(inputImage.Width, inputImage.Height) * 1.0 / SampleCountPerDimension);
            Task.Run(() =>
            {
                ResultImage = filter.Execute(Parameters, inputImage.ScaleDown(samplingScale))
                    .ScaleUp(samplingScale)
                    .ToBitmapImage(ImageFormat.Jpeg);
                IsLoading = false;
            });
        }

        private IFilter CreateFilter()
        {
            if (_selectedFilterType == FilterType.GaussianBlur)
                return new GaussianBlur();
            else
                return new AdaptiveThresholding();
        }

        private IFilterParameters CreateDefaultParameters()
        {
            if (_selectedFilterType == FilterType.GaussianBlur)
                return new Kernel(3, 3);
            else
                return new ThresholdingParameters();
        }
    }
}
