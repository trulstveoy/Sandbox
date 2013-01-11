namespace OperationContextHookSample
{
    public class FooService : IFooService
    {
        public string Foo(int value)
        {
            return "Foo";
        }

        public int Bar(string s)
        {
            return 3;
        }
    }
}
