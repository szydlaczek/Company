using CompanySelf.Infrastructure.CommandQuery.Commands;
using CompanySelf.Infrastructure.CommandQuery.Handlers;
using System.Threading.Tasks;

namespace CompanySelf.Infrastructure.CommandQuery.Bus
{
    public interface IHandleCommand
    {
    }

    public interface IHandleCommand<TCommand> : IHandleCommand
    where TCommand : ICommand
    {
        Task<IResult> Handle(TCommand command);
    }
}