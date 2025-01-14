using Dedsi.CleanArchitecture.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using TobaccoDMAuthorization.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TobaccoDMAuthorization;

[DependsOn(
    typeof(DedsiCleanArchitectureInfrastructureModule)
)]
public class TobaccoDMAuthorizationInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // EntityFrameworkCore
        context.Services.AddAbpDbContext<TobaccoDMAuthorizationDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });
    }
}