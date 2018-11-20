using CompanySelf.Infrastructure.Validators;
using System.Collections.Generic;

namespace CompanySelf.Infrastructure.Dtos
{
    [FluentValidation.Attributes.Validator(typeof(SearchValidator))]
    public class SearchCriteria
    {
        public string Keyword { get; set; } = "";
        public string EmployeeDateOfBirthFrom { get; set; }
        public string EmployeeDateOfBirthTo { get; set; }
        public List<string> EmployeeJobTitles { get; set; } = new List<string>();
    }
}