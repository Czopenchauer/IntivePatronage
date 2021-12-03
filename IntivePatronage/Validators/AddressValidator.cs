using Application.Models;
using FluentValidation;

namespace API.Validators
{
    public class AddressValidator : AbstractValidator<AddressDto>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Country).NotEmpty().MaximumLength(100).WithMessage("Country field must be a string type with a maximum lenght of 100");
            RuleFor(x => x.City).NotEmpty().MaximumLength(100).WithMessage("City field must be a string type with a maximum lenght of 100");
            RuleFor(x => x.PostCode).NotEmpty().MaximumLength(10).WithMessage("PostCode field must be a string type with a maximum lenght of 10");
            RuleFor(x => x.Street).NotEmpty().MaximumLength(100).WithMessage("Street field must be a string type with a maximum lenght of 100");
            RuleFor(x => x.HouseNumber).NotEmpty().MaximumLength(10).WithMessage("Country field must be a string type with a maximum lenght of 10");
            RuleFor(x => x.LocalNumber).MaximumLength(10).WithMessage("LocalNumber field must be a string type with a maximum lenght of 10");
        }
    }
}
