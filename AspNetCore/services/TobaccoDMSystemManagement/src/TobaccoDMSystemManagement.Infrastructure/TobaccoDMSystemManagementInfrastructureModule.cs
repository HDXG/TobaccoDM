using Dedsi.CleanArchitecture.Infrastructure;
using Volo.Abp.Modularity;
namespace TobaccoDMSystemManagement.Infrastructure;

[DependsOn(
    typeof(DedsiCleanArchitectureInfrastructureModule)
    )]
public class TobaccoDMSystemManagementInfrastructureModule:AbpModule
{

}
