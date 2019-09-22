using CompanySelf.Application.Infrastructure;
using MediatR;

namespace CompanySelf.Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest<Response>
    {
        public long CompanyId { get; }

        public DeleteCompanyCommand(long companyId)
        {
            CompanyId = companyId;
        }
    }
}