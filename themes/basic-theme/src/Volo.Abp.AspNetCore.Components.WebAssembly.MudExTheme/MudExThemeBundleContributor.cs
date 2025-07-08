using System;
using Volo.Abp.Bundling;

namespace Volo.Abp.AspNetCore.Components.WebAssembly.MudExTheme;

[Obsolete("This class is obsolete and will be removed in the future versions. Use GlobalAssets instead.")]
public class MudExThemeBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {
        context.Add("_content/MudBlazor/MudBlazor.min.js");
    }

    public void AddStyles(BundleContext context)
    {
        context.Add("https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap");
        context.Add("_content/MudBlazor/MudBlazor.min.css");
        context.Add("_content/MudBlazor.Extensions/mudBlazorExtensions.min.css");
    }
}
