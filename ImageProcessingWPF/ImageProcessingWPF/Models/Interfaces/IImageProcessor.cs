using System;
using System.Windows.Media.Imaging;

namespace ImageProcessingWPF.Models.Interfaces
{
    interface IImageProcessor
    {
        BitmapImage ResultImage { get; }
        event Action ResultImageUpdated;
    }
}
