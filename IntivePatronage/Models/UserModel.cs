using System;

namespace IntivePatronage.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool Gender { get; set; }

        public decimal? Weight { get; set; }

        public string AddressCountry { get; set; }

        public string AddressCity { get; set; }

        public string AddressPostCode { get; set; }

        public string AddressStreet { get; set; }

        public string AddressHouseNumber { get; set; }

        public string AddressLocalNumber { get; set; }
    }
}
