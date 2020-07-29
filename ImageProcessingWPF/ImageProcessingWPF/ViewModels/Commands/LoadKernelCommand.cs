using ImageProcessingWPF.Models;
using ImageProcessingWPF.Models.Interfaces;
using System;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels.Commands
{
    class LoadKernelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private IKernelContainer _container;
        public LoadKernelCommand(IKernelContainer container)
        {
            _container = container;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _container.SetDeserializedKernel(new KernelSerializer().Deserialize());
        }
    }
}
