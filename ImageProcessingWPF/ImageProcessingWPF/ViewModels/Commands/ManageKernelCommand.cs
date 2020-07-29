using System;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels.Commands
{
    class ManageKernelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _openKernelDialogWindowDelegate;
        public ManageKernelCommand(Action openKernelDialogWindowDelegate)
        {
            _openKernelDialogWindowDelegate = openKernelDialogWindowDelegate;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _openKernelDialogWindowDelegate.Invoke();
        }
    }
}
