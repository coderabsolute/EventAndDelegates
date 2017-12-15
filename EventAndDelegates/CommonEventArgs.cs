using System;

namespace EventAndDelegates
{
    public class CommonEventArgs<T> : EventArgs
    {
        public T Payload { get; set; }
    }
}
