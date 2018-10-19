using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using AVFoundation;
using AVKit;
using CoreMedia;
using Foundation;
using UIKit;
using Welic.App.Implements;
using Welic.App.Services.VideoPlayer;
using Welic.App.Services.VideoPlayer.Enums;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(VideoPlayer),
                          typeof(Welic.App.iOS.VideoPlayerRenderer))]

namespace Welic.App.iOS
{
    public class VideoPlayerRenderer : ViewRenderer<VideoPlayer, UIView>
    {
        AVPlayer _player;
        AVPlayerItem _playerItem;
        AVPlayerViewController _playerViewController;       // solely for ViewController property

        public override UIViewController ViewController => _playerViewController;

        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> args)
        {
            base.OnElementChanged(args);

            if (args.NewElement != null)
            {
                if (Control == null)
                {
                    // Create AVPlayerViewController
                    _playerViewController = new AVPlayerViewController();

                    // Set Player property to AVPlayer
                    _player = new AVPlayer();
                    _playerViewController.Player = _player;

                    var x = _playerViewController.View;

                    // Use the View from the controller as the native control
                    SetNativeControl(_playerViewController.View);
                }

                SetAreTransportControlsEnabled();
                SetSource();
                SetAspectModel();

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
            base.Dispose(disposing);

            if (_player != null)
            {
                _player.ReplaceCurrentItemWithPlayerItem(null);
            }
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
            else if (args.PropertyName == VideoPlayer.PositionProperty.PropertyName)
            {
                TimeSpan controlPosition = ConvertTime(_player.CurrentTime);

                if (Math.Abs((controlPosition - Element.Position).TotalSeconds) > 1)
                {
                    _player.Seek(CMTime.FromSeconds(Element.Position.TotalSeconds, 1));
                }
            }
            else if (args.PropertyName == VideoPlayer.AspectModeProperty.PropertyName)
            {
                SetAspectModel();
            }
        }

        void SetAspectModel()
        {
            if (Element.AspectMode.Equals(VideoAspectMode.AspectFill))
                ((AVPlayerViewController) ViewController).EntersFullScreenWhenPlaybackBegins = true;                
            else
                ((AVPlayerViewController)ViewController).ExitsFullScreenWhenPlaybackEnds = true;          
        }

        void SetAreTransportControlsEnabled()
        {
            ((AVPlayerViewController)ViewController).ShowsPlaybackControls = Element.AreTransportControlsEnabled;
        }

        void SetSource()
        {
            AVAsset asset = null;

            if (Element.Source is UriVideoSource)
            {
                string uri = (Element.Source as UriVideoSource).Uri;

                if (!String.IsNullOrWhiteSpace(uri))
                {
                    asset = AVAsset.FromUrl(new NSUrl(uri));
                }
            }
            else if (Element.Source is FileVideoSource)
            {
                string uri = (Element.Source as FileVideoSource).File;

                if (!String.IsNullOrWhiteSpace(uri))
                {
                    asset = AVAsset.FromUrl(new NSUrl(uri));
                }
            }
            else if (Element.Source is ResourceVideoSource)
            {
                string path = (Element.Source as ResourceVideoSource).Path;

                if (!String.IsNullOrWhiteSpace(path))
                {
                    string directory = Path.GetDirectoryName(path);
                    string filename = Path.GetFileNameWithoutExtension(path);
                    string extension = Path.GetExtension(path).Substring(1);
                    NSUrl url = NSBundle.MainBundle.GetUrlForResource(filename, extension, directory);
                    asset = AVAsset.FromUrl(url);
                }
            }

            if (asset != null)
            {
                _playerItem = new AVPlayerItem(asset);
            }
            else
            {
                _playerItem = null;
            }

            _player.ReplaceCurrentItemWithPlayerItem(_playerItem);

            if (_playerItem != null && Element.AutoPlay)
            {
                _player.Play();
            }
        }

        // Event handler to update status
        void OnUpdateStatus(object sender, EventArgs args)
        {
            VideoStatus videoStatus = VideoStatus.NotReady;

            switch (_player.Status)
            {
                case AVPlayerStatus.ReadyToPlay:
                    switch (_player.TimeControlStatus)
                    {
                        case AVPlayerTimeControlStatus.Playing:
                            videoStatus = VideoStatus.Playing;
                            break;

                        case AVPlayerTimeControlStatus.Paused:
                            videoStatus = VideoStatus.Paused;
                            break;
                    }
                    break;
            }
            ((IVideoPlayerController)Element).Status = videoStatus;

            if (_playerItem != null)
            {
                ((IVideoPlayerController)Element).Duration = ConvertTime(_playerItem.Duration);
                ((IElementController)Element).SetValueFromRenderer(VideoPlayer.PositionProperty, ConvertTime(_playerItem.CurrentTime));
            }
        }

        TimeSpan ConvertTime(CMTime cmTime)
        {
            return TimeSpan.FromSeconds(Double.IsNaN(cmTime.Seconds) ? 0 : cmTime.Seconds);

        }

        // Event handlers to implement methods
        void OnPlayRequested(object sender, EventArgs args)
        {
            _player.Play();
        }

      
        void OnPauseRequested(object sender, EventArgs args)
        {
            _player.Pause();
        }

        void OnStopRequested(object sender, EventArgs args)
        {
            _player.Pause();
            _player.Seek(new CMTime(0, 1));
        }
    }
}