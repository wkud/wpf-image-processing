using System.ComponentModel;

namespace ImageProcessingWPF.Utility
{
    static class NotifyPropertyChangedUtility
    {
        public static void Notify(this PropertyChangedEventHandler handler, object sender, string propertyName)
        {
            handler?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
}
