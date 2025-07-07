using Localization.Resources.AbpUi;
using SampleModule.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace SampleModule;

[DependsOn(
    typeof(SampleModuleApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class SampleModuleHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SampleModuleHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<SampleModuleResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
