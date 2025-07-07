using System.Threading.Tasks;

namespace OnlyFreights.Data;

public interface IOnlyFreightsDbSchemaMigrator
{
    Task MigrateAsync();
}
