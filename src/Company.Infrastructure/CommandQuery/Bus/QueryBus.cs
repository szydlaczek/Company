using CompanySelf.Infrastructure.CommandQuery.Queries;
using System;
using System.Threading.Tasks;

namespace CompanySelf.Infrastructure.CommandQuery.Bus
{
    public class QueryBus : IQueryBus
    {
        private readonly Func<Type, IHandleQuery> _handlersFactory;

        public QueryBus(Func<Type, IHandleQuery> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public async Task<QueryResult> Send<TQuery>(TQuery query) where TQuery : IQuery
        {
            var handler = (IHandleQuery<TQuery>)_handlersFactory(typeof(TQuery));
            return await handler.Handle(query);
        }
    }
}