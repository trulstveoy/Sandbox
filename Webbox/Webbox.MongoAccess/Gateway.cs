using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using NLog;
using Webbox.Core.Logging;
using Webbox.Domain;
using Webbox.Domain.Dto;

namespace Webbox.MongoAccess
{
    public class Gateway
    {
        private static readonly Logger Log = WebboxLog.LogFor<Gateway>();

        public void DropCustomers()
        {
            const string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("webbox");
            var collection = database.GetCollection<Customer>("customers");
            collection.Drop();
        }

        public void PopulateCustomers()
        {
            const string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("webbox");
            var collection = database.GetCollection<Customer>("customers");

            const int count = 100;
            foreach (var customer in DomainGenerator.CreateCustomers(count))
            {
                collection.Insert(customer);
            }

            Log.Debug("Inserted {0} customers", count);
        }

        public List<Customer> GetCustomers()
        {
            const string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("webbox");
            var collection = database.GetCollection<Customer>("customers");

            var list = collection.AsQueryable().Where(x => x.Addresses.Any(y => y.Country.StartsWith("U"))).ToList();
            return list;
        }

        public List<Customer> SearchCustomers(string phrase)
        {
            return null;
        }
    }
}
