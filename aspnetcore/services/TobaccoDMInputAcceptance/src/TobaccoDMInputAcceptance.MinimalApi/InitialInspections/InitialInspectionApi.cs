using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace TobaccoDMInputAcceptance.InitialInspections;

public static class InitialInspectionApi
{
    /// <summary>
    /// Map InitialInspection Api
    /// </summary>
    /// <param name="builder"></param>
    public static void MapInitialInspectionApi(this IEndpointRouteBuilder builder)
    {
        var api = builder
            .MapGroup(TobaccoDMInputAcceptanceMinimalApi.ApiPrefix + "/InitialInspection")
            .WithTags("InitialInspection");
        
        api.MapGet("/", () => "InitialInspection");
    }
}