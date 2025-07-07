using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace SampleModule;

[DependsOn(
    typeof(SampleModuleApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class SampleModuleHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(SampleModuleApplicationContractsModule).Assembly,
            SampleModuleRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SampleModuleHttpApiClientModule>();
        });

    }
}
