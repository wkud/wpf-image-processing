using System;
using System.Windows.Media.Imaging;

namespace ImageProcessingWPF.Models.Interfaces
{
    interface IImageLoader
    {
        BitmapImage LoadedImage { get; }
        event Action ImageLoaded;
    }
}
