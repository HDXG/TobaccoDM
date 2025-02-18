using Dedsi.Ddd.CQRS.Mediators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TobaccoDMInputAcceptance.InitialInspections.Commands;
using TobaccoDMInputAcceptance.InitialInspections.Queries;
using Volo.Abp.Guids;

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

        api.MapPost("/GetInitialInspectionPaged", (
                [FromBody] GetInitialInspectionPagedInputDto input,
                IInitialInspectionQuery initialInspectionQuery,
                HttpContext httpContext) => initialInspectionQuery.GetInitialInspectionPagedAsync(
                httpContext.RequestAborted,
                input.PageIndex,
                input.PageSize, 
                input.InitialName, 
                input.InitialInspectorUserName, 
                input.TobaccoGrowerName))
            .WithSummary("获取初验分页数据");
    }


    /// <summary>
    /// 创建初验
    /// </summary>
    /// <param name="request"></param>
    /// <param name="dedsiMediator"></param>
    /// <param name="guidGenerator"></param>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    private static Task<bool> CreateInitialInspectionAsync(
        [FromBody] CreateInitialInspectionInputDto request, 
        IDedsiMediator dedsiMediator, 
        IGuidGenerator guidGenerator, 
        HttpContext httpContext)
    {
        var initialInspector = new InitialInspector(request.InitialInspector.UserId, request.InitialInspector.UserName, request.InitialInspector.DeptId);

        var tobaccoGrowers = request
                                            .TobaccoGrowers
                                            .Select(a => new TobaccoGrower(guidGenerator.Create(), a.Name, a.IdCard, a.ImplementationQuantity))
                                            .ToArray();

        return  dedsiMediator.SendAsync(new CreateInitialInspectionCommand(request.InitialName, request.InitialDescription, initialInspector, tobaccoGrowers), httpContext.RequestAborted);
    }
}