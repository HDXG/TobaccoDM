using Dedsi.AspNetCore;
using Volo.Abp.Modularity;

namespace TobaccoDMInputAcceptance;

[DependsOn(
    typeof(TobaccoDMInputAcceptanceUseCaseModule),
    typeof(DedsiAspNetCoreModule)
)]
public class TobaccoDMInputAcceptanceMinimalApiModule : AbpModule;