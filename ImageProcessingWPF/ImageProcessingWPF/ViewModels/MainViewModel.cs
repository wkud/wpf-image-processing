using ImageProcessingWPF.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingWPF.ViewModels
{
    class MainViewModel
    {
		private FileViewModel _fileViewModel = new FileViewModel();
		public FileViewModel FileViewModel
		{
			get { return _fileViewModel; }
		}

		private FilterViewModel _filterViewModel = new FilterViewModel();
		public FilterViewModel FilterViewModel
		{
			get { return _filterViewModel; }
		}


	}
}
