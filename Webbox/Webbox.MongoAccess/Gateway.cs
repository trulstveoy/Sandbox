using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Webbox.MongoAccess.Dto;

namespace Webbox.MongoAccess
{
    public class Gateway
    {
        public void PopulateMongo()
        {
            const string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("webbox");
            var collection = database.GetCollection<Customer>("customers");

            var customer = new Customer() {Name = "Foobar"};
            collection.Insert(customer);
        }

        public List<Customer> GetCustomers()
        {
            const string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("webbox");
            var collection = database.GetCollection<Customer>("customers");

            var query = Query<Customer>.EQ(e => e.Name, "Foobar");
            var cursor = collection.Find(query);

            return cursor.ToList();
        }
    }
}
