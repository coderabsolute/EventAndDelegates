using EventAndDelegates.Models;
using EventAndDelegates.Services;
using System;

namespace EventAndDelegates.Helpers
{
    public class EncodeVoiceHelper
    {
        public static void EncodeVoice(int speakerId, string speakerName)
        {
            var speakerModel = PrepareVoiceEncodingModel(speakerId, speakerName);

            VoiceEncodingOperation(speakerModel);
        }

        static SpeakerModel PrepareVoiceEncodingModel(int speakerId, string speakerName)
        {
            return new SpeakerModel()
            {
                SpeakerId = speakerId,
                SpeakerName = speakerName
            };
        }

        static void VoiceEncodingOperation(SpeakerModel speakerModel)
        {
            var voiceEncodingService = new VoiceEncodingService(speakerModel);

            voiceEncodingService.VideoEncoded += OnEncoded;
            voiceEncodingService.VideoEncoded += OnEncodedSendEmail;

            voiceEncodingService.Operation();
        }

        static void OnEncoded(object source, CommonEventArgs<SpeakerModel> args)
        {
            Console.WriteLine($"Voice encoding is completed for {args.Payload.SpeakerName}");
        }
        static void OnEncodedSendEmail(object source, CommonEventArgs<SpeakerModel> args)
        {
            new EmailHelper().Send($"Email sent to {args.Payload.SpeakerName}");
        }
    }
}
