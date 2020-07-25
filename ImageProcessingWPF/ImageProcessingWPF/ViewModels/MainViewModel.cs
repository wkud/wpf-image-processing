using ImageProcessingWPF.Commands;
using ImageProcessingWPF.Views;
using System.Windows.Input;

namespace ImageProcessingWPF.ViewModels
{
	class MainViewModel
    {
		public ICommand LoadImageFromFileCommand => new LoadImageFromFileCommand();

		private MainWindow _window;
		public MainViewModel(MainWindow window)
		{
			_window = window;
		}

	}
}
