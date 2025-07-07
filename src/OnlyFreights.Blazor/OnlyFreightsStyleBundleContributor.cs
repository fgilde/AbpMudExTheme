using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace OnlyFreights.Blazor;

public class OnlyFreightsStyleBundleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add(new BundleFile("main.css", true));
    }
}
