using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Welic.App.Models.Usuario;
using Welic.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InicioPage : ContentPage
	{
	    private InicioViewModel ViewModel => BindingContext as InicioViewModel;
        public InicioPage ()
		{
			InitializeComponent ();
		    BindingContext = new InicioViewModel();
		}

	    protected async override void OnAppearing()
	    {
	        base.OnAppearing();
	        if (ViewModel != null)
	        {
	            
	           
	        }
        }

	    private async Task<FingerprintAuthenticationResult> ValidaFingerprint()
	    {
	        return await CrossFingerprint.Current.AuthenticateAsync("É você mesmo?");
        }
	}
}
