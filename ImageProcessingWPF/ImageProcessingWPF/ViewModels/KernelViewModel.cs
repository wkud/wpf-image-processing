using ImageProcessingWPF.Models.FilterParameters;
using ImageProcessingWPF.Models.Interfaces;
using ImageProcessingWPF.Utility;
using ImageProcessingWPF.Utility.Validators;
using System.ComponentModel;

namespace ImageProcessingWPF.ViewModels
{
    public class KernelViewModel : IKernelContainer, INotifyPropertyChanged
    {
        private const int minSize = 3;
        private const int maxSize = 20;
        private IValidator<int> _rangeValidator = new IsWithinRangeValidator(minSize, maxSize);

        public Kernel Kernel { get; private set; }

        private int _width;
        public string Width
        {
            get { return _width.ToString(); }
            set
            {
                var oldValue = _width;
                _width = value.ParseAndValidate(_width, _rangeValidator);
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
                _height = value.ParseAndValidate(_height, _rangeValidator);
                Kernel.OnHeightChanged(oldValue, _height);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public KernelViewModel(Kernel kernel)
        {
            if (kernel != null)
            {
                _width = kernel.Width;
                _height = kernel.Height;
                Kernel = kernel;
            }
            else
            {
                _width = minSize;
                _height = minSize;
                Kernel = new Kernel(_width, _height);
            }
        }

        public void SetDeserializedKernel(Kernel kernel)
        {
            if (kernel is null)
                return;

            Kernel = kernel;
            PropertyChanged.Notify(this, "Kernel");

            if (!_rangeValidator.IsValid(Kernel.Width))
            {
                MessageBoxExtension.ShowWarning($"Invalid kernel width={Kernel.Width}. The value has been changed to lie beetwen {minSize} and {maxSize}");
                var correctedWidth = _rangeValidator.MakeValid(Kernel.Width);
                Kernel.OnWidthUpdated(Kernel.Width, correctedWidth);
            }
            _width = Kernel.Width;
            PropertyChanged.Notify(this, "Width");

            if (!_rangeValidator.IsValid(Kernel.Height))
            {
                MessageBoxExtension.ShowWarning($"Invalid kernel height={Kernel.Height}. The value has been changed to lie beetwen {minSize} and {maxSize}");
                var correctedHeight = _rangeValidator.MakeValid(Kernel.Height);
                Kernel.OnHeightChanged(Kernel.Height, correctedHeight);
            }
            _height = Kernel.Height;
            PropertyChanged.Notify(this, "Height");
        }
    }
}
