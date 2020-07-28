using ImageProcessingWPF.Views;

namespace ImageProcessingWPF.ViewModels
{
    class KernelDialogViewModel
    {
        public KernelDialogViewModel(MainWindow parentView)
        {
            KernelDialogWindow dialogWindow = new KernelDialogWindow();
            dialogWindow.Owner = parentView;
            dialogWindow.ShowDialog();
        }
    }
}
