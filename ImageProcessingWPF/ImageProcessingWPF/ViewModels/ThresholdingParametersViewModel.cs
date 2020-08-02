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
        private IValidator<double> _deviationValidator = new IsPercentValidator();
        private IValidator<int> _meanAreaSizeValidator = new IsEqualOrGreaterValidator(2);

        private double _maxDeviation = 0.15;
        public string MaxDeviation
        {
            get { return _maxDeviation.ToString(CultureInfo.InvariantCulture); }
            set
            {
                _maxDeviation = value.ParseAndValidate(_maxDeviation, _deviationValidator);
                _parameters.MaxDeviation = _maxDeviation;
                _parametersContainer.Parameters = _parameters;
            }
        }

        private int _meanAreaSize = 200;
        public string MeanAreaSize
        {
            get { return _meanAreaSize.ToString(); }
            set
            {
                _meanAreaSize = value.ParseAndValidate(_meanAreaSize, _meanAreaSizeValidator);
                _parameters.MeanAreaSize = _meanAreaSize;
                _parametersContainer.Parameters = _parameters;
            }
        }

        private IFilterParametersContainer _parametersContainer;
        private ThresholdingParameters _parameters = new ThresholdingParameters();
        public ThresholdingParametersViewModel(FilterHandler filterHandler) : base(filterHandler, FilterType.AdaptiveThresholding)
        {
            _parametersContainer = filterHandler;

            _parameters.MeanAreaSize = _meanAreaSize;
            _parameters.MaxDeviation = _maxDeviation;
            _parametersContainer.Parameters = _parameters;
        }
    }
}
