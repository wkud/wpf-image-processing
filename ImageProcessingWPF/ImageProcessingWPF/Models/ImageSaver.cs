using ImageProcessingWPF.ViewModels.Commands;
using Microsoft.Win32;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ImageProcessingWPF.Models
{
    class ImageSaver
    {
        public ICommand SaveResultImageToFileCommand => new SaveResultImageToFileCommand(SaveImage, _imageProcessor); //propably will need notify update

        private IImageProcessor _imageProcessor;
        public ImageSaver(IImageProcessor imageProcessor)
        {
            _imageProcessor = imageProcessor;
        }

        public void SaveImage(BitmapImage imageToSave)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Document";
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
