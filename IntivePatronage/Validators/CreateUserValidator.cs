using Application.Models;
using FluentValidation;

namespace API.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            Include(new BaseUserValidator());
            RuleFor(x => x.Address).NotNull().SetValidator(new AddressValidator());
        }
    }
}
