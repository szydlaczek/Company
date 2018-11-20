using CompanySelf.Infrastructure.CommandQuery.Commands;
using CompanySelf.Infrastructure.CommandQuery.Handlers;
using System;
using System.Threading.Tasks;

namespace CompanySelf.Infrastructure.CommandQuery.Bus
{
    public class CommandsBus : ICommandsBus
    {
        private readonly Func<Type, IHandleCommand> _handlersFactory;

        public CommandsBus(Func<Type, IHandleCommand> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public async Task<IResult> Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = (IHandleCommand<TCommand>)_handlersFactory(typeof(TCommand));
            return await handler.Handle(command);
        }
    }
}