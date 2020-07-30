using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace ImageProcessingWPF.Utility
{
    static class BitmapExtension
    {
        public static Bitmap ToBitmap(this BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }
        public static BitmapImage ToBitmapImage(this Bitmap bitmap, ImageFormat format)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, format);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        public static Bitmap ScaleDown(this Bitmap image, double scale = 1)
        {
            int height = (int)(image.Height / scale);
            int width = (int)(image.Width / scale);
            return new Bitmap(image, width, height);
        }
        public static Bitmap ScaleUp(this Bitmap image, double scale = 1)
        {
            int height = (int)(image.Height * scale);
            int width = (int)(image.Width * scale);
            return new Bitmap(image, width, height);
        }
    }
}
