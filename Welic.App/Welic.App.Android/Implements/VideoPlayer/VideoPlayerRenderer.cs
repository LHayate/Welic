using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.Views;
using Android.Widget;
using Welic.App.Implements;
using Welic.App.Services.VideoPlayer;
using Welic.App.Services.VideoPlayer.Enums;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ARelativeLayout = Android.Widget.RelativeLayout;
using Path = System.IO.Path;


[assembly: ExportRenderer(typeof(VideoPlayer),
                          typeof(Welic.App.Droid.VideoPlayerRenderer))]

namespace Welic.App.Droid
{
    public class VideoPlayerRenderer : ViewRenderer<VideoPlayer, ARelativeLayout>
    {
        VideoView _videoView;
        MediaController _mediaController;    // Used to display transport controls
        
        bool _isPrepared;

        public VideoPlayerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> args)
        {
            base.OnElementChanged(args);

            if (args.NewElement != null)
            {
                if (Control == null)
                {
                    // Save the VideoView for future reference
                    _videoView = new VideoView(Context);

                    // Put the VideoView in a RelativeLayout                    
                    ARelativeLayout relativeLayout = new ARelativeLayout(Context);
                    relativeLayout.AddView(_videoView);

                    // Center the VideoView in the RelativeLayout
                    ARelativeLayout.LayoutParams layoutParams =
                        new ARelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                    layoutParams.AddRule(LayoutRules.CenterInParent);
                    layoutParams.AddRule(LayoutRules.CenterInParent);

                    _videoView.LayoutParameters = layoutParams;

                    // Handle a VideoView event
                    _videoView.Prepared += OnVideoViewPrepared;

                    SetNativeControl(relativeLayout);
                }

                SetAreTransportControlsEnabled();
                SetSource();
                SetFullScreen();

                args.NewElement.UpdateStatus += OnUpdateStatus;
                args.NewElement.PlayRequested += OnPlayRequested;
                args.NewElement.PauseRequested += OnPauseRequested;
                args.NewElement.StopRequested += OnStopRequested;
            }

            if (args.OldElement != null)
            {
                args.OldElement.UpdateStatus -= OnUpdateStatus;
                args.OldElement.PlayRequested -= OnPlayRequested;
                args.OldElement.PauseRequested -= OnPauseRequested;
                args.OldElement.StopRequested -= OnStopRequested;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null && _videoView != null)
            {
                _videoView.Prepared -= OnVideoViewPrepared;
            }
            if (Element != null)
            {
                Element.UpdateStatus -= OnUpdateStatus;
            }

            base.Dispose(disposing);
        }

        void OnVideoViewPrepared(object sender, EventArgs args)
        {
            _isPrepared = true;
            ((IVideoPlayerController)Element).Duration = TimeSpan.FromMilliseconds(_videoView.Duration);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == VideoPlayer.AreTransportControlsEnabledProperty.PropertyName)
            {
                SetAreTransportControlsEnabled();
            }
            else if (args.PropertyName == VideoPlayer.SourceProperty.PropertyName)
            {
                SetSource();
            }
            else if (args.PropertyName == VideoPlayer.AspectModeProperty.PropertyName)
            {
                SetFullScreen();
            }
            else if (args.PropertyName == VideoPlayer.PositionProperty.PropertyName)
            {
                if (Math.Abs(_videoView.CurrentPosition - Element.Position.TotalMilliseconds) > 1000)
                {
                    _videoView.SeekTo((int)Element.Position.TotalMilliseconds);
                }
            }
        }
       
        void  SetFullScreen()
        {
            if (Element.AspectMode == VideoAspectMode.None)
            {
                Control.Layout(0, 0, Width, Height);
                return;
            }

            // assume video size = view size if the player has not been loaded yet
            var videoWidth = _videoView.Width;
            var videoHeight = _videoView.Height;

            var scaleWidth = (double)Width / (double)videoWidth;
            var scaleHeight = (double)Height / (double)videoHeight;

            double scale;
            switch (Element.AspectMode)
            {
                case VideoAspectMode.AspectFit:
                    scale = Math.Min(scaleWidth, scaleHeight);
                    break;
                case VideoAspectMode.AspectFill:
                    scale = Math.Max(scaleWidth, scaleHeight);
                    break;
                default:
                    // should not happen
                    scale = 1;
                    break;
            }

            var scaledWidth = (int)Math.Round(videoWidth * scale);
            var scaledHeight = (int)Math.Round(videoHeight * scale);

            // center the video
            var l = (Width - scaledWidth) / 2;
            var t = (Height - scaledHeight) / 2;
            var r = l + scaledWidth;
            var b = t + scaledHeight;
            Control.Layout(l, t, r, b);
        }        

        void SetAreTransportControlsEnabled()
        {
            if (Element.AreTransportControlsEnabled)
            {
                _mediaController = new MediaController(Context);
                _mediaController.SetMediaPlayer(_videoView);
                _videoView.SetMediaController(_mediaController);
            }
            else
            {
                _videoView.SetMediaController(null);

                if (_mediaController != null)
                {
                    _mediaController.SetMediaPlayer(null);
                    _mediaController = null;
                }
            }
        }

        void SetSource()
        {
            _isPrepared = false;
            bool hasSetSource = false;

            if (Element.Source is UriVideoSource)
            {
                string uri = (Element.Source as UriVideoSource).Uri;

                if (!String.IsNullOrWhiteSpace(uri))
                {
                    _videoView.SetVideoURI(Android.Net.Uri.Parse(uri));
                    hasSetSource = true;
                }
            }
            else if (Element.Source is FileVideoSource)
            {
                string filename = (Element.Source as FileVideoSource).File;

                if (!String.IsNullOrWhiteSpace(filename))
                {
                    _videoView.SetVideoPath(filename);
                    hasSetSource = true;
                }
            }
            else if (Element.Source is ResourceVideoSource)
            {
                string package = Context.PackageName;
                string path = (Element.Source as ResourceVideoSource).Path;

                if (!String.IsNullOrWhiteSpace(path))
                {
                    string filename = Path.GetFileNameWithoutExtension(path).ToLowerInvariant();
                    string uri = "android.resource://" + package + "/raw/" + filename;
                    _videoView.SetVideoURI(Android.Net.Uri.Parse(uri));
                    hasSetSource = true;
                }
            }

            if (hasSetSource && Element.AutoPlay)
            {
                _videoView.Start();
            }
        }

        // Event handler to update status
        void OnUpdateStatus(object sender, EventArgs args)
        {
            VideoStatus status = VideoStatus.NotReady;

            if (_isPrepared)
            {
                status = _videoView.IsPlaying ? VideoStatus.Playing : VideoStatus.Paused;
            }

            ((IVideoPlayerController)Element).Status = status;

            // Set Position property
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(_videoView.CurrentPosition);
            ((IElementController)Element).SetValueFromRenderer(VideoPlayer.PositionProperty, timeSpan);
        }

        // Event handlers to implement methods
        void OnPlayRequested(object sender, EventArgs args)
        {
            _videoView.Start();
        }

        void OnPauseRequested(object sender, EventArgs args)
        {
            _videoView.Pause();
        }

        void OnStopRequested(object sender, EventArgs args)
        {
            _videoView.StopPlayback();
        }
    }
}