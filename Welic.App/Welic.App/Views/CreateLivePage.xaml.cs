using System;
using System.Collections.Generic;
using Plugin.FileUploader;
using Plugin.FileUploader.Abstractions;
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
		    CrossFileUploader.Current.FileUploadCompleted += Current_FileUploadCompleted;
		    CrossFileUploader.Current.FileUploadError += Current_FileUploadError;
		    CrossFileUploader.Current.FileUploadProgress += Current_FileUploadProgress;
        }

	    public CreateLivePage(params object[] obj)
	    {
	        InitializeComponent();
	        BindingContext = new CreateLiveViewModel(obj);
	        CrossFileUploader.Current.FileUploadCompleted += Current_FileUploadCompleted;
	        CrossFileUploader.Current.FileUploadError += Current_FileUploadError;
	        CrossFileUploader.Current.FileUploadProgress += Current_FileUploadProgress;
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

	  
        private void Current_FileUploadProgress(object sender, FileUploadProgress e)
	    {
	        Device.BeginInvokeOnMainThread(() =>
	        {                
	            progress.Progress = e.Percentage / 100.0f;
	        });
	    }

	    private void Current_FileUploadError(object sender, FileUploadResponse e)
	    {
	        isBusya = false;
	        System.Diagnostics.Debug.WriteLine($"{e.StatusCode} - {e.Message}");
	        Device.BeginInvokeOnMainThread(async () =>
	        {
	            await DisplayAlert("File Upload", "Upload Failed", "Ok");
	            progress.IsVisible = false;
	            progress.Progress = 0.0f;
	        });
	    }

	    private void Current_FileUploadCompleted(object sender, FileUploadResponse e)
	    {
	        isBusya = false;
	        System.Diagnostics.Debug.WriteLine($"{e.StatusCode} - {e.Message}");
	        Device.BeginInvokeOnMainThread(async () =>
	        {
	            await DisplayAlert("File Upload", "Upload Completed", "Ok");
	            progress.IsVisible = false;
	            progress.Progress = 0.0f;
	        });
	    }
    }
}