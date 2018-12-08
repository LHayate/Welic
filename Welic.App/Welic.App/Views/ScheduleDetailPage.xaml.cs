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
	public partial class ScheduleDetailPage : ContentPage
	{
		public ScheduleDetailPage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<ScheduleDetailViewModel>();
		}
	    public ScheduleDetailPage(params object[] obj)
	    {
	        InitializeComponent();
	        BindingContext = new ScheduleDetailViewModel(obj);
	    }	    

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        (BindingContext as ScheduleDetailViewModel)?.LoadTela();
        }
	}
}