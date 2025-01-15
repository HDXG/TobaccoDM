using TobaccoDMSystemManagement.Core;
using Volo.Abp.Modularity;

namespace TobaccoDMSystemManagement.Infrastructure;

/// <summary>
/// 
/// </summary>
[DependsOn(
    typeof(TobaccoDMSystemManagementCoreModule)
)]
public class TobaccoDMSystemManagementInfrastructureModule : AbpModule
{

}
