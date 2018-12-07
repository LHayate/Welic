using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Schedule;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListSchedulePage : ContentPage
	{
		public ListSchedulePage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<ListScheduleViewModel>();
		}

	    private void ListViewStart_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        var item = (ScheduleDto)e.Item;

	        if (item != null)
	            (BindingContext as ListScheduleViewModel)?.OpenSchedule(item);
        }
	    protected override void OnAppearing()
	    {
	        base.OnAppearing();

	        //(BindingContext as ListScheduleViewModel)?.SetListSchedule();
	        ListViewStart.SendRefreshing();

	    }
    }
}