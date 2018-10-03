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
    public partial class HomePage : TabbedPage
    {
        public HomePage ()
        {
            InitializeComponent();
            BarBackgroundColor = Color.FromHex("#DFDDDD");
            
            try
            {
                BindingContext = ViewModelLocator.Resolve<HomeViewModel>();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}