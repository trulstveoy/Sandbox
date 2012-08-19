namespace AutoFixtureSample
{
    public class Foo
    {
        public Bar Bar { get; set; }

        public Foo(string a, string b, Bar bar)
        {
            Bar = bar;
        }
    }

    public class Bar
    {
        public Bar(string a, string b)
        {
        }
    }
}
