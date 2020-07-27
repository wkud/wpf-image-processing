using ImageProcessingWPF.Utility;
using ImageProcessingWPF.ViewModels.Commands;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ImageProcessingWPF.Models
{
    class ImageSaver : INotifyPropertyChanged
    {
        public ICommand SaveResultImageToFileCommand => new SaveResultImageToFileCommand(SaveImage, _imageProcessor);

        private IImageProcessor _imageProcessor;

        public event PropertyChangedEventHandler PropertyChanged;

        public ImageSaver(IImageProcessor imageProcessor)
        {
            _imageProcessor = imageProcessor;
            _imageProcessor.ResultImageUpdated += () => PropertyChanged.Notify(this, "SaveResultImageToFileCommand");
        }

        public void SaveImage(BitmapImage imageToSave)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "result image";
            dialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Png Image|*.png";
            if (dialog.ShowDialog() == true)
            {
                var encoder = new JpegBitmapEncoder(); // TODO Add other encoders (e.g. PngBitmapEncoder)
                encoder.Frames.Add(BitmapFrame.Create(imageToSave));
                using (var stream = dialog.OpenFile())
                {
                    encoder.Save(stream);
                }
            }
        }
    }
}
