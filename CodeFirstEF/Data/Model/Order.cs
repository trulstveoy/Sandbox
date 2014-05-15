using System.Collections.Generic;

namespace Data.Model
{
    public class Order
    {
        public long Id { get; set; }
        public string Buyer { get; set; }
        public List<Product> Products { get; set; }
    }
}