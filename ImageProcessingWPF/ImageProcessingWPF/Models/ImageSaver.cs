using ImageProcessingWPF.Utility;
using ImageProcessingWPF.ViewModels.Commands;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows;

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

        private void SaveImage(BitmapImage imageToSave)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "result image";
            dialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Png Image|*.png|Test|.badextension"; //TODO remove .badextension option after testing is done
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    var encoder = GetEncoderByExtension(dialog.FileName);
                    encoder.Frames.Add(BitmapFrame.Create(imageToSave));
                    using (var stream = dialog.OpenFile())
                    {
                        encoder.Save(stream);
                    }
                }
                catch (IOException exception)
                {
                    MessageBox. Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private BitmapEncoder GetEncoderByExtension(string fileName)
        {
            var extension = Path.GetExtension(fileName).Trim().ToLower();
            
            BitmapEncoder encoder;
            if (extension == ".jpg" || extension == ".jpeg")
                encoder = new JpegBitmapEncoder(); 
            else if (extension == ".bmp")
                encoder = new BmpBitmapEncoder();
            else if (extension == ".png")
                encoder = new PngBitmapEncoder();
            else
                throw new IOException($"File can not be saved in *{extension} extension");
            return encoder;
        }
    }
}
