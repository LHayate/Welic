using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Newtonsoft.Json;
using Welic.App.Models.Galery;
using Welic.App.Models.Live;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
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
		    BindingContext = ViewModelLocator.Resolve<GaleryViewModel>();
		    PreecheTela();
        }

	    private async void PreecheTela()
	    {
            try
            {
                //TODO: Resolver para pegar os videos 
                GetVideosTeacher();

                //Get dados para a scroll view de Recentes
                GetRecentes();

                //GET para Scroll View de Favoritos
                GetFavoritos();
                
            }
            catch (AppCenterException e)
            {
                DisplayAlert("Erro", e.Message, "OK");                
            }
	        
        }

	    private async  void GetFavoritos()
	    {
	        var listFavorites = await(BindingContext as GaleryViewModel)?.GetListFavorite();

	        if (listFavorites != null &&   listFavorites.Count > 0)
	        {
	            foreach (var item in listFavorites)
	            {
	                var grid = new Grid
	                {
	                    RowDefinitions =
	                    {
	                        new RowDefinition {Height = 100},
	                        new RowDefinition {Height = 15},
	                    },
	                    ColumnDefinitions =
	                    {
	                        new ColumnDefinition {Width = 100}
	                    }
	                };

	                var img = new Image {Source = ImageSource.FromUri(new Uri(item.Print))};
	                var lblNome = new Label {Text = item.Title};

	                grid.Children.Add(img, 0, 0);
	                grid.Children.Add(lblNome, 0, 1);

	                FavoritesGallery.Children.Add(grid);
	            }
	        }
	        else
	        {
	            var lblNome = new Label { Text = "Nenhum Favorito :(" };
                FavoritesGallery.Children.Add(lblNome);
            }
	    }

	    private async void GetRecentes()
	    {
	        var listRecentes = await (BindingContext as GaleryViewModel)?.GetListRecente();

	        if (listRecentes != null && listRecentes.Count > 0)
	        {
	            foreach (var item in listRecentes)
	            {
	                var grid = new Grid
	                {
	                    RowDefinitions =
	                    {
	                        new RowDefinition {Height = 100},
	                        new RowDefinition {Height = 15},
	                    },
	                    ColumnDefinitions =
	                    {
	                        new ColumnDefinition {Width = 100}
	                    }
	                };

	                var img = new Image
	                    {Source = ImageSource.FromUri(new Uri(item.Print)), HeightRequest = 150, WidthRequest = 150};
	                var lblNome = new Label
	                {
	                    Text = item.Title, HorizontalOptions = LayoutOptions.End,
	                    VerticalOptions = LayoutOptions.Center, HeightRequest = 15
	                };
	                var btnLive = new Button {BackgroundColor = Color.Transparent};

	                grid.Children.Add(img, 0, 0);
	                grid.Children.Add(lblNome, 0, 1);

	                StackGallery.Children.Add(grid);
	            }
	        }
	        else
	        {
	            var lblNome = new Label { Text = "Nenhum Favorito :(" };
	            StackGallery.Children.Add(lblNome);
            }
	    }

	    private async void GetVideosTeacher()
	    {
	       
            //var images = await GetImageListAsync();
            //foreach (var photo in images.Photos)
            //{
            //    var image = new Image
            //    {
            //        Source = ImageSource.FromUri(new Uri(photo + string.Format("?width={0}&height={0}&mode=max", Device.RuntimePlatform == Device.UWP ? 120 : 240)))
            //    };
            //    wrapLayout.Children.Add(image);
            //}

            //var listRecentes = await (BindingContext as GaleryViewModel)?.GetListTeacher();

            //foreach (var item in listRecentes)
            //{
            //    var grid = new Grid
            //    {
            //        RowDefinitions =
            //        {
            //            new RowDefinition { Height = 100 },
            //            new RowDefinition { Height = 15 },
            //        },
            //        ColumnDefinitions =
            //        {
            //            new ColumnDefinition { Width = 100 }
            //        }
            //    };

            //    var img = new Image { Source = ImageSource.FromUri(new Uri(item.Print)), HeightRequest = 150, WidthRequest = 150 };
            //    var lblNome = new Label { Text = item.Title, HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Center, HeightRequest = 15 };
            //    var btnLive = new Button { BackgroundColor = Color.Transparent };

            //    grid.Children.Add(img, 0, 0);
            //    grid.Children.Add(lblNome, 0, 1);

            //    wrapLayout.Children.Add(grid); 
            //}
        }

	    protected override async void OnAppearing()
	    {
	        base.OnAppearing();	        
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
        private void RecentesCarouselView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        var item = (LiveDto)e.SelectedItem;

	        if (item != null)
	            (BindingContext as GaleryViewModel)?.OpenLive(item);
        }
	}
}