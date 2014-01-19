using System;
using System.Collections.Generic;
using Dodap.Dto;

namespace Tests
{
    public static class DomainGenerator
    {
        public static List<Customer> CreateCustomers(int n)
        {
            var list = new List<Customer>();

            for (int i = 0; i < n; i++)
            {
                var customer = new Customer();
                customer.CustomerId = 100000 + i;
                customer.Name = Faker.Company.Name();
                customer.CatchPhrase = Faker.Company.CatchPhrase();
                customer.PhoneNumber = Faker.Phone.Number();
                
                list.Add(customer);
            }

            return list;
        }
    }
}
