using TobaccoDMSystemManagement.Domain;
using Volo.Abp.Modularity;

namespace TobaccoDMSystemManagement.Core;

[DependsOn(
    typeof(TobaccoDMSystemManagementDomainModule)
)]
public class TobaccoDMSystemManagementCoreModule : AbpModule
{
    
}