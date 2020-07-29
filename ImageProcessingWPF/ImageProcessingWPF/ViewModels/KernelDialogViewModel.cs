using ImageProcessingWPF.ViewModels.Commands;
using ImageProcessingWPF.Views;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels
{
    class KernelDialogViewModel
    {
        private KernelViewModel _kernelViewModel;
        public KernelViewModel KernelViewModel => _kernelViewModel;

        public ICommand SaveKernel => new SaveKernelCommand(KernelViewModel.Kernel);

        public KernelDialogViewModel(MainWindow parentView)
        {
            KernelDialogWindow dialogWindow = new KernelDialogWindow();
            dialogWindow.DataContext = this;
            dialogWindow.Owner = parentView;

            _kernelViewModel = new KernelViewModel();
            dialogWindow.ShowDialog();
        }

    }
}
