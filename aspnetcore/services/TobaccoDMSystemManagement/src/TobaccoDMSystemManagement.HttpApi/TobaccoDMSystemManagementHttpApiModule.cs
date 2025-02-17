using Microsoft.Extensions.DependencyInjection;
using TobaccoDMSystemManagement.AppService;
using TobaccoDMSystemManagement.Extensions;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace TobaccoDMSystemManagement.HttpApi;

[DependsOn(
    typeof(TobaccoDMSystemManagementCoreModule),
    
    typeof(AbpAspNetCoreMvcModule)
)]
public class TobaccoDMSystemManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(TobaccoDMSystemManagementHttpApiModule).Assembly);
        });
        context.Services.AddControllers(option =>
        {
            option.Filters.Add<HttpResponseExceptionFilter>();
            option.Filters.Add<HttpResponseSuccessFilter>();
        });
    }
}
