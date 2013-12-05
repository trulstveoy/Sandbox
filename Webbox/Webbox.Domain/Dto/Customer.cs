using System;
using System.Collections.Generic;

namespace Webbox.Domain.Dto
{
    public class Customer
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CatchPhrase { get; set; }
        public List<Address> Addresses { get; set; }
    }
}