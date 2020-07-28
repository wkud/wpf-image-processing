using ImageProcessingWPF.Models;
using ImageProcessingWPF.ViewModels.Commands;
using ImageProcessingWPF.Views;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels
{
    class KernelBarViewModel : ParametersViewModelBase
    {
        public ICommand ManageKernelCommand => new ManageKernelCommand(this);

        private MainWindow _mainWindow;
        private KernelDialogViewModel _kernelDialogViewModel;
        public KernelBarViewModel(FilterHandler filterHandler, MainWindow mainWindow) : base(filterHandler, FilterType.GaussianBlur)
        {
            _mainWindow = mainWindow;
        }

        public void OpenKernelWindowDialog()
        {
            _kernelDialogViewModel = new KernelDialogViewModel(_mainWindow);
        }
    }
}
