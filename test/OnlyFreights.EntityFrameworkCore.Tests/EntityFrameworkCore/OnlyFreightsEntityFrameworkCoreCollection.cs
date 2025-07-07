using Xunit;

namespace OnlyFreights.EntityFrameworkCore;

[CollectionDefinition(OnlyFreightsTestConsts.CollectionDefinitionName)]
public class OnlyFreightsEntityFrameworkCoreCollection : ICollectionFixture<OnlyFreightsEntityFrameworkCoreFixture>
{

}
