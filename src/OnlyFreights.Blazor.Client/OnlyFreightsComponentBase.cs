using OnlyFreights.Localization;
using Volo.Abp.AspNetCore.Components;

namespace OnlyFreights.Blazor.Client;

public abstract class OnlyFreightsComponentBase : AbpComponentBase
{
    protected OnlyFreightsComponentBase()
    {
        LocalizationResource = typeof(OnlyFreightsResource);
    }
}
