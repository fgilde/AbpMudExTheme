using Volo.Abp.Modularity;

namespace OnlyFreights;

/* Inherit from this class for your domain layer tests. */
public abstract class OnlyFreightsDomainTestBase<TStartupModule> : OnlyFreightsTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
