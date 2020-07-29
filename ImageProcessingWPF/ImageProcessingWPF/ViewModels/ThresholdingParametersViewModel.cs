using ImageProcessingWPF.Models;
using ImageProcessingWPF.Models.FilterParameters;
using ImageProcessingWPF.Models.Interfaces;
using ImageProcessingWPF.Utility;
using ImageProcessingWPF.Utility.Validators;
using System.Globalization;

namespace ImageProcessingWPF.ViewModels
{
    class ThresholdingParametersViewModel : ParametersViewModelBase
    {
        private IValidator<double> _percentValidator = new IsPercentValidator();
        private IValidator<int> _rangeValidator = new IsWithinRangeValidator(2, 20);

        private double _maxDeviation;
        public string MaxDeviation
        {
            get { return _maxDeviation.ToString(CultureInfo.InvariantCulture); }
            set
            {
                _maxDeviation = value.ParseAndValidate(_maxDeviation, _percentValidator);
                _parameters.MaxDeviation = _maxDeviation;
                _parametersContainer.SetFilterParameters(_parameters);
            }
        }

        private int _meanAreaSize;
        public string MeanAreaSize
        {
            get { return _meanAreaSize.ToString(); }
            set
            {
                _meanAreaSize = value.ParseAndValidate(_meanAreaSize, _rangeValidator);
                _parameters.MeanAreaSize = _meanAreaSize;
                _parametersContainer.SetFilterParameters(_parameters);
            }
        }

        private IFilterParametersContainer _parametersContainer;
        private ThresholdingParameters _parameters = new ThresholdingParameters();
        public ThresholdingParametersViewModel(FilterHandler filterHandler) : base(filterHandler, FilterType.AdaptiveThresholding)
        {
            _parametersContainer = filterHandler;
        }
    }
}
