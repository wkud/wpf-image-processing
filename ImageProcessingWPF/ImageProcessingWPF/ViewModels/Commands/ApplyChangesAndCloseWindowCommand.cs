using ImageProcessingWPF.Models.FilterParameters;
using ImageProcessingWPF.Models.Interfaces;
using ImageProcessingWPF.Views;
using System;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels.Commands
{
    class ApplyChangesAndCloseWindowCommand : ICommand
    {
        private IFilterParametersContainer _parametersContainer;
        private KernelDialogWindow _dialogWindow;
        private IKernelContainer _kernelContainer;
        public ApplyChangesAndCloseWindowCommand(IFilterParametersContainer parametersContainer, KernelDialogWindow dialogWindow, IKernelContainer kernelContainer)
        {
            _parametersContainer = parametersContainer;
            _dialogWindow = dialogWindow;
            _kernelContainer = kernelContainer;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _parametersContainer.Parameters = _kernelContainer.Kernel;
            _dialogWindow.Close();
        }
    }
}
