using Dedsi.CleanArchitecture.Domain;
using Volo.Abp.Modularity;

namespace TobaccoDMInputAcceptance;

[DependsOn(
    typeof(DedsiCleanArchitectureDomainModule)    
)]
public class TobaccoDMInputAcceptanceDomainModule : AbpModule
{
    
}