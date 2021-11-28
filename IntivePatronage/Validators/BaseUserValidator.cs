using API.Models;
using FluentValidation;
using System;

namespace API.Validators
{
    public class BaseUserValidator : AbstractValidator<BaseUserDto>
    {
        public BaseUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50).WithMessage("First name field must be a string type with a maximum lenght of 50");
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50).WithMessage("Last name field must be a string type with a maximum lenght of 50");
            RuleFor(x => x.DateOfBirth).NotEmpty().Must(BeAValidDate).WithMessage("Date of birth field couldn't be parsed to DateTime format");
            RuleFor(x => x.Gender).NotNull().Must(y => y == false || y == true).WithMessage("Gender field must be a bool");
            RuleFor(x => x.Weight).ScalePrecision(2, 5).Must(x => x > 0).WithMessage("Weight field must be greater than 0");
        }

        private bool BeAValidDate(string value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date);
        }
    }
}
