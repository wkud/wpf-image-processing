using ImageProcessingWPF.Utility;
using ImageProcessingWPF.ViewModels.Commands;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ImageProcessingWPF.Models
{
    class ImageLoader : INotifyPropertyChanged
    {
        public ICommand LoadImageFromFileCommand => new LoadImageFromFileCommand(LoadImage);

        private BitmapImage _loadedImage;
        public BitmapImage LoadedImage
        {
            get
            {
                return _loadedImage;
            }
            set
            {
                _loadedImage = value;
                PropertyChanged.Notify(this, "LoadedImage");
            }
        }

        private string _loadedFileName;
        public string LoadedFileName
        {
            get
            {
                return _loadedFileName is null ? "None" : _loadedFileName;
            }
            set
            {
                _loadedFileName = value is null ? null : $"\"{Path.GetFileName(value)}\"";
                PropertyChanged.Notify(this, "LoadedFileName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void LoadImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg,*.jpeg,*.png)|*.jpg;*.jpeg;*.png|All Files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = dialog.FileName;
                LoadedFileName = selectedFileName;
                LoadedImage = new BitmapImage(new Uri(selectedFileName, UriKind.Absolute));
                return;
            }
            LoadedFileName = null;
            LoadedImage = null;
        }
    }
}
