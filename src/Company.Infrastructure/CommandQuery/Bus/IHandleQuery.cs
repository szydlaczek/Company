using CompanySelf.Infrastructure.CommandQuery.Queries;
using System.Threading.Tasks;

namespace CompanySelf.Infrastructure.CommandQuery.Bus
{
    public interface IHandleQuery
    {
    }

    public interface IHandleQuery<TQuery> : IHandleQuery
    where TQuery : IQuery
    {
        Task<QueryResult> Handle(TQuery query);
    }
}