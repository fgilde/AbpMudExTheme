using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SampleModule;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SampleModuleDomainSharedModule)
)]
public class SampleModuleDomainModule : AbpModule
{

}
