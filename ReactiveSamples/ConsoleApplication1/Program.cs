using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            SimpleSubject();
            UsingObservableCollection();
            UsingObservableCollection2();
            UsingObservableCollection3();
            UsingObservableCollection4();
            UsingObservableImpl();
            //UsingObservableImpl2();
            UsingScheduler();

            Console.ReadKey();
        }

        private static void UsingScheduler()
        {
            var s = new EventLoopScheduler();
            s.Schedule(x =>
                           {
                               Type type = x.GetType();
                               Console.WriteLine(DateTime.Now);
                               x();
                           });
        }

        private static void UsingObservableImpl2()
        {
            Console.WriteLine("UsingFoo");
            var a = new ObservableImpl2();
            a.Listen().Subscribe(x =>
                                     {
                                         string s = x;
                                         Console.WriteLine(s);
                                     });

            a.Add("a");
            a.Add("b");
            a.Add("c");
            a.Add("d");
            a.Add("e");
            


        }

        private static void UsingObservableImpl()
        {
            var a = new ObservableImpl<string>();

            a.Where(item => item is ObservableImpl<string>.ItemAdded)
             .Subscribe(item => Console.WriteLine("Added: " + item));

            a.Where(item => item is ObservableImpl<string>.ItemRemoved)
             .Subscribe(item => Console.WriteLine("Removed: " + item));

            a.Add("a");
            a.Add("b");
            a.Add("c");
            a.Add("d");
            a.Add("e");
            a.Add("f");
        }

        private static Task<string> Foo()
        {
            throw new NotImplementedException();
        }

        private static void UsingObservableCollection4()
        {
            var col = new ObservableCollection<string>();

            Observable
                .FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(h => col.CollectionChanged += h, h => col.CollectionChanged -= h)
                .Where(pattern => pattern.EventArgs.Action == NotifyCollectionChangedAction.Add)
                .Subscribe(pattern =>
                {
                    foreach (var newItem in pattern.EventArgs.NewItems)
                    {
                        Console.WriteLine(newItem);
                    }
                });

            col.Add("a");
            col.Add("b");
            col.Add("c");
            col.Add("d");
        }
        
        private static void UsingObservableCollection3()
        {
            var col = new ObservableCollection<string>();

            Observable
                .FromEvent<NotifyCollectionChangedEventArgs>(h => col.CollectionChanged += (o, args) => h(args), h => col.CollectionChanged -= (o, args) => h(args))
                .Where(args => args.Action == NotifyCollectionChangedAction.Add)
                .Subscribe(args =>
                               {
                                   foreach (var newItem in args.NewItems)
                                   {
                                       Console.WriteLine(newItem);
                                   }
                               });

            col.Add("a");
            col.Add("b");
            col.Add("c");
            col.Add("d");
        }

        

       

        private static void UsingObservableCollection2()
        {
            var collection = new ObservableCollection<string>();
            
            Observable.FromEventPattern<NotifyCollectionChangedEventArgs>(collection, "CollectionChanged")
                .Where(e => e.EventArgs.Action == NotifyCollectionChangedAction.Add)
                .Subscribe(e => Handle(e.EventArgs));

            collection.Add("a");
        }

        private static void Handle(NotifyCollectionChangedEventArgs args)
        {
            foreach (var newItem in args.NewItems)
            {
                Console.WriteLine(newItem);
            }
        }

        private static void UsingObservableCollection()
        {
            var collection = new ObservableCollection<string>();
            collection.CollectionChanged += OnCollectionChanged;

            collection.Add("a");
            collection.Add("b");
            collection.RemoveAt(0);
            collection.Add("c");
            collection.Remove("c");
        }

        static void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedAction notifyCollectionChangedAction = e.Action;
            if (notifyCollectionChangedAction.ToString() == "Add")
            {
                foreach (var newItem in e.NewItems)
                {
                    Console.WriteLine(newItem + " added");
                }
            }

            if (notifyCollectionChangedAction.ToString() == "Remove")
            {
                foreach (var oldItem in e.OldItems)
                {
                    Console.WriteLine(oldItem + " removed");
                }
            }
        }

        private static void SimpleSubject()
        {
            var subject = new Subject<string>();
            subject.Subscribe(OnNext);

            subject.OnNext("a");
            subject.OnNext("b");
            subject.OnNext("c");
            subject.OnNext("d");
        }

        private static void OnNext(string str)
        {
            Console.WriteLine(str);
        }
    }
}
