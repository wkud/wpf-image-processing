using ImageProcessingWPF.Models.FilterParameters;
using ImageProcessingWPF.Models.Interfaces;
using ImageProcessingWPF.ViewModels.Commands;
using ImageProcessingWPF.Views;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels
{
    class KernelDialogViewModel
    {
        public KernelViewModel KernelViewModel { get; private set; }

        public ICommand SaveKernelCommand => new SaveKernelCommand(KernelViewModel.Kernel);
        public ICommand LoadKernelCommand => new LoadKernelCommand(KernelViewModel);
        public ICommand ApplyChangesAndCloseWindowCommand => new ApplyChangesAndCloseWindowCommand(_parametersContainer, _dialogWindow, KernelViewModel);

        private IFilterParametersContainer _parametersContainer;
        private KernelDialogWindow _dialogWindow;
        private MainWindow _parentWindow;
        public KernelDialogViewModel(MainWindow parentWindow, IFilterParametersContainer parametersContainer)
        {
            _parametersContainer = parametersContainer;
            _parentWindow = parentWindow;
        }

        public void ShowWindow()
        {
            KernelViewModel = new KernelViewModel(_parametersContainer.Parameters as Kernel);

            _dialogWindow = new KernelDialogWindow();
            _dialogWindow.DataContext = this;
            _dialogWindow.Owner = _parentWindow;
            _dialogWindow.ShowDialog();
        }
    }
}
