using System;

namespace DelegatePlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Foo();
            var b = new Foo();

            var action = (Action)Delegate.Combine(new Delegate[] {a.Bar, b.Bar});
            action();

            
        }
    }

    public class Foo
    {
        public Action Bar { get; set; }

        public Foo()
        {
            Bar = () => {Console.WriteLine("Bar");};
        }
    }
}
