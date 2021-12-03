using Application.Models;
using FluentValidation;

namespace API.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            Include(new BaseUserValidator());
            RuleFor(x => x.Address).SetValidator(new AddressValidator());
        }
    }
}
