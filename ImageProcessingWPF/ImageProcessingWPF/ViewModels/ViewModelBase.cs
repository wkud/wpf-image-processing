using System.Windows.Controls;

namespace ImageProcessingWPF.ViewModels
{
    class ViewModelBase<TView> where TView : UserControl
    {
        private TView _view;
        protected TView View => _view;

        public MainViewModel MainViewModel { get; set; }

        public ViewModelBase(TView view)
        {
            _view = view;
        }
    }
}
