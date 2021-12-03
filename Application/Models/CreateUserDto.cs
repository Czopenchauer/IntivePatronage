namespace Application.Models
{
    public class CreateUserDto : BaseUserDto
    {      
        public AddressDto Address { get; set; }
    }
}
