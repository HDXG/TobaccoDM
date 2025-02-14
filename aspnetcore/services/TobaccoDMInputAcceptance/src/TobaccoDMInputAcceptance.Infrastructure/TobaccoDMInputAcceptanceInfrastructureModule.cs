using Dedsi.CleanArchitecture.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using TobaccoDMInputAcceptance.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TobaccoDMInputAcceptance;

[DependsOn(
    typeof(DedsiCleanArchitectureInfrastructureModule)
)]
public class TobaccoDMInputAcceptanceInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // EntityFrameworkCore
        context.Services.AddAbpDbContext<TobaccoDMInputAcceptanceDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });
    }
}