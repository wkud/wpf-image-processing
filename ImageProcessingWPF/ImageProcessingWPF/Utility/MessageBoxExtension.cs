using System.Windows;

namespace ImageProcessingWPF.Utility
{
    static class MessageBoxExtension
    {
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
