using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Welic.App.Implements
{
    public class CustomDescriptionLabel : Label
    {
        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create(
                nameof(MaxLength), 
                typeof(int), 
                typeof(CustomDescriptionLabel), 
                100);

        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TextProperty.PropertyName)
            {
                if (Text?.Length > MaxLength)
                {
                    Text = $"{Text.Substring(0, (MaxLength - 15) < 0 ? 10 : MaxLength - 15)} " +
                           $"     ...Leia Mais";
                }
            }

        }
    }
}
