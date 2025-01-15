using Dedsi.CleanArchitecture.Domain;
using Volo.Abp.Modularity;

namespace TobaccoDMSystemManagement.Domain
{
    [DependsOn(
        typeof(DedsiCleanArchitectureDomainModule)
     )]
    public class TobaccoDMSystemManagementDomainModule:AbpModule
    {

    }
}
