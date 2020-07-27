using ImageProcessingWPF.Models;

namespace ImageProcessingWPF.ViewModels
{
    class KernelBarViewModel : ParametersViewModelBase
    {
        public KernelBarViewModel(FilterHandler filterHandler) : base(filterHandler, FilterType.GaussianBlur)
        {

        }
    }
}
