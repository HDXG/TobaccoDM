using TobaccoDMSystemManagement.Domain;
using Volo.Abp.FluentValidation;
using Volo.Abp.Guids;
using Volo.Abp.Modularity;

namespace TobaccoDMSystemManagement.AppService;

[DependsOn(
    typeof(TobaccoDMSystemManagementDomainModule),
    typeof(AbpFluentValidationModule),
    typeof(AbpGuidsModule)
)]
public class TobaccoDMSystemManagementCoreModule : AbpModule;