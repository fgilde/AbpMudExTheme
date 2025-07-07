using Volo.Abp.Modularity;

namespace SampleModule;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class SampleModuleDomainTestBase<TStartupModule> : SampleModuleTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
