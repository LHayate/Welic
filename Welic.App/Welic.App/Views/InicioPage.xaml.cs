using System;
using System.Collections.Generic;
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

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        if (ViewModel != null)
	        {
	            //Verifica se o dispositivo já está registrado e habilitado
                var usuario = ViewModel.LoadAsync();
	            if (usuario)
	                App.Current.MainPage = new MainPage();
	        }
        }
	}
}