using Volo.Abp.AspNetCore.Components.Server.MudExTheme.Bundling;
using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.AspNetCore.Components.Server.Theming.Bundling;
using Volo.Abp.AspNetCore.Components.Web.MudExTheme;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;

namespace Volo.Abp.AspNetCore.Components.Server.MudExTheme;

[DependsOn(
    typeof(AbpAspNetCoreComponentsWebMudExThemeModule),
    typeof(AbpAspNetCoreComponentsServerThemingModule)
    )]
public class AbpAspNetCoreComponentsServerMudExThemeModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new MudExThemeToolbarContributor());
        });

        Configure<AbpBundlingOptions>(options =>
        {
            options
                .StyleBundles
                .Add(BlazorMudExThemeBundles.Styles.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(BlazorStandardBundles.Styles.Global)
                        .AddContributors(typeof(BlazorMudExThemeStyleContributor));
                });

            options
                .ScriptBundles
                .Add(BlazorMudExThemeBundles.Scripts.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(BlazorStandardBundles.Scripts.Global)
                        .AddContributors(typeof(BlazorMudExThemeScriptContributor));
                });
        });
    }
}
