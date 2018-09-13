

using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Welic.App.Implements;
using Welic.App.UWP.Implements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms.Xaml;


[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryUwp))]
namespace Welic.App.UWP.Implements
{
    public class CustomEntryUwp : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            //if (e.NewElement == null) return;


            //var view = (CustomEntry)Element;

            //if (view.IsCurvedCornersEnabled)
            //{
            //    // creating gradient drawable for the curved background
            //    var gradientBackground = new GradientBrush();

            //    gradientBackground. (Rectangle);              
        }

    }
}
