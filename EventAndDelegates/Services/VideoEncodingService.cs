using EventAndDelegates.Models;
using System;
using System.Threading;

namespace EventAndDelegates.Services
{
    public class VideoEncodingService : _BaseService<VideoModel>
    {
        readonly VideoModel _videoModel;

        public VideoEncodingService(VideoModel videoModel) : base(videoModel)
        {
            _videoModel = videoModel;
        }

        protected override void Encode()
        {
            Console.WriteLine("Encoding the video.");
            Thread.Sleep(1000);
        }
    }
}
