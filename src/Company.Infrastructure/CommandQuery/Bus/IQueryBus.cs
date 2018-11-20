using CompanySelf.Infrastructure.CommandQuery.Queries;
using System.Threading.Tasks;

namespace CompanySelf.Infrastructure.CommandQuery.Bus
{
    public interface IQueryBus
    {
        Task<QueryResult> Send<TQuery>(TQuery query) where TQuery : IQuery;
    }
}