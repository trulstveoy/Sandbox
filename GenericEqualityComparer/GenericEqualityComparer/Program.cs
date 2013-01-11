using System.Collections.Generic;
using System.Linq;

namespace GenericEqualityComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new List<Foo>();
            source.Add(new Foo() {A = "A"});
            source.Add(new Foo() {A = "B"});
            
            var target = new List<Foo>();
            target.Add(new Foo() { A = "A" });

            var c1 = new Comparer<Foo>(x => x.A);
            var c2 = new Comparer<Foo>(x => x.A, x => x.B);
        }
    }


    public class Foo
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
    }
}
