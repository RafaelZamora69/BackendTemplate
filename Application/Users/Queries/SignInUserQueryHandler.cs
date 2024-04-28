using MediatR;

namespace Application.Users.Queries;

internal sealed class SignInUserQueryHandler : IRequestHandler<SignInUserQuery>
{
    public Task Handle(SignInUserQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}