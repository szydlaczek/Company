using CompanySelf.Application.Infrastructure;
using MediatR;
using System.Collections.Generic;

namespace CompanySelf.Application.Companies.Queries.SearchCompany
{
    public class SearchCompanyQuery : IRequest<Response>
    {
        public string Keyword { get; set; } = "";
        public string EmployeeDateOfBirthFrom { get; set; }
        public string EmployeeDateOfBirthTo { get; set; }
        public List<string> EmployeeJobTitles { get; set; } = new List<string>();
    }
}