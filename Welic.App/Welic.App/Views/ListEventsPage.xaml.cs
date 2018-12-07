using Welic.App.Models.Schedule;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListEventsPage : ContentPage
	{
		public ListEventsPage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<ListEventsViewModel>();
		}
	    private void ListViewStart_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        var item = (ScheduleDto)e.Item;

	        if (item != null)
	            (BindingContext as ListEventsViewModel)?.OpenSchedule(item);
	    }
    }
}