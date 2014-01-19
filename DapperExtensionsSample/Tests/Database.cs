using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using DapperExtensions;
using Dodap;
using Dodap.Dto;

namespace Tests
{
    public class Database
    {
        private const string DbFile = @"C:\temp\test.db";
        private readonly string _connectionString = string.Format(@"Data Source={0}; Pooling=false; FailIfMissing=false;", DbFile);
        
        private void Connect(Action<DbConnection> action)
        {
            using (var factory = new SQLiteFactory())
            {
                using (DbConnection connection = factory.CreateConnection())
                {
                    if (connection == null)
                    {
                        throw new InvalidOperationException("connection should not be null");
                    }

                    connection.ConnectionString = _connectionString;
                    connection.Open();
                    action(connection);
                }
            }
        }

        public void Create()
        {
            if (File.Exists(DbFile))
            {
                File.Delete(DbFile);
            }

            Connect(connection =>
            {
                using (DbCommand cmd = connection.CreateCommand())
                {
                    //create table
                    cmd.CommandText = @"CREATE TABLE Customer (CustomerId long primary key, Name text, PhoneNumber text, CatchPhrase text);";
                    cmd.ExecuteNonQuery();
                }
            });
        }

        public void Insert()
        {
            var repo = new Repo(Connect);
            repo.Insert(DomainGenerator.CreateCustomers(50));
        }

        public void SelectAll()
        {
            var repo = new Repo(Connect);
            IEnumerable<Customer> items = repo.GetList();

            Write.Out(items);
        }

        public void Select()
        {
            var repo = new Repo(Connect);
            
            IEnumerable<Customer> items = repo.GetStartingWithR();

            Write.Out(items);
        }

        public void Paged()
        {
            var repo = new Repo(Connect);

            int i = 0;
            IEnumerable<Customer> items;
            do
            {
                items = repo.GetPaged(i++);
                Write.Out(items);
                Console.ReadKey();
            } while (items.Any());
        }
    }
}
