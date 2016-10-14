using System;
using System.Net;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.IO;
using System.Windows.Media.Imaging;
using ImageTools.IO.Gif;
using ImageTools.IO.Png;

namespace Chapter06Sample.Helpers
{
    public class GifConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                // Decode the GIF using the ImageTools library (from CodePlex)
                // NOTE: Silverlight has no native support for GIF files
                MemoryStream gifStream = new MemoryStream(value as byte[]);
                ImageTools.Image image = new ImageTools.Image();
                GifDecoder decoder = new GifDecoder();
                decoder.Decode(image, gifStream);
                gifStream.Dispose();

                // Re-encode the image as a PNG (which is supported by Silverlight)
                // and put it into a BitmapImage so it can be used by the Image control
                MemoryStream pngStream = new MemoryStream();
                PngEncoder encoder = new PngEncoder();
                encoder.IsWritingUncompressed = true;
                encoder.Encode(image, pngStream);
                BitmapImage pngImage = new BitmapImage();
                pngImage.SetSource(pngStream);
                pngStream.Dispose();

                return pngImage;
            }
            catch { }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
