using System.Security.Claims;
using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace GrabIt.Infrastructure.src.AuthorizationRequirements
{
    public class OrderOwnerRequirements : IAuthorizationRequirement
    {

    }

    public class OrderOwnerOnlyRequirementHandler : AuthorizationHandler<OrderOwnerRequirements, Order>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OrderOwnerRequirements requirement, Order resource)
        {
            if (context.User.FindFirst(ClaimTypes.NameIdentifier)!.Value == resource.UserId.ToString())
            {
                context.Succeed(requirement);
            }


            return Task.CompletedTask;
        }

    }
}