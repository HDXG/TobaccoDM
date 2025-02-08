using Dedsi.Ddd.CQRS.Mediators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TobaccoDMAuthorization.DmRoles.Commands;
using TobaccoDMAuthorization.DmRoles.Requests;

namespace TobaccoDMAuthorization.DmRoles;

public static class DmRoleApi
{
    public static void MapDmRoleApis(this IEndpointRouteBuilder builder)
    {
        var api = builder
            .MapGroup(TobaccoDMAuthorizationMinimalApi.ApiPrefix + "/DmRole")
            .WithTags("DmRole");

        api.MapPost("/Create", CreateAsync);
    }
    
    /// <summary>
    /// 创建 DmRole
    /// </summary>
    /// <param name="request"></param>
    /// <param name="dedsiMediator"></param>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    private static Task<bool> CreateAsync([FromBody] CreateDmRoleRequest request, IDedsiMediator dedsiMediator, HttpContext httpContext)
    {
        return dedsiMediator.PublishAsync(new CreateDmRoleCommand(request.RoleName, request.ChildrenRoleNames), httpContext.RequestAborted);
    }
}