using Microsoft.Extensions.Localization;
using OnlyFreights.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace OnlyFreights;

[Dependency(ReplaceServices = true)]
public class OnlyFreightsBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<OnlyFreightsResource> _localizer;

    public OnlyFreightsBrandingProvider(IStringLocalizer<OnlyFreightsResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
