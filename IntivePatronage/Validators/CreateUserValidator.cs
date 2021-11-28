using API.Models;
using FluentValidation;
using IntivePatronage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.User).NotNull().SetValidator(new BaseUserValidator());
            RuleFor(x => x.Address).NotNull().SetValidator(new AddressValidator());
        }
    }
}
