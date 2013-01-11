using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernateSample.Dto;

namespace NHibernateSample
{
    public class DoIt
    {
        private readonly ISession _session;
        private readonly ITransaction _transaction;
        
        public void Now()
        {
            Console.WriteLine("Start....");

            var watch = new Stopwatch();

            watch.Start();
            ISessionFactory sessionFactory = CreateSessionFactory();


            var session = sessionFactory.OpenSession();
            using (var transaction = session.BeginTransaction())
            {
                var list = new List<Task>();

                for (int i = 0; i < 1000; i++)
                {
                    list.Add(Task.Factory.StartNew(() => Save(session)));
                }

                Task.WaitAll(list.ToArray());
                transaction.Commit();
            }

            session.Close();
            session = null;
            
            watch.Stop();

            Console.WriteLine(TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds).TotalSeconds);
        }

        private static void Save(ISession session)
        {
            Console.WriteLine("Saving...");
            
            var foo = new Foo(Guid.NewGuid(), "abcd", "def");
            session.Save(foo);
            
            Console.WriteLine("Saved");
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("TestConnectionString"))
                    .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FooMap>())
                .Diagnostics(d => d.OutputToConsole())
                .BuildSessionFactory();
        }
    }
}
