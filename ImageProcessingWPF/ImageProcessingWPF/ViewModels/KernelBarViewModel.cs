using ImageProcessingWPF.Models;
using ImageProcessingWPF.Models.Interfaces;
using ImageProcessingWPF.ViewModels.Commands;
using ImageProcessingWPF.Views;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels
{
    class KernelBarViewModel : ParametersViewModelBase
    {
        public ICommand ManageKernelCommand => new ManageKernelCommand(OpenKernelDialogWindow);

        private IFilterParametersContainer _parametersContainer;
        private MainWindow _mainWindow;

        private KernelDialogViewModel _dialogModel;
        public KernelBarViewModel(FilterHandler filterHandler, MainWindow mainWindow) : base(filterHandler, FilterType.GaussianBlur)
        {
            _mainWindow = mainWindow;
            _parametersContainer = filterHandler;
        }

        private void OpenKernelDialogWindow()
        {
            if (_dialogModel is null)
                _dialogModel = new KernelDialogViewModel(_mainWindow, _parametersContainer);

            _dialogModel.ShowWindow();
        }
    }
}
