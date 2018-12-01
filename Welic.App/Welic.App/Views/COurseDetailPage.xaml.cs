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
	public partial class CourseDetailPage : ContentPage
	{
		public CourseDetailPage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<CourseDetailViewModel>();
		}
	    public CourseDetailPage(params object[] obj)
	    {
	        InitializeComponent();
	        BindingContext = new CourseDetailViewModel(obj);
	    }

	    private void ListViewStart_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        var item = (LiveDto)e.Item;

	        if (item != null)
	            (BindingContext as ListLiveViewModel)?.OpenLive(item);
        }
	}
}