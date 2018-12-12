using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
		public SearchPage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<SearchViewModel>();// new SearchViewModel();
            
        }
	    void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        ((ListView)sender).SelectedItem = null;
	    }

	    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {	      
	    }


	    private async void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
	    {
	        if (this.searchBar.Text.Length > 2)
	        {
	            GetCursos(searchBar.Text);
	            await (BindingContext as SearchViewModel)?.Search(searchBar.Text);
            }

	        else
	        {
	            await (BindingContext as SearchViewModel)?.ClearSearch();
	            StackGallery.Children.Clear();
            }
                

        }
	    private async void GetCursos(string text)
	    {
	        try
	        {
	            var listcouse = await (BindingContext as SearchViewModel)?.SearchCursos(text);

	            if (listcouse != null && listcouse.Count > 0)
	            {
	                foreach (var item in listcouse)
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
	                        { Source = ImageSource.FromUri(new Uri(item.Image?? "https://welic.app/arquivos/icons/iIPathCourse.png")), HeightRequest = 150, WidthRequest = 150 };
	                    var lblNome = new Label
	                    {
	                        Text = item.Name,
	                        HorizontalOptions = LayoutOptions.End,
	                        VerticalOptions = LayoutOptions.Center,
	                        HeightRequest = 15
	                    };
	                    var btnLive = new Button { BackgroundColor = Color.Transparent };

	                    grid.Children.Add(img, 0, 0);
	                    grid.Children.Add(lblNome, 0, 1);

	                    StackGallery.Children.Add(grid);
	                }
	            }
	            else
	            {
	                var lblNome = new Label { Text = "Nenhum Curso Encontrado :(" };
	                StackGallery.Children.Add(lblNome);
	            }
            }
	        catch (System.Exception e)
	        {
	            Console.WriteLine(e);
	            var lblNome = new Label { Text = "Nenhum Curso Encontrado :(" };
	            StackGallery.Children.Add(lblNome);
            }
	        
	    }
    }
}