using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Welic.App.Models.Usuario;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
#if DEBUG

#endif

namespace Welic.App.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class CreateLivePage : ContentPage
	{
        private MediaFile _mediaFile;
        
        
        public CreateLivePage ()
        {
 
            InitializeComponent();

            
		    BindingContext = ViewModelLocator.Resolve<CreateLiveViewModel>();
		  
        }

	    public CreateLivePage(params object[] obj)
	    {
            InitializeComponent();

	        BindingContext = new CreateLiveViewModel(obj);
	       
        }

	    private async  void PickFile_OnClicked(object sender, EventArgs e)
	    {
            //await CrossMedia.Current.Initialize();

            //if (!CrossMedia.Current.IsPickVideoSupported)
            //{
            //    await DisplayAlert("No PickVideo", ":( No Pick Available.", "OK");
            //}

            //_mediaFile = await CrossMedia.Current.PickVideoAsync();

            //if (_mediaFile == null)
            //    return;

    
            //PathFile.Text += $"{_mediaFile.Path.Split('/').LastOrDefault()}";
	        
	       

        }	          
    }
}