using System;
using System.Collections.Generic;
using System.Text;

namespace Welic.App.Services.VideoPlayer
{
    public enum VideoStatus
    {
        NotReady,
        Playing,
        Paused,
        Loading,
        Buffering,
        Failed
    }
}
