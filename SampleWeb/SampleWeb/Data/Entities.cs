namespace SampleWeb.Data
{
    using System.Collections.Generic;
    using Models;

    public class Entities
    {
        public List<Product> Products { get; set; }

        public Entities()
        {
            Products = new List<Product>();
            Products.Add(new Product() {Name = "Burger"});
            Products.Add(new Product() {Name = "Fries"});
            Products.Add(new Product() {Name = "Coke"});
        }
    }
}