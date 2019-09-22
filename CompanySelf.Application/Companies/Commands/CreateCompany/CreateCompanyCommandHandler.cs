using CompanySelf.Application.Infrastructure;
using CompanySelf.Domain.Entities;
using CompanySelf.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CompanySelf.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : BaseCompanyHandler, IRequestHandler<CreateCompanyCommand, Response>
    {
        public CreateCompanyCommandHandler(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Response> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company(request.Name, request.EstablishmentYear);

            base.AddEmployees(company, request.Employees);

            await _context.Companies.AddAsync(company);

            await _context.SaveChangesAsync();

            return new Response(new
            {
                id = company.Id
            });
        }
    }
}