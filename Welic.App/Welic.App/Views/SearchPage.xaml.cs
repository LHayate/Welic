using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.App.ViewModels;
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
		    BindingContext = new SearchViewModel();
        }
	    void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        ((ListView)sender).SelectedItem = null;
	    }

	    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {	      
	    }
    }
}