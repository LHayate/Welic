using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Implements.PDF.Interfaces;
using Welic.App.Models.Ebook;
using Welic.App.ViewModels.Base;
using Xamarin.Forms;

namespace Welic.App.ViewModels
{
    public class EbookViewModel: BaseViewModel
    {
        private string _urlPdf;

        public string UrlPdf
        {
            get => _urlPdf;
            set => SetProperty(ref _urlPdf, value);
        }


        public EbookViewModel(params object[] obj)
        {
            var book = (EbookDto)obj[0];

            if (book != null)
            {
                var localPath = string.Empty;
                if (Device.RuntimePlatform == Device.Android)
                {
                    var dependency = DependencyService.Get<ILocalFileProvider>();

                    if (dependency == null)
                    {
                        MessageService.ShowOkAsync("Error loading PDF", "Computer says no", "OK");

                        return;
                    }

                    var fileName = Guid.NewGuid().ToString();

                   
                        //// Download PDF locally for viewing
                        using (var httpClient = new HttpClient())
                        {
                            try
                            {

                                using (MemoryStream mem = new MemoryStream())
                                {
                                    ConvertToStream(book.UrlDestino, mem);
                                    mem.Seek(0, SeekOrigin.Begin);

                                    localPath =
                                        Task.Run(() => dependency.SaveFileToDisk(mem, $"{fileName}.pdf")).Result;

                            }
                            //var pdfStream = Task.Run(() => httpClient.GetStreamAsync(book.UrlDestino)).Result;

                            
                            }
                            catch (System.Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                    }

                        if (string.IsNullOrWhiteSpace(localPath))
                        {
                            MessageService.ShowOkAsync("Error loading PDF", "Computer says no", "OK");

                            return;
                        }
                    
                    
                }

                if (Device.RuntimePlatform == Device.Android)
                    UrlPdf = 
                        $"file:///android_asset/pdfjs/web/viewer.html?file={WebUtility.UrlEncode(localPath)}";
                else
                    UrlPdf = book.UrlDestino;
            }
            else
            {
                NavigationService.ReturnModalToAsync(true);
            }
        }
        private static void ConvertToStream(string fileUrl, Stream stream)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fileUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            try
            {
                Stream response_stream = response.GetResponseStream();

                response_stream.CopyTo(stream, 4096);
            }
            finally
            {
                response.Close();
            }
        }
    }
}
