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
	public partial class CreateEbookPage : ContentPage
	{
		public CreateEbookPage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<CreateEbookViewModel>();
		}

	    public CreateEbookPage(params object[] obj)
	    {
	        InitializeComponent();
	        BindingContext = new  CreateEbookViewModel(obj);
	    }
	}
}