using EventAndDelegates.Models;
using System;
using System.Threading;

namespace EventAndDelegates.Services
{
    public class VoiceEncodingService : _BaseService<SpeakerModel>
    {
        readonly SpeakerModel _speakerModel;

        public VoiceEncodingService(SpeakerModel speakerModel) : base(speakerModel)
        {
            _speakerModel = speakerModel;
        }

        protected override void Encode()
        {
            Console.WriteLine("Encoding the voice.");
            Thread.Sleep(1000);
        }
    }
}
