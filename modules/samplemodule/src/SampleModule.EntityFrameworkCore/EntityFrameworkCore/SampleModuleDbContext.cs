using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SampleModule.EntityFrameworkCore;

[ConnectionStringName(SampleModuleDbProperties.ConnectionStringName)]
public class SampleModuleDbContext : AbpDbContext<SampleModuleDbContext>, ISampleModuleDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public SampleModuleDbContext(DbContextOptions<SampleModuleDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureSampleModule();
    }
}
