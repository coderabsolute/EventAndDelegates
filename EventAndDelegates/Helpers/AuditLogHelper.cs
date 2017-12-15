using System;

namespace EventAndDelegates.Helpers
{
    public class AuditLogHelper : IMessage
    {
        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
