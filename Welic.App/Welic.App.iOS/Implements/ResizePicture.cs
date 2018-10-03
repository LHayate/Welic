using System;
using System.Drawing;
using UIKit;
using Welic.App.Services.ResizePcture;
using Xamarin.Forms;

[assembly: Dependency(typeof(Welic.App.iOS.Implements.ResizePicture))]
namespace Welic.App.iOS.Implements
{
    class ResizePicture : IResizePicture
    {
        public byte[] ResizeImage(byte[] imageData, float width, float heigth)
        {
            UIImage originalImage = ImageFromByteArray(imageData);

            var originalHeight = originalImage.Size.Height;
            var originalWidth = originalImage.Size.Width;

            nfloat newHeight;
            nfloat newWidth;

            if (originalHeight > originalWidth)
            {
                newHeight = heigth;
                nfloat ratio = originalHeight / heigth;
                newWidth = originalWidth / ratio;
            }
            else
            {
                newWidth = width;
                nfloat ratio = originalWidth / width;
                newHeight = originalHeight / ratio;
            }

            width = (float)newWidth;
            heigth = (float)newHeight;

            UIGraphics.BeginImageContext(new SizeF(width, heigth));
            originalImage.Draw(new RectangleF(0, 0, width, heigth));
            var resizedImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            var bytesImagen = resizedImage.AsJPEG().ToArray();
            resizedImage.Dispose();
            return bytesImagen;
        }

        public UIImage ImageFromByteArray(byte[] data)
        {
            if (data == null)
                return null;

            return new UIImage(Foundation.NSData.FromArray(data));
        }
    }
}