using CompanySelf.Infrastructure.Validators;
using System.Collections.Generic;

namespace CompanySelf.Infrastructure.Dtos
{
    [FluentValidation.Attributes.Validator(typeof(CompanyValidator))]
    public class CompanyDto
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; }

        public CompanyDto()
        {
            Employees = new HashSet<EmployeeDto>();
        }
    }
}