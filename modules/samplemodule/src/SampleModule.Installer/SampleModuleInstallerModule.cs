using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace SampleModule;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class SampleModuleInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SampleModuleInstallerModule>();
        });
    }
}
