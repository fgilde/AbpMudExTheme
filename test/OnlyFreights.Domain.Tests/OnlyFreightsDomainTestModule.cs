using Volo.Abp.Modularity;

namespace OnlyFreights;

[DependsOn(
    typeof(OnlyFreightsDomainModule),
    typeof(OnlyFreightsTestBaseModule)
)]
public class OnlyFreightsDomainTestModule : AbpModule
{

}
