using System;
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
        public LivePage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<LiveViewModel>();		   
        }
	    public LivePage(params object[] obj)
	    {
	        InitializeComponent();
	        BindingContext = new LiveViewModel(obj);	       
	    }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (videoPlayer.Status == VideoStatus.Playing)
            {
                videoPlayer.Pause();
            }
            else if (videoPlayer.Status == VideoStatus.Paused)
            {
                videoPlayer.Play();
            }
            else if (videoPlayer.Status == VideoStatus.NotReady)
            {
                videoPlayer.Play();
            }
        }

    }
}