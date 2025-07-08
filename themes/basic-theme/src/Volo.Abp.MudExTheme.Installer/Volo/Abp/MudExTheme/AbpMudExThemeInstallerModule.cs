using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.MudExTheme;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class AbpMudExThemeInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpMudExThemeInstallerModule>();
        });
    }
}
