using System;
using System.IO;
using System.Threading.Tasks;
using Welic.App.iOS.Services;
using Welic.App.Implements.PDF.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileProvider))]

namespace Welic.App.iOS.Services
{
    public class LocalFileProvider : ILocalFileProvider
    {
        private readonly string _rootDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "pdfjs");

        public async Task<string> SaveFileToDisk(Stream stream, string fileName)
        {
            if (!Directory.Exists(_rootDir))
                Directory.CreateDirectory(_rootDir);

            var filePath = Path.Combine(_rootDir, fileName);

            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                File.WriteAllBytes(filePath, memoryStream.ToArray());
            }

            return filePath;
        }
    }
}