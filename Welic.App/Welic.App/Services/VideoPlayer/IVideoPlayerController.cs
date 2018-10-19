using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Welic.App.Services.VideoPlayer
{
    public interface IVideoPlayerController
    {
        VideoStatus Status { set; get; }

        TimeSpan Duration { set; get; }  

        /// <summary>
        /// Plays the current MediaFile
        /// </summary>
        void Play();

        /// <summary>
        /// Pauses the current MediaFile
        /// </summary>
        void Pause();

        /// <summary>
        /// Stops playing
        /// </summary>
        void Stop();      
    }
}
