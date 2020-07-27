using ImageProcessingWPF.Models;
using System;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ImageProcessingWPF.ViewModels.Commands
{
    class SaveResultImageToFileCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<BitmapImage> _saveImageDelegate;
        private IImageProcessor _imageProcessor;
        public SaveResultImageToFileCommand(Action<BitmapImage> saveImageDelegate, IImageProcessor imageProcessor)
        {
            _saveImageDelegate = saveImageDelegate;
            _imageProcessor = imageProcessor;
        }

        public bool CanExecute(object parameter)
        {
            return _imageProcessor.ResultImage != null;
        }

        public void Execute(object parameter)
        {
            _saveImageDelegate.Invoke(_imageProcessor.ResultImage);
        }
    }
}
