﻿using System;
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
	public partial class ListNewsPage : ContentPage
	{
		public ListNewsPage ()
		{
			InitializeComponent ();
		    BindingContext = ViewModelLocator.Resolve<ListNewsViewModel>();
		}
	}
}