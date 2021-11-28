using API.Models;

namespace IntivePatronage.Models
{
    public class CreateUserDto
    {
        public BaseUserDto User { get; set; }

        public AddressDto Address { get; set; }
    }
}
