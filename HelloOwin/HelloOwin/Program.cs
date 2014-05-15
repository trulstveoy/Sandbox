using System;
using Microsoft.Owin.Hosting;

namespace HelloOwin
{
    public class Program
    {
        public static void Main()
        {
            using (WebApp.Start<Startup>("http://localhost:12345"))
            {
                Console.ReadLine();
            }
        }
    }
}
