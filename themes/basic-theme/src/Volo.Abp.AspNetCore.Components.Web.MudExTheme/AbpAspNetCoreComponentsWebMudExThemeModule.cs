using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Extensions;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Theming;
using Volo.Abp.Modularity;

namespace Volo.Abp.AspNetCore.Components.Web.MudExTheme;

[DependsOn(
    typeof(AbpAspNetCoreComponentsWebThemingModule)
)]
public class AbpAspNetCoreComponentsWebMudExThemeModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpThemingOptions>(options =>
        {
            options.Themes.Add<MudExTheme>();

            if (options.DefaultThemeName == null)
            {
                options.DefaultThemeName = MudExTheme.Name;
            }
        });
        context.Services.AddMudServicesWithExtensions();
        context.Services.AddTransient<IThemeManager, ThemeManager>();
        context.Services.AddTransient<ThemeManager>();
    }
}
