namespace AsyncSample
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            //var test = new Single();
            //test.Run();

            //var test = new Multiple();
            //test.Run();

            var test = new Compact();
            test.Run();
            Thread.Sleep(3000);
        }
    }
}
