using System.ComponentModel;
using Welic.App.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ResolutionGroupName("CustomColorEffect")]
[assembly: ExportEffect(typeof(EntryFocusEffect), "EntryFocusEffect")]
namespace Welic.App.Droid
{
    public class EntryFocusEffect :PlatformEffect
    {
        private readonly Android.Graphics.Color _color = Color.Blue;
        protected override void OnAttached()
        {
            this.Control.SetBackgroundColor(this._color);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            if (args.PropertyName.Equals("IsFocused"))
            {
                var background = (Android.Graphics.Drawables.ColorDrawable)this.Control.Background;
                if (background.Color == this._color)                
                    this.Control.SetBackgroundColor(Android.Graphics.Color.AliceBlue);
                else
                    this.Control.SetBackgroundColor(Android.Graphics.Color.Blue);

            }
        }

        protected override void OnDetached()
        {           
        }
    }
}