using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Ebook;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListEbookPage : ContentPage
	{
		public ListEbookPage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<ListEBookViewModel>();
		}

	    private void ListViewStart_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        var item = (EbookDto)e.Item;

	        if (item != null)
	            (BindingContext as ListEBookViewModel)?.OpenBook(item);
        }
	}
}