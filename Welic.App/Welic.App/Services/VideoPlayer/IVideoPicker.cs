using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Welic.App.Services.VideoPlayer
{
    public interface IVideoPicker
    {
        Task<string> GetVideoFileAsync();
    }
}
