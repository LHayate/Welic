using System;
using System.Collections.Generic;
using System.Text;

namespace Welic.App.Services.VideoPlayer
{
    public interface IVideoPlayerController
    {
        VideoStatus Status { set; get; }

        TimeSpan Duration { set; get; }
    }
}
