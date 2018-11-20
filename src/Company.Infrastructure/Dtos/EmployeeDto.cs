using CompanySelf.Infrastructure.Validators;

namespace CompanySelf.Infrastructure.Dtos
{
    [FluentValidation.Attributes.Validator(typeof(EmployeeValidator))]
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string JobTitle { get; set; }
    }
}