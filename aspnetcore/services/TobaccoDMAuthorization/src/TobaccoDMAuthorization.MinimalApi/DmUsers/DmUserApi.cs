using Dedsi.Ddd.CQRS.Mediators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TobaccoDMAuthorization.DmUsers;
using TobaccoDMAuthorization.DmUsers.Commands;
using TobaccoDMAuthorization.DmUsers.Requests;

namespace TobaccoDMAuthorization.DmUsers;

public static class DmUserApi
{
    public static void MapDmUserApis(this IEndpointRouteBuilder builder)
    {
        var api = builder
            .MapGroup(TobaccoDMAuthorizationMinimalApi.ApiPrefix + "/DmUser")
            .WithTags("DmUser");
        
        api
            .MapGet("/GetDefulatPpassWord", () => DmUserConsts.DefulatPpassWord)
            .WithSummary("获取默认密码");

        api.MapGet("/CreateDmUser", CreateDmUserAsync);
    }

    /// <summary>
    /// 创建用户
    /// </summary>
    /// <param name="request"></param>
    /// <param name="dedsiMediator"></param>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    private static Task<bool> CreateDmUserAsync([FromBody] CreateDmUserRequest request, IDedsiMediator dedsiMediator, HttpContext httpContext)
    {
        var dmUserRoles = new DmUserRoleItem[]
        {
            
        };

        return dedsiMediator.PublishAsync(new CreateDmUserCommand(request.UserName, request.LoginAccount, request.Email, dmUserRoles), httpContext.RequestAborted);
    }
}