using ImageProcessingWPF.Models.FilterParameters;
using ImageProcessingWPF.Utility;
using ImageProcessingWPF.Utility.Validators;
using System.Drawing;

namespace ImageProcessingWPF.Models.Filters
{
    class AdaptiveThresholding 
    {
        private int[,] _integralImage;

        private IValidator<int> _indexValidatorX;
        private IValidator<int> _indexValidatorY;

        private int GetIntegralImageValue(int x, int y)
        {
            x = _indexValidatorX.MakeValid(x);
            y = _indexValidatorY.MakeValid(y);
            return _integralImage[x, y];
        }
        public Bitmap Execute(ThresholdingParameters parameters, Bitmap inputImage)
        {
            var halfOfAreaSize = parameters.MeanAreaSize / 2;
            var inversedDeviationPercent = 1 - parameters.MaxDeviation;

            var grayInput = inputImage.ToIntensityArray();

            _indexValidatorX = new IsWithinRangeValidator(0, inputImage.Width - 1);
            _indexValidatorY = new IsWithinRangeValidator(0, inputImage.Height - 1);

            _integralImage = new int[inputImage.Width, inputImage.Height];
            for (int i = 0; i < inputImage.Width; i++)
            {
                var sum = 0;
                for (int j = 0; j < inputImage.Height; j++)
                {
                    sum += grayInput[i, j];
                    if (i == 0)
                        _integralImage[i, j] = sum;
                    else
                        _integralImage[i, j] = _integralImage[i - 1, j] + sum;
                }
            }

            var outputImage = new Bitmap(inputImage.Width, inputImage.Height);
            for (int i = 0; i < inputImage.Width; i++)
            {
                for (int j = 0; j < inputImage.Height; j++)
                {
                    var startX = i - halfOfAreaSize;
                    var endX = i + halfOfAreaSize;
                    var startY = j - halfOfAreaSize;
                    var endY = j + halfOfAreaSize;

                    var count = (endX - startX) * (endY - startY);
                    var sum = GetIntegralImageValue(endX, endY)
                        - GetIntegralImageValue(endX, startY - 1)
                        - GetIntegralImageValue(startX - 1, endY)
                        + GetIntegralImageValue(startX - 1, startY - 1);
                    if (grayInput[i, j] * count <= sum * inversedDeviationPercent)
                    {
                        outputImage.SetPixel(i, j, Color.Black);
                    }
                    else
                    {
                        outputImage.SetPixel(i, j, Color.White);
                    }
                }
            }
            return outputImage;
        }
    }
}
