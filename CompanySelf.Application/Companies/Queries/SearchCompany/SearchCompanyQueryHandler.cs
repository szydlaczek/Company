using CompanySelf.Application.Companies.Helpers;
using CompanySelf.Application.Companies.Queries.ModelsPreview;
using CompanySelf.Application.Infrastructure;
using CompanySelf.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CompanySelf.Application.Companies.Queries.SearchCompany
{
    public class SearchCompanyQueryHandler : IRequestHandler<SearchCompanyQuery, Response>
    {
        private readonly ApplicationDbContext _context;

        public SearchCompanyQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(SearchCompanyQuery request, CancellationToken cancellationToken)
        {
            var companies = _context.Companies.Include(a => a.Employees).AsQueryable();

            var filteredCompanies = await companies.Filter(request).ToListAsync();

            var result = filteredCompanies.AsQueryable().Select(CompanyPreview.Projection).ToList();

            return new Response(result);
        }
    }
}