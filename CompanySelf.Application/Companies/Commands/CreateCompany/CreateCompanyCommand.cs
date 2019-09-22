using CompanySelf.Application.Companies.Commands.Dtos;
using CompanySelf.Application.Infrastructure;
using MediatR;
using System.Collections.Generic;

namespace CompanySelf.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public List<CompanyEmployeeDto> Employees { get; set; } = new List<CompanyEmployeeDto>();
    }
}