using CompanySelf.Application.Companies.Commands.Dtos;
using CompanySelf.Application.Infrastructure;
using CompanySelf.Domain.Entities;
using CompanySelf.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanySelf.Application.Companies.Commands
{
    public abstract class BaseCompanyHandler
    {
        protected readonly ApplicationDbContext _context;

        protected BaseCompanyHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        protected void AddEmployees(Company company, List<CompanyEmployeeDto> employees)
        {
            foreach (var item in employees)
            {
                company.AddEmployee(item.FirstName, item.LastName, DateTime.Parse(item.DateOfBirth), (JobType)Enum.Parse(typeof(JobType), item.JobTitle));
            }
        }

        protected async Task<Company> GetCompany(long id)
        {
            var company = await _context.Companies
                .Include(e => e.Employees)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (company is null)
                throw new NotFoundException($"Company with id {id} doesnt exist");

            return company;
        }

        protected void RemoveEmployees(Company company)
        {
            foreach (var employee in company.Employees.ToList())
            {
                _context.Employees.Remove(employee);
            }
        }
    }
}