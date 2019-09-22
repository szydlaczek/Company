using CompanySelf.Application.Companies.Commands.Dtos;
using CompanySelf.Application.Infrastructure;
using MediatR;
using System.Collections.Generic;

namespace CompanySelf.Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest<Response>
    {
        public long CompanyId { get; protected set; }
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public List<CompanyEmployeeDto> Employees { get; set; } = new List<CompanyEmployeeDto>();

        public void SetCompanyId(long id)
        {
            CompanyId = id;
        }
    }
}