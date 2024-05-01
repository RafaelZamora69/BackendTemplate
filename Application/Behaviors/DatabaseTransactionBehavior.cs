using Infrastructure.DataContext;
using MediatR;

namespace Application.Behaviors;

public class DatabaseTransactionBehavior<TRequest, TResponse>(MariaDbContext context) 
    : IPipelineBehavior<TRequest, TResponse> where TRequest : class
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var transaction = await context.Database
            .BeginTransactionAsync(cancellationToken);

        var response = await next();

        await transaction.CommitAsync(cancellationToken);

        return response;
    }
}