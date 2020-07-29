﻿using ImageProcessingWPF.Models;
using ImageProcessingWPF.Models.Interfaces;
using ImageProcessingWPF.ViewModels.Commands;
using ImageProcessingWPF.Views;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels
{
    class KernelBarViewModel : ParametersViewModelBase
    {
        public ICommand ManageKernelCommand => new ManageKernelCommand(this);

        private IFilterParametersContainer _parametersContainer;
        private MainWindow _mainWindow;
        public KernelBarViewModel(FilterHandler filterHandler, MainWindow mainWindow) : base(filterHandler, FilterType.GaussianBlur)
        {
            _mainWindow = mainWindow;
            _parametersContainer = filterHandler;
        }

        public void OpenKernelWindowDialog()
        {
             new KernelDialogViewModel(_mainWindow, _parametersContainer);
        }
    }
}
