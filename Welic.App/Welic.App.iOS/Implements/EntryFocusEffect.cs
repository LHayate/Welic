using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Welic.App.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("CustomColorEffect")]
[assembly: ExportEffect(typeof(EntryFocusEffect), "EntryFocusEffect")]
namespace Welic.App.iOS
{
    public class EntryFocusEffect: PlatformEffect
    {
        readonly UIColor _color = UIColor.Blue;
        protected override void OnAttached()
        {
            this.Control.BackgroundColor = this._color;
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            if (args.PropertyName.Equals("IsFocused"))
            {
                this.Control.BackgroundColor = this.Control.BackgroundColor.Equals(this._color) ? UIColor.Gray : this._color;
            }
        }

        protected override void OnDetached(){}
    }
}