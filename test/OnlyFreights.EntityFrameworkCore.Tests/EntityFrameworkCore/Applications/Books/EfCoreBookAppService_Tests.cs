using OnlyFreights.Books;
using Xunit;

namespace OnlyFreights.EntityFrameworkCore.Applications.Books;

[Collection(OnlyFreightsTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<OnlyFreightsEntityFrameworkCoreTestModule>
{

}