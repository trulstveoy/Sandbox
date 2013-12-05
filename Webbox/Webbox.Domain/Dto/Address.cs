using System;

namespace Webbox.Domain.Dto
{
    public class Address
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
    }
}