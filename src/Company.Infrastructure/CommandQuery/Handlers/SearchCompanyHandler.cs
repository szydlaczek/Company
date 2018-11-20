using CompanySelf.Infrastructure.CommandQuery.Bus;
using CompanySelf.Infrastructure.CommandQuery.Queries;
using CompanySelf.Infrastructure.Context;
using CompanySelf.Infrastructure.Dtos;
using CompanySelf.Infrastructure.SearchFilters;
using System.Linq;
using System.Threading.Tasks;

namespace CompanySelf.Infrastructure.CommandQuery.Handlers
{
    public class SearchCompanyHandler : IHandleQuery<SearchCompanyQuery>
    {
        private readonly ApplicationDbContext _context;

        public SearchCompanyHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<QueryResult> Handle(SearchCompanyQuery query)
        {
            var companies = _context.Companies.AsQueryable();

            var result = new QueryResult
            {
                Data = companies.Filter(query.SearchCriteria).Select(c => new CompanyDto
                {
                    Employees = c.Employees.Select(e => new EmployeeDto
                    {
                        DateOfBirth = e.DateOfBirth.ToString(),
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        JobTitle = e.JobTitle.ToString()
                    }).ToList(),
                    EstablishmentYear = c.EstablishmentYear,
                    Name = c.Name
                }).ToList()
            };
            return await Task.FromResult(result);
        }
    }
}