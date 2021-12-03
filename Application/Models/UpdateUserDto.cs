namespace Application.Models
{
    public class UpdateUserDto : BaseUserDto
    {
        public int Id { get; set; }

        public AddressDto Address { get; set; }
    }
}
