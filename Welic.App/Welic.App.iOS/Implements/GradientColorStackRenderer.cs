using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;
using Welic.App.Implements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Welic.App.iOS.Implements
{
    public class GradientColorStackRenderer : VisualElementRenderer<StackLayout>
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            GradientColorStack  button = (GradientColorStack)this.Element;
            CGColor startColor = button.StartColor.ToCGColor();

            CGColor endColor = button.EndColor.ToCGColor();

            #region for Vertical Gradient

            var gradientLayer = new CAGradientLayer();

            #endregion

            #region for Horizontal Gradient

            //var gradientLayer = new CAGradientLayer()
            //{
            //  StartPoint = new CGPoint(0, 0.5),
            //  EndPoint = new CGPoint(1, 0.5)
            //};

            #endregion

            gradientLayer.Frame = rect;
            gradientLayer.Colors = new CGColor[] { startColor, endColor
            };

            NativeView.Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}
