﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Welic.App.Services.VideoPlayer
{
    public class FileVideoSource : VideoSource
    {
        public static readonly BindableProperty FileProperty =
            BindableProperty.Create(nameof(File), typeof(string), typeof(FileVideoSource));

        public string File
        {
            set => SetValue(FileProperty, value);
            get => (string)GetValue(FileProperty);
        }
    }
}
