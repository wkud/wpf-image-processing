using ImageProcessingWPF.Models.Interfaces;

namespace ImageProcessingWPF.Models.FilterParameters
{
    class ThresholdingParameters : IFilterParameters
    {
        public double MaxDeviation { get; set; }
        public int MeanAreaSize { get; set; }
    }
}
