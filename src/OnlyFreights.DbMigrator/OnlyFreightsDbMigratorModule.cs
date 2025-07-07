using OnlyFreights.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace OnlyFreights.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OnlyFreightsEntityFrameworkCoreModule),
    typeof(OnlyFreightsApplicationContractsModule)
)]
public class OnlyFreightsDbMigratorModule : AbpModule
{
}
