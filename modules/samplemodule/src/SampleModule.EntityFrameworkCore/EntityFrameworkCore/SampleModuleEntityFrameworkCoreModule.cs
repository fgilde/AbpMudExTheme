using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SampleModule.EntityFrameworkCore;

[DependsOn(
    typeof(SampleModuleDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class SampleModuleEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<SampleModuleDbContext>(options =>
        {
            options.AddDefaultRepositories<ISampleModuleDbContext>(includeAllEntities: true);
            
            /* Add custom repositories here. Example:
            * options.AddRepository<Question, EfCoreQuestionRepository>();
            */
        });
    }
}
