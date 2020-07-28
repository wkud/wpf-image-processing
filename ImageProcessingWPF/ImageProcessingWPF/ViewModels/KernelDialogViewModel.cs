using ImageProcessingWPF.Models;
using ImageProcessingWPF.Views;

namespace ImageProcessingWPF.ViewModels
{
    class KernelDialogViewModel
    {
        private DynamicMatrixViewModel _matrixHandler;
        public DynamicMatrixViewModel MatrixHandler => _matrixHandler;

        public KernelDialogViewModel(MainWindow parentView)
        {
            KernelDialogWindow dialogWindow = new KernelDialogWindow();
            dialogWindow.DataContext = this;
            dialogWindow.Owner = parentView;

            _matrixHandler = new DynamicMatrixViewModel();
            dialogWindow.ShowDialog();
        }

    }
}
