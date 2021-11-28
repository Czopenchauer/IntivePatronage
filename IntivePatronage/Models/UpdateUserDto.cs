namespace API.Models
{
    public class UpdateUserDto
    {
        public BaseUserDto User { get; set; }

        public AddressDto Address { get; set; }
    }
}
