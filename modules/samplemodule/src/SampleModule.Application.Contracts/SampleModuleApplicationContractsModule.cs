using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace SampleModule;

[DependsOn(
    typeof(SampleModuleDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class SampleModuleApplicationContractsModule : AbpModule
{

}
