using Dedsi.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.Modularity;

namespace TobaccoDMSystemManagement.HttpApi;

[DependsOn(
    typeof(DedsiAspNetCoreModule)
)]
public class TobaccoDMSystemManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(TobaccoDMSystemManagementHttpApiModule).Assembly);
        });
    }
}
