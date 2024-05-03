using System.Security.Claims;
using Application.Abstractions.Attributes;
using Domain.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Setup;

public class CanAuthorizationHandler(IUserRepository userRepository, IPermissionRepository permissionRepository)
    : AuthorizationHandler<CanAttribute>
{
    
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CanAttribute requirement)
    {
        var userGuid = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);

        if (userGuid is null)
        {
            context.Fail();

            return;
        }

        var user = await userRepository.Find(Guid.Parse(userGuid.Value));

        if (user is null)
        {
            context.Fail();
            return;
        }

        var hasPermission = permissionRepository.UserHasPermission(requirement.Code, user);
        if (!hasPermission)
        {
            context.Fail();
        }

        context.Succeed(requirement);
    }
    
}