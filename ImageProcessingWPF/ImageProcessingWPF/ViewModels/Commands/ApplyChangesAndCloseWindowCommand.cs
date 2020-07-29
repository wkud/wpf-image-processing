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
        private Kernel _kernel;
        public ApplyChangesAndCloseWindowCommand(IFilterParametersContainer parametersContainer, KernelDialogWindow dialogWindow, Kernel kernel)
        {
            _parametersContainer = parametersContainer;
            _dialogWindow = dialogWindow;
            _kernel = kernel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _parametersContainer.SetFilterParameters(_kernel);
            _dialogWindow.Close();
        }
    }
}
