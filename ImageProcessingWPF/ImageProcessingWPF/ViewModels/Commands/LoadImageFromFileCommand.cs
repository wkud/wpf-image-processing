﻿using System;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels.Commands
{
    class LoadImageFromFileCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
