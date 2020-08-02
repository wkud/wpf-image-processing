using ImageProcessingWPF.Models.FilterParameters;
using ImageProcessingWPF.Utility;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace ImageProcessingWPF.Models.Filters
{
    class GaussianBlurTask
    {
        private Task _task;
        private Bitmap _result;

        public int StripOffsetX { get; private set; }
        public int StripWidth { get; private set; }

        public GaussianBlurTask Run(Kernel kernel, Bitmap inputImage, int widthPerTask, int taskIndex)
        {
            StripOffsetX = taskIndex * widthPerTask;
            StripWidth = Math.Min(widthPerTask, inputImage.Width - StripOffsetX);

            _task = Task.Run(() =>
            {
                _result = new GaussianBlur().Execute(kernel, inputImage, StripWidth, StripOffsetX);
            });
            return this;
        }

        public Bitmap WaitForResult()
        {
            _task.Wait();
            if (_task.Exception != null)
                _task.Exception.ShowAsError(); //TODO debug
            return _result;
        }
    }
}
