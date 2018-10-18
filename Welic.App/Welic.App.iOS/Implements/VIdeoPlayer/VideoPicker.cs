using System;
using System.Threading.Tasks;
using UIKit;
using Welic.App.iOS;
using Welic.App.Services.VideoPlayer;
using Xamarin.Forms;

[assembly: Dependency(typeof(VideoPicker))]

namespace Welic.App.iOS
{
    public class VideoPicker : IVideoPicker
    {
        TaskCompletionSource<string> _taskCompletionSource;
        UIImagePickerController _imagePicker;

        public Task<string> GetVideoFileAsync()
        {
            // Create and define UIImagePickerController
            _imagePicker = new UIImagePickerController
            {
                SourceType = UIImagePickerControllerSourceType.SavedPhotosAlbum,
                MediaTypes = new[] { "public.movie" }
            };

            // Set event handlers
            _imagePicker.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
            _imagePicker.Canceled += OnImagePickerCancelled;

            // Present UIImagePickerController;
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            var viewController = window.RootViewController;
            viewController.PresentModalViewController(_imagePicker, true);

            // Return Task object
            _taskCompletionSource = new TaskCompletionSource<string>();
            return _taskCompletionSource.Task;
        }

        void OnImagePickerFinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs args)
        {
            if (args.MediaType == "public.movie")
            {
                _taskCompletionSource.SetResult(args.MediaUrl.AbsoluteString);
            }
            else
            {
                _taskCompletionSource.SetResult(null);
            }
            _imagePicker.DismissModalViewController(true);
            DetachHandlers();
        }

        void OnImagePickerCancelled(object sender, EventArgs args)
        {
            _taskCompletionSource.SetResult(null);
            _imagePicker.DismissModalViewController(true);
            DetachHandlers();
        }

        void DetachHandlers()
        {
            _imagePicker.FinishedPickingMedia -= OnImagePickerFinishedPickingMedia;
            _imagePicker.Canceled -= OnImagePickerCancelled;
        }
    }
}