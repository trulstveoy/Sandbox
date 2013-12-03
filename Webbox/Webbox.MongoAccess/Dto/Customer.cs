using MongoDB.Bson;

namespace Webbox.MongoAccess.Dto
{
    public class Customer
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}