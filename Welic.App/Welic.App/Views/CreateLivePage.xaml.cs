using System;
using System.Collections.Generic;
using Plugin.Media.Abstractions;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateLivePage : ContentPage
	{	        
	   
	    bool isBusya = false;
        public CreateLivePage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<CreateLiveViewModel>();
		  
        }

	    public CreateLivePage(params object[] obj)
	    {
	        InitializeComponent();
	        BindingContext = new CreateLiveViewModel(obj);
	       
        }

	    private async  void PickFile_OnClicked(object sender, EventArgs e)
	    {
         //   await CrossMedia.Current.Initialize();

         //   if (!CrossMedia.Current.IsPickVideoSupported)
         //   {
         //       await DisplayAlert("No PickVideo", ":( No Pick Available.", "OK");
         //   }

         //   _mediaFile = await CrossMedia.Current.PickVideoAsync();

         //   if (_mediaFile == null)
         //       return;

	        //var user = new UserDto().LoadAsync();
         //   path = $"\"{user.FirstName}_{user.LastName}\"{_mediaFile.Path.Split('/').LastOrDefault()}\"";
         //   PathFile.Text += _mediaFile.Path;

        }	          
    }
}