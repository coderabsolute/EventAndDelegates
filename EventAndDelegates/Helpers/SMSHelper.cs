using System;

namespace EventAndDelegates.Helpers
{
    public class SMSHelper : IMessage
    {
        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
