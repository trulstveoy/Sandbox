using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace ConsoleApplication1
{
    public class ObservableImpl2
    {
        private readonly IScheduler _scheduler = new EventLoopScheduler();
        private readonly List<string> _items = new List<string>(); 

        public IObservable<string> Listen()
        {
            return Observable.Create<string>(o =>
                                         {
                                             return _scheduler.Schedule(recurse =>
                                                                            {
                                                                                var items = GetStrings();
                                                                                foreach (var item in items)
                                                                                {
                                                                                    o.OnNext(item);
                                                                                }

                                                                                recurse();
                                                                            });
                                         });
        }

        private IEnumerable<string> GetStrings()
        {
            return _items;
        }

        public void Add(string item)
        {
            _items.Add(item);
        }
    }
}
