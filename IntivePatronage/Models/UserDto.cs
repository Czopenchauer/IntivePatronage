using System;

namespace API.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public bool Gender { get; set; }

        public decimal? Weight { get; set; }

        public AddressDto Address { get; set; }

    }
}
