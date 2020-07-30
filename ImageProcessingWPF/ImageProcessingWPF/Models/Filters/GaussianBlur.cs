using ImageProcessingWPF.Models.FilterParameters;
using ImageProcessingWPF.Models.Interfaces;
using System;
using System.Drawing;

namespace ImageProcessingWPF.Models.Filters
{
    class GaussianBlur : IFilter
    {
        private int _kernelWidth;
        private int _kernelHeight;

        //offset from center of kernel to it's left top corner
        private int _offsetX;
        private int _offsetY;

        private int _kernelTotalValue;

        private Bitmap _input;
        public Bitmap Execute(Bitmap inputImage, IFilterParameters parameters)
        {
            var kernel = (parameters as Kernel).ToArray();
            _input = inputImage;

            _kernelWidth = kernel.GetLength(0);
            _kernelHeight = kernel.GetLength(1);

            //offset is slightly larger for even numbers, so center of kernel will be slightly shifted towards right/bottom
            _offsetX = (int)Math.Ceiling((_kernelWidth - 1) / 2.0);
            _offsetY = (int)Math.Ceiling((_kernelHeight - 1) / 2.0);

            _kernelTotalValue = 0;
            for (int i = 0; i < _kernelWidth; i++)
            {
                for (int j = 0; j < _kernelHeight; j++)
                {
                    _kernelTotalValue += kernel[i, j];
                }
            }

            Bitmap output = new Bitmap(_input.Width, _input.Height);
            for (int x = 0; x < _input.Width; x++)
            {
                for (int y = 0; y < _input.Height; y++)
                {
                    var sum = new int[] { 0, 0, 0 };
                    for (int i = 0; i < _kernelWidth; i++)
                    {
                        for (int j = 0; j < _kernelHeight; j++)
                        {
                            var inputColor = GetColor(x, y, i, j);
                            sum[0] += kernel[i, j] * inputColor.R;
                            sum[1] += kernel[i, j] * inputColor.G;
                            sum[2] += kernel[i, j] * inputColor.B;
                        }
                    }
                    var r = sum[0] / _kernelTotalValue;
                    var g = sum[1] / _kernelTotalValue;
                    var b = sum[2] / _kernelTotalValue;
                    var color = Color.FromArgb(r, g, b);
                    output.SetPixel(x, y, color);
                }
            }
            return output;
        }
        private Color GetColor(int x, int y, int i, int j)
        {
            var indexX = x - _offsetX + i;
            var indexY = y - _offsetY + j;

            try
            {
                return _input.GetPixel(indexX, indexY);
            }
            catch (ArgumentOutOfRangeException)
            {
                return _input.GetPixel(x, y);
            }
        }
    }
}
