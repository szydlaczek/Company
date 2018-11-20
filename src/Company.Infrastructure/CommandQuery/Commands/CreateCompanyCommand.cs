using CompanySelf.Infrastructure.Dtos;

namespace CompanySelf.Infrastructure.CommandQuery.Commands
{
    public class CreateCompanyCommand : ICommand
    {
        public CompanyDto Company { get; set; }
    }
}