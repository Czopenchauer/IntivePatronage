using System;

namespace API.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        public BaseUserDto User { get; set; }

        public AddressDto Address { get; set; }

    }
}
