using ImageProcessingWPF.ViewModels.Commands;
using ImageProcessingWPF.Views;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels
{
    class KernelDialogViewModel
    {
        public KernelViewModel KernelViewModel { get; private set; }

        public ICommand SaveKernelCommand => new SaveKernelCommand(KernelViewModel.Kernel);
        public ICommand LoadKernelCommand => new LoadKernelCommand(KernelViewModel);

        public KernelDialogViewModel(MainWindow parentView)
        {
            KernelDialogWindow dialogWindow = new KernelDialogWindow();
            dialogWindow.DataContext = this;
            dialogWindow.Owner = parentView;

            KernelViewModel = new KernelViewModel();
            dialogWindow.ShowDialog();
        }
    }
}
