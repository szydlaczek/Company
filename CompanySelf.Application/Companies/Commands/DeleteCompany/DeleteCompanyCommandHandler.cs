using CompanySelf.Application.Infrastructure;
using CompanySelf.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CompanySelf.Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommandHandler : BaseCompanyHandler, IRequestHandler<DeleteCompanyCommand, Response>
    {
        public DeleteCompanyCommandHandler(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Response> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await GetCompany(request.CompanyId);

            RemoveEmployees(company);

            _context.Companies.Remove(company);

            await _context.SaveChangesAsync();
            return new Response();
        }
    }
}