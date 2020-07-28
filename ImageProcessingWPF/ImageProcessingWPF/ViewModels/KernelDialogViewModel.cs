using ImageProcessingWPF.Models;
using ImageProcessingWPF.Views;

namespace ImageProcessingWPF.ViewModels
{
    class KernelDialogViewModel
    {
        private DynamicMatrixHandler _matrixHandler;
        public DynamicMatrixHandler MatrixHandler => _matrixHandler;

        public KernelDialogViewModel(MainWindow parentView)
        {
            KernelDialogWindow dialogWindow = new KernelDialogWindow();
            dialogWindow.DataContext = this;
            dialogWindow.Owner = parentView;

            _matrixHandler = new DynamicMatrixHandler();
            dialogWindow.ShowDialog();
        }

    }
}
