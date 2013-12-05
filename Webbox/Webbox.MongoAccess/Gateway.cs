using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Webbox.Domain;
using Webbox.Domain.Dto;

namespace Webbox.MongoAccess
{
    public class Gateway
    {
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
            
            foreach (var customer in DomainGenerator.CreateCustomers(20))
            {
                collection.Insert(customer);
            }
        }

        public List<Customer> GetCustomers()
        {
            const string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("webbox");
            var collection = database.GetCollection<Customer>("customers");
            var cursor = collection.FindAll();

            return cursor.ToList();
        }

        public List<Customer> SearchCustomers(string phrase)
        {
            return null;
        }
    }
}
