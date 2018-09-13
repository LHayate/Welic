using System;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using Welic.App.Droid.Implements;
using Welic.App.Implements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryDroid))]

namespace Welic.App.Droid.Implements
{
    public class CustomEntryDroid : EntryRenderer
    {
        public CustomEntryDroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null) return;

            var view = (CustomEntry)Element;

            if (view.IsCurvedCornersEnabled)
            {
                // creating gradient drawable for the curved background
                var gradientBackground = new GradientDrawable();
                gradientBackground.SetShape(ShapeType.Rectangle);
                gradientBackground.SetColor(view.BackgroundColor.ToAndroid());

                // Thickness of the stroke line
                gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());

                // Radius for the curves
                gradientBackground.SetCornerRadius(
                    DpToPixels(Context,
                        Convert.ToSingle(view.CornerRadius)));

                // set the background of the label
                Control.SetBackground(gradientBackground);
            }

            // Set padding for the internal text from border
            Control.SetPadding(10, 2, 10, 2);
        }
        public static float DpToPixels(Context context, float valueInDp)
        {
            var metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}