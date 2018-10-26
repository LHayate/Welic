using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json.Linq;
using Welic.App.Models.Usuario;
using Welic.App.UWP;
using Welic.App.Views;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace Welic.App.UWP
{
    public class LoginPageRenderer : PageRenderer
    {
        private Windows.UI.Xaml.Controls.Frame _frame;
        private bool _isShown;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
        {
            base.OnElementChanged(e);

            if (_isShown) return;
            _isShown = true;

            if (Control == null)
            {
                WindowsPage windowsPage = new WindowsPage();

                var auth = new OAuth2Authenticator(
                    clientId: "someID",
                    scope: "",
                    authorizeUrl: new Uri("https://oauth.vk.com/authorize"),
                    redirectUrl: new Uri("https://oauth.vk.com/blank.html"));

                _frame = windowsPage.Frame;
                if (_frame == null)
                {
                    _frame = new Windows.UI.Xaml.Controls.Frame();
                    //_frame.Language = global::Windows.Globalization.ApplicationLanguages.Languages[0];

                    windowsPage.Content = _frame;
                    SetNativeControl(windowsPage);
                }

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

                        await Welic.App.App.NavigateToProfile(userDto);
                        //AuthInfo.Token = eventArgs.Account.Properties["access_token"].ToString();
                        //AuthInfo.UserID = eventArgs.Account.Properties["user_id"].ToString();
                    }
                    else
                    {
                        // The user cancelled
                    }
                };

                Type pageType = auth.GetUI();
                _frame.Navigate(pageType, auth);
                Window.Current.Activate();
            }
        }
    }
}
