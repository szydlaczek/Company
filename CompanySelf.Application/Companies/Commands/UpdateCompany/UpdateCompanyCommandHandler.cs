using CompanySelf.Application.Infrastructure;
using CompanySelf.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CompanySelf.Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : BaseCompanyHandler, IRequestHandler<UpdateCompanyCommand, Response>
    {
        public UpdateCompanyCommandHandler(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Response> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await GetCompany(request.CompanyId);

            RemoveEmployees(company);

            company.UpdateCompany(request.Name, request.EstablishmentYear);

            AddEmployees(company, request.Employees);

            await _context.SaveChangesAsync();

            return new Response();
        }
    }
}