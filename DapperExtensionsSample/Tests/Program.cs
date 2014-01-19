using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions.Sql;

namespace Tests
{
    class Program
    {
        static void Main()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new SqliteDialect();

            var database = new Database();
            database.Create();
            database.Insert();
            database.SelectAll();
            database.Select();
            database.Paged();
        }
    }
}
