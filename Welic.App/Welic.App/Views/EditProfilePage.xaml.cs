﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Welic.App.Models.Usuario;
using Welic.App.Services;
using Welic.App.Services.ResizePcture;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditProfilePage : ContentPage
	{
	    
	    private UserDto _userdto;
		public EditProfilePage ()
		{
			InitializeComponent ();
            BindingContext = ViewModelLocator.Resolve<EditProfileViewModel>();
            
		}
	    

	    private async  void Button_OnClicked(object sender, EventArgs e)
	    {
	        try
	        {
	            await CrossMedia.Current.Initialize();

	            if (!CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable)
	            {
	                await App.Current.MainPage.DisplayAlert("Ops", "Nenhuma câmera detectada.", "OK");

	                return;
	            }

	            var file = await CrossMedia.Current.TakePhotoAsync(
	                new StoreCameraMediaOptions
	                {
	                    Directory = "Resources",
	                    Name = "Perfil.png",
	                    PhotoSize = PhotoSize.Small,
	                    CompressionQuality = 50,
	                    DefaultCamera = CameraDevice.Front,
	                    AllowCropping = true,
                    });

	            if (file == null)
	                return;

                await (new UserDto()).RegisterPhoto(file);

                CircleImage.Source = ImageSource.FromStream(() =>
	            {
	                var stream = file.GetStream();
	                file.Dispose();
	                return stream;
	            });
	        }
	        catch (System.Exception ex)
	        {
	            await App.Current.MainPage.DisplayAlert("Ops", "Erro ao Tentar abrir a camera." + ex.Message, "OK");
	        }
        }
	}
}