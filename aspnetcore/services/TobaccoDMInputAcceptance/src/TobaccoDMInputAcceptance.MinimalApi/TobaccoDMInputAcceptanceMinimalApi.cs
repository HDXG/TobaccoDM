using Microsoft.AspNetCore.Routing;
using TobaccoDMInputAcceptance.InitialInspections;

namespace TobaccoDMInputAcceptance;

public static class TobaccoDMInputAcceptanceMinimalApi
{
    public const string ApiPrefix = "api/TobaccoDMInputAcceptance";
    
    /// <summary>
    /// Map TobaccoDMInputAcceptance MinimalApis
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapTobaccoDMInputAcceptanceMinimalApis(this IEndpointRouteBuilder builder)
    {
        builder.MapInitialInspectionApi();
        
        return builder;
    }
}