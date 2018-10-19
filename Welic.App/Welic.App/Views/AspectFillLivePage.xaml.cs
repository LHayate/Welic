using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Services.VideoPlayer;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AspectFillLivePage : ContentPage
	{
		public AspectFillLivePage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<AspectFillLiveViewModel>();
        }

	    public AspectFillLivePage (params object[] args)
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<AspectFillLiveViewModel>();

		    videoPlayer.Source = (VideoSource) args[0];

            this.OnSizeAllocated(this.Height, this.Width);
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