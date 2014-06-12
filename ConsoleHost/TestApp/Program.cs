using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hello world");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
