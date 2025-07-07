using Volo.Abp.Modularity;

namespace OnlyFreights;

public abstract class OnlyFreightsApplicationTestBase<TStartupModule> : OnlyFreightsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
