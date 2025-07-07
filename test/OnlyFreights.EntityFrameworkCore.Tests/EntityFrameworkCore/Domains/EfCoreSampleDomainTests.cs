using OnlyFreights.Samples;
using Xunit;

namespace OnlyFreights.EntityFrameworkCore.Domains;

[Collection(OnlyFreightsTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<OnlyFreightsEntityFrameworkCoreTestModule>
{

}
