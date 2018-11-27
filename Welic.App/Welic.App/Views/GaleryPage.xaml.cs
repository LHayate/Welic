using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Welic.App.Models.Galery;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GaleryPage : ContentPage
	{
		public GaleryPage ()
		{
			InitializeComponent ();
		}
	    protected override async void OnAppearing()
	    {
	        base.OnAppearing();

	        var images = await GetImageListAsync();
	        foreach (var photo in images.Photos)
	        {
	            var image = new Image
	            {
	                Source = ImageSource.FromUri(new Uri(photo + string.Format("?width={0}&height={0}&mode=max", Device.RuntimePlatform == Device.UWP ? 120 : 240)))
	            };
	            wrapLayout.Children.Add(image);
	        }
	    }
	    async Task<ImageList> GetImageListAsync()
	    {
	        var requestUri = "https://docs.xamarin.com/demo/stock.json";
	        using (var client = new HttpClient())
	        {
	            var result = await client.GetStringAsync(requestUri);
	            return JsonConvert.DeserializeObject<ImageList>(result);
	        }
	    }
    }
}