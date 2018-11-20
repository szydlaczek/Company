﻿using CompanySelf.Core.Models;
using CompanySelf.Infrastructure.Dtos;
using FluentValidation;
using System;
using System.Globalization;

namespace CompanySelf.Infrastructure.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Employee FirstName cannot be empty")
                .NotNull()
                .WithMessage("Enter Employee FirstName")
                .MaximumLength(20)
                .WithMessage("Employee FirstName to long, max lenght is 20");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Employee LastName cannot be empty")
                .NotNull()
                .WithMessage("Enter Employee LastName")
                .MaximumLength(20)
                .WithMessage("Employee LastName to long, max lenght is 20");

            RuleFor(x => x.DateOfBirth)
                .Must(BeValidDate)
                .WithMessage("Please enter Birth of date in format yyyy-mm-dd");

            RuleFor(x => x.JobTitle)
                .Must(BeValidJob)
                .WithMessage("Please enter one of jobs name: Administrator, Developer, Architect, Manager");
        }

        private bool BeValidDate(string value)
        {
            DateTime date;
            return DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        private bool BeValidJob(string value)
        {
            JobTitle job;
            return (Enum.TryParse(value, true, out job) && job != JobTitle.None) ? true : false;
        }
    }
}