using System;
using System.Windows;

namespace ImageProcessingWPF.Utility
{
    static class MessageBoxExtension
    {
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void ShowAsError(this Exception exception)
        {
            ShowError(exception.Message);
        }
    }
}
