using Volo.Abp.Modularity;

namespace OnlyFreights;

[DependsOn(
    typeof(OnlyFreightsApplicationModule),
    typeof(OnlyFreightsDomainTestModule)
)]
public class OnlyFreightsApplicationTestModule : AbpModule
{

}
