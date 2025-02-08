using Dedsi.AspNetCore;
using Volo.Abp.Modularity;

namespace TobaccoDMAuthorization.MinimalApi;

[DependsOn(
    typeof(TobaccoDMAuthorizationUseCaseModule),
    typeof(DedsiAspNetCoreModule)
)]
public class TobaccoDMAuthorizationMinimalApiModule : AbpModule;