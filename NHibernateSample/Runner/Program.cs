using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernateSample;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var doIt = new DoIt();
            doIt.Now(); 
        }
    }
}
