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
                await (BindingContext as SearchViewModel)?.Search(searchBar.Text);
            else
                await (BindingContext as SearchViewModel)?.ClearSearch();
        }
	}
}