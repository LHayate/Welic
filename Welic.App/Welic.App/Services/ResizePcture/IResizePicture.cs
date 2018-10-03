namespace Welic.App.Services.ResizePcture
{
    public interface IResizePicture
    {
        byte[] ResizeImage(byte[] imageData, float width, float heigth);

    }
}
