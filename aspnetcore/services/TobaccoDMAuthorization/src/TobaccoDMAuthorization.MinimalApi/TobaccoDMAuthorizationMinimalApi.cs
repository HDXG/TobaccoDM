using Microsoft.AspNetCore.Routing;
using TobaccoDMAuthorization.DmRoles;
using TobaccoDMAuthorization.DmUsers;

namespace TobaccoDMAuthorization;

public static class TobaccoDMAuthorizationMinimalApi
{
    public const string TobaccoDmAuthorizationApiPrefix = "api/TobaccoDMAuthorization";

    public const string TobaccoDmAuthorizationAdminApiPrefix = "api/TobaccoDMAuthorizationAdmin";
    
    /// <summary>
    /// Map TobaccoDMAuthorization MinimalApis
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static void MapTobaccoDmAuthorizationMinimalApis(this IEndpointRouteBuilder builder)
    {

    }
    
    /// <summary>
    /// Map TobaccoDMAuthorizationAdmin MinimalApis
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static void MapTobaccoDmAuthorizationAdminMinimalApis(this IEndpointRouteBuilder builder)
    {
        builder.MapDmUserApis();
        builder.MapDmRoleApis();
    }
    

}