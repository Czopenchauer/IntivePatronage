using System;

namespace Database.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool Gender { get; set; }

        public decimal? Weight { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
