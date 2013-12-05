using System;
using System.Collections.Generic;
using Webbox.Domain.Dto;

namespace Webbox.Domain
{
    public static class DomainGenerator
    {
        public static List<Customer> CreateCustomers(int n)
        {
            var list = new List<Customer>();

            for (int i = 0; i < n; i++)
            {
                var customer = new Customer();
                customer.Id = Guid.NewGuid();
                customer.Number = 100000 + i;
                customer.Name = Faker.Company.Name();
                customer.CatchPhrase = Faker.Company.CatchPhrase();
                customer.PhoneNumber = Faker.Phone.Number();

                customer.Addresses = new List<Address>();
                for (int j = 0; j < Faker.RandomNumber.Next(1, 4); j++)
                {
                    var address = new Address();
                    address.Id = Guid.NewGuid();
                    address.StreetName = Faker.Address.StreetName();
                    address.City = Faker.Address.City();
                    address.ZipCode = Faker.Address.ZipCode();
                    address.Country = Faker.Address.Country();
                    address.ContactPerson = Faker.Name.FullName();
                    address.PhoneNumber = Faker.Phone.Number();

                    customer.Addresses.Add(address);
                }
                list.Add(customer);
            }

            return list;
        }
    }
}
