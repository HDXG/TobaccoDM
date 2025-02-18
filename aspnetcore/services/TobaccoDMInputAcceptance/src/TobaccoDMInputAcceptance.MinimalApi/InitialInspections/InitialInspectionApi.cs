using Dedsi.Ddd.CQRS.Mediators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TobaccoDMInputAcceptance.InitialInspections.CommandHandlers;
using TobaccoDMInputAcceptance.InitialInspections.Commands;
using TobaccoDMInputAcceptance.InitialInspections.Dtos;

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
        
        api.MapPost("/CreateInitialInspection", CreateInitialInspectionAsync);
    }


    private static Task<bool> CreateInitialInspectionAsync([FromBody] CreateInitialInspectionInputDto request, IDedsiMediator dedsiMediator, HttpContext httpContext)
    {
        return  dedsiMediator.SendAsync(new CreateInitialInspectionCommand(request.initialName, request. initialDescription, request.InitialInspectorInputDto, request.TobaccoGrowers), httpContext.RequestAborted);
    }
}