using CompanySelf.Infrastructure.CommandQuery.Commands;
using CompanySelf.Infrastructure.CommandQuery.Handlers;
using System.Threading.Tasks;

namespace CompanySelf.Infrastructure.CommandQuery.Bus
{
    public interface ICommandsBus
    {
        Task<IResult> Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}