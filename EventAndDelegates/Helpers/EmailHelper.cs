using System;

namespace EventAndDelegates.Helpers
{
    public class EmailHelper : IMessage
    {
        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
