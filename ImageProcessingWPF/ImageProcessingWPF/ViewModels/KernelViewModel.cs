using ImageProcessingWPF.Models;
using ImageProcessingWPF.Models.Interfaces;
using ImageProcessingWPF.Utility;
using System.ComponentModel;

namespace ImageProcessingWPF.ViewModels
{
    public class KernelViewModel : IKernelContainer, INotifyPropertyChanged
    {
        private const int minSize = 3;
        private const int maxSize = 20;

        public Kernel Kernel { get; private set; }

        private int _width;
        public string Width
        {
            get { return _width.ToString(); }
            set
            {
                var oldValue = _width;
                _width = value.ParseAndValidate(_width, minSize, maxSize);
                Kernel.OnWidthUpdated(oldValue, _width);
            }
        }

        private int _height;
        public string Height
        {
            get { return _height.ToString(); }
            set
            {
                var oldValue = _height;
                _height = value.ParseAndValidate(_height, minSize, maxSize);
                Kernel.OnHeightChanged(oldValue, _height);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public KernelViewModel(int initialWidth = 3, int initialHeight = 3)
        {
            _width = initialWidth;
            _height = initialHeight;
            Kernel = new Kernel(_width, _height);
        }

        public void SetDeserializedKernel(Kernel kernel)
        {
            if (kernel is null)
                return;

            Kernel = kernel;
            PropertyChanged.Notify(this, "Kernel");

            _width = Kernel.Width;
            PropertyChanged.Notify(this, "Width");

            _height = Kernel.Height;
            PropertyChanged.Notify(this, "Height");
        }
    }
}
