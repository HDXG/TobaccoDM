using System.Reflection;
using Dedsi.Ddd.CQRS;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace TobaccoDMInputAcceptance;

[DependsOn(
    // TobaccoDMInputAcceptance
    typeof(TobaccoDMInputAcceptanceDomainModule),
    typeof(TobaccoDMInputAcceptanceInfrastructureModule),
    
    typeof(DedsiDddCqrsModule)
)]
public class TobaccoDMInputAcceptanceUseCaseModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // MediatR
        context.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}