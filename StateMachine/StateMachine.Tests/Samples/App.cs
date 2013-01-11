namespace StateMachine.Tests.Samples
{
    public class App
    {
        private static Worker _worker;
        public static Worker Worker
        {
            get { return _worker ?? (_worker = new Worker()); }
        }
    }

    public class Worker
    {
        public int Value { get; private set; }

        public void Increase()
        {
            Value++;
        }
    }
}