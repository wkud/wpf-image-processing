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
        public ICommand ApplyChangesAndCloseWindowCommand => new ApplyChangesAndCloseWindowCommand(_parametersContainer, _dialogWindow, KernelViewModel.Kernel);

        private IFilterParametersContainer _parametersContainer;
        private KernelDialogWindow _dialogWindow;
        public KernelDialogViewModel(MainWindow parentView, IFilterParametersContainer parametersContainer)
        {
            _parametersContainer = parametersContainer;

            _dialogWindow= new KernelDialogWindow();
            _dialogWindow.DataContext = this;
            _dialogWindow.Owner = parentView;

            KernelViewModel = new KernelViewModel();
            _dialogWindow.ShowDialog();
        }

    }
}
