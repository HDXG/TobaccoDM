using TobaccoDMSystemManagement.Core;
using Volo.Abp.Modularity;

namespace TobaccoDMSystemManagement.Infrastructure;

[DependsOn(
    typeof(TobaccoDMSystemManagementCoreModule)
)]
public class TobaccoDMSystemManagementInfrastructureModule : AbpModule
{

}
