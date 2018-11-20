using CompanySelf.Infrastructure.CommandQuery.Bus;
using CompanySelf.Infrastructure.CommandQuery.Commands;
using CompanySelf.Infrastructure.Context;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CompanySelf.Infrastructure.CommandQuery.Handlers
{
    public class DeleteCompanyHandler : IHandleCommand<DeleteCompanyCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeleteCompanyHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IResult> Handle(DeleteCompanyCommand command)
        {
            var company = await _context
                .Companies
                .Where(c => c.Id == command.CompanyId)
                .FirstOrDefaultAsync();

            if (company == null)
                return new OperationResult
                {
                    Message = $"Company with Id {command.CompanyId} doesn't exist",
                    Succeeded = false
                };

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return new OperationResult
            {
                Succeeded = true
            };
        }
    }
}