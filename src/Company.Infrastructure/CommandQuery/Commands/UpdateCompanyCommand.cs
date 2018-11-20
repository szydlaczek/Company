using CompanySelf.Infrastructure.Dtos;

namespace CompanySelf.Infrastructure.CommandQuery.Commands
{
    public class UpdateCompanyCommand : ICommand
    {
        public long CompanyId { get; set; }
        public CompanyDto Company { get; set; }
    }
}