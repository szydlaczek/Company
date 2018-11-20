using CompanySelf.Infrastructure.Dtos;

namespace CompanySelf.Infrastructure.CommandQuery.Queries
{
    public class SearchCompanyQuery : IQuery
    {
        public SearchCriteria SearchCriteria { get; set; }
    }
}