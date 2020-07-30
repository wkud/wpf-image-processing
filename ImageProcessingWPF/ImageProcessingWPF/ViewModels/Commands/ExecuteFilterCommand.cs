using ImageProcessingWPF.Models.Interfaces;
using System;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels.Commands
{
    class ExecuteFilterCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _executeFilterDelegate;
        private IImageLoader _imageLoader;
        private bool _isLoading;
        public ExecuteFilterCommand(Action executeFilterDelegate, IImageLoader imageLoader, bool isLoading)
        {
            _executeFilterDelegate = executeFilterDelegate;
            _imageLoader = imageLoader;
            _isLoading = isLoading;
        }

        public bool CanExecute(object parameter)
        {
            return _imageLoader.LoadedImage != null && !_isLoading;
        }

        public void Execute(object parameter)
        {
            _executeFilterDelegate.Invoke();
        }
    }
}
