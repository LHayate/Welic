
using Windows.UI.Xaml.Controls;
using Welic.App.Implements;
using Xamarin.Forms.Platform.UWP;

using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;

[assembly: ExportRenderer(typeof(VideoPlayer),
    typeof(Welic.App.UWP.VideoPlayerRenderer))]

namespace Welic.App.UWP
{
    public class VideoPlayerRenderer : ViewRenderer<VideoPlayer, MediaElement>
    {
        //protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> args)
        //{
        //    base.OnElementChanged(args);

        //    if (args.NewElement != null)
        //    {
        //        if (Control == null)
        //        {
        //            MediaElement mediaElement = new MediaElement();
        //            SetNativeControl(mediaElement);

        //            mediaElement.MediaOpened +=  OnMediaElementMediaOpened;
        //            mediaElement.CurrentStateChanged += OnMediaElementCurrentStateChanged;
        //        }                
        //    }            
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (Control != null)
        //    {
        //        Control.MediaOpened -= OnMediaElementMediaOpened;
        //        Control.CurrentStateChanged -= OnMediaElementCurrentStateChanged;
        //    }

        //    base.Dispose(disposing);
        //}                
    }
}
