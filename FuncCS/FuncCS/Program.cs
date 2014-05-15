using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abc";

            s.Pipe(x => x.ToCharArray()).Pipe(x =>
            {
                Array.Reverse(x);
                return x;
            }).Pipe(Console.WriteLine);
        }
    }
}
