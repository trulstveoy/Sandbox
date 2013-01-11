using System;

namespace NHibernateSample.Dto
{
    public class Foo
    {
        public virtual Guid Id { get; set; }
        public virtual string A { get; set; }
        public virtual string B { get; set; }

        public Foo()
        {}

        public Foo(Guid id, string a, string b)
        {
            Id = id;
            A = a;
            B = b;
        }
    }
}