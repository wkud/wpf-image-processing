using System;

namespace ImageProcessingWPF.Utility
{
    abstract class Observer<T> : IObserver<T>
    {
        IDisposable _unsubsriber;
        public Observer(IObservable<T> observable)
        {
            _unsubsriber = observable.Subscribe(this);
        }

        public void OnCompleted()
        {
            Unsubscribe();
        }

        public void OnError(Exception error)
        {
            MessageBoxExtension.ShowError(error.Message);
        }

        public void OnNext(T value)
        {
            Notify(value);
        }

        protected abstract void Notify(T value);
        private void Unsubscribe()
        {
            _unsubsriber.Dispose();
        }

    }
}
