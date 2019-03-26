using System;
using Android.App;
using Android.Content;
using Newtonsoft.Json.Linq;
using Welic.App.Droid;
using Welic.App.Models.Usuario;
using Welic.App.Views;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginExternoPage), typeof(LoginPageRenderer))]
namespace Welic.App.Droid
{
    public class LoginPageRenderer : PageRenderer
    {        
        public LoginPageRenderer(Context context) :base(context)
        {
            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: "2151075064975934", // your OAuth2 client id
                scope: "", // the scopes for the particular API you're accessing, delimited by "+" symbols
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

            auth.Completed += async (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated)
                {
                    var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                    var expiresIn = Convert.ToDouble(eventArgs.Account.Properties["expires_in"]);
                    var expiryDate = DateTime.Now + TimeSpan.FromSeconds(expiresIn);

                    var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, eventArgs.Account);
                    var response = await request.GetResponseAsync();
                    var obj = JObject.Parse(response.GetResponseText());

                    var id = obj["id"].ToString().Replace("\"", "");
                    var name = obj["name"].ToString().Replace("\"", "");
                    var email = obj["email"].ToString().Replace("\"", "");

                    UserDto userDto = new UserDto
                    {
                        RememberMe = true,
                        Email = email,
                        NickName = name,

                    };
                    await App.NavigateToProfile(userDto);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Login", "Usuário Cancelou o login", "OK");
                }
            };

            activity?.StartActivity(auth.GetUI(activity));
        }
    }
}