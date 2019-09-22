using CompanySelf.Application.Companies.Commands.CreateCompany;
using FluentValidation;
using FluentValidation.Results;
using System;

namespace CompanySelf.Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public override ValidationResult Validate(ValidationContext<UpdateCompanyCommand> context)
        {
            RuleFor(c => c.Name).MinimumLength(5)
                .WithMessage("Company name to short");

            RuleFor(c => c.EstablishmentYear)
                .LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("Bad EstablishmentYear")
                .GreaterThan(0)
                .WithMessage("Bad EstablishmentYear");

            var employeeValidator = new EmployeeValidator();
            RuleForEach(c => c.Employees).SetValidator(employeeValidator);

            return base.Validate(context);
        }
    }
}