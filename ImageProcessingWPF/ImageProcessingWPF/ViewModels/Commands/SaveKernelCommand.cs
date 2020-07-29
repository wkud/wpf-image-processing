using ImageProcessingWPF.Models;
using ImageProcessingWPF.Models.FilterParameters;
using System;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels.Commands
{
    class SaveKernelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Kernel _kernel;
        public SaveKernelCommand(Kernel kernel)
        {
            _kernel = kernel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            new KernelSerializer().Serialize(_kernel);
        }
    }
}
