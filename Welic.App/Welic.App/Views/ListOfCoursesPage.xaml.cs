using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Course;
using Welic.App.Models.Live;
using Welic.App.ViewModels;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Welic.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfCoursesPage : ContentPage
    {
        public ListOfCoursesPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.Resolve<ListOfCoursesViewModel>();

           
        }       

        private void ListViewStart_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (CourseDto)e.Item;

            if (item != null)
                (BindingContext as ListOfCoursesViewModel)?.OpenCourse(item);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ListViewStart.SendRefreshing();
        }
    }
}
