using Dedsi.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TobaccoDMSystemManagement.UseCase;
using Volo.Abp.Modularity;
namespace TobaccoDMSystemManagement.HttpApi
{
    [DependsOn(
        typeof(TobaccoDMSystemManagementUseCaseModule),
        typeof(DedsiAspNetCoreModule)
        )]
    public class TobaccoDMSystemManagementHttpApiModule:AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(TobaccoDMSystemManagementHttpApiModule).Assembly);
            });
        }
    }
}
