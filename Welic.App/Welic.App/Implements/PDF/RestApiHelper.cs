﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace Welic.App.Implements.PDF
{
    public static class RestApiHelper
    {
        public static async Task<MemoryStream> DownloadFileAsync(string url)
        {
            if (CrossConnectivity.Current.IsConnected == false)
            {
                return null;
            }

            try
            {
                var stream = new MemoryStream();
                using (var httpClient = new HttpClient())
                {
                    var downloadStream = await httpClient.GetStreamAsync(new Uri(url));
                    if (downloadStream != null)
                    {
                        await downloadStream.CopyToAsync(stream);
                    }
                }

                return stream;
            }
            catch (System.Exception exception)
            {
                Debug.WriteLine(exception);
                return null;
            }
        }
    }
}