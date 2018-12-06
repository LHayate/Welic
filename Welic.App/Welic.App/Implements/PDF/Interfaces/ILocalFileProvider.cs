using System.IO;
using System.Threading.Tasks;

namespace Welic.App.Implements.PDF.Interfaces
{
    public interface ILocalFileProvider
    {
        Task<string> SaveFileToDisk(Stream stream, string fileName);
    }
}