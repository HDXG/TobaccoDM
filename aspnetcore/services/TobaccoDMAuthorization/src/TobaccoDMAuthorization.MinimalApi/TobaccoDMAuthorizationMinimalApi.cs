using Microsoft.AspNetCore.Routing;
using TobaccoDMAuthorization.MinimalApi.DmRoleApis;
using TobaccoDMAuthorization.MinimalApi.DmUserApis;

namespace TobaccoDMAuthorization.MinimalApi;

public static class TobaccoDMAuthorizationMinimalApi
{
    public const string ApiPrefix = "api/TobaccoDMAuthorization";
    
    /// <summary>
    /// Map TobaccoDMAuthorization MinimalApis
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapTobaccoDmAuthorizationMinimalApis(this IEndpointRouteBuilder builder)
    {
        builder.MapDmUserApis();
        builder.MapDmRoleApis();

        return builder;
    }
}