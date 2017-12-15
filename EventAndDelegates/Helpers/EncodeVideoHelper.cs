using EventAndDelegates.Models;
using EventAndDelegates.Services;
using System;

namespace EventAndDelegates.Helpers
{
    public class EncodeVideoHelper
    {
        public static void EncodeVideo(int videoId, string videoName)
        {
            var videoModel = PrepareVideoEncodingModel(videoId, videoName);

            VideoEncodingOperation(videoModel);
        }

        static VideoModel PrepareVideoEncodingModel(int videoId, string videoName)
        {
            return new VideoModel()
            {
                VideoId = videoId,
                VideoName = videoName
            };
        }
        static void VideoEncodingOperation(VideoModel videoModel)
        {
            var videoEncoder = new VideoEncodingService(videoModel);

            videoEncoder.VideoEncoded += OnEncoded;
            videoEncoder.VideoEncoded += OnEncodedSendEmail;
            videoEncoder.VideoEncoded += OnEncodedSendSMS;
            videoEncoder.VideoEncoded += OnEncodedLogAudit;

            videoEncoder.Operation();
        }

        static void OnEncoded(object source, CommonEventArgs<VideoModel> args)
        {
            Console.WriteLine($"Video encoding is completed for {args.Payload.VideoName}");
        }
        static void OnEncodedSendEmail(object source, CommonEventArgs<VideoModel> args)
        {
            new EmailHelper().Send($"Email sent about the {args.Payload.VideoName}");
        }
        static void OnEncodedSendSMS(object source, CommonEventArgs<VideoModel> args)
        {
            new SMSHelper().Send($"SMS sent about the {args.Payload.VideoName}");
        }
        static void OnEncodedLogAudit(object source, CommonEventArgs<VideoModel> args)
        {
            new AuditLogHelper().Send($"Log audited for the {args.Payload.VideoName}");
        }
    }
}
