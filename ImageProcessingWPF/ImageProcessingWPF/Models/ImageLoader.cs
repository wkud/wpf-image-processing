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
    class ImageLoader : INotifyPropertyChanged, IImageProcessor //TODO remove inheritance from IImageProcessor after testing is done
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
                ResultImageUpdated.Invoke(); //TODO Remove after testing is done
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

        public BitmapImage ResultImage => LoadedImage; //TODO Remove after testing is done
        public event Action ResultImageUpdated; //TODO Remove after testing is done

        public event PropertyChangedEventHandler PropertyChanged;

        public void LoadImage()
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
