using System;

namespace EventAndDelegates
{
    public abstract class _BaseService<T> where T : class
    {
        protected readonly T _model;
        public event EventHandler<CommonEventArgs<T>> VideoEncoded;

        public _BaseService(T model)
        {
            _model = model;
        }

        protected abstract void Encode();

        public void Operation()
        {
            Encode();
            OnEncoded(_model);
        }

        protected virtual void OnEncoded(T model)
        {
            if (VideoEncoded == null)
            {
                return;
            }

            var videoEventArgs = new CommonEventArgs<T>()
            {
                Payload = model
            };

            VideoEncoded(this, videoEventArgs);
        }
    }
}
