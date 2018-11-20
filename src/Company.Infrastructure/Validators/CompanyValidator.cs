using CompanySelf.Infrastructure.Dtos;
using FluentValidation;
using System;

namespace CompanySelf.Infrastructure.Validators
{
    public class CompanyValidator : AbstractValidator<CompanyDto>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.EstablishmentYear)
                .NotNull()
                .LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage($"EstablismentYear must be less or equal to {DateTime.Now.Year}")
                .GreaterThan(0)
                .WithMessage($"EstablismentYear must be greater than 0");
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Name can not be empty")
                .MaximumLength(100)
                .WithMessage("Max length company name is 100")
                .NotEmpty()
                .WithMessage("Name cannot be empty");
        }
    }
}