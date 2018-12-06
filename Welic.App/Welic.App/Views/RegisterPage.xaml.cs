using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Welic.App.Models.Usuario;
using Welic.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		    BindingContext = new RegisterViewModel();
		}

	    //private async void Button_OnClicked(object sender, EventArgs e)
	    //{
	    //    try
	    //    {
	    //        await CrossMedia.Current.Initialize();

	    //        if (!CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable)
	    //        {
	    //            await App.Current.MainPage.DisplayAlert("Ops", "Nenhuma câmera detectada.", "OK");

	    //            return;
	    //        }

	    //        var file = await CrossMedia.Current.TakePhotoAsync(
	    //            new StoreCameraMediaOptions
	    //            {
	    //                Directory = "Resources",
	    //                Name = "Perfil.png",
	    //                PhotoSize = PhotoSize.Small,
	    //                CompressionQuality = 50,
	    //                DefaultCamera = CameraDevice.Front,
	    //                AllowCropping = true,
	    //            });

	    //        if (file == null)
	    //            return;	            

	    //        CircleImage.Source = ImageSource.FromStream(() =>
	    //        {
	    //            var stream = file.GetStream();
	    //            file.Dispose();
	    //            return stream;
	    //        });
	    //    }
	    //    catch (System.Exception ex)
	    //    {
	    //        await App.Current.MainPage.DisplayAlert("Ops", "Erro ao Tentar abrir a camera." + ex.Message, "OK");
	    //    }
	    //}
    }
}