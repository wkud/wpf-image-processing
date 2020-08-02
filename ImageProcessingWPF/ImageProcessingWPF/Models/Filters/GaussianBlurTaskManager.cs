using ImageProcessingWPF.Models.FilterParameters;
using ImageProcessingWPF.Utility;
using System.Drawing;

namespace ImageProcessingWPF.Models.Filters
{
    class GaussianBlurTaskManager
    {
        private bool _useDownsampling;
        private int _samplingScale;

        private GaussianBlurTask[] _tasks;
        private int _widthPerTask;

        private Bitmap _inputImage;
        public GaussianBlurTaskManager(Bitmap inputImage)
        {
            _inputImage = inputImage;
        }

        public GaussianBlurTaskManager UseDownsampling(int samplingScale)
        {
            _useDownsampling = true;
            _samplingScale = samplingScale;
            _inputImage = _inputImage.ScaleDown(samplingScale);

            return this;
        }

        public GaussianBlurTaskManager RunAll(int taskCount, Kernel kernel)
        {
            _widthPerTask = _inputImage.Width / taskCount + 1;

            _tasks = new GaussianBlurTask[taskCount];
            for (int taskIndex = 0; taskIndex < taskCount; taskIndex++)
            {
                _tasks[taskIndex] = new GaussianBlurTask().Run(kernel, _inputImage.Copy(), _widthPerTask, taskIndex);
            }

            return this;
        }

        public Bitmap WaitForResult()
        {
            var outputImage = new Bitmap(_inputImage.Width, _inputImage.Height);
            using (var graphics = Graphics.FromImage(outputImage))
            {
                foreach (var task in _tasks)
                {
                    var outputImageStrip = task.WaitForResult();
                    graphics.DrawImage(outputImageStrip, new Rectangle(task.StripOffsetX, 0, task.StripWidth, _inputImage.Height));
                }
            }

            if (_useDownsampling)
                return outputImage.ScaleUp(_samplingScale);

            return outputImage;
        }
    }
}
