using Welic.App.Implements.Converts;
using Xamarin.Forms;

namespace Welic.App.Services.VideoPlayer
{
    [TypeConverter(typeof(VideoSourceConverter))]
    public class VideoSource : Element
    {
        public static VideoSource FromUri(string uri)   
        {
            return new UriVideoSource() { Uri = uri };
        }

        public static VideoSource FromFile(string file)
        {
            return new FileVideoSource() { File = file };
        }

        public static VideoSource FromResource(string path)
        {
            return new ResourceVideoSource() { Path = path };
        }
    }      
}
