using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Live;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListLivePage : ContentPage
	{
		public ListLivePage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<ListLiveViewModel>();		   
		}


	    private void ListViewStart_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        var item = (LiveDto)e.Item;

            if(item != null)
                (BindingContext as ListLiveViewModel)?.OpenLive(item);
	    }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	       
	        //ListViewStart.SendRefreshing();
	    }
	}
}