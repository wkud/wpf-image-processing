using ImageProcessingWPF.Models.Interfaces;
using System;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels.Commands
{
    class ExecuteFilterCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;


        Action _executeFilterDelegate;
        IImageLoader _imageLoader;
        public ExecuteFilterCommand(Action executeFilterDelegate, IImageLoader imageLoader)
        {
            _executeFilterDelegate = executeFilterDelegate;
            _imageLoader = imageLoader;
        }

        public bool CanExecute(object parameter)
        {
            return _imageLoader.LoadedImage != null;
        }

        public void Execute(object parameter)
        {
            _executeFilterDelegate.Invoke();
        }
    }
}
