using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Plugin.Media;
using Welic.App.Services.ResizePcture;
using Xamarin.Forms;

//[assembly: Dependency(typeof(Welic.App.UWP.Implements.ResizePicture))]
namespace Welic.App.UWP.Implements
{
    //class ResizePicture : IResizePicture
    //{
    //    private MediaImplementation mi = new MediaImplementation();
    //    public byte[] ResizeImage(byte[] imageData, float width, float heigth)
    //    {
    //        byte[] resizedData;


    //        using (MemoryStream streamIn = new MemoryStream(imageData))
    //        {
    //            WriteableBitmap bitmap = PictureDecoder.DecodeJpeg(streamIn, (int)width, (int)heigth);

    //            float Height = 0;
    //            float Width = 0;

    //            float originalHeight = bitmap.PixelHeight;
    //            float originalWidth = bitmap.PixelWidth;

    //            if (originalHeight > originalWidth)
    //            {
    //                Height = heigth;
    //                float ratio = originalHeight / heigth;
    //                Width = originalWidth / ratio;
    //            }
    //            else
    //            {
    //                Width = width;
    //                float ratio = originalWidth / width;
    //                Height = originalHeight / ratio;
    //            }

    //            using (MemoryStream streamOut = new MemoryStream())
    //            {
    //                bitmap.SaveJpeg(streamOut, (int)Width, (int)Height, 0, 100);
    //                resizedData = streamOut.ToArray();
    //            }
    //        }
    //        return resizedData;
    //    }
    //}
}
