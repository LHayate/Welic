using System;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Welic.App.Services.VideoPlayer;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LivePage : ContentPage
	{
	    private IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;
        public LivePage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<LiveViewModel>();
		    this.volumeLabel.Text = "Volume (0-" + CrossMediaManager.Current.VolumeManager.MaxVolume + ")";
		    //Initialize Volume settings to match interface
		    int.TryParse(this.volumeEntry.Text, out var vol);
		    CrossMediaManager.Current.VolumeManager.CurrentVolume = vol;
		    //CrossMediaManager.Current.VolumeManager.Muted = false;

		    CrossMediaManager.Current.PlayingChanged += (sender, e) =>
		    {
		        Device.BeginInvokeOnMainThread(() =>
		        {
		            ProgressBar.Progress = e.Progress;
		            Duration.Text = "" + e.Duration.TotalSeconds + " seconds";
		        });
		    };
        }

	    public LivePage(params object[] obj)
	    {
	        InitializeComponent();
	        BindingContext = new LiveViewModel(obj);
	        this.volumeLabel.Text = "Volume (0-" + CrossMediaManager.Current.VolumeManager.MaxVolume + ")";
	        //Initialize Volume settings to match interface
	        int.TryParse(this.volumeEntry.Text, out var vol);
	        CrossMediaManager.Current.VolumeManager.CurrentVolume = vol;
	        //CrossMediaManager.Current.VolumeManager.Muted = false;

	        CrossMediaManager.Current.PlayingChanged += (sender, e) =>
	        {
	            Device.BeginInvokeOnMainThread(() =>
	            {
	                ProgressBar.Progress = e.Progress;
	                Duration.Text = "" + e.Duration.TotalSeconds + " seconds";
	            });
	        };
        }

	    protected override void OnAppearing()
	    {
	        videoView.Source = "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4";
	    }

	    void PlayClicked(object sender, System.EventArgs e)
	    {
	        PlaybackController.Play();
	    }

	    void PauseClicked(object sender, System.EventArgs e)
	    {
	        PlaybackController.Pause();
	    }

	    void StopClicked(object sender, System.EventArgs e)
	    {
	        PlaybackController.Stop();
	    }
	    private void SetVolumeBtn_OnClicked(object sender, EventArgs e)
	    {
	        int.TryParse(this.volumeEntry.Text, out var vol);
	        CrossMediaManager.Current.VolumeManager.CurrentVolume = vol;
	    }

	    private void MutedBtn_OnClicked(object sender, EventArgs e)
	    {
	        //if (CrossMediaManager.Current.VolumeManager.Muted)
	        //{
	        //    CrossMediaManager.Current.VolumeManager.Muted = false;
	        //    mutedBtn.Text = "Mute";
	        //}
	        //else
	        //{
	        //    CrossMediaManager.Current.VolumeManager.Muted = true;
	        //    mutedBtn.Text = "Unmute";
	        //}
	    }
     //   private void Button_OnClicked(object sender, EventArgs e)
	    //{	        
	    //    if (videoPlayer.Status == VideoStatus.Playing)
	    //    {
	    //        videoPlayer.Pause();
	    //    }
	    //    else if (videoPlayer.Status == VideoStatus.Paused)
	    //    {
	    //        videoPlayer.Play();
	    //    }
	    //    else if (videoPlayer.Status == VideoStatus.NotReady)
	    //    {
	    //        videoPlayer.Play();
	    //    }	       
     //   }	    
    }
}