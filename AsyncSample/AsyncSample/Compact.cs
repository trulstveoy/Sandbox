namespace AsyncSample
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class Compact
    {
         public async void Run()
         {
             
             var task = Task.Run(() =>
                                     {
                                         var now = DateTime.Now.ToString();
                                         Thread.Sleep(2000);
                                         return now;
                                     });
             await task;
             Console.WriteLine(task.Result);
         }
    }
}