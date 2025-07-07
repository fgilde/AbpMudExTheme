using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace OnlyFreights.Data;

/* This is used if database provider does't define
 * IOnlyFreightsDbSchemaMigrator implementation.
 */
public class NullOnlyFreightsDbSchemaMigrator : IOnlyFreightsDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
