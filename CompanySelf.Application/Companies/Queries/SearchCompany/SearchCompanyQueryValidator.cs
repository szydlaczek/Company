using FluentValidation;
using FluentValidation.Results;
using System;
using System.Globalization;

namespace CompanySelf.Application.Companies.Queries.SearchCompany
{
    public class SearchCompanyQueryValidator : AbstractValidator<SearchCompanyQuery>
    {
        public override ValidationResult Validate(ValidationContext<SearchCompanyQuery> context)
        {
            RuleFor(x => x.EmployeeDateOfBirthFrom)
                .Must(BeValidDate)
                .WithMessage("Please enter EmployeeDateOfBirthFrom in format yyyy-mm-dd");

            RuleFor(x => x.EmployeeDateOfBirthTo)
                .Must(BeValidDate)
                .WithMessage("Please enter EmployeeDateOfBirthTo in format yyyy-mm-dd");

            return base.Validate(context);
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