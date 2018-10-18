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
	}
}