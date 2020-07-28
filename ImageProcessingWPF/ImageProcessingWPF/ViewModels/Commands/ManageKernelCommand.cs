using System;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels.Commands
{
    class ManageKernelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private KernelBarViewModel _barViewModel;
        public ManageKernelCommand(KernelBarViewModel barViewModel)
        {
            _barViewModel = barViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _barViewModel.IsVisible;
        }

        public void Execute(object parameter)
        {
            _barViewModel.OpenKernelWindowDialog();
        }
    }
}
