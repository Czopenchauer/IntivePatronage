using API.Models;

namespace IntivePatronage.Models
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public bool Gender { get; set; }

        public decimal? Weight { get; set; }

        public AddressDto Address { get; set; }
    }
}
