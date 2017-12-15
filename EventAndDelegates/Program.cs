using EventAndDelegates.Helpers;
using System;

namespace EventAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            EncodeVideoHelper.EncodeVideo(12, "Facebook Video");
            EncodeVoiceHelper.EncodeVoice(90, "Mr. Xyz");

            HappyEnding();
        }

        static void HappyEnding()
        {
            Console.WriteLine("");
            Console.WriteLine("***********************");
            Console.WriteLine("Press any key to exit.");
            Console.WriteLine("***********************");
            Console.ReadLine();
        }
    }
}
