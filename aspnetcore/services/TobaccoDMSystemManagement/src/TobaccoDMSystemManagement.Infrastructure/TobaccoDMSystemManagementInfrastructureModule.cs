using Microsoft.Extensions.DependencyInjection;
using TobaccoDMSystemManagement.Domain;
using TobaccoDMSystemManagement.Infrastructure.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TobaccoDMSystemManagement.Infrastructure;

[DependsOn(
    typeof(TobaccoDMSystemManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class TobaccoDMSystemManagementInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<TobaccoDMSystemManagementDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });
    }
}
