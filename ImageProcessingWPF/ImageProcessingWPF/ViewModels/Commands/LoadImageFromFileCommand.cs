using ImageProcessingWPF.Models;
using System;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels.Commands
{
    class LoadImageFromFileCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _loadImageDelegate;
        public LoadImageFromFileCommand(Action loadImageDelegate)
        {
            _loadImageDelegate = loadImageDelegate;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _loadImageDelegate.Invoke();
        }
    }
}
