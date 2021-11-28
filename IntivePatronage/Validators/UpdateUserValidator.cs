using API.Models;
using FluentValidation;
using IntivePatronage.Models;
using System;

namespace API.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.User).NotNull().SetValidator(new BaseUserValidator());
            RuleFor(x => x.Address).SetValidator(new AddressValidator());
        }
    }
}
