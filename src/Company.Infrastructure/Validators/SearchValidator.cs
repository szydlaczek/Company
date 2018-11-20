using CompanySelf.Infrastructure.Dtos;
using FluentValidation;
using System;
using System.Globalization;

namespace CompanySelf.Infrastructure.Validators
{
    public class SearchValidator : AbstractValidator<SearchCriteria>
    {
        public SearchValidator()
        {
            RuleFor(x => x.EmployeeDateOfBirthFrom)
                .Must(BeValidDate)
                .WithMessage("Please enter EmployeeDateOfBirthFrom in format yyyy-mm-dd");

            RuleFor(x => x.EmployeeDateOfBirthTo)
                .Must(BeValidDate)
                .WithMessage("Please enter EmployeeDateOfBirthTo in format yyyy-mm-dd");
        }

        private bool BeValidDate(string value)
        {
            if (string.IsNullOrEmpty(value))
                return true;

            DateTime date;
            return DateTime.TryParseExact(value.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }
    }
}