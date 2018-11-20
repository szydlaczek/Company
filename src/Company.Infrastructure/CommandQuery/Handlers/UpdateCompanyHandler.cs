using CompanySelf.Core.Models;
using CompanySelf.Infrastructure.CommandQuery.Bus;
using CompanySelf.Infrastructure.CommandQuery.Commands;
using CompanySelf.Infrastructure.Context;
using CompanySelf.Infrastructure.Dtos;

using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CompanySelf.Infrastructure.CommandQuery.Handlers
{
    public class UpdateCompanyHandler : IHandleCommand<UpdateCompanyCommand>
    {
        private readonly ApplicationDbContext _context;

        public UpdateCompanyHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(UpdateCompanyCommand command)
        {
            return await UpdateCompanyAsync(command.Company, command.CompanyId);
        }

        private async Task<IResult> UpdateCompanyAsync(CompanyDto companyDto, long companyId)
        {
            var company = await _context.Companies
                .Include(e => e.Employees)
                .Where(c => c.Id == companyId)
                .FirstOrDefaultAsync();

            if (company == null)
                return new OperationResult { Succeeded = false, Message = $"Company with Id {companyId} doesn't exist" };

            foreach (var employee in _context.Employees.Where(e => e.CompanyId == company.Id).ToList())
            {
                _context.Employees.Remove(employee);
            }

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

            await _context.SaveChangesAsync();
            return new OperationResult { Data = company, Message = $"Company with Id {companyId} has been updated", Succeeded = true };
        }
    }
}