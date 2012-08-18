namespace AsyncSample
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class Single
    {
        public void Run()
        {
            Console.WriteLine(DateTime.Now);
            var task = Bar();
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(task.Result);
        }

        

        public async Task<string> Bar()
        {
            return await Task.Run(() =>
                                {
                                    var now = DateTime.Now.ToString();
                                    Thread.Sleep(2000);
                                    return now;
                                });
        }
    }
}