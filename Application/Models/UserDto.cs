namespace Application.Models
{
    public class UserDto : BaseUserDto
    {
        public int Id { get; set; }

        public AddressDto Address { get; set; }

    }
}
