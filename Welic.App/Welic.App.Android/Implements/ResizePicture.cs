using System.IO;
using Android.Graphics;
using Welic.App.Services.ResizePcture;
using Xamarin.Forms;

[assembly: Dependency(typeof(Welic.App.Droid.Implements.ResizePicture))]

namespace Welic.App.Droid.Implements
{
    class ResizePicture : IResizePicture
    {
        public byte[] ResizeImage(byte[] imageData, float width, float heigth)
        {

            // Load the bitmap 
            BitmapFactory.Options
                options =
                    new BitmapFactory.Options(); // Create object of bitmapfactory's option method for further option use
            options.InPurgeable = true; // inPurgeable is used to free up memory while required
            Bitmap originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length, options);

            float newHeight;
            float newWidth;

            var originalHeight = originalImage.Height;
            var originalWidth = originalImage.Width;

            if (originalHeight > originalWidth)
            {
                newHeight = heigth;
                float ratio = originalHeight / heigth;
                newWidth = originalWidth / ratio;
            }
            else
            {
                newWidth = width;
                float ratio = originalWidth / width;
                newHeight = originalHeight / ratio;
            }

            Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int) newWidth, (int) newHeight, true);

            originalImage.Recycle();

            using (MemoryStream ms = new MemoryStream())
            {
                resizedImage.Compress(Bitmap.CompressFormat.Png, 100, ms);

                resizedImage.Recycle();

                return ms.ToArray();
            }

        }
    }
}