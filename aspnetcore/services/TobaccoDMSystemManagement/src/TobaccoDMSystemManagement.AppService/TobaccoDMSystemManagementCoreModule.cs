using TobaccoDMSystemManagement.Domain;
using Volo.Abp.Guids;
using Volo.Abp.Modularity;

namespace TobaccoDMSystemManagement.AppService;

[DependsOn(
    typeof(TobaccoDMSystemManagementDomainModule),
    typeof(AbpGuidsModule)
)]
public class TobaccoDMSystemManagementCoreModule : AbpModule;