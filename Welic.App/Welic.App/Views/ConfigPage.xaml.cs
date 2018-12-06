using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Fingerprint;
using Welic.App.Models.Config;
using Welic.App.Models.Usuario;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfigPage : ContentPage
	{
		public ConfigPage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<ConfigViewModel>();

		    //btnAutenticar.Clicked += async (sender, e) => {

		    //    var result = await CrossFingerprint.Current.AuthenticateAsync("É você mesmo?");
		    //    if (result.Authenticated)
		    //    {
		    //        lbAutenticado.Text = "Autenticado!";
		    //    }
		    //    else
		    //    {
		    //        lbAutenticado.Text = "Atenção: Este app esta sendo roubado ligue imediatamente para carsystem";
		    //    }

		    //};
        }

	    private async void Handle_Toggled(object sender, ToggledEventArgs e)
	    {
	        var result = await CrossFingerprint.Current.AuthenticateAsync("É você mesmo?");

	        var user = new UserDto().LoadAsync();
	        var config = new ConfigDto();
	        config.Biometria = true;
	        config.UserId = user.Id;

	        config.CreateConfig(config);
        }
	}
}