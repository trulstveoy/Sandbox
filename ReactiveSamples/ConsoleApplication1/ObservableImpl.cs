using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class ObservableImpl<T> : IObservable<ObservableImpl<T>.Change>
    {
        public abstract class Change
        {
            public T Value { get; set; }
        }

        public class ItemAdded : Change
        {}

        public class ItemRemoved : Change
        {}

        private readonly List<IObserver<Change>> _observers = new List<IObserver<Change>>(); 

        public void Add(T item)
        {
            var itemAdded = new ItemAdded {Value = item};
            foreach (var observer in _observers)
            {
                observer.OnNext(itemAdded);
            }
        }

        public IDisposable Subscribe(IObserver<Change> observer)
        {
            _observers.Add(observer);

            return null;
        }
    }
}
