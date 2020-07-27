using ImageProcessingWPF.Models;

namespace ImageProcessingWPF.ViewModels
{
    class ThresholdingParametersViewModel : ParametersViewModelBase
    {
        public ThresholdingParametersViewModel(FilterHandler filterHandler) : base(filterHandler, FilterType.AdaptiveThresholding)
        {

        }
    }
}
