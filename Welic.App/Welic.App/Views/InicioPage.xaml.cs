using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Welic.App.Models.Usuario;
using Welic.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using View = Android.Views.View;

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

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        if (ViewModel != null)
	        {
	            //Verifica se o dispositivo já está registrado e habilitado
                
	            //var temLeitor = CrossFingerprint.Current.GetAvailabilityAsync();

             //   if (temLeitor.Result != FingerprintAvailability.Unknown)
	            //{
	            //    if (ViewModel.ValidaBiometric())
	            //    {
	                    
	            //        if (ValidaFingerprint().Result.Authenticated)
	            //        {
	            //            (BindingContext as LoginViewModel)?.Login();	                                                 
	            //        }
	            //    }
	            //    else
	            //    {
	            //        var usuario = ViewModel.LoadAsync();
	            //        if (usuario)
	            //            App.Current.MainPage = new MainPage();
             //       }
             //   }
             //   else
             //   {
                    var usuario = ViewModel.LoadAsync();
                    if (usuario)
                        App.Current.MainPage = new MainPage();
                //}

	           
	        }
        }

	    private async Task<FingerprintAuthenticationResult> ValidaFingerprint()
	    {
	        return await CrossFingerprint.Current.AuthenticateAsync("É você mesmo?");
        }
	}
}