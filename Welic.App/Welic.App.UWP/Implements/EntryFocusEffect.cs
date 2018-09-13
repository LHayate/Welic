using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Welic.App.UWP.Implements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("CustomColorEffect")]
[assembly: ExportEffect(typeof(EntryFocusEffect), "EntryFocusEffect")]
namespace Welic.App.UWP.Implements
{
    public class EntryFocusEffect : PlatformEffect
    {
        //readonly  _color = UIColor.Blue;
        protected override void OnAttached()
        {
            var control = this.Control as Windows.UI.Xaml.Controls.Control;
            var textbox = this.Control as FormsTextBox;

            control.Background = new SolidColorBrush(Colors.Blue);
            textbox.BackgroundFocusBrush = new SolidColorBrush(Colors.Aqua);

        }

        protected override void OnDetached() { }
    }
}
