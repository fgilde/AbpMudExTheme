using Volo.Abp.Modularity;

namespace SampleModule;

[DependsOn(
    typeof(SampleModuleDomainModule),
    typeof(SampleModuleTestBaseModule)
)]
public class SampleModuleDomainTestModule : AbpModule
{

}
