using Volo.Abp.Modularity;

namespace SampleModule;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class SampleModuleApplicationTestBase<TStartupModule> : SampleModuleTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
