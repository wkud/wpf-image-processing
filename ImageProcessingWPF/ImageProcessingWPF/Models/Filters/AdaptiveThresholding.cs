using ImageProcessingWPF.Models.FilterParameters;
using ImageProcessingWPF.Models.Interfaces;
using ImageProcessingWPF.Utility;
using System;
using System.Drawing;

namespace ImageProcessingWPF.Models.Filters
{
    class AdaptiveThresholding : IFilter
    {
        enum CornerType
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
        }
        private int[,] _integralImage;
        private int _width;
        private int _height;
        private int GetIntegralImageValue(int x, int y, CornerType closestArrayCorner)
        {
            try
            {
                return _integralImage[x, y];
            }
            catch(IndexOutOfRangeException)
            {
                switch (closestArrayCorner)
                {
                    case CornerType.TopLeft:
                        return _integralImage[0, 0];
                    case CornerType.TopRight:
                        return _integralImage[_width - 1, 0];
                    case CornerType.BottomLeft:
                        return _integralImage[0, _height - 1];
                    case CornerType.BottomRight:
                        return _integralImage[_width - 1, _height - 1];
                    default:
                        throw new ArgumentException("Unhandled CornerType argument");
                }
            }
        }
        public Bitmap Execute(IFilterParameters parameters, Bitmap inputImage)
        {
            var thresholdingParameters = parameters as ThresholdingParameters;
            var halfOfAreaSize = thresholdingParameters.MeanAreaSize / 2;
            var inversedDeviationPercent = 1 - thresholdingParameters.MaxDeviation;

            var grayInput = inputImage.ToIntensityArray();

            _width = inputImage.Width;
            _height = inputImage.Height;

            _integralImage = new int[_width, _height];
            for (int i = 0; i < _width; i++)
            {
                var sum = 0;
                for (int j = 0; j < _height; j++)
                {
                    sum += grayInput[i, j];
                    if (i == 0)
                        _integralImage[i, j] = sum;
                    else
                        _integralImage[i, j] = _integralImage[i - 1, j] + sum;
                }
            }

            var outputImage = new Bitmap(_width, _height);
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    var startX = i - halfOfAreaSize;
                    var endX = i + halfOfAreaSize;
                    var startY = j - halfOfAreaSize;
                    var endY = j + halfOfAreaSize;

                    var count = (endX - startX) * (endY - startY);
                    var sum = GetIntegralImageValue(endX, endY, CornerType.BottomRight) 
                        - GetIntegralImageValue(endX, startY - 1, CornerType.TopRight) 
                        - GetIntegralImageValue(startX - 1, endY, CornerType.BottomLeft) 
                        + GetIntegralImageValue(startX - 1, startY - 1, CornerType.TopLeft); 
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
