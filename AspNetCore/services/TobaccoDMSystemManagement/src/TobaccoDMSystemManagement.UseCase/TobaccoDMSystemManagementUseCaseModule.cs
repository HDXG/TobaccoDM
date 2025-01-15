using System.Reflection;
using Dedsi.Ddd.CQRS;
using Microsoft.Extensions.DependencyInjection;
using TobaccoDMSystemManagement.Domain;
using TobaccoDMSystemManagement.Infrastructure;
using Volo.Abp.Modularity;
namespace TobaccoDMSystemManagement.UseCase
{
    [DependsOn(
        typeof(TobaccoDMSystemManagementDomainModule),
        typeof(TobaccoDMSystemManagementInfrastructureModule),
        typeof(DedsiDddCQRSModule)   
        )]
    public class TobaccoDMSystemManagementUseCaseModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMediatR(opt =>
            {
                opt.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });
        }
    }
}
