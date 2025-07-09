using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Extensions;
using Volo.Abp.AspNetCore.Components.Web;
using Volo.Abp.AspNetCore.Components.Web.MudExTheme;
using Volo.Abp.AspNetCore.Components.Web.MudExTheme.Services;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Volo.Abp.AspNetCore.Components.WebAssembly.MudExTheme.Bundling;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Http.Client.IdentityModel.WebAssembly;
using Volo.Abp.Modularity;

namespace Volo.Abp.AspNetCore.Components.WebAssembly.MudExTheme;

[DependsOn(
    typeof(AbpAspNetCoreComponentsWebAssemblyMudExThemeBundlingModule),
    typeof(AbpAspNetCoreComponentsWebMudExThemeModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule),
    typeof(AbpHttpClientIdentityModelWebAssemblyModule)
    )]
public class AbpAspNetCoreComponentsWebAssemblyMudExThemeModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(AbpAspNetCoreComponentsWebAssemblyMudExThemeModule).Assembly);
        });

        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new MudExThemeToolbarContributor());
        });

        if (context.Services.ExecutePreConfiguredActions<AbpAspNetCoreComponentsWebOptions>().IsBlazorWebApp)
        {
            Configure<AuthenticationOptions>(options =>
            {
                options.LoginUrl = "Account/Login";
                options.LogoutUrl = "Account/Logout";
            });
        }

        context.Services.AddMudServicesWithExtensions();
    }
}
