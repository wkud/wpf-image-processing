using System.ComponentModel;

namespace ImageProcessingWPF.Utility
{
    static class NotifyPropertyChangedUtility
    {
        public static void OnPropertyChanged(this PropertyChangedEventHandler handler, object sender, string propertyName)
        {
            handler?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
}
