using OnlyFreights.Samples;
using Xunit;

namespace OnlyFreights.EntityFrameworkCore.Applications;

[Collection(OnlyFreightsTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<OnlyFreightsEntityFrameworkCoreTestModule>
{

}
