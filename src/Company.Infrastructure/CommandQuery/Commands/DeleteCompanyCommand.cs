namespace CompanySelf.Infrastructure.CommandQuery.Commands
{
    public class DeleteCompanyCommand : ICommand
    {
        public long CompanyId { get; set; }
    }
}