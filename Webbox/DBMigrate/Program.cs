using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbox.DataAccess;

namespace DBMigrate
{
    class Program
    {
        static void Main(string[] args)
        {
            Migrate.Now();
        }
    }
}
