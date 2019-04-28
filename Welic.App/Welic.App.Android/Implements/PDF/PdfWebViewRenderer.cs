﻿using System;
using System.ComponentModel;
using Android.Content;
using Android.Print;
using Android.Webkit;
using Welic.App.Droid.Implements.PDF;
using Welic.App.Implements.PDF;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using WebView = Xamarin.Forms.WebView;

[assembly: ExportRenderer(typeof(PdfWebView), typeof(PdfWebViewRenderer))]
namespace Welic.App.Droid.Implements.PDF
{
    public class PdfWebViewRenderer : WebViewRenderer
    {
        public PdfWebViewRenderer(Context context) : base(context)
        {
        }

        internal class PdfWebChromeClient : WebChromeClient
        {
            public override bool OnJsAlert(Android.Webkit.WebView view, string url, string message, JsResult result)
            {
                if (message != "PdfViewer_app_scheme:print")
                {
                    return base.OnJsAlert(view, url, message, result);
                }

                using (var printManager = Forms.Context.GetSystemService(Android.Content.Context.PrintService) as PrintManager)
                {
                    printManager?.Print(FileName, new FilePrintDocumentAdapter(FileName, Uri), null);
                }

                return true;
            }

            public string Uri { private get; set; }

            public string FileName { private get; set; }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            var pdfView = Element as PdfWebView;

            if (pdfView == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(pdfView.Uri) == false)
            {
                Control.SetWebChromeClient(new PdfWebChromeClient
                {
                    Uri = pdfView.Uri,
                    FileName = GetFileNameFromUri(pdfView.Uri)
                });
            }

            Control.Settings.AllowFileAccess = true;
            Control.Settings.AllowUniversalAccessFromFileURLs = true;
            LoadFile(pdfView.Uri);
        }
        private static string GetFileNameFromUri(string uri)
        {
            var lastIndexOf = uri?.LastIndexOf("/", StringComparison.InvariantCultureIgnoreCase);
            return lastIndexOf > 0 ? uri.Substring(lastIndexOf.Value, uri.Length - lastIndexOf.Value) : string.Empty;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName != PdfWebView.UriProperty.PropertyName)
            {
                return;
            }

            var pdfView = Element as PdfWebView;

            if (pdfView == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(pdfView.Uri) == false)
            {
                Control.SetWebChromeClient(new PdfWebChromeClient
                {
                    Uri = pdfView.Uri,
                    FileName = GetFileNameFromUri(pdfView.Uri)
                });
            }

            LoadFile(pdfView.Uri);
        }

        private void LoadFile(string uri)
        {
            if (string.IsNullOrWhiteSpace(uri))
            {
                return;
            }
            Control.LoadUrl($"file:///android_asset/pdfjs/web/viewer.html?file=file://{uri}");
        }
    }
}