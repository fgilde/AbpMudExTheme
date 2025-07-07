using Volo.Abp.Modularity;

namespace SampleModule;

[DependsOn(
    typeof(SampleModuleApplicationModule),
    typeof(SampleModuleDomainTestModule)
    )]
public class SampleModuleApplicationTestModule : AbpModule
{

}
