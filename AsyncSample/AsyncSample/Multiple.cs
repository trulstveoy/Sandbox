namespace AsyncSample
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;

    internal class Multiple
    {
        public void Run()
        {
            Console.WriteLine(DateTime.Now);
            string[] strings = Bar().Result;
            Console.WriteLine(DateTime.Now);
            foreach(var str in strings)
                Console.WriteLine(str);
        }
        

        private async Task<string[]> Bar()
        {
            var t1 = Task.Run(() =>
                                {
                                    var now = DateTime.Now.ToString();
                                    Thread.Sleep(2000);
                                    return now;
                                });

            var t2 = Task.Run(() =>
                                {
                                    var now = DateTime.Now.ToString();
                                    Thread.Sleep(2000);
                                    return now;
                                });

            return await Task.WhenAll(t1, t2);
        }
    }
}