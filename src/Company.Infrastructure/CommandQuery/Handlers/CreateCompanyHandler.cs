using CompanySelf.Core.Models;
using CompanySelf.Infrastructure.CommandQuery.Bus;
using CompanySelf.Infrastructure.CommandQuery.Commands;
using CompanySelf.Infrastructure.Context;
using CompanySelf.Infrastructure.Dtos;

using System;
using System.Threading.Tasks;

namespace CompanySelf.Infrastructure.CommandQuery.Handlers
{
    public class CreateCompanyHandler : IHandleCommand<CreateCompanyCommand>
    {
        private readonly ApplicationDbContext _context;

        public CreateCompanyHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(CreateCompanyCommand command)
        {
            var result = await Create(command.Company);
            return new OperationResult
            {
                Succeeded = true,
                Data = result.Id
            };
        }

        private async Task<Company> Create(CompanyDto companyDto)
        {
            var company = new Company();
            company.EstablishmentYear = companyDto.EstablishmentYear;
            company.Name = companyDto.Name;

            foreach (var employee in companyDto.Employees)
            {
                company.Employees.Add(new Employee
                {
                    DateOfBirth = Convert.ToDateTime(employee.DateOfBirth),
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    JobTitle = (JobTitle)Enum.Parse(typeof(JobTitle), employee.JobTitle)
                });
            }

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }
    }
}