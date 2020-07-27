using System;
using System.Collections.Generic;

namespace ImageProcessingWPF.Utility
{
    class Observable<T> : IObservable<T>
    {
        private List<IObserver<T>> _observers = new List<IObserver<T>>();
        public IDisposable Subscribe(IObserver<T> observer)
        {
            _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        protected void NotifyAllObservers(T value)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(value);
            }
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<T>> _observers;
            private IObserver<T> _observer;

            public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}
