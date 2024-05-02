using Microsoft.AspNetCore.Authorization;

namespace Application.Abstractions.Attributes;

[AttributeUsage(AttributeTargets.Class |
                AttributeTargets.Method)]
public class CanAttribute(string code) 
    : AuthorizeAttribute, IAuthorizationRequirement, IAuthorizationRequirementData
{
    
    public string Code { get; } = code;

    public IEnumerable<IAuthorizationRequirement> GetRequirements()
    {
        yield return this;
    }
    
}