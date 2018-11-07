using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Welic.App.Models.Live;
using Welic.App.Models.Usuario;
using Welic.App.Services.API;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateLivePage : ContentPage
	{
	    private MediaFile _mediaFile;
	    private string path;
        public CreateLivePage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<CreateLiveViewModel>();
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

	    private async void Creat_Upload_OnClicked(object sender, EventArgs e)
	    {
            //try
            //{
            //    var content = new MultipartFormDataContent();

            //    content.Add(new StreamContent(_mediaFile.GetStream()),
            //        "\"file\"",
            //        $"\"{_mediaFile.Path}\"");

            //    await WebApi.Current.PostAsync("uploads/files", content);

            //}
            //catch (System.Exception exception)
            //{
            //    Console.WriteLine(exception);
            //    await DisplayAlert("Erro", "Erro ao criar", "OK");
            //}
        }
    }
}