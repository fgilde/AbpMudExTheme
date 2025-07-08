using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Volo.Abp.AspNetCore.Components.Server.MudExTheme.Bundling;

public class BlazorMudExThemeStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.AddIfNotContains("/_content/Volo.Abp.AspNetCore.Components.Web.MudExTheme/libs/abp/css/theme.css");
        context.Files.AddIfNotContains("/_content/Volo.Abp.AspNetCore.Components.Web.MudExTheme/MudExTheme.css");
    }
}
