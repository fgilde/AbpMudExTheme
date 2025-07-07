using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SampleModule.EntityFrameworkCore;

[ConnectionStringName(SampleModuleDbProperties.ConnectionStringName)]
public interface ISampleModuleDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
