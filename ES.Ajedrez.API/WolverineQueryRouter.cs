using ES.Ajedrez.Dominio;
using Wolverine;

namespace ES.Ajedrez.API;

public class WolverineQueryRouter(IMessageBus messageBus) : IQueryRouter
{
    public Task<TResult> ResolveAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
        where TQuery : class
    {
        return messageBus.InvokeAsync<TResult>(query, cancellationToken);
    }
}