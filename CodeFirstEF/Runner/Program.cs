using System;
using System.Collections.Generic;
using Data;
using Data.Model;

namespace Runner
{
    class Program
    {
        static void Main()
        {
            try
            {
                var dbContext = new DataContext();
                //dbContext.Database.ExecuteSqlCommand("delete from category");
                dbContext.Database.ExecuteSqlCommand("delete from product");
                dbContext.Database.ExecuteSqlCommand("delete from [order]");

                var order = new Order {Id = 1, Buyer = "Foobar"};
                order.Products = new List<Product>();
                var product = new Product {Id = 2, Name = "Foobar"};
                order.Products.Add(product);

                dbContext.Orders.Add(order);
                //dbContext.Products.Add();
                //dbContext.Categories.Add(new Category() {Id = 3, Name = "Foobar"});

                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
